using UnityEngine;

public class SceneController : Singleton<SceneController>
{
    GameObject player;
    private void Awake() {
        base.Awake();
        DontDestroyOnLoad(this);
    }
    public void TransitionToDestination(TransitionPoint transitionPoint)
    {
        switch (TransitionPoint.TransitionType)
        {
            case TransitionPoint.TransitionType.SameScene:
                StartCoroutine(Transition(SceneManager.GetActiveScene().name,transitionPoint.targetDestinationTag));
                break;
            case TransitionPoint.TransitionType.DifferentScene:
                StartCoroutine(Transition(transitionPoint.sceneName,transitionPoint.targetDestinationTag));
                break;               
        }
    }
    IEnumerater Transition(string sceneName,TransitionPoint.DestinationTag targetDestinationTag){
        //TODO:保存數據
        if(SceneManager.GetActiveScene().name!=sceneName){
            yield return SceneManager.LoadSceneAsync(sceneName);
            yield return Instantiate(player,GetDestination(targetDestinationTag).transform.position,GetDestination(targetDestinationTag).transform.rotation);
            yield break;
        }
        else{
        player=GameManager.Instance.playerStats.gameObject;
        player.transform.SetPositionAndRotation(GetDestination(targetDestinationTag).transform.position,GetDestination(targetDestinationTag).transform.rotation);
        }
    }
    TransitionPoint GetDestination(TransitionPoint.DestinationTag targetDestinationTag){
        var entrances=FindObjectsOfType<TransitionPoint>();
        for(int i=0;i<entrances.Length;i++){
            if(entrances[i].myselfDestinationTag==targetDestinationTag)
            return entrances[i];
        }
        return null;
    }
        void LoadScene(int number){
        SceneManager.LoadScene(number);
    }
    void ReloadScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}