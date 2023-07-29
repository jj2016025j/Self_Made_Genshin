using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FixResolution : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector2 resolution = transform.parent.GetComponent<CanvasScaler>().referenceResolution;
        RectTransform rect = GetComponent<RectTransform>();
        float ratio = (Screen.width * resolution.y) / (Screen.height * resolution.x);
        Debug.Log(ratio);
        rect.sizeDelta *= ratio;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.root.GetComponent<CanvasScaler>().referenceResolution;
    }
}
