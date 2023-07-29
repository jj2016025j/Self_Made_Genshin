using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class SkillManager : MonoBehaviour
{
    public Organism selfOrganism;
    public Organism targetOrganism;
    public bool SkillIsWorking = true;

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
        if (collision.gameObject.GetComponent<Organism>() == selfOrganism)
        {

            return;
        }
        else if(collision.gameObject.GetComponent<Organism>() && collision.transform.CompareTag("Player"))
        {

            targetOrganism = collision.gameObject.GetComponent<Organism>() ? collision.gameObject.GetComponent<Organism>() : targetOrganism;
            selfOrganism.TakeDamage(selfOrganism, targetOrganism);
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
