using System;
using System.Collections.Generic;
using UnityEngine;

public class Vacuum : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Trash"))
            return;

        PrefabReference refScript = other.GetComponent<PrefabReference>();
        if (refScript != null && refScript.originalPrefab != null)
            TrashManager.Instance.AddTrashToList(refScript.originalPrefab);

        Destroy(other.gameObject);
    }
}