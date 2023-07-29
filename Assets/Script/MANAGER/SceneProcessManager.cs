//繼承單例 
//Boss and monster的物件 位置 數量
//隨機怪物重生點的方法
//生成怪物方法 過關直接讓怪物死亡的方法
//玩家死亡後由流程
//判斷是否需要生成怪物
//過關要求轉換場景
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneProcessManager : Singleton<SceneProcessManager>
{
    [Header("prefab")]
    public GameObject Boss;
    public GameObject monster;
    public Vector3 bossBirthPoint;
    public List<Vector3> monsterBirthPoint;
    public int bossQuantity;
    public int monsterQuantity;
    [Header("singleton")]
    void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);
        Invoke("MonsterPassOut", 3);
        Invoke("BossPassOut", 3);
    }
        static SceneProcessManager singleton;
   
    public static SceneProcessManager Singleton
    {
        get
        {
            if (singleton == null)
            {
                singleton = new SceneProcessManager();
            }
            
            return singleton;
        }
    }
        void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            BossPassOut();
            MonsterPassOut();
        }
    }

    public void SpawnBoss()
    {
        Vector3 offset = new Vector3(Random.Range(-10, 10), 5, Random.Range(-10, 10));
        Instantiate(Boss, bossBirthPoint + offset, Quaternion.identity);
        bossQuantity++;
    }
    public void SpawnMonster()
    {
        Vector3 offset = new Vector3(Random.Range(-10, 10), 5, Random.Range(-10, 10));
        Instantiate(Boss, monsterBirthPoint[Random.Range(0, monsterBirthPoint.Count)] + offset, Quaternion.identity);
        monsterQuantity++;
    }
    public void BossPassOut()
    {
        bossQuantity--;
        if (bossQuantity <= 0)
        {
            bossQuantity = 0;
            SpawnBoss();
        }
    }
    public void MonsterPassOut()
    {
        monsterQuantity--;
        int i = Random.Range(3, 8);
        while (monsterQuantity < i)
        {
            SpawnMonster();
        }
    }
        list<int> L1;
        list<int> L2;
        void startGame(){
            InstanceUnit(L1);
            i=l1.count;
        }
        viod InstanceUnit(list<int> list){
            foreach (int unit in list){
                //在隨機點生成物件
            }
        }
        void Dead (){
            i--;
            if(i<0){
                i=0;
                InstanceUnit(L2);
            }
            BiologyQuantity--;
            int i=Random.range(1,10);
            if(BiologyQuantity<i){
            //等待時間後復活

        }
    void startGame()
    {
        InstanceNPC();
        InstanceAnimal();
        InstanceMonster();
        InstanceResource();
    }
    Vector3 npcResurrectionPoint;
    void InstanceNPC()
    {
        Instance(npc,npcResurrectionPoint,原始旋轉);
    }
    void InstanceAnimal()
    {
        
    }
    void InstanceMonster()
    {
        
    }
    void InstanceResource()
    {
        
    }
    int BiologyQuantity;
    Vector3 RandomResurrectionPoint()
    {
        //隨機點=隨機空中點向下發出射線後碰撞到的點
        Vector3 V=new Vector3(Random.range(-10,10),10,Random.range(-10,10));
        return new Vector3(0,0,0);
    }
        }
}