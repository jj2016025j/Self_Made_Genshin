using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownSkill : SkillManager
{

    public ParticleSystem _particleSystem;

    private void Start()
    {
        _particleSystem = GetComponent<ParticleSystem>();
    }

    private void OnParticleCollision(UnityEngine.GameObject other)
    {
        print("hit");
        //�O�_�����ͪ�
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
