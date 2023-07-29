using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.UI.Image;

//控制地圖狀態功能
public class MapManager : MonoBehaviour
{
    [Header("Manager")]
    public UIManager UIManager;
    public GameManager gameManager;
    public PlayerManager playerManager;
    public List<MonsterManager> monsterManagers;

    public GameObject UnitUIParent;
    public GameObject UnitUI;

    //生物數量
    public int StartUnitQuantity=5;
    public int CurrentUnitQuantity=0;
    public int UnitQuantityUpperLimit = 10;

    //Other
    public float InstantiateTime=1;
    public float time=10;
    public bool isWaiting;

    private void Awake()
    {
        UIManager = GetComponent<UIManager>();
        gameManager = GetComponent<GameManager>();
        playerManager = GetComponent<PlayerManager>();
        UnitUIParent = GameObject.Find("OtherUnit");
        UnitUI = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Unit.prefab");
    }

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
        //Instantiate(playerManager, new Vector3(0, 0, 0), Quaternion.identity);
        Instantiate(UnitUI, UnitUIParent.transform, false);
        //UNDO Create UI
    }

    //單位死亡
    public void UnitDead(MonsterManager monsterManager)
    {
        CurrentUnitQuantity -= 1;
        JudgeQuantity();
        monsterManagers.Remove(monsterManager);
        //UNDO Delete UI
    }

    //確認剩餘數量
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

    //切換場景
    public void Load_ImagePlay_Scene()
    {
        ChangeScene("ImagePlay");
    }

    public void Load_SampleScene_Scene()
    {
        ChangeScene("SampleScene");
    }

    //根據輸入載入場景
    public void ChangeScene(string sceneName)
    {
        if (SceneManager.GetActiveScene().name != sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    public void MonsterListAdd(MonsterManager monsterManager)
    {
        monsterManagers.Add(monsterManager);
    }
}
