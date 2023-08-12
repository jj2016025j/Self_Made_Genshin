using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownSkill : SkillManager
{
    private void OnParticleCollision(GameObject other)
    {
        print("hit");
        //�O�_�����ͪ�
        if (other.GetComponent<EntityData>() == selfEntity)
        {
            return;
        }
        else if (other.GetComponent<EntityData>() != selfEntity && other.GetComponent<EntityData>())
        {
            selfEntity.DamageSkill(selfEntity, targetEntity);
            return;
        }
    }
}
