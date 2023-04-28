using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoScript : MonoBehaviour
{
    [SerializeField] RawImage _image = null;
    [SerializeField] VideoPlayer _video = null;
    [SerializeField] GameObject _mainMenu = null;




    private void Start()
    {
      Playvideo();
    }

  IEnumerator Playvideo()

    {
        _video.Prepare();
        WaitForSeconds waitForSeconds = new WaitForSeconds(1);
        while (!_video.isPrepared)
        {
            yield return waitForSeconds;
            break;
        }
        _image.texture = _video.texture;
        _video.Play();
        
    }
}
