using UnityEngine;

public class TransitionPoint : MonoBehaviour {
    public enum TransitionType{
        SameScene,DifferentScene
    }
    public enum DestinationTag{
        A,B,C
    }

    [Headeer("Transitiom Info")]
    public string sceneName;
    public TransitionType transitionType; //TODO:改成private
    public DestinationTag targetDestinationTag; //TODO:改成private
    public DestinationTag myselfDestinationTag;
    public bool canTrans;

    void Update(){
        if(Input.GetKeyDown(KeyCode.E)&&canTrans)
        {
            //TODO:做視窗
            SceneController.Instance.TransitionToDestination(this);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        canTrans=true;
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        canTrans=false;        
    }
}