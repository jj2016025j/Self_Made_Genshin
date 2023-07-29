using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.Examples;
using UnityEditor.U2D.Animation;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIManager : MonoBehaviour
{
    public PlayerManager playerManager;
    public MapManager MapManager;
    public GameObject playerUI, AttackButton, RestoreButton,test,test2,test3;//JumpButton;
    public TextMeshProUGUI currentHealthText;

    public bool updatePlayerUI;
    //public GameObject joystick;

    //public Text objectTypeText;
    //public Text objcetNameText;
    //public Text objectStateText;
    //public Text maxHealthtext;
    //public Text currentMaxHealthText;
    //public Text baseHealthRestoretext;
    //public Text currentHealthRestoreText;
    //public Text baseDefencetext;
    //public Text deadTimeText;
    //public Text currentDeadTimeText;
    //public Text currentDefenceText;
    //public Text baseDamagetext;
    //public Text currentDamageText;
    //public Text criticalmultipliertext;
    //public Text criticalchanceText;
    
    private void Awake()
    {
        playerManager = GetComponent<PlayerManager>();
        playerUI = GameObject.Find("PlayerUI");
        AttackButton = GameObject.Find("AttackButton");
        RestoreButton = GameObject.Find("RestoreButton");

        test = GameObject.Find("AttackSelf");
        test3 = GameObject.Find("Test3");

        MapManager = GameObject.Find("GameManager").GetComponent<MapManager>();
        currentHealthText = GameObject.Find("HealthText").GetComponent<TextMeshProUGUI>();

        AttackButton.GetComponent<Button>().onClick.AddListener(() => Attack());
        RestoreButton.GetComponent<Button>().onClick.AddListener(() => Restore());
        test.GetComponent<Button>().onClick.AddListener(() => Test());
        test3.GetComponent<Button>().onClick.AddListener(() => Test3());

        UpdatePlayerUI(playerManager.currentHealth);
    }

    private void Test()
    {
        MapManager.monsterManagers[0].Dead();
        UpdatePlayerUI(playerManager.currentHealth);
        Debug.Log("Test");
    }
    private void Test2()
    {
        MapManager.monsterManagers[0].Dead();
        UpdatePlayerUI(playerManager.currentHealth);
        Debug.Log("Test2");
    }
    private void Test3()
    {
        playerManager.skillManager.SkillAEnd(playerManager, MapManager.monsterManagers[0]);
        UpdatePlayerUI(playerManager.currentHealth);
        Debug.Log("Test3");
    }

    void Update()
    {
        if (updatePlayerUI)
        {
            UpdatePlayerUI(playerManager.currentHealth);
        }
    }
    void UpdatePlayerUI(float currentHealth)
    {
        playerManager.UpdatePlayer();
        currentHealthText.text = currentHealth.ToString();
    }
    void Attack()
    {
        playerManager.TakeDamageSelf(playerManager);
        UpdatePlayerUI(playerManager.currentHealth);
        Debug.Log("Attack");
    }
    void Restore()
    {
        playerManager.Restore();
        UpdatePlayerUI(playerManager.currentHealth);
        Debug.Log("Restore");
    }
    /*void Jump()
    {
        PlayerManager.Jump();

    }*/
    void Move()
    {
        playerManager.Move();
    }

}
