using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//直線技能
public class LineSkill : SkillManager
{
    private void OnParticleCollision(GameObject other)
    {
        print("hit");
        //是否擊中生物
        if (other.GetComponent<EntityData>() == selfOrganism)
        {
            return;
        }
        else if (other.GetComponent<EntityData>() != selfOrganism && other.GetComponent<EntityData>())
        {
            selfOrganism.DamageSkill(selfOrganism, targetOrganism);
            return;
        }
    }
}