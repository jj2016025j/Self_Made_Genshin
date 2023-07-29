using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyskill : MonoBehaviour//飛行技能
{
    float time_f;
    int time_i;
    public Rigidbody fallobject;
    private void Start()
    {
        fallobject = gameObject.GetComponent<Rigidbody>();
        fallobject.AddForce(30, 0, 0, ForceMode.Impulse);
    }
    void Update()
    {
        time_f += Time.deltaTime;
        time_i = Mathf.FloorToInt(time_f);
        if (time_i >= 10)
        {
            Destroy(gameObject);
        }
        fallobject.AddForce(30, 0, 0, ForceMode.Impulse);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
        }
        Destroy(gameObject);
    }
}
/*switch (skillType)
{
        SkillType skillType;
/*case SkillType.right:
        break;
    case SkillType.up:
        break;
    case SkillType.fiy:
        flyskill();
        break;
    case SkillType.slash:
        slashskill();
        break;
enum SkillType//技能種類
    {
        right, down, up, fiy, slash
    }
}*/