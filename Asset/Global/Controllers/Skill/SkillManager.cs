using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

//�ޯ�������ͽd��B�H����g�X�B�H�ɤl�g�X�B���ͩǪ�
public class SkillManager : MonoBehaviour
{
    public Organism selfOrganism;
    public Organism targetOrganism;
    public bool SkillIsWorking = true;

    private ParticleSystem _particleSystem;

    private void OnParticleCollision(GameObject other)
    {
        // Do something when a particle collides with another object
    }

    private void Start()
    {
        _particleSystem = GetComponent<ParticleSystem>();
        
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
        //�O�_�����ͪ�
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
