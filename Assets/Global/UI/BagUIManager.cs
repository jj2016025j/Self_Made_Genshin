using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagUIManager : MonoBehaviour
{
    //­I¥]
    public GameObject Bag;
    public Button BagButton;

    private void Awake()
    {
        Bag = GameObject.Find("Bag");

        BagButton = this.GetComponent<Button>();
        BagButton.onClick.AddListener(() => BagSwitch());
    }

    private void Start()
    {
        Bag.SetActive(false);
        BagButton.gameObject.SetActive(false);
    }
    void BagSwitch()
    {
        Bag.SetActive(!Bag.activeSelf);
    }

}
