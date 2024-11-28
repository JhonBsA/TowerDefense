using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    private Transform cameraTransform;

    void Start()
    {
        // Find the main camera
        cameraTransform = Camera.main.transform;
    }

    void LateUpdate()
    {
        // Make the health bar face the camera
        transform.LookAt(transform.position + cameraTransform.forward);
    }
}
