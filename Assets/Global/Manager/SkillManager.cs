using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public Organism OrganismA;
    public Organism OrganismB;

    public void SkillAStart(Organism OrganismA, Organism OrganismB)
    {
        SkillAEnd(OrganismA,OrganismB);
    }
    public void SkillAEnd(Organism OrganismA,Organism OrganismB)
    {
        OrganismA.TakeDamage(OrganismA,OrganismB);
    }

    public void SkillBStart()
    {

    }
    public void SkillBEnd()
    {
        OrganismB.Restore();
    }

    public void SkillCStart()
    {

    }
    public void SkillCEnd()
    {

    }

}
