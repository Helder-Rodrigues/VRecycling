using System;
using System.Collections.Generic;
using UnityEngine;

public class TrashManager : MonoBehaviour
{
    public static TrashManager Instance;
    
    private static List<GameObject> trashList = new List<GameObject>();
    
    private int trashInScene = 0;

    public int TrashInScene => trashInScene;

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            
            trashList.Clear();
        }
        else
            Destroy(this);
    }

    // Whenever trash is gathered in the vacuum call this
    public void AddTrashToList(GameObject trash)
    {
        trashList.Add(trash);
    }
    
    // When the trash needs to be emptied call this
    public void EmptyTrashList()
    {
        if (SpawnTrash.Instance)
        {
            SpawnTrash.Instance.SpawnObject(trashList);
            trashInScene = trashList.Count;
            trashList.Clear();
        }
    }
    
    public List<GameObject> GetTrashList() =>  trashList; 

    public void RemoveTrash()
    {
        trashInScene--;
    }
}
