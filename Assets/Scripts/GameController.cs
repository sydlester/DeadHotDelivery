using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameOverScreen gameOverScreen;
    private GameTimer gameTimer;

    private void Start()
    {
        gameTimer = GetComponent<GameTimer>();
    }

    //Initializes Game Over Screen
    public void Win()
    {
        // gameOverScreen.Setup(gameTimer.elapsedTime);
        gameOverScreen.Setup(1f);
    }
}
