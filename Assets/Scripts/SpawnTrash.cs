using Oculus.Platform.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrash : MonoBehaviour
{   

    [SerializeField] private List<GameObject> trashPrefab;
    [SerializeField] private float delay = 0.3f;
    [SerializeField] private List<Vector3> factors;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
            this.factors = new List<Vector3>()
            {
            new Vector3(0.05f, 0, 0.05f),
            new Vector3(-0.05f, 0f, -0.05f),
            new Vector3(0.05f, 0f,  -0.05f),
            new Vector3(-0.05f, 0f, 0.05f)
            };
        SpawnObject(trashPrefab,delay);

    }

    
    void SpawnObject(List<GameObject> trashObject, float delay)
    {
        StartCoroutine(SpawnDelay(trashObject, delay));
    }
    private IEnumerator SpawnDelay(List<GameObject> trashObject, float delay)
    {
     
        for (int i = 0; i < trashObject.Count; i++)
        {   
            Instantiate(trashObject[i], transform.position + factors[i % 4], Quaternion.identity);
            yield return new WaitForSeconds(delay);

        }
        

    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
