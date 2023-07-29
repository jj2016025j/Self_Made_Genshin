//繼承單例 
//單體目標or群體目標 
//找目標方法 (給AI、技能、UI使用)
//是否可控制 UI 玩家控制器及AI控制器
//玩家prefab 背包 技能列表
//生成玩家function
//技能按鈕輸入判定輸出SWITCH
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random=UnityEngine.Random;
public class playerManager2 : Singleton<playerManager2>
{
    [Header("Target")]
    public List<characterStats> targets;
    public characterStats target;
    void FindAllTargets(List<characterStats> targets)
    {
        targets.Clear();
        var foundTargets = FindObjectsOfType<characterStats>();

        foreach (var foundTarget in foundTargets)
        {
            if (foundTarget != own)
            {
                targets.Add(foundTarget);
            }
        }
    }
    characterStats RandomGoal(List<characterStats> targets)
    {
        characterStats target = targets[UnityEngine.Random.Range(0, targets.Count)];
        int i = 0;
        if (target.transform.GetComponent<characterStats>() == own || target.GetComponent<characterStats>().dead == true)
        {
            target = RandomGoal(targets);
            i++;
            if (i == 50)
                return transform.GetComponent<characterStats>();//find another one
        }
        return target;
    }
    characterStats RecentGoal(List<characterStats> targets)
        {
        characterStats clossOne = targets[0];
        float minDis = Vector3.Distance(targets[0].transform.position, transform.position);
        if (targets[0].transform == transform)
        {
            if (targets[1].transform != null)
            {
                clossOne = targets[1];
                minDis = Vector3.Distance(targets[1].transform.position, transform.position);
            }
            if (targets[1].transform == null)
            {
                clossOne = null;
            }
        }
        for (int i = 0; i < targets.Count; i++)
        {
            if (targets[i].transform != transform)
            {
                float dis = Vector3.Distance(targets[i].transform.position, transform.position);
                if (minDis > dis || targets[i].GetComponent<characterStats>().dead == true)
                {
                    minDis = dis;
                    clossOne = targets[i];
                }
            }
        }
        return clossOne;
    }
    [Header("Tool")]
    bool ControlledByPlayer;
    healthBar healthBar;
    TPPPlayerController tPPPlayerController;
    aiController aiController;
    [Header("singleton")]
    private static PlayerManager singleton = null;
    public static PlayerManager Singleton
    {
        get
        {
            // TODO: Automatic creation
            if (singleton == null)
            {
                singleton = new GameObject(t.Name, typeof(PlayerManagert));
            }
            return singleton;
        }
    }
    private void Awake()
    {
        base.Awake();
        SpawnPlayer();
        if (singleton != null)
        {
            Debug.LogErrorFormat(this.gameObject, "Multiple instances of {0} is not allow", GetType().Name);
            return;
        }
        singleton = this;
        GameObject.DontDestroyOnLoad(this.gameObject);        
        DontDestroyOnLoad(this);
    }
    [Header("Player")]
    public GameObject playerObject;//之後用MANAGER創建
    public characterStats own;
    bag bag;
    //Canva
    private List<GameObject> skill;//他需要技能列表不是物件
    public void SpawnPlayer()
    {
        Vector3 offset = new Vector3(Random.Range(-10, 10), 5, Random.Range(-10, 10));
        Instantiate(playerObject, playerBirthPoint + offset, Quaternion.identity);
        if(!IsLife){
            GameManager.PlayerDead();
        }
    }
    [Header("Skill")]
   List<SkillSerialNumber> skillSerialNumber;
   void ExecutionOfKeyCode(KeyCode key){
      switch(key)
      {
         case F:
            Execution(skillSerialNumber[0]);
            break;
         case V:
            Execution(skillSerialNumber[1]);
            break;
         case G:
            Execution(skillSerialNumber[2]);
            break;
         case C:
            Execution(skillSerialNumber[3]);
            break;
      }
   }
}
