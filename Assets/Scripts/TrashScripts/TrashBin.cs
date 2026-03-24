using UnityEngine;

public class TrashBin : MonoBehaviour
{
    [SerializeField] private TrashType trashType;

    private void OnTriggerEnter(Collider other)
    {
        print("Trigger entered");
        if (other.TryGetComponent(out Trash trash))
        {
            if (trashType == trash.TrashType) // Correct trash in bin
            {
                print("Correct trash type");
                TreeManager.Instance.GrowTree();
            }
            else // Wrong trash
            {
                print("Wrong trash type");
                TreeManager.Instance.ShrinkTree();
                
            }
            Destroy(trash.gameObject);
        }
    }
}
