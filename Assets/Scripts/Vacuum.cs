using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vacuum : MonoBehaviour
{
    [SerializeField] private TrashGroundSpawner trashInfo;
    [SerializeField] private Slider slider;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip suckingSound;

    private float trashValue = 0.1f;
    
    private void Start()
    {
        trashValue = 1 / trashInfo.trashQtyToSpawn + 0.001f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Trash") || slider.value > 0.99f)
            return;

        
        PrefabReference refScript = other.GetComponent<PrefabReference>();
        if (refScript != null && refScript.originalPrefab != null)
            audioSource.PlayOneShot(suckingSound);
        TrashManager.Instance.AddTrashToList(refScript.originalPrefab);

        Destroy(other.gameObject);
        slider.value += trashValue;
    }
}