using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashGuide : MonoBehaviour
{
    public static TrashGuide Instance;

    [SerializeField] private List<TrashBin> trashBins;
    
    private void Start()
    {
        Instance = this;
    }

    public void StartGuideTrashSort(TrashType trashType)
    {
        print("TryStartGuide instance exist");
        foreach (TrashBin bin in trashBins)
        {
            if (bin.TrashType == trashType)
            {
                bin.ToggleGuideVisual(true);
                return;
            }
        }
    }

    public void EndGuideTrashSort(TrashType trashType)
    {
        foreach (TrashBin bin in trashBins)
        {
            if (bin.TrashType == trashType)
            {
                bin.ToggleGuideVisual(false);
                return;
            }
        }
    }

    
}
