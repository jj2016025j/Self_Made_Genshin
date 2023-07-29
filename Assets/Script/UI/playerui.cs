using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class playerui2 : MonoBehaviour
{
    public GameObject bagwindow;
    public GameObject inspectwindow;
    public GameObject settingwindow;
    public GameObject skillwindow;

    public GameObject bagbutton;
    public GameObject inspectbutton;
    public GameObject settingbutton;
    public GameObject skillbutton;

    public bool bagisopen;
    public bool inspectisopen;
    public bool settingisopen;
    public bool skillisopen;
    public bool UImanagerisopen;
    public WindowsState currentState;
    public WindowsState previousState;
    public enum WindowsState
    {
        inspectwindow,
        bagwindow,
        settingwindow,
        skillwindow,
        closewindow
    }
    private void Start()
    {
        bagwindow = GameObject.Find("bagwindow");
        inspectwindow = GameObject.Find("inspectwindow");
        settingwindow = GameObject.Find("settingwindow");
        skillwindow = GameObject.Find("skillwindow");

        bagbutton = GameObject.Find("bagbutton");
        inspectbutton = GameObject.Find("inspectbutton");
        settingbutton = GameObject.Find("settingbutton");
        skillbutton = GameObject.Find("skillbutton");
        bagbutton.GetComponent<Button>().onClick.AddListener(() => Bagbutton());
        inspectbutton.GetComponent<Button>().onClick.AddListener(() => Inspectbutton());
        settingbutton.GetComponent<Button>().onClick.AddListener(() => Settingbutton());
        skillbutton.GetComponent<Button>().onClick.AddListener(() => Skillbutton());

        bagisopen = false;
        inspectisopen = false;
        settingisopen = false;
        skillisopen = false;
        UImanagerisopen = false;
        currentState = WindowsState.closewindow;
        previousState = WindowsState.closewindow;
        correctandsetactive();
    }

    private void FixedUpdate()
    {
        if (UImanagerisopen == true)
        {
            useswitch();
            correctandsetactive();
            UImanagerisopen = false;
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            Bagbutton();
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            Inspectbutton();
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            Settingbutton();
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            Skillbutton();
        }
    }
    public void useswitch()
    {
        switch (currentState)
        {
            case WindowsState.inspectwindow:
                bagisopen = false;
                inspectisopen = true;
                settingisopen = false;
                skillisopen = false;
                correctandsetactive();
                break;
            case WindowsState.bagwindow:
                bagisopen = true;
                inspectisopen = false;
                settingisopen = false;
                skillisopen = false;
                correctandsetactive();
                break;
            case WindowsState.settingwindow:
                bagisopen = false;
                inspectisopen = false;
                settingisopen = true;
                skillisopen = false;
                correctandsetactive();
                break;
            case WindowsState.skillwindow:
                bagisopen = false;
                inspectisopen = false;
                settingisopen = false;
                skillisopen = true;
                correctandsetactive();
                break;
            case WindowsState.closewindow:
                bagisopen = false;
                inspectisopen = false;
                settingisopen = false;
                skillisopen = false;
                correctandsetactive();
                break;
        }
    }

    public void correctandsetactive()
    {
        bagwindow.SetActive(bagisopen);
        inspectwindow.SetActive(inspectisopen);
        settingwindow.SetActive(settingisopen);
        skillwindow.SetActive(skillisopen);
        previousState = currentState;
    }
    public void Inspectbutton()
    {
        currentState = WindowsState.inspectwindow;
        repeatswitch();
    }
    public void Bagbutton()
    {
        currentState = WindowsState.bagwindow;
        repeatswitch();
    }
    public void Settingbutton()
    {
        currentState = WindowsState.settingwindow;
        repeatswitch();
    }
    public void Skillbutton()
    {
        currentState = WindowsState.skillwindow;
        repeatswitch();
    }
    public void repeatswitch()
    {
        UImanagerisopen = true;
        if (previousState == currentState)
            Closebutton();
    }
    public void Closebutton()
    {
        currentState = WindowsState.closewindow;
    }
}
