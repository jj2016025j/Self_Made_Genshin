using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingUIManager : MonoBehaviour
{
    public GameObject Setting;
    public Button SettingButton;
    private void Awake()
    {
        Setting = GameObject.Find("Setting");

        SettingButton = this.GetComponent<Button>();
        SettingButton.onClick.AddListener(() => SettingSwitch());
    }

    private void Start()
    {
        Setting.SetActive(false);
        SettingButton.gameObject.SetActive(false);
    }

    public void SettingSwitch()
    {
        Setting.SetActive(!Setting.activeSelf);
    }
}
