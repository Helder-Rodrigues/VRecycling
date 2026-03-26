using System;
using UnityEngine;

public class PutTrashBackOnTable : MonoBehaviour
{
    [SerializeField] private Transform respawnLocation;
    
    // private void OnCollisionEnter(Collision other)
    // {
    //     if (other.transform.TryGetComponent(out Trash trash))
    //     {
    //         trash.transform.position = respawnLocation.position;
    //     }
    // }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Trash trash))
        {
            trash.transform.position = respawnLocation.position;
        }
    }
}
