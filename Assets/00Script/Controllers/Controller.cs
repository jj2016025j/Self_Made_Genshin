using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Controller : MonoBehaviour
{
    // 基本移動
    public void Move(Vector3 direction)
    {
        // 根據傳入的方向向量來移動角色。
    }

    // 旋轉角色
    public void Rotate(Quaternion targetRotation)
    {
        // 將角色旋轉至指定的目標旋轉角度。
    }

    // 觸發跳躍行為
    public void Jump()
    {
        // 觸發角色的跳躍行為。
    }

    // 觸發攀爬行為
    public void Climb()
    {
        // 觸發角色的攀爬行為。
    }

    // 觸發衝刺行為
    public void Dash()
    {
        // 觸發角色的衝刺行為。
    }

    // 觸發滑翔行為
    public void Glide()
    {
        // 觸發角色的滑翔行為。
    }

    // 更新動畫狀態
    public void UpdateAnimationState()
    {
        // 更新角色的動畫狀態。
    }

    // 攻擊動作
    public void Attack()
    {
        // 執行攻擊動作。
    }

    // 受到傷害
    public void TakeDamage(int damage)
    {
        // 扣除角色的血量。
    }

    // 角色死亡
    public void Die()
    {
        // 執行角色的死亡動畫和遊戲邏輯。
    }

    // 角色與物件互動
    public void Interact()
    {
        // 角色與遊戲世界中的其他物體互動。
    }

    // 使用技能
    public void UseSkill(SkillManager skill)
    {
        // 使用一個特定的技能或法術。
    }

    // 躲避或閃避
    public void Dodge()
    {
        // 執行躲避或閃避的動作。
    }

    // 跑步
    public void Run()
    {
        // 使角色跑步或是增加速度。
    }

    // 游泳
    public void Swim()
    {
        // 讓角色進行游泳動作。
    }

    // Set Cooldown
    public void SetCooldown(float cooldown)
    {
        // Set the cooldown for an ability.
    }

    // Upgrade Skill
    public void UpgradeSkill(SkillManager skill)
    {
        // Upgrade a specific skill.
    }
}
