using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//�����������
//���������a��
public class SceneControll : Singleton<SceneControll>
{
    //���J�Ϥ�����
    public void Load_ImagePlay_Scene()
    {
        ChangeScene("ImagePlay");
    }
    
    //���J��l����
    public void Load_SampleScene_Scene()
    {
        ChangeScene("GameScene");
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //�ھڿ�J���J����
    private void ChangeScene(string sceneName)
    {
        if(SceneManager.GetActiveScene().name!=sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
