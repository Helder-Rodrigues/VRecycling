using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class TreeManager : MonoBehaviour
{
    public static TreeManager Instance;
    
    [SerializeField] private float sizeChangeAmount = 0.1f;
    [SerializeField] private float sizeChangeDuration = 0.1f;

    [SerializeField] private Transform particleSpawn;
    [SerializeField] private ParticleSystem happyParticles, sadParticles;
    
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
        Instantiate(happyParticles, particleSpawn.position, particleSpawn.rotation);
    }

    public void ShrinkTree()
    {
        currentScale -= sizeChangeAmount;
        if(currentScale < 0.1)
            currentScale = 0;
        StopCoroutine(SizeTree());
        StartCoroutine(SizeTree(-1));
        Instantiate(sadParticles, particleSpawn.position, particleSpawn.rotation);
        
    }

    private IEnumerator SizeTree(int direction = 1)
    {
        transform.DOScale(currentScale + direction * sizeChangeAmount/2, sizeChangeDuration);
        yield return new WaitForSeconds(sizeChangeDuration);
        transform.DOScale(currentScale, sizeChangeDuration);
    }
}
