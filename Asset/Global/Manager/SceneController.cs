using UnityEngine.SceneManagement;

//控制場景切換
//紀錄場景地圖
public class SceneController : Singleton<SceneController>
{
    public GameManager GameManager;

    public MapManager MapManager;
    //public List<MapManager> MapManagers;

    public string CurrentScene;
    
    public void Load_ImagePlay_Scene()
    {
        ChangeScene("ImagePlay");
        CurrentScene = "ImagePlay";
    }
    
    public void Load_SampleScene_Scene()
    {
        ChangeScene("GameScene");
        CurrentScene = "ImagePlay";
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        CurrentScene = SceneManager.GetActiveScene().name;
    }

    private void ChangeScene(string sceneName)
    {
        if(SceneManager.GetActiveScene().name!= sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
