using Oculus.Platform.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrash : MonoBehaviour
{   

    [SerializeField] private List<GameObject> trashPrefab;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnObject(trashPrefab,0.1f);

    }

    
    void SpawnObject(List<GameObject> trashObject, float delay)
    {
        StartCoroutine(SpawnDelay(trashObject, delay));
    }
    private IEnumerator SpawnDelay(List<GameObject> trashObject, float delay)
    {
        for (int i = 0; i < trashObject.Count; i++)
        {
            Instantiate(trashObject[i], transform.position, Quaternion.identity);
            yield return new WaitForSeconds(delay);

        }
        

    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
