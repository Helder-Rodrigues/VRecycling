using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class TreeManager : MonoBehaviour
{
    public static TreeManager Instance;
    
    [SerializeField] private float sizeChangeAmount = 0.1f;
    [SerializeField] private float sizeChangeDuration = 0.1f;

    [SerializeField] private ParticleSystem ps;

    private int correctCount = 0;
    
    private List<GameObject> trees = new List<GameObject>();
    private float currentScale;
    
    private void Start()
    {
        Instance = this;
        currentScale = transform.localScale.x;
    }

    public void GrowTree()
    {
        currentScale += sizeChangeAmount;
        StopCoroutine(SizeTree());
        StartCoroutine(SizeTree());
    }

    private void PlayTreeParticle()
    {
        correctCount++;
        var burst = ps.emission.GetBurst(0);
        burst.count = correctCount;
        ps.emission.SetBurst(0, burst);
        ps.Play();
    }

    public void ShrinkTree()
    {
        currentScale -= sizeChangeAmount;
        if(currentScale < 0.1)
            currentScale = 0;
        StopCoroutine(SizeTree());
        StartCoroutine(SizeTree(-1));
    }

    private IEnumerator SizeTree(int direction = 1)
    {
        transform.DOScale(currentScale + direction * sizeChangeAmount/2, sizeChangeDuration);
        yield return new WaitForSeconds(sizeChangeDuration);
        if (direction == 1)
        {
            PlayTreeParticle();
        }
        transform.DOScale(currentScale, sizeChangeDuration);
    }
}
