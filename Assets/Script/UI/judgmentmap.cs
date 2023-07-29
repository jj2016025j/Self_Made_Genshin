using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class judgmentmap : MonoBehaviour
{
    public showui showui;
    public Typeofmap typeofmap;
    public GameObject GameObject;
    public enum Typeofmap
    {
        Town,
        Valley,
        Forest,
        Ocean
    }
    private void OnTriggerEnter(Collider other)
    {
        switch1();
        showui.FadeIn();
        Debug.Log("Must have canvas group attached!");

    }
    public void enterarea()
    {
        switch1();
        showui.FadeIn();
        Debug.Log("Must have canvas group attached!");
    }
    void switch1()
    {
        switch (typeofmap)
        {
            case Typeofmap.Town:
                GameObject.transform.GetChild(0).gameObject.SetActive(true);
                GameObject.transform.GetChild(1).gameObject.SetActive(false);
                GameObject.transform.GetChild(2).gameObject.SetActive(false);
                GameObject.transform.GetChild(3).gameObject.SetActive(false);
                break;
            case Typeofmap.Valley:
                GameObject.transform.GetChild(0).gameObject.SetActive(false);
                GameObject.transform.GetChild(1).gameObject.SetActive(true);
                GameObject.transform.GetChild(2).gameObject.SetActive(false);
                GameObject.transform.GetChild(3).gameObject.SetActive(false);
                break;
            case Typeofmap.Forest:
                GameObject.transform.GetChild(0).gameObject.SetActive(false);
                GameObject.transform.GetChild(1).gameObject.SetActive(false);
                GameObject.transform.GetChild(2).gameObject.SetActive(true);
                GameObject.transform.GetChild(3).gameObject.SetActive(false);
                break;
            case Typeofmap.Ocean:
                GameObject.transform.GetChild(0).gameObject.SetActive(false);
                GameObject.transform.GetChild(1).gameObject.SetActive(false);
                GameObject.transform.GetChild(2).gameObject.SetActive(false);
                GameObject.transform.GetChild(3).gameObject.SetActive(true);
                break;
        }
    }
    
}
