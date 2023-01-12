using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehindCamera : MonoBehaviour
{
    public bool hasEnteredCorrectCode;
    public AudioSource whispers;

    public Transform originObject;
    public Transform lookingCameraTransform;
    [Range(0f, 1f)]
    public float sensitivity = 0.4f;
    Vector3 forwardVectorTowardsCamera;
    bool cameraLooking;
    float dotProductResult;

    void Start()
    {
        hasEnteredCorrectCode = false;
    }

    void Update()
    {
        CheckIfCameraIsLooking();
    }

    public void CheckIfCameraIsLooking()
    {

        forwardVectorTowardsCamera = (lookingCameraTransform.position - originObject.position).normalized;
        dotProductResult = Vector3.Dot(lookingCameraTransform.forward, forwardVectorTowardsCamera);
        if (cameraLooking)
        {
            if (dotProductResult > sensitivity)
            {
                cameraLooking = false;
                StartNotLooking();
            }
        }
        else
        {
            if (dotProductResult < -sensitivity)
            {
                cameraLooking = true;
                StartLooking();
            }
        }

        if (cameraLooking)
        {
            PlayerIsLooking();
        }
        else
        {
            PlayerIsNotLooking();
        }
    }

    void StartLooking()
    {
        if(hasEnteredCorrectCode)
            whispers.Stop();
        Debug.Log("Camera started looking");
    }
    void PlayerIsLooking()
    {
        Debug.Log("Camera is currently looking");
    }

    void StartNotLooking()
    {
        if(hasEnteredCorrectCode)
            whispers.Play();
        Debug.Log("Camera has stopped looking");
    }

    void PlayerIsNotLooking()
    {
        Debug.Log("Camera is currently not looking");
    }
}
