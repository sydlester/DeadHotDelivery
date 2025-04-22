using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ButtonSetup : MonoBehaviour
{
    private Button myButton;
    [SerializeField] string sceneToLoad;

    void Start()
    {
        myButton = GetComponent<Button>();
        myButton.onClick.AddListener(OnButtonClick);
    }

    void OnButtonClick()
    {
        Debug.Log("Button clicked! Loading scene: " + sceneToLoad);
        SceneManager.LoadScene(sceneToLoad);
    }
}
