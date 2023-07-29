using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerManager2 : MonoBehaviour
{
    //W,A,S,D, SPACE, SHIFT, CTRL, TAB, F~K, V~M,     �ڻݭn������
    [Header("�ؼ�")]
    public List<characterstats> targets;
    //public List<characterstats> specialObjectsOrEnemys;
    public bool �Q�аO;
    public GameObject �аO;
    public Transform noTarget;
    [Header("���a")]
    public TPPplayermovement1 playerController;
    public characterstats own;
    public List<GameObject> �ޯ�;
    public Vector3 offset;
    public bool �i���;

    //public GameObject talkUI;
    void Start()
    {
        �аO.SetActive(�Q�аO); 
        own = GetComponent<characterstats>();
        noTarget = Instantiate(�аO.transform);
        noTarget.position = transform.forward*1000;
        �i��� = playerController.�i���;
    }

    // Update is called once per frame
    void Update()
    {
        if (�i���)
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                AttackAnyOne(targets);
            }
            if (own.objectState != characterdata.ObjectState.Dead)
            {
                if (Input.GetKeyDown(KeyCode.Tab))//���ۤv
                {
                    own.TakeDamageByMySelf();
                }
                if (Input.GetKeyDown(KeyCode.H))//����
                {
                    �����аO();
                    FindObjectByFindObjectsOfType(targets);
                    �ɦ�(targets);
                }
                if (Input.GetKeyDown(KeyCode.J))
                {
                    �d��ɦ�();
                }
                if (Input.GetKey(KeyCode.K))
                {
                    ���V�ޯ�();
                }
                if (Input.GetKeyDown(KeyCode.F))
                {
                    �l�ܧޯ�();
                }
                if (Input.GetKeyDown(KeyCode.G))
                {
                    �l�ܧޯ�2();
                }
                if (Input.GetKey(KeyCode.L))
                {
                    FindObjectByFindObjectsOfType(targets);
                }
            }
            if(!own.�԰����A)
                �����аO();//�ק�
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                Run();
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                Walk();
            }
        }
    }
    public void AttackAnyOne(List<characterstats> objectsOrEnemys)//�����Ҧ��Q�аO���ĤH
    {
        foreach(var objectOrEnemy in objectsOrEnemys)
        {
            if (objectOrEnemy.objectState != characterdata.ObjectState.Dead)
                own.TakeDamage(own, objectOrEnemy,1); 
        }
    }
    public void �ɦ�(List<characterstats> targets)//�^�_�Ҧ��Q�аO���ĤH
    {
        foreach (var target in targets)
        {
            if (target.objectState != characterdata.ObjectState.Dead)
                own.�ɦ�(own, target, 0.7f);
        }
    }
    public void �d��ɦ�()//�s�y�@�ӽd��
    {
        Instantiate(�ޯ�[1], transform.position + new Vector3(0, -0.5f, 0), transform.rotation, transform);//�аO�����鬰������
        own.�ɦ�(own, own, 0.7f);
    }
    public void ���V�ޯ�()
    {
        offset = new Vector3(0, 1, 0);
        Instantiate(�ޯ�[0], transform.position + offset, transform.rotation, transform);//�аO�����鬰������
    }
    public void �l�ܧޯ�()
    {
        offset = new Vector3(0, 1, 0);
        FindObjectByFindObjectsOfType(targets);
        for (int i = 0; i <= 15; i++)
        {
            Instantiate(�ޯ�[2], transform.position + offset, transform.rotation, transform);//�аO�����鬰������
            �ޯ�[2].GetComponent<skill>().target = �̪�ؼ�(targets).transform;
        }
    }
    public void �l�ܧޯ�2()
    {
        offset = new Vector3(0, 1, 0);
        FindObjectByFindObjectsOfType(targets);
        for (int i = 0; i <= 20; i++)
        {
            Instantiate(�ޯ�[2], transform.position + offset, transform.rotation, transform);//�аO�����鬰������
            �ޯ�[2].GetComponent<skill>().target = �H���ؼ�(targets).transform;
        }
    }
    public characterstats �H���ؼ�(List<characterstats> targets)
    {
        characterstats target = targets[Random.Range(0, targets.Count)];
        if (target.transform.GetComponent<characterstats>() == own && target.objectState != characterdata.ObjectState.Dead)
        {
            target = �H���ؼ�(targets);
        }
        return target;
    }
    public characterstats �̪�ؼ�(List<characterstats> targets)
    {
        characterstats clossOne = targets[0];
        float minDis = Vector3.Distance(targets[0].transform.position, transform.position);
        if (targets[0].transform == transform)
        {
            if (targets[1].transform != null)
            {
                clossOne = targets[1];
                minDis = Vector3.Distance(targets[1].transform.position, transform.position);
            }
            else if (targets[1].transform == null) clossOne = null;
        }
        for (int i = 0; i < targets.Count; i++)
        {
            if (targets[i].transform != transform)
            {
                float dis = Vector3.Distance(targets[i].transform.position, transform.position);
                if (minDis > dis && targets[i].objectState != characterdata.ObjectState.Dead)
                {
                    minDis = dis;
                    clossOne = targets[i];
                }
            }
        }
        return clossOne;
    }

public void FindObjectByFindObjectsOfType(List<characterstats> targets)
    {
        targets.Clear();
        var enemys = FindObjectsOfType<characterstats>();

        foreach (var enemy in enemys)
        {
            if (enemy != own)
            {
                targets.Add(enemy);
                enemy.GetComponent<playerManager2>().�Q�аO = true;
                enemy.GetComponent<playerManager2>().�аO.SetActive(�Q�аO);
                //GameObject �Q�аO = enemy.GetComponent<playerManager>().�Q�аO;
                //Instantiate(�аO, �Q�аO.transform.position, Quaternion.identity, �Q�аO.transform);
            }
        }
    }
    public void �����аO()
    {
        foreach(var objectOrEnemy in targets)
        {
            �Q�аO = false;
            �аO.SetActive(�Q�аO); 
            /*GameObject �Q�аO = objectOrEnemy.GetComponent<playerManager>().�Q�аO;
            for(int i=0;i<= �Q�аO.transform.childCount; i++)
            {
                if (�Q�аO.transform.GetChild(i)==null)
                {
                    return;

                }
                Debug.Log("0");
                Destroy(�Q�аO.transform.GetChild(i).gameObject);
            }*/

        }
        targets.Clear();
    }
    public void Run()
    {
        own.currentSpeed *= 2;
        playerController.GetSpeed();
    }
    public void Walk()
    {
        own.currentSpeed = own.baseSpeed;
        playerController.GetSpeed();
    }

}
