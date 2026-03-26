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
        if (TrashGuide.Instance)
        {
            TrashGuide.Instance.StartGuidePlayer(trashType);
        }
    }

    public void TryEndGuide()
    {
        if (TrashGuide.Instance)
        {
            TrashGuide.Instance.EndGuidePlayer(trashType);
        }
        
    }
}
    
