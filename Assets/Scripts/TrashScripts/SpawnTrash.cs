using Oculus.Platform.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrash : MonoBehaviour
{   
    public static SpawnTrash Instance;

    [SerializeField] private List<GameObject> trashPrefab;
    [SerializeField] private float delay = 0.3f;
    [SerializeField] private List<Vector3> factors;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instance = this;
        
        this.factors = new List<Vector3>()
            {
            new Vector3(0.05f, 0, 0.05f),
            new Vector3(-0.05f, 0f, -0.05f),
            new Vector3(0.05f, 0f,  -0.05f),
            new Vector3(-0.05f, 0f, 0.05f)
            };

        /*
        List<GameObject> trashToSpawn = TrashManager.Instance.GetTrashList();
        if (trashToSpawn.Count == 0)
            trashToSpawn = trashPrefab;
            
        SpawnObject(trashToSpawn);
        */
        foreach (var trash in trashPrefab)
        {
            TrashManager.Instance.AddTrashToList(trash);
        }
    }

    
    public void SpawnObject(List<GameObject> trashObject)
    {
        var copyOfList = new List<GameObject>(trashObject);
        StartCoroutine(SpawnDelay(copyOfList));
    }
    
    private IEnumerator SpawnDelay(List<GameObject> trashObject)
    {
        for (int i = 0; i < trashObject.Count; i++)
        {   
            Instantiate(trashObject[i], transform.position + factors[i % 4], Quaternion.identity);
            yield return new WaitForSeconds(delay);
        }
    }
}
