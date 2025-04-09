using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverScreen : MonoBehaviour
{
    public TMP_Text timerText;
    public void Setup(float time)
    {
        gameObject.SetActive(true);
        int minutes = Mathf.FloorToInt(time / 60F);
        int seconds = Mathf.FloorToInt(time % 60F);

        timerText.text = $"Time: {minutes:00}:{seconds:00}";
    }
}
