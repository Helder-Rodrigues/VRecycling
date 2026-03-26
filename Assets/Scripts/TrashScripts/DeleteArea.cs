using UnityEngine;

namespace TrashScripts
{
    public class DeleteArea : MonoBehaviour
    {
        [SerializeField] private TrashGroundSpawner spawner;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Trash")
                Destroy(other.gameObject);
            
            spawner.TrySpawn();
        }
    }
}
