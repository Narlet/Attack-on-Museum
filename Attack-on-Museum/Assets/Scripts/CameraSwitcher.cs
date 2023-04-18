using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public static class CameraSwitcher 
{
   
    static List <CinemachineVirtualCamera> cameras = new List <CinemachineVirtualCamera>();

    public static CinemachineVirtualCamera _activeCamera = null;



    public static bool IsActiveCamera(CinemachineVirtualCamera camera)
    {
        return camera == _activeCamera;
    }




    public static void SwitchCamera(CinemachineVirtualCamera camera)
    {
        camera.Priority = 10;
        _activeCamera = camera;

        foreach (CinemachineVirtualCamera c in cameras)
        {
            if (c != camera)
            {
                c.Priority = 0;
            }
        }
    }


    public static void Register(CinemachineVirtualCamera camera)
    {
        cameras.Add(camera);
        Debug.Log("camera Registered" + camera);
    }

    public static void Unregister(CinemachineVirtualCamera camera)
    {
        cameras.Remove(camera);
        Debug.Log("camera Unregistered" + camera);
    }

}
