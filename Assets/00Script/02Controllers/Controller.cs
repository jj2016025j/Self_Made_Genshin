using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Controller : MonoBehaviour
{
    // �򥻲���
    public void Move(Vector3 direction)
    {
        // �ھڶǤJ����V�V�q�Ӳ��ʨ���C
    }

    // ���ਤ��
    public void Rotate(Quaternion targetRotation)
    {
        // �N�������ܫ��w���ؼб��ਤ�סC
    }

    // Ĳ�o���D�欰
    public void Jump()
    {
        // Ĳ�o���⪺���D�欰�C
    }

    // Ĳ�o�k���欰
    public void Climb()
    {
        // Ĳ�o���⪺�k���欰�C
    }

    // Ĳ�o�Ĩ�欰
    public void Dash()
    {
        // Ĳ�o���⪺�Ĩ�欰�C
    }

    // Ĳ�o�Ƶ��欰
    public void Glide()
    {
        // Ĳ�o���⪺�Ƶ��欰�C
    }

    // ��s�ʵe���A
    public void UpdateAnimationState()
    {
        // ��s���⪺�ʵe���A�C
    }

    // �����ʧ@
    public void Attack()
    {
        // ��������ʧ@�C
    }

    // ����ˮ`
    public void TakeDamage(int damage)
    {
        // �������⪺��q�C
    }

    // ���⦺�`
    public void Die()
    {
        // ���樤�⪺���`�ʵe�M�C���޿�C
    }

    // ����P���󤬰�
    public void Interact()
    {
        // ����P�C���@�ɤ�����L���餬�ʡC
    }

    // �ϥΧޯ�
    public void UseSkill(SkillManager skill)
    {
        // �ϥΤ@�ӯS�w���ޯ�Ϊk�N�C
    }

    // ���שΰ{��
    public void Dodge()
    {
        // ������שΰ{�ת��ʧ@�C
    }

    // �]�B
    public void Run()
    {
        // �Ϩ���]�B�άO�W�[�t�סC
    }

    // ��a
    public void Swim()
    {
        // ������i���a�ʧ@�C
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
