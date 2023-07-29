using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownSkill : SkillManager
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
