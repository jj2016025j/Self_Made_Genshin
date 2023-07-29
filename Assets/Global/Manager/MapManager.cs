using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.UI.Image;

//����a�Ϫ��A�\��
public class MapManager : MonoBehaviour
{
    [Header("Manager")]
    public MapUIManager MapUIManager;
    public GameManager GameManager;
    public List<MonsterManager> MonsterManagers;

    public GameObject Unit;

    //�ͪ��ƶq
    public int StartUnitQuantity=5;
    public int CurrentUnitQuantity=0;
    public int UnitQuantityUpperLimit = 10;

    //Other
    public float InstantiateTime=1;
    public float time=10;
    public bool isWaiting;

    private void Start()
    {
        for(int i = 1; i <= StartUnitQuantity; i++)
        {
            InstantiateUnit();
        }
        JudgeQuantity();
    }
    
    //Instantiate
    private void Update()
    {
        if (isWaiting)
        {
            time -= Time.deltaTime;
            if (time <= 0)
            {
                InstantiateUnit();
                time = InstantiateTime;
                JudgeQuantity();
            }
            else if(time > InstantiateTime)
            {
                time = InstantiateTime;
            }
        }
        else
        {
            time = 10;
        }
    }

    void InstantiateUnit()
    {
        CurrentUnitQuantity++;
        Debug.Log(CurrentUnitQuantity);
        Instantiate(Unit, new Vector3(0, 10, 0), Quaternion.identity);
        //UNDO Create UI
    }

    //��즺�`
    public void UnitDead(MonsterManager monsterManager)
    {
        CurrentUnitQuantity -= 1;
        JudgeQuantity();
        MonsterManagers.Remove(monsterManager);
        //UNDO Delete UI
    }

    //�T�{�Ѿl�ƶq
    public void JudgeQuantity()
    {
        isWaiting = CurrentUnitQuantity < UnitQuantityUpperLimit ? true : false;
    }

    //Scene
    public string currentScene;
    public string[] allScene;
    public string currentMap;
    public string targetMap;
    public string[] allMap = { "Home", "City", "Field" };

    //
    public void Load_Map(string targetMap)
    {

    }

    //��������
    public void Load_ImagePlay_Scene()
    {
        ChangeScene("ImagePlay");
    }

    public void Load_SampleScene_Scene()
    {
        ChangeScene("SampleScene");
    }

    //�ھڿ�J���J����
    public void ChangeScene(string sceneName)
    {
        if (SceneManager.GetActiveScene().name != sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    public void MonsterListAdd(MonsterManager monsterManager)
    {
        MonsterManagers.Add(monsterManager);
    }
}
