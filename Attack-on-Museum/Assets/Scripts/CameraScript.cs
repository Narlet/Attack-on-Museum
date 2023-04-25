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
    


    private void OnEnable()
    {
        CameraSwitcher.Register(_CC1);
        CameraSwitcher.Register(_CC2);
        CameraSwitcher.SwitchCamera(_CC1);
    }

    private void OnDisable()
    {
        CameraSwitcher.Unregister(_CC1);
        CameraSwitcher.Unregister(_CC2);
        
    }

  

    private void OnTriggerEnter(Collider other)
    {
       if(CameraSwitcher.IsActiveCamera(_CC1))
        {
            CameraSwitcher.SwitchCamera(_CC2);
        }
       else if(CameraSwitcher.IsActiveCamera(_CC2))
        {
            CameraSwitcher.SwitchCamera(_CC1);
        }
    }
}

