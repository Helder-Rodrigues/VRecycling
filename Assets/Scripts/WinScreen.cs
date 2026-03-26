using System.Collections;
using TMPro;
using UnityEngine;

public class WinScreen : MonoBehaviour
{
    [SerializeField] private GameObject finishSortingText;
    [SerializeField] private float textVisibleInSeconds;

    private void Start()
    {
        if(TrashManager.Instance)
            TrashManager.Instance.OnTrashGone += OnWin;
    }

    private void OnWin()
    {
        StartCoroutine(SpawnParticlesInOrder());
    }

    private IEnumerator SpawnParticlesInOrder()
    {
        finishSortingText.SetActive(true);
        yield return new WaitForSeconds(textVisibleInSeconds);
        finishSortingText.SetActive(false);
    }
}
