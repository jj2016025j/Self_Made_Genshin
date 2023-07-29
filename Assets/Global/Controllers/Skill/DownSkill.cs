using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownSkill : SkillManager
{
    public float moveSpeed = 3;
    public Rigidbody rb;

    public Transform target;
    Vector3 Vector3;
    public float damage;

    public override void SkillStart()
    {
        Vector3 = new Vector3(Random.Range(-3, 3), -30, Random.Range(-3, 3));
    }

    public override void SkillDoing()
    {
        if (target != null)
        {
            rb.AddForce(moveSpeed * Time.deltaTime * Vector3, ForceMode.Force);
            if (Vector3.Distance(transform.position, target.position) < 0.5f)
            {
                Collider[] hitColliders = Physics.OverlapSphere(transform.position, 1f);
                foreach (Collider collider in hitColliders)
                {
                    //是否擊中生物
                    if (collider.gameObject.GetComponent<Organism>() == selfOrganism)
                    {
                        //UNDO damage
                        return;
                    }
                    else if (collider.gameObject.GetComponent<MonsterManager>() && collider.transform.CompareTag("Player"))
                    {
                        targetOrganism = collider.gameObject.GetComponent<MonsterManager>() ? collider.gameObject.GetComponent<MonsterManager>() : targetOrganism;
                        selfOrganism.TakeDamage(selfOrganism, targetOrganism);
                        return;
                    }
                }
            }
        }
        else
        {
            target = selfOrganism.FindClosestMonster(selfOrganism.GameManager.MapManager.MonsterManagers).transform;
        }
    }

}
