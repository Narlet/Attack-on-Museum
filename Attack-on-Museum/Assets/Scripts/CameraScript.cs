using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;

public class CameraScript : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera _cam;
    [SerializeField] private CamController _camController;


    private void OnEnable()
    {
    }

    private void OnDisable()
    {
        
    }

  

    private void OnTriggerEnter2D(Collider2D other)
    {
        _camController.SwitchCam(_cam);
    }
}

