using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static TheObject;

//已有別的方式代替
public class PlayerControllerUIManager : MonoBehaviour
{
    public UIManager UIManager;

    public PlayerManager PlayerManager;
    //public GameObject joystick;
    public SkillCdUI AttackSelfButton, RestoreButton, ChaseSkillButton, HelfChaseSkillButton, LineSkillButton, DownSkillButton, CloseSkillButton;

    //Active
    public void AttackSelf()
    {
        if (AttackSelfButton.SkillEnable)
        {
            AttackSelfButton.SkillEnable = false;
        }
    }

    public void Restore()
    {
        if (RestoreButton.SkillEnable)
        {
            RestoreButton.SkillEnable = false;
        }
    }
    /*public void ChaseSkill()
    {
        if (ChaseSkillButton.SkillEnable)
        {
            ChaseSkillButton.SkillEnable = false;
            PlayerManager.ChaseSkill();
        }
    }

    public void HelfChaseSkill()
    {
        if (HelfChaseSkillButton.SkillEnable)
        {
            HelfChaseSkillButton.SkillEnable = false;
            PlayerManager.HelfChaseSkill();
        }
    }

    public void LineSkill()
    {
        if (LineSkillButton.SkillEnable)
        {
            LineSkillButton.SkillEnable = false;
            PlayerManager.LineSkill();
        }
    }

    public void DownSkill()
    {
        if (DownSkillButton.SkillEnable)
        {
            DownSkillButton.SkillEnable = false;
            PlayerManager.DownSkill();
        }
    }

    public void CloseSkill()
    {
        if (CloseSkillButton.SkillEnable)
        {
            CloseSkillButton.SkillEnable = false;
            PlayerManager.CloseSkill();
        }
    }*/
}
