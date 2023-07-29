using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseSkill : SkillManager
{
    public override void SkillStart()
    {
        Destroy(gameObject,0.2f);
    }
}
