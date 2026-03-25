using System;
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

    public void StartGuidePlayer(TrashType trashType)
    {
        foreach (TrashBin bin in trashBins)
        {
            if (bin.TrashType == trashType)
            {
                bin.ToggleGuideVisual(true);
                return;
            }
        }
    }

    public void EndGuidePlayer(TrashType trashType)
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
