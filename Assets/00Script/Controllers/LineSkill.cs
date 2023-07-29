using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineSkill : SkillManager
{
    public ParticleSystem _particleSystem;

    private void Start()
    {
        _particleSystem = GetComponent<ParticleSystem>();
    }

    private void OnParticleCollision(UnityEngine.GameObject other)
    {
        print("hit");
        //是否擊中生物
        if (other.GetComponent<TheObject>() == selfOrganism)
        {
            return;
        }
        else if (other.GetComponent<TheObject>() != selfOrganism && other.GetComponent<TheObject>())
        {
            selfOrganism.TakeDamage(selfOrganism, targetOrganism);
            return;
        }
    }
}