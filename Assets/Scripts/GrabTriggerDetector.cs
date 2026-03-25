using System;
using Oculus.Interaction;
using UnityEngine;

public class GrabTriggerDetector : MonoBehaviour
{
    [SerializeField] private BoxCollider vacuumColider;
        
    private Grabbable grabbable;

    [Header("Raycast Settings")]
    public float raycastDistance = 2f; // distance for the raycast
    public LayerMask grabLayer; // specify layers to detect the object (e.g. Vacuum)
    public string targetObjectName = "Vacuum"; // object to grab

    private bool leftInside = false;
    private bool rightInside = false;

    private bool soundActivated = false;
    
    void Start()
    {
        grabbable = GetComponent<Grabbable>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.tag.ToLower().Contains("controller"))
            return;
        
        if (GetIfLeft(other))
            leftInside = true;
        else
            rightInside = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.tag.ToLower().Contains("controller"))
            return;
        
        if (GetIfLeft(other))
            leftInside = false;
        else
            rightInside = false;
    }

    private bool GetIfLeft(Collider other) => other.tag.ToLower().Contains("left");

    void Update()
    {
        bool leftTriggerDown = OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch);
        bool leftTriggerUp = OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch);
        
        bool rightTriggerDown = OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch);
        bool rightTriggerUp = OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch);
        
        if (soundActivated)
            return;
        
        if (leftInside)
        {
            if (leftTriggerDown)
                ActivateVacuum();
            else if (leftTriggerUp)
                DeactivateVacuum();
        }
        
        if (soundActivated)
            return;

        if (rightInside)
        {
            if (rightTriggerDown)
                ActivateVacuum();
            else if (rightTriggerUp)
                DeactivateVacuum();
        }
    }

    private void ActivateVacuum()
    {
        // start sound

        soundActivated = true;
                    
        vacuumColider.enabled = true;
    }
    
    private void DeactivateVacuum()
    {
        // stop sound
                
        soundActivated = false;
                    
        vacuumColider.enabled = false;
    }
}