//繼承單例 玩家及Manager管理
//玩家死亡 玩家註冊 
//當前場景 判斷場景決定動作 執行進入場景 進入場景後檢查
//遊戲流程控制=>關閉遊戲
//紀錄當前場景有多少單位
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : Singleton<GameManager>
{
    [Header("About player")]
    public PlayerManager playerStates;
    public MainManager mainStates;
    public MapManager mapManager;
    //Dont Destroy
    private void Awake() {
        base.Awake();
        DontDestroyOnLoad(this);
    }

    public void PlayerDead()
    {
        //告訴所有單位
        NotifyObserver();
    }

    void PlayerGet()
    {
        
    }

    public void RigisterPlayer(PlayerManager player)
    {
        playerStates=player;
    }

    [Header ("All applicable")]
    private void OnApplicationQuit() 
    {
        Application.Quit();
        EditorApplication.isPlaying();
    }

    [Header ("About scene")]
    public string sceneName;

    void JudgeSceneNumber()
    {
        switch(SceneManager.GetActiveScene().name) {
            case "0":
                Scene1();
                break;
            case "1":
                Scene2();
                break;
            case "2":
                Scene3s();
                break;
            default:
			    Debug.Log("Default case");
			    break;
        }
    }

    void EnteringStartScene()
    {//Start Scene

    }

    void EnterStartScene()
    {

    }    

    void Void()
    {
        
    }



    [Header ("About Observer")]

    List<IEndGameObserver> endGameObservers=new List<IEndGameObserver>();

    public void AddObserver(IEndGameObserver Observer)
    {
        endGameObservers.Add(Observer);
    }

    public void RemoveObserver(IEndGameObserver Observer)
    {
        endGameObservers.Remove(Observer);
    }

    public void NotifyObserver(){
        foreach(var Observer in endGameObservers){
            Observer.EndNotufy();
        }
    }

}