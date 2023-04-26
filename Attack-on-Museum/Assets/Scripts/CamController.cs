using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera[] _camPoints = null;

    public void SwitchCam(CinemachineVirtualCamera camToSwitch)
    {
        for (int i = 0; i < _camPoints.Length; i++)
        {
            if (camToSwitch == _camPoints[i])
            {
                _camPoints[i].Priority = 10;
            }
            else
                _camPoints[i].Priority = 0;
                        
        }
    }
}
