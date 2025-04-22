using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneController : MonoBehaviour
{
    public static SceneController instance;
    //prevents from being destroyed when loading a new scene
   private void Awake() {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
   }

    //loads the scene based on the level number
   public void LevelSelector(int level) {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + level);
   }
}
