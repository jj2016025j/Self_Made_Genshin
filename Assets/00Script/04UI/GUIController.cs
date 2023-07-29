using UnityEngine;

public class GUIControler:MonoBehaviour
{
    PlayerManager PlayerManager;
    private void Awake()
    {
        PlayerManager = GetComponent<PlayerManager>();
    }
    /*
    private void OnGUI()
    {
        if (PlayerManager.canAction) {
            Attacking();
            Jumping();
        }

        Debug();
    }

    private void Attacking()
    {
        if (PlayerManager.MaintainingGround() && PlayerManager.canAction) {
                if (GUI.Button(new Rect(25, 85, 100, 30), "Attack1")) { PlayerManager.Attack1(); }
        }
    }

    private void Jumping()
    {
        if (PlayerManager.canJump
            && PlayerManager.canAction) {
            if (PlayerManager.MaintainingGround()) {
                if (GUI.Button(new Rect(25, 175, 100, 30), "Jump")) {
                    if (PlayerManager.canJump) { PlayerManager.inputJump = true; ; }
                }
            }
        }
    }

    private void Debug()
    {
        if (GUI.Button(new Rect(600, 15, 120, 30), "Debug Controller")) { PlayerManager.ControllerDebug(); }
        if (GUI.Button(new Rect(600, 50, 120, 30), "Debug Animator")) { PlayerManager.AnimatorDebug(); }
    }*/
}
