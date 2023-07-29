using UnityEngine;
using UnityEngine.AI;

//怪物行為控制 
public class Monstermanager : CreatureManager
{
    // 怪物進行攻擊
    public void Attack()
    {
        // 這裡可以添加怪物進行攻擊時的行為的程式碼
    }

    // 使用技能
    public void UseSkill(string skillName)
    {
        // 在這裡添加使用技能的代碼
        // 例如，你可能需要根據技能名稱來決定使用哪種技能，
        // 或者你可能需要檢查生物是否有足夠的資源（例如魔法值）來使用該技能

        Debug.Log("生物使用了技能：" + skillName);
    }
}
