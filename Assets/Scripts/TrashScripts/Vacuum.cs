using System;
using System.Collections.Generic;
using TrashScripts;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Vacuum : MonoBehaviour
{
    [SerializeField] private TrashGroundSpawner trashInfo;
    public Slider slider;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip suckingSound;

    private int trashVacuumQty = 5;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Trash") || slider.value > 0.999f)
            return;
        
        PrefabReference refScript = other.GetComponent<PrefabReference>();
        if (refScript != null && refScript.originalPrefab != null)
        {
            audioSource.PlayOneShot(suckingSound);
            TrashManager.Instance.AddTrashToList(refScript.originalPrefab);
        }

        Destroy(other.gameObject);
        slider.value += (1.0f / trashVacuumQty);
    }

}