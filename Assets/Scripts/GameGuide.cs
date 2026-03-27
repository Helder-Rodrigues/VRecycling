using System;
using System.Collections;
using UnityEngine;

public class GameGuide : MonoBehaviour
{
    [SerializeField] private TrashArrowAnimation guideArrow;
    [SerializeField] private Vector3 offset = new Vector3(0.0f, 1.0f, 0.0f);
    private Renderer guideRenderer;

    private void Start()
    {
        guideRenderer = guideArrow.GetComponent<Renderer>();
    }

    public void StartGuideOnObject(Transform target)
    {
        guideRenderer.enabled = true;
        StartCoroutine(MoveArrowWithItem(target));
    }

    private IEnumerator MoveArrowWithItem(Transform target)
    {
        while (true)
        {
            guideArrow.transform.position = target.position + offset;
            yield return new WaitForEndOfFrame();
        }
    }

    public void EndGuideOnObject()
    {
        guideRenderer.enabled = false;
        StopCoroutine(MoveArrowWithItem(guideRenderer.transform));
    }
}
