using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        trashValue = (1.0f / trashInfo.trashQtyToSpawn) + 0.001f;
        Debug.Log("Trash Quantity is: " + trashInfo.trashQtyToSpawn);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Trash") || slider.value > 0.99f)
            return;

        
        PrefabReference refScript = other.GetComponent<PrefabReference>();
        if (refScript != null && refScript.originalPrefab != null)
        {
            audioSource.PlayOneShot(suckingSound);
            TrashManager.Instance.AddTrashToList(refScript.originalPrefab);
        }

        Destroy(other.gameObject);
        Debug.Log("slider.value = " + slider.value);
        slider.value += trashValue;

        //TODO: replace this with a better way to transition to the garbage sorting scene:
        if(slider.value > 0.8f)
        {
            Debug.Log("Going to next scene!");
            SceneManager.LoadScene("SortTrash");
        }
    }

}