using UnityEngine;
using UnityEngine.UI;
using TMPro;

//times gameplay
public class GameTimer : MonoBehaviour
{

    public float elapsedTime = 0f;

    void Update()
    {
        elapsedTime += Time.deltaTime;
    }
}
