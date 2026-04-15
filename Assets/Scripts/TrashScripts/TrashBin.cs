using UnityEngine;

public class TrashBin : MonoBehaviour
{
    [SerializeField] private TrashType trashType;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip winningSound;
    [SerializeField] private AudioClip failureSound;
    [SerializeField] private Renderer guideVisual;

    public TrashType TrashType => trashType;


    public void ToggleGuideVisual(bool toggle)
    {
        if (!Tutorial.IsOn) return;
        
        guideVisual.enabled = toggle;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Trash trash))
        {
            if (trashType == trash.TrashType) // Correct trash in bin
            {
                audioSource.PlayOneShot(winningSound);
                TreeManager.Instance.GrowTree();
                TrashManager.Instance.RemoveTrash();
            }
            else // Wrong trash
            {
                audioSource.PlayOneShot(failureSound);
                TreeManager.Instance.ShrinkTree();
                SpawnTrash.Instance.SpawnSingleObject(trash.gameObject);
            }
            Destroy(trash.gameObject);
        }
    }
}
