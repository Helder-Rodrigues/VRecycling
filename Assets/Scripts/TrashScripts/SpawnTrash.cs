using Oculus.Platform.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrash : MonoBehaviour
{   
    public static SpawnTrash Instance;
    
    [SerializeField] private bool addThis0TrashToList = true;
    [SerializeField] private List<GameObject> trashPrefab;
    [SerializeField] private float delay = 0.3f;
    [SerializeField] private List<Vector3> factors;
    


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
        
        if (addThis0TrashToList) 
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

    public void SpawnSingleObject(GameObject trashObject)
    {
        Instantiate(trashObject, transform.position, Quaternion.identity);
    }
    
    private IEnumerator SpawnDelay(List<GameObject> trashObject)
    {
        for (int i = 0; i < trashObject.Count; i++)
        {   
            var instance = Instantiate(trashObject[i], transform.position + factors[i % 4], Quaternion.identity);
            var script = instance.AddComponent<PrefabReference>();
            script.originalPrefab = trashObject[i];
            yield return new WaitForSeconds(delay);
        }
    }
}
