using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObject : MonoBehaviour
{
    // Awake�b����ͦ��ɥ���Start����A�`�`�ΨӰ���l�ƪ��ʧ@
    void Awake()
    {
        Debug.Log("���� " + gameObject.name + " �Q�ͦ�");
        // TODO: ��l�ƪ��󪺪��A
    }

    // Start�O�b�Ĥ@�V��s�e����A�ΨӪ�l�ƹC���ܼ�
    void Start()
    {
        Debug.Log("���� " + gameObject.name + " ��Start�Q����");
        // TODO: ��l�ƪ��󪺪��A
    }

    // Update�b�C�@�V�Q�եΡA�`�ΨӳB�z�C���޿�
    void Update()
    {
        Debug.Log("���� " + gameObject.name + " ��Update�Q����");
        // TODO: ��s���󪺦欰�Ϊ��A
    }

    // ����Q���a�椬�ɳQ�I�s
    public void Interact()
    {
        Debug.Log("���� " + gameObject.name + " �Q�椬");
        // TODO: �B�z����Q���a�椬�ɪ��欰
    }

    // ����Q�P���ɳQ�I�s
    public void DestroyObject()
    {
        Debug.Log("���� " + gameObject.name + " �Q�P��");
        // TODO: �B�z����Q�P���ɪ��欰
        Destroy(gameObject);  // �P�����C������
    }
}
