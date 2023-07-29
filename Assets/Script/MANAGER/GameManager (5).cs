using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager> ,IEndGameObserver
{
    void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);
    }
    [Header ("About player")]
    public playerManager2 playerManager;
    public void PlayerDead()
    {
        NotifyObserver();
    }
    void PlayerGet()
    {
  
    }
    public void RigisterPlayer(playerManager2 player)
    {
        playerManager=player;
    }
    private void OnApplicationQuit() 
    {
        Application.Quit();
        //EditorApplication.isPlaying();
    }
    void JudgeSceneNumber()
    {
        switch(SceneManager.GetActiveScene().name) {
            case "0":

                break;
            case "1":

                break;
            case "2":

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
    void Stage1()
    {
        //to do instance mobs小怪
    }
    void Stage2()
    {
        //to do instance BOSS
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
            Observer.EndNotify();
        }
    }
    public void EndNotify(){}

}
