using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class jsondemo : MonoBehaviour
{
    void Start()
    {

        //�ŧi�@��Listy�@���D��C��æs�J��ӹD��
        List<string> equips = new List<string>();
        equips.Add("sword");
        equips.Add("shield");
        equips.Add("apple");

        //�έ��ŧi�n��Class�Ыؤ@���x�s�ƭȪ�����A�õ����ƭ����������ƭ�(�Ҧp�ͩR�]�w��100�A����250....)

        Data newData = new Data
        {
            health = 200,
            money = 2500,
            equip = equips
        };

        //����Ыئn���ƭȪ����ରJson�r��A�å�JsonInfo�Ѽ��x�s�A���U�ӧ�o�Ӧr��g�J���w���ɮצ�m(�U������r�Ч令�ۤv�����|�m���i�H�n�̫᭱�O�ɮצW��)

        string jsonInfo = JsonUtility.ToJson(newData, true);
        File.WriteAllText("D:/���ӦbC��/unity�m�߱M��/test01/Assets/file1", jsonInfo);

        Debug.Log("�g�J����");
    }

}

//�n�x�s����ƥΤ@��Class�h�x�s�A�̭��i�H��U���������(���O�����Dictionary �ܭ��n!!!�ڳQ�I�˫ܤ[)
public class Data
{
    public float health;
    public int money;
    public List<string> equip;
}