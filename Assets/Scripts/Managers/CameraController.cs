using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Camera _firstViewCamera;
    [SerializeField] private Camera _thirdViewCamera;


    private void Start()
    {
        _firstViewCamera = Camera.main;
        _thirdViewCamera = GameObject.FindGameObjectWithTag("ThirdViewCamera").GetComponent<Camera>() as Camera;
    }

    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            _firstViewCamera.enabled = true;
            _thirdViewCamera.enabled = false;
        }
        else if (Input.GetKeyDown("2"))
        {
            _firstViewCamera.enabled = false;
            _thirdViewCamera.enabled = true;
        }
    }
}