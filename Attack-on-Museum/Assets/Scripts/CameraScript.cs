using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;

public class CameraScript : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera _CC1;
    [SerializeField] CinemachineVirtualCamera _CC2;
    [SerializeField] CinemachineVirtualCamera _CC3;
    [SerializeField] CinemachineVirtualCamera _CC4;
    [SerializeField] CinemachineVirtualCamera _CC5;
    [SerializeField] CinemachineVirtualCamera _CC6;
    [SerializeField] CinemachineVirtualCamera _CC7;
    [SerializeField] CinemachineVirtualCamera _CC8;
    [SerializeField] CinemachineVirtualCamera _CC9;
    [SerializeField] CinemachineVirtualCamera _CC10;
    [SerializeField] CinemachineVirtualCamera _CC11;
    [SerializeField] CinemachineVirtualCamera _CC12;
    [SerializeField] CinemachineVirtualCamera _CC13;


    private void OnEnable()
    {
        CameraSwitcher.Register(_CC1);
        CameraSwitcher.Register(_CC2);
        CameraSwitcher.Register(_CC3);
        CameraSwitcher.Register(_CC4);
        CameraSwitcher.Register(_CC5);
        CameraSwitcher.Register(_CC6);
        CameraSwitcher.Register(_CC7);
        CameraSwitcher.Register(_CC8);
        CameraSwitcher.Register(_CC9);
        CameraSwitcher.Register(_CC10);
        CameraSwitcher.Register(_CC11);
        CameraSwitcher.Register(_CC12);
        CameraSwitcher.Register(_CC13);
    }

    private void OnDisable()
    {
        CameraSwitcher.Unregister(_CC1);
        CameraSwitcher.Unregister(_CC2);
        CameraSwitcher.Unregister(_CC3);
        CameraSwitcher.Unregister(_CC4);
        CameraSwitcher.Unregister(_CC5);
        CameraSwitcher.Unregister(_CC6);
        CameraSwitcher.Unregister(_CC7);
        CameraSwitcher.Unregister(_CC8);
        CameraSwitcher.Unregister(_CC9);
        CameraSwitcher.Unregister(_CC10);
        CameraSwitcher.Unregister(_CC11);
        CameraSwitcher.Unregister(_CC12);
        CameraSwitcher.Unregister(_CC13);
        

    }

  

    private void OnTriggerEnter(Collider other)
    {
       
    }
}

