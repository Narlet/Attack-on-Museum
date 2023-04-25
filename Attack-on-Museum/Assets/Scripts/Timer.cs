using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _timerText = null;
    // Start is called before the first frame update
    void Start()
    {
        _timerText.text = "Time Left : " + Mathf.Floor(TimeManager.Instance.MaxTime).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        float minutes = Mathf.Floor((TimeManager.Instance.MaxTime - TimeManager.Instance.CurrentTime) / 60);
        float seconds = Mathf.RoundToInt((TimeManager.Instance.MaxTime - TimeManager.Instance.CurrentTime) % 60);
        string fseconds = seconds.ToString();
        string fminutes = minutes.ToString();
        if (minutes < 10)
        {
            fminutes = "0" + minutes.ToString();
        }
        if (seconds < 10)
        {
            fseconds = "0" + seconds.ToString();
        }
        _timerText.text = "Time Left : " + fminutes + ":" + fseconds;
    }
}
