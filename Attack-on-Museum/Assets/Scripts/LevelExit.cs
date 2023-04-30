using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelExit : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == ScoreManager.Instance.CurrentCharacter)
        {
            if (ScoreManager.Instance.CurrentScore > 0)
            {
                TimeManager.Instance.Victory = true;
            }
            else
            {
                TimeManager.Instance.GameOver = true;
            }
        }
    }
}
