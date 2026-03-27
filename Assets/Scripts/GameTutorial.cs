using System;
using System.Diagnostics;
using UnityEngine;

public class GameTutorial : MonoBehaviour
{
    private enum TutorialState
    {
        Begin,
        GrabVacuum,
        VacuumTrash,
        VacuumFull,
        GoToTable,
        PressButton,
        SortTrash,
        End
    }
    
    [SerializeField] private GameGuide guide;
    
    

    private TutorialState backerState;
    
    private TutorialState currentState
    {
        get => backerState;
        set
        {
            if (backerState == value) return;
            backerState = value;
            EnterState();
        }
    }

    private void Start()
    {
        currentState = TutorialState.Begin;
    }

    void EnterState()
    {
        switch (currentState)
        {
            case TutorialState.Begin:
                break;
            case TutorialState.GrabVacuum:
                break;
            case TutorialState.VacuumTrash:
                break;
            case TutorialState.VacuumFull:
                break;
            case TutorialState.GoToTable:
                break;
            case TutorialState.PressButton:
                break;
            case TutorialState.SortTrash:
                break;
            case TutorialState.End:
                break;

        }
    }

    private void Update()
    {
        CheckState();
    }

    void CheckState()
    {
        switch (currentState)
        {
            case TutorialState.Begin:
                break;
            case TutorialState.GrabVacuum:
                break;
            case TutorialState.VacuumTrash:
                break;
            case TutorialState.VacuumFull:
                break;
            case TutorialState.GoToTable:
                break;
            case TutorialState.PressButton:
                break;
            case TutorialState.SortTrash:
                break;
            case TutorialState.End:
                break;

        }
    }
}
