using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitPoint : MonoBehaviour
{
    [SerializeField] private int levelToLoad;
    //checks if player has wlaked into the exit point
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneController.instance.LevelSelector(levelToLoad);
        }
    }
}
