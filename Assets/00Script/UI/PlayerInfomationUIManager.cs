using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

//���H�����q���
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
//currentHealthText.text = "��q" + currentHealth.ToString("f0") + "/" + currentMaxHealth.ToString("f0");
//currentDeadTimeText.text = currentDeadTime.ToString("f0") + "/" + deadTime.ToString("f0");
//objectTypeText.text = "����:" + objectTypeText.text;
//objcetNameText.text = "�W��:" + objcetName;
//currentHealthText.text = "��q" + currentHealth.ToString("f0") + "/" + currentMaxHealth.ToString("f0");
//currentDefenceText.text = "���m:" + currentDefense.ToString("f0");
//Convert.ToString(currentHealthRestore)�p�ƥγo��
//criticalchance.ToString("f0.00")��ƥγo��
//currentDeadTimeText.text = (objectState == ObjectState.Dead) ? currentDeadTime + "/" + deadTime : " ";
//objectStateText.text = "���A:" + objectStateText.text;
//public Text objectStateText;
//objectTypeText.text = "Player";
//currentHealthRestoreText.text = "�^�_:" + (100 * currentHealthRestore).ToString("f0") + "%";

//criticalchanceText.text = "�z�����v:" + (100 * criticalchance).ToString("f0") + "%";
//currentDamageText.text = "�����O:" + currentDamage.ToString("f0");
//objectTypeText.text = "Monster";
//currentDamageText.text = "�����O:" + currentDamage.ToString("f0");
//objectTypeText.text = "Material";
//objectStateText.text = "�ݩR";
//objectStateText.text = "Patrol";
//objectStateText.text = "���`";