using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateLocation : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset = new Vector3(0.75f, -0.5f, 0); // Offset to position the object above the player

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        if (player != null)
        {
            transform.position = player.transform.position + offset;
        }
    }
}
