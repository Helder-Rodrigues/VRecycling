using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public static bool IsOn = false;
    
    
    [SerializeField] private TextMeshPro text;

    private void Start()
    {
        text.text = IsOn ? "Tutorial (On)" : "Tutorial (Off)";

    }

    public void ToggleTutorial()
    {
        IsOn = !IsOn;

        text.text = IsOn ? "Tutorial (On)" : "Tutorial (Off)";
    }
}
