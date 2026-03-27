using UnityEngine;
public enum TrashType 
{
    Waste,
    Organic,
    Paper,
    Plastic,
    Glass,
    Metal,
}

public class Trash : MonoBehaviour
{
    [SerializeField] private TrashType trashType;
    public TrashType TrashType => trashType;

    public void TryStartGuide()
    {
        print("TryStartGuide");
        if (TrashGuide.Instance)
        {
            print("TryStartGuide instance exsist");
            TrashGuide.Instance.StartGuideTrashSort(trashType);
        }
    }

    public void TryEndGuide()
    {
        if (TrashGuide.Instance)
        {
            TrashGuide.Instance.EndGuideTrashSort(trashType);
        }
        
    }
}
    
