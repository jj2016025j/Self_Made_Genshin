using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill : MonoBehaviour//�ޯ�
{
    //�n���@��!!!!!!!!!
    //buff
    public trigger healing;//�ɦ�

    //nerf
    
    public string[] skilltype;//�ޯ����

    public player[] playerA;//��X��
    public player[] playerB;//�Q��X��
    public GameObject player;  

    void Start()
    {
        skilltype[]= (buff[], nerf[], physics[], other[]);

        buff[]= (HP, ATK, MAG, SPD);
        nerf[]= (HP, ATK, MAG, SPD);
        physics[]= ();
        other[]= ();

        playerA[] = GameObject.Find("playerA");//�M�䪫��
        playerB[] = GameObject.Find("playerB");
        var findObjects = FindObjectOfType<enemy>();//�M�䦳�ե󪺶���
        Debug.Log("�ե�ƶq" + findObjects.Length);//�M��쪺�ƶq

        
    }


    void FixedUpdate()
    {

    }
    Instantiate(����, ��m, ���)
    void OntriggerEnter(collider other)
    {
        switch (skilltype[])//�ޯ����
        {
            case == buff[]:
                switch (buff[0])
                {
                    case == HP:
                        basicATK()
                        break;
                }           
                
            case == nerf[]:
                switch (nerf[0])
                {
                    case == HP:
                        healing()
                        break;
                }
                break;
        }

    void OntriggerExit(collider other)
    {

    }

    void OntriggerStay(collider other)
    {

    }

    void basicatk()//��¦����
        {
        PlayerB.HP = PlayerB.HP - playerA.ATK;
        Debug.Log("��" + PlayerB + "�y��" + playerA.ATK + "�ˮ`");
    }
    void skillatk()//�ޯ�ˮ`
    {
        PlayerB.HP = PlayerB.HP - playerA.ATK * 1.2f;
        Debug.Log("�y���ˮ`*" + playerA.ATK * 1.2f);
    }
    void healing()//�v¡
    {
        PlayerB.HP = PlayerB.HP + playerA.mag;
        Debug.Log("�^�_�ͩR*"+ playerA.mag);
    }
    void slowmove()//�w�t
    {
        PlayerB.mspd = PlayerB.mspd *0.5f;
        Debug.Log("�w�t");
    }
    void daze()//�w�t
    {
        PlayerB.mspd = 0;�t�׬��s
        Debug.Log("�w�t");
    }
    void daze()//��P
    {
        Destroy(gameObject,0);//X���R������
        Debug.Log("��P����");
    }
    void daze()//�Ϯg
    {
        journeyLength = Vector.Distance(startMarker.position, endMarker.position);//�}�Ҫ��󭫤O�ìI�[�Y��V���O
        transform.LookAt(endMarker);//��V�ؼ�
        float discovered = (Time.time - startTime) * speed;//���ʮɶ�*�t��
        float fracjourney = discovered / journeyLength;//�{�b��Ҧ�m=�{�b����/�`��
        transform.position=Vector3.Lerp(startMarker.position, endMarker.position, fracjourney)//�ƶ������ʨ���I

    }

        void skillstay()//����ĪG
        Invoke("FixedUpdate", 2);
        //�o�Ӥ��²��A�g�bc#�}�����A�N�� ����Z�եΤ@���AMethodName��k�C
        InvokeRepeating("FixedUpdate", 1, 2);
        //�o�Ӥ�k�N�O�h���ե�Invoke�A�Y�z�Ѭ��@��Z�A�C�j���ե�MethodName��k�C
        CancelInvoke("FixedUpdate");
        //����MethodName��k���եΡC
    }

