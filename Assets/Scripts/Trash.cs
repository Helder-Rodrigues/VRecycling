using UnityEngine;
public enum TrashType 
{
    Waste,
    Organic,
    Paper,
    Plastic,
    Glass,
    Metal
}

public class Trash : MonoBehaviour
{
    [SerializeField] private TrashType trashType;
    public TrashType TrashType => trashType;
}
    
