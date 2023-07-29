using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIManager : MonoBehaviour
{
    public UIManager UIManager;

    public PlayerManager PlayerManager;

    public TextMeshProUGUI PlayerName, currentHealthText;

    public Image HealthBar;
    
    //public GameObject joystick;

    //Update

    public void UpdateUI(float currentHealth, float maxHealth)
    {
        currentHealthText.text = currentHealth.ToString("f0");
        HealthBar.fillAmount = currentHealth / maxHealth;
    }

    //Active
    public void AttackSelf()
    {
        PlayerManager.AttackSelf();
        Debug.Log("AttackSelf");
    }

    public void Restore()
    {
        PlayerManager.Restore();
        Debug.Log("Restore");
    }

    public void ChaseSkill()
    {
        PlayerManager.ChaseSkill();
        Debug.Log("ChaseSkill");
    }

    public void HelfChaseSkill()
    {
        PlayerManager.HelfChaseSkill();
        Debug.Log("HelfChaseSkill");
    }

    public void LineSkill()
    {
        PlayerManager.LineSkill();
        Debug.Log("LineSkill");
    }
    
    public void DownSkill()
    {
        PlayerManager.DownSkill();
        Debug.Log("DownSkill");
    }
    
    public void CloseSkill()
    {
        PlayerManager.CloseSkill();
        Debug.Log("CloseSkill");
    }
}
