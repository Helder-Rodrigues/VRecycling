using System.Collections.Generic;
using UnityEngine;

public class TrashManager : MonoBehaviour
{
    public static TrashManager Instance;
    
    private static List<GameObject> trashList = new List<GameObject>();

    private void Awake()
    {
        if (!Instance)
            Instance = this;
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
            trashList.Clear();
        }
    }
}
