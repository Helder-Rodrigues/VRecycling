using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class SubtitleController : MonoBehaviour
{
    public static SubtitleController Instance;
    
    [SerializeField] private Canvas canvas;
    [SerializeField] private float rotationLimit = 40.0f;
    [SerializeField] private float rotationAdjustmentTarget = 20.0f;
    [SerializeField] private float rotationSpeed = 5.0f;
    [SerializeField] private float smoothTime = 0.2f;      
    [SerializeField] private TextMeshProUGUI textField;
    
    private float rotationVelocity = 0f;
    private Camera cam;
    private bool isBusy;

    public event Action OnSubtitlesEnd;

    private void Awake()
    {
        
        if (Instance == null)
            Instance = this;
        else 
            Destroy(gameObject);
        
        cam = Camera.main;
    }
    

    private float GetAngleBetweenCameraAndCanvas()
    {
        var camForward = cam.transform.forward;
        var camToCanvas = (canvas.transform.position - cam.transform.position).normalized;
        
        return Vector3.Angle(camForward, camToCanvas);
    }

    private void LateUpdate()
    {
        MoveWithCamera();
        RotateWithCamera();
    }

    private void MoveWithCamera()
    {
        transform.position = cam.transform.position;
    }

    private void RotateWithCamera()
    {
        if (isBusy) return;
        // Check if camera is looking away and move the subtitles if so.
        if (GetAngleBetweenCameraAndCanvas() > rotationLimit)
        {
            StartCoroutine(SetRotation());
        }
    }

    private IEnumerator SetRotation()
    {
        isBusy = true;

        while (Mathf.Abs(Mathf.DeltaAngle(transform.eulerAngles.y, cam.transform.eulerAngles.y)) > 0.1f)
        {
            var currentY = transform.eulerAngles.y;
            var targetY = cam.transform.eulerAngles.y;

            float newYRotation = Mathf.SmoothDampAngle(currentY, targetY, ref rotationVelocity, smoothTime);

            transform.eulerAngles = new Vector3(transform.eulerAngles.x, newYRotation, transform.eulerAngles.z);
        
            yield return null;
        }
    
        isBusy = false;
    }

    public void SetSubtitles(string subtitles)
    {
        StartCoroutine(SetSubtitlesTimer(subtitles, 10));
    }

    public void SetSubtitles(string subtitles, float duration)
    {
        StartCoroutine(SetSubtitlesTimer(subtitles, 10));
    }

    private IEnumerator SetSubtitlesTimer(string text, float duration)
    {
        canvas.gameObject.SetActive(true);
        textField.text = text;
        
        yield return new WaitForSeconds(duration);
        canvas.gameObject.SetActive(false);
        yield return null;
        OnSubtitlesEnd?.Invoke();
        
    }
}
