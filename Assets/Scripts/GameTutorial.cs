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
        PressButton,
        SortTrash,
        End
    }
    
    [SerializeField] private GameGuide guide;
    
    [Header("Guide Arrow Targets")]
    [SerializeField] private Transform grabVacuumTarget;
    [SerializeField] private Transform vacuumFullTarget;
    [SerializeField] private Transform pressButtonTarget;
    
    [Header("Tutorial Texts")]
    [SerializeField] private string beginString = "";
    [SerializeField] private string grabVacuumString = "";
    [SerializeField] private string vacuumTrashString = "";
    [SerializeField] private string vacuumFullString = "";
    [SerializeField] private string pressButtonString = "";
    [SerializeField] private string sortTrashString = "";


    private bool isVacuumPickedUp, isVacuumFull, isButtonPressed;
    
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
        if (!Tutorial.IsOn) return;
        
        
        EnterState();

        SubtitleController.Instance.OnSubtitlesEnd += SubtitleEnd;
    }

    

    void EnterState()
    {
        if (!Tutorial.IsOn) return;
        
        guide.EndGuideOnObject();
        switch (currentState)
        {
            case TutorialState.Begin:
                SubtitleController.Instance.SetSubtitles(beginString);
                break;
            case TutorialState.GrabVacuum:
                SubtitleController.Instance.SetSubtitles(grabVacuumString);
                guide.StartGuideOnObject(grabVacuumTarget);
                break;
            case TutorialState.VacuumTrash:
                SubtitleController.Instance.SetSubtitles(vacuumTrashString);
                break;
            case TutorialState.VacuumFull:
                SubtitleController.Instance.SetSubtitles(vacuumFullString);
                guide.StartGuideOnObject(vacuumFullTarget);
                break;
            case TutorialState.PressButton:
                SubtitleController.Instance.SetSubtitles(pressButtonString);
                guide.StartGuideOnObject(pressButtonTarget);
                break;
            case TutorialState.SortTrash:
                SubtitleController.Instance.SetSubtitles(sortTrashString);
                break;
            case TutorialState.End:
                this.enabled = false;
                break;
            default:
                return;
        }
    }

    private void Update()
    {
        if (!Tutorial.IsOn) return;
        
        CheckStateToExit();
    }

    void CheckStateToExit()
    {
        switch (currentState)
        {
            case TutorialState.GrabVacuum:
                // When vacuum is grabbed
                if (isVacuumPickedUp)
                    currentState = TutorialState.VacuumTrash;
                break;
            case TutorialState.VacuumTrash:
                // When vacuum is full
                if (isVacuumFull)
                    currentState = TutorialState.VacuumFull;
                break;
            case TutorialState.PressButton:
                // After pressing button
                if (isButtonPressed)
                    currentState = TutorialState.SortTrash;
                break;
            default:
                return;
        }
    }
    
    private void SubtitleEnd()
    {
        if (!Tutorial.IsOn) return;
        
        switch (currentState)
        {
            case TutorialState.Begin:
                // Wait til intro dialogue is finished
                currentState = TutorialState.GrabVacuum;
                break;
            case TutorialState.VacuumFull:
                // After dialogue explaining vacuum is full
                currentState = TutorialState.PressButton;
                break;
            case TutorialState.SortTrash:
                // After sorting trash dialogue
                currentState = TutorialState.End;
                break;
            case TutorialState.End:
                break;
            default:
                return;

        }
    }

    public void VacuumPickedUp()
    {
        isVacuumPickedUp = true;
        print("Vacuum Picked Up");
    }

    public void OnVacuumTrash(Single single)
    {
        if (single > .9f)
            isVacuumFull = true;
    }

    public void OnButtonPressed()
    {
        isButtonPressed = true;
    }
}
