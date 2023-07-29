using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//控制場景切換
//紀錄場景地圖
public class SceneControll : Singleton<SceneControll>
{
    //載入圖片場景
    public void Load_ImagePlay_Scene()
    {
        ChangeScene("ImagePlay");
    }
    
    //載入初始場景
    public void Load_SampleScene_Scene()
    {
        ChangeScene("GameScene");
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //根據輸入載入場景
    private void ChangeScene(string sceneName)
    {
        if(SceneManager.GetActiveScene().name!=sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
