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
        if (other.GetComponent<ObjectData>() == selfOrganism)
        {
            return;
        }
        else if (other.GetComponent<ObjectData>() != selfOrganism && other.GetComponent<ObjectData>())
        {
            selfOrganism.DamageSkill(selfOrganism, targetOrganism);
            return;
        }
    }
}
