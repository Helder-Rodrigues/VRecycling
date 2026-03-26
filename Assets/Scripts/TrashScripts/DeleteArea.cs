using UnityEngine;

namespace TrashScripts
{
    public class DeleteArea : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Trash")
                Destroy(other.gameObject);
        }
    }
}
