using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameTimer : MonoBehaviour
{

    public float elapsedTime = 0f;

    void Update()
    {
        elapsedTime += Time.deltaTime;
    }
}
