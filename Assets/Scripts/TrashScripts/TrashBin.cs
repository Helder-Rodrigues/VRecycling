using UnityEngine;

public class TrashBin : MonoBehaviour
{
    [SerializeField] private TrashType trashType;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip winningSound;
    [SerializeField] private AudioClip failureSound;

    private void OnTriggerEnter(Collider other)
    {
        print("Trigger entered");
        if (other.TryGetComponent(out Trash trash))
        {
            if (trashType == trash.TrashType) // Correct trash in bin
            {
                print("Correct trash type");
                audioSource.PlayOneShot(winningSound);
                TreeManager.Instance.GrowTree();
            }
            else // Wrong trash
            {
                print("Wrong trash type");
                audioSource.PlayOneShot(failureSound);
                TreeManager.Instance.ShrinkTree();
                
            }
            Destroy(trash.gameObject);
        }
    }
}
