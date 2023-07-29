using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class talkbutton : MonoBehaviour
{
    public GameObject button;
    public GameObject talkUI;
    private void OnTriggerEnter(Collider other)
    {
        button.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        button.SetActive(false);
    }
    private void Start()
    {
        button.SetActive(false);
        talkUI.SetActive(false);

    }
    void Update()
    {
        if (button.activeSelf & Input.GetKeyDown(KeyCode.H))
        {
            talkUI.SetActive(true);
        }
    }
}
