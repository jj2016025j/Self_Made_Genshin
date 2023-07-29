using System.Collections;
using System.Collections.Generic;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.UI.Image;

//北瓜篈
public class MapManager : MonoBehaviour
{
    [Header("Manager")]
    public GameManager GameManager;
    public MapUIManager MapUIManager;
    public List<GameObject> MonsterManagers;

    public GameObject Slime, BossSlime, DarkBoss;

    //ネ计秖
    public int StartUnitQuantity=5;
    public int UnitQuantityUpperLimit = 20;

    //Other
    public float InstantiateTime=10;
    public float time=10;
    public bool isWaiting = false;

    private void Start()
    {
        StartCoroutine(CoroutineTest());
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

    IEnumerator CoroutineTest()
    {
        for (int i = 1; i <= StartUnitQuantity; i++)
        {
            InstantiateUnit();
            yield return new WaitForSeconds(1f);
        }
    }

    //Quantity Controll
    void InstantiateUnit()
    {
        JudgeQuantity();
        GameObject UnitUI = MapUIManager.InstantiateUnitUI();
        GameObject unit= Instantiate(DarkBoss, new Vector3(Random.Range(-50,50), 0, Random.Range(-50, 50)), Quaternion.identity);
        unit.GetComponent<MonsterManager>().HealthBar = UnitUI.transform.GetChild(2).GetComponent<Image>();
        unit.GetComponent<MonsterManager>().UnitName = UnitUI.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        unit.GetComponent<MonsterManager>().UnitUI = UnitUI;
        MonsterManagers.Add(unit);
        Debug.Log("Monster计秖:" + MonsterManagers.Count);
    }

    //虫
    public void UnitDead(GameObject gameObject, GameObject UnitUI, GameObject UnitUIWorldSpace)
    {
        MapUIManager.DestroyUnitUI(UnitUI, UnitUIWorldSpace);
        MonsterManagers.Remove(gameObject);
        Destroy(gameObject);
        JudgeQuantity();
    }

    //絋粄逞緇计秖
    public void JudgeQuantity()
    {
        isWaiting = MonsterManagers.Count < UnitQuantityUpperLimit;
    }















    public List<MonsterManager> MonsterManagers2;
    public List<MonsterManager> MonsterManagers3;
    //ネ计秖
    public int StartUnitQuantity2 = 2;
    public int CurrentUnitQuantity2 = 0;
    public int UnitQuantityUpperLimit2 = 2;

    //ネ计秖
    public int StartUnitQuantity3 = 1;
    public int CurrentUnitQuantity3 = 0;
    public int UnitQuantityUpperLimit3 = 1;

}
