using System;
using System.Collections.Generic;
using UnityEngine;

public class TrashManager : MonoBehaviour
{
    [SerializeField] private Vacuum vacuumInfo;
    public static TrashManager Instance;
    
    private static List<GameObject> trashList = new List<GameObject>();
    
    public event Action OnTrashGone;
    
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
            trashInScene += trashList.Count;
            print("Trash in scene: " +trashInScene);
            SpawnTrash.Instance.SpawnObject(trashList);
            trashList.Clear();
            vacuumInfo.slider.value = 0f;
        }
    }
    
    public List<GameObject> GetTrashList() =>  trashList; 

    public void RemoveTrash()
    {
        trashInScene--;
        if (trashInScene <= 0)
        {
            OnTrashGone?.Invoke();
        }
    }
}
