using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class input : MonoBehaviour
{
    public GameObject game;
    void Start()
    {
        game = GameObject.Find("GameManagerUI");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            GetComponent<GameManager>().score++;
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            GameObject.Find("GameManagerUI").GetComponent<GameManager>().PlayerScored();
        }
    }
}
