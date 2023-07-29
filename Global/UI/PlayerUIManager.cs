using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIManager : MonoBehaviour
{
    public UIManager UIManager;

    public PlayerManager PlayerManager;

    //UNDO Button
    public Button AttackButton, RestoreButton, AttackSelfButton, ShieldButton, BowButton, JumpButton, SprintButton;

    public TextMeshProUGUI PlayerName, currentHealthText;

    public Image HealthBar;

    //public GameObject joystick;

    public void Update()
    {
        UpdatePlayerUI(PlayerManager.currentHealth);
    }

    public void Test()
    {
        UIManager.GameManager.MapManager.MonsterManagers[0].Dead();
        UpdatePlayerUI(PlayerManager.currentHealth);
        Debug.Log("Test");
    }
    public void Test2()
    {
        UIManager.GameManager.MapManager.MonsterManagers[0].Dead();
        UpdatePlayerUI(PlayerManager.currentHealth);
        Debug.Log("Test2");
    }
    public void Test3()
    {
        PlayerManager.SkillManager.SkillAEnd(PlayerManager, UIManager.GameManager.MapManager.MonsterManagers[0]);
        UpdatePlayerUI(PlayerManager.currentHealth);
        Debug.Log("Test3");
    }

    public void UpdatePlayerUI(float currentHealth)
    {
        currentHealthText.text = PlayerManager.currentHealth.ToString();
        HealthBar.fillAmount = PlayerManager.currentHealth / PlayerManager.maxHealth;
    }

    public void Attack()
    {
        PlayerManager.TakeDamage(PlayerManager, PlayerManager);
        Debug.Log("Attack");
    }

    public void AttackSelf()
    {
        PlayerManager.TakeDamageSelf(PlayerManager);
        Debug.Log("AttackSelf");
    }

    public void Restore()
    {
        PlayerManager.Restore();
        UpdatePlayerUI(PlayerManager.currentHealth);
        Debug.Log("Restore");
    }
}
