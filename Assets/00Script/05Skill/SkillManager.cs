using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

//技能分成產生範圍、以物件射出、以粒子射出、產生怪物
public class SkillManager : MonoBehaviour
{
    //SkillData 
    /*有血條的可互動物件
    生物類物件
    怪物類物件
    玩家腳色類物件*/
    [Header("SKILL")]
    public ChaseSkill chaseSkill;
    public HelfChaseSkill helfChaseSkill;
    public LineSkill lineSkill;
    public DownSkill downSkill;
    public CloseSkill closeSkill;
    
    public OrganismData selfOrganism;
    public OrganismData targetOrganism;
    public bool SkillIsWorking = true;

    private void OnParticleCollision(UnityEngine.GameObject other)
    {
        // Do something when a particle collides with another object
    }

    private void Start()
    {        
        Destroy(gameObject,10);
        SkillIsWorking = true;
        SkillStart();
        //transform.localScale= selfOrganism.transform.localScale;
    }

    private void FixedUpdate()
    {
        if (SkillIsWorking)
        {
            SkillDoing();
        }
    }

    public virtual void SkillStart()
    {
    }

    public virtual void SkillDoing()
    {

    }

    public virtual void SkillEnd(Collision collision)
    {
        //是否擊中生物
        if (collision.gameObject.GetComponent<OrganismData>() == selfOrganism)
        {

            return;
        }
        else if(collision.gameObject.GetComponent<OrganismData>() && collision.transform.CompareTag("Player"))
        {

            targetOrganism = collision.gameObject.GetComponent<OrganismData>() ? collision.gameObject.GetComponent<OrganismData>() : targetOrganism;
            selfOrganism.DamageSkill(selfOrganism, targetOrganism);
            Destroy(gameObject);
            return;
        }

 //       SkillIsWorking = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        SkillEnd(collision);
    }

}
