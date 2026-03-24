using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class TreeManager : MonoBehaviour
{
    public static TreeManager Instance;
    
    [SerializeField] private float sizeChangeAmount = 0.1f;
    [SerializeField] private float sizeChangeDuration = 0.1f;
    
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

    public void ShrinkTree()
    {
        currentScale -= sizeChangeAmount;
        StopCoroutine(SizeTree());
        StartCoroutine(SizeTree(-1));
    }

    private IEnumerator SizeTree(int direction = 1)
    {
        transform.DOScale(currentScale + direction * sizeChangeAmount/2, sizeChangeDuration);
        yield return new WaitForSeconds(sizeChangeDuration);
        transform.DOScale(currentScale, sizeChangeDuration);
    }
}
