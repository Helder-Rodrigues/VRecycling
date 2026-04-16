using System.Collections;
using TMPro;
using UnityEngine;

public class WinScreen : MonoBehaviour
{
    [SerializeField] private Transform trashParent;
    [SerializeField] private RestartManager restartManager;
    
    [SerializeField] private GameObject finishSortingText;
    [SerializeField] private float textVisibleInSeconds;

    private void Start()
    {
        if (TrashManager.Instance)
            TrashManager.Instance.OnTrashGone += OnWin;
    }

    private void OnWin()
    {
        StartCoroutine(SpawnParticlesInOrder());
        
        if (!HasTrashChild(trashParent))
        {
            // No trash in the ground left
            restartManager.ShowResult();
        }
    }

    private bool HasTrashChild(Transform parent)
    {
        foreach (Transform child in parent)
        {
            if (child.CompareTag("Trash"))
            {
                return true;
            }
        }

        return false;
    }

    private IEnumerator SpawnParticlesInOrder()
    {
        finishSortingText.SetActive(true);
        yield return new WaitForSeconds(textVisibleInSeconds);
        finishSortingText.SetActive(false);
    }
}