using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Data", menuName = "Character Stats/Data")]
public class characterdata : ScriptableObject
{
    public enum ObjectType { Player, Monster, Material,AI };
    public ObjectType objectType;
    public enum ObjectState { Guard, Patrol, Chase, Dead, Attack };
    public ObjectState objectState;

    public string objcetName;

    [Header("Stats Info")]
    //血量
    public float maxHealth;
    public float currentMaxHealth;
    public float currentHealth;
    //回復
    public float baseHealthRestore;
    public float currentHealthRestore;
    //防禦
    public float baseDefense;
    public float currentDefense;
    //死亡時間
    public float deadTime;
    public float currentDeadTime;

    [Header("Damage Info")]
    //攻擊
    public float baseDamage;
    public float currentDamage;
    public float attackRange;
    //其他
    public float skillRange;
    public float coolDown;
    public float criticalMultiplier;//爆擊加成
    public float criticalChance;//爆擊機率

    [Header("Other Info")]
    //戰鬥
    public bool inBattle;
    public float OutOfCombatTime;

    //速度
    public float baseSpeed;
    public float currentSpeed;

    //其他
    public float luck;
    public int money;
    //public bagData bagData;

    [Header("AI Info")]
    //偵測範圍
    public float patrolRange;
    public float sightRange;
}
