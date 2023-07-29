using UnityEngine;

public class SaveManager : Singleton<SaveManager>
{
    private void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);
    }

}