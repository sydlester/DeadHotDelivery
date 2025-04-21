using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitPoint : MonoBehaviour
{
    [SerializeField] private int levelToLoad;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("ExitPoint Triggered");
        if (other.CompareTag("Player"))
        {
            SceneController.instance.LevelSelector(levelToLoad);
        }
    }
}
