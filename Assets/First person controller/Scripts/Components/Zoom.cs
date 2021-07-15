﻿using UnityEngine;

public class Zoom : MonoBehaviour
{
    public float sensitivity = 1;
    Camera cameraZoom;
    [HideInInspector]
    public float defaultFOV;
    [Tooltip("Effectively the min FOV that we can reach while zooming with this camera.")]
    public float maxZoom = 15;
    [HideInInspector]
    public float zoomAmount;


    void Awake()
    {
        cameraZoom = GetComponent<Camera>();
    }

    void Start()
    {
        defaultFOV = cameraZoom.fieldOfView;
    }

    void Update()
    {
        zoomAmount += Input.mouseScrollDelta.y * sensitivity * .05f;
        zoomAmount = Mathf.Clamp01(zoomAmount);
        cameraZoom.fieldOfView = Mathf.Lerp(defaultFOV, maxZoom, zoomAmount);
    }
}
