using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageMiniMap : MonoBehaviour
{
    public GameObject miniMap;
    public bool isMiniMapActive = false;
    public CanvasGroup canvasGroup;

    // Start is called before the first frame update
    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0; // Hide the minimap at the start
        // miniMap = GameObject.Find("MiniMap");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M)) // or MouseButtonDown(0)
        {
            if (!isMiniMapActive)
            {
                canvasGroup.alpha = 1; // Show the minimap
                isMiniMapActive = true;
            }
            else
            {
                canvasGroup.alpha = 0; // Hide the minimap
                isMiniMapActive = false;
            }
        }
    }
}
