using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//²H¤J²H¥X
public class sceneFadeInOut : MonoBehaviour
{
    public float fadeSpeed = 1.5f;
    public bool sceneStarting = true;
    public static bool sceneEnding = false;
    public RawImage rawImage;
    void Awake()
    {
        rawImage = GetComponent<RawImage>();
    }

    void Start()
    {
    }

    void Update()
    {
        if (sceneStarting)
        {
            StartScene();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            sceneStarting = true;
        }
        if (sceneEnding)
        {
            EndScene();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            sceneEnding = true;
        }
    }

    private void FadeToClear()
    {
        rawImage.color = Color.Lerp(rawImage.color, Color.clear, fadeSpeed * Time.deltaTime);
    }

    private void FadeToBlack()
    {
        rawImage.color = Color.Lerp(rawImage.color, Color.black, fadeSpeed * Time.deltaTime);
    }

    void StartScene()
    {
        FadeToClear();
        if (rawImage.color.a < 0.05f)
        {
            rawImage.color = Color.clear;
            rawImage.enabled = false;
            sceneStarting = false;
            Debug.Log("StartScene");

        }
    }

    void EndScene()
    {
        rawImage.enabled = true;
        FadeToBlack();
        if (rawImage.color.a > 0.9999f)
        {
            sceneEnding = false;
            Debug.Log("EndScene");
            //SceneManager.LoadScene(Globe.Name);
        }
    }

    void OnDestroy()
    {

    }
}

