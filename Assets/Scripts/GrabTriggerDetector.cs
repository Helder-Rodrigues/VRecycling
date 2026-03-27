using System;
using Oculus.Interaction;
using UnityEngine;

public class GrabTriggerDetector : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip vacuumSound;
    [SerializeField] private BoxCollider vacuumColider;

    private bool leftInside = false;
    private bool leftTriggerDown = false;

    private bool rightInside = false;
    private bool rightTriggerDown = false;

    private bool soundActivated = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.tag.ToLower().Contains("controller"))
            return;

        bool isLeft = GetIfLeft(other);
        if (isLeft)
            leftInside = true;
        else
            rightInside = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.tag.ToLower().Contains("controller"))
            return;

        bool isLeft = GetIfLeft(other);
        if (isLeft)
            leftInside = false;
        else
            rightInside = false;
    }

    private bool GetIfLeft(Collider other)
    {
        bool result = other.tag.ToLower().Contains("left");
        return result;
    }

    void Update()
    {
        bool leftTriggerDown = OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch);
        bool leftTriggerUp = OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch);

        bool rightTriggerDown = OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch);
        bool rightTriggerUp = OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch);

        if (leftTriggerUp)
            DeactivateVacuum(true);
        if (rightTriggerUp)
            DeactivateVacuum(false);

        if (leftTriggerDown && rightTriggerDown)
            return;

        if (leftInside && leftTriggerDown)
            ActivateVacuum(true);
        if (rightInside && rightTriggerDown)
            ActivateVacuum(false);
    }

    private void ActivateVacuum(bool leftBtnDown)
    {
        if (leftBtnDown)
        {
            if (leftTriggerDown)
                return;
            leftTriggerDown = true;
        }
        else
        {
            if (rightTriggerDown)
                return;
            rightTriggerDown = true;
        }

        if (soundActivated)
            return;

        soundActivated = true;
        vacuumColider.enabled = true;
        
        if (audioSource != null && vacuumSound != null)
        {
            audioSource.clip = vacuumSound;
            audioSource.Play();
        }
    }

    private void DeactivateVacuum(bool leftBtnUp)
    {
        if (leftBtnUp)
        {
            if (!leftTriggerDown)
                return;

            leftTriggerDown = false;

            if (rightTriggerDown)
                return;
        }
        else
        {
            if (!rightTriggerDown)
                return;

            rightTriggerDown = false;

            if (leftTriggerDown)
                return;
        }

        soundActivated = false;
        vacuumColider.enabled = false;
        
        if (audioSource != null)
        {
            audioSource.Stop();
        }
    }
}