using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

public class TrashArrowAnimation : MonoBehaviour
{
    [SerializeField] private float heightChangeAmount = 0.5f;
    [SerializeField] private float heightChangeSpeed = 0.5f;
    private void Start()
    {
        StartCoroutine(AnimateArrow());
    }

    private IEnumerator AnimateArrow()
    {
        while (true)
        {
            transform.DOMoveY(transform.position.y - heightChangeAmount, heightChangeSpeed);
            yield return new WaitForSeconds(heightChangeSpeed);
            transform.DOMoveY(transform.position.y + heightChangeAmount, heightChangeSpeed);
            yield return new WaitForSeconds(heightChangeSpeed);
        }
    }
}
