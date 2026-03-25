using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

public class TrashArrowAnimation : MonoBehaviour
{
    [SerializeField] private float heightChangeAmount = 0.5f;
    [SerializeField] private float rotationChangeAmount = 180f;
    [SerializeField] private float changeSpeed = 0.5f;

    private float waitTime;
    private void Start()
    {
        StartCoroutine(AnimateArrowTransform());
        StartCoroutine(AnimateArrowRotation());
        
        waitTime = changeSpeed + .1f;
    }

    private IEnumerator AnimateArrowTransform()
    {
        while (true)
        {
            transform.DOMoveY(transform.position.y - heightChangeAmount, changeSpeed);
            yield return new WaitForSeconds(waitTime);
            transform.DOMoveY(transform.position.y + heightChangeAmount, changeSpeed);
            yield return new WaitForSeconds(waitTime);
        }
    }

    private IEnumerator AnimateArrowRotation()
    {
        while (true)
        {
            transform.DORotate(transform.eulerAngles + new Vector3(0, rotationChangeAmount, 0), changeSpeed, RotateMode.FastBeyond360);
            yield return new WaitForSeconds(waitTime);
        }
    }
}
