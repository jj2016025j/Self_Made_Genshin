using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

//跟隨角色血量顯示
public class PlayerInfomationUIManager : MonoBehaviour
{
    public UIManager UIManager;
    
    public PlayerManager PlayerManager;

    public TextMeshProUGUI PlayerName, currentHealthText;
    public Image HealthBar;

    //Update
    public void UpdateUI(float currentHealth, float maxHealth)
    {
        currentHealthText.text = currentHealth.ToString("f0");
        HealthBar.fillAmount = currentHealth / maxHealth;
    }
}
//public Text objectTypeText;
//public Text objectStateText;

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
//currentHealthText.text = "血量" + currentHealth.ToString("f0") + "/" + currentMaxHealth.ToString("f0");
//currentDeadTimeText.text = currentDeadTime.ToString("f0") + "/" + deadTime.ToString("f0");
//objectTypeText.text = "種類:" + objectTypeText.text;
//objcetNameText.text = "名稱:" + objcetName;
//currentHealthText.text = "血量" + currentHealth.ToString("f0") + "/" + currentMaxHealth.ToString("f0");
//currentDefenceText.text = "防禦:" + currentDefense.ToString("f0");
//Convert.ToString(currentHealthRestore)小數用這個
//criticalchance.ToString("f0.00")整數用這個
//currentDeadTimeText.text = (objectState == ObjectState.Dead) ? currentDeadTime + "/" + deadTime : " ";
//objectStateText.text = "狀態:" + objectStateText.text;
//public Text objectStateText;
//objectTypeText.text = "Player";
//currentHealthRestoreText.text = "回復:" + (100 * currentHealthRestore).ToString("f0") + "%";

//criticalchanceText.text = "爆擊機率:" + (100 * criticalchance).ToString("f0") + "%";
//currentDamageText.text = "攻擊力:" + currentDamage.ToString("f0");
//objectTypeText.text = "Monster";
//currentDamageText.text = "攻擊力:" + currentDamage.ToString("f0");
//objectTypeText.text = "Material";
//objectStateText.text = "待命";
//objectStateText.text = "Patrol";
//objectStateText.text = "死亡";