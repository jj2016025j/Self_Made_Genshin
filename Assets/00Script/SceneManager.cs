using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public GameObject Slime;  // �Ǫ����w�]�ҪO
    //public List<GameObject> Monsters;  // �޲z�Ҧ��ͦ����Ǫ�
    public int Monsters;//�Ǫ��ƶq

    public int StartUnitQuantity = 5;  // �}�l�ɪ��Ǫ��ƶq
    public int UnitQuantityUpperLimit = 20;  // �̤j���Ǫ��ƶq

    public float InstantiateTime = 10;  // �C�j�h�֮ɶ��ͦ��Ǫ�
    private bool isSpawning = false;  // �O�_���ӥͦ��Ǫ�

    // �b�C���}�l�ɽե�
    private void Awake()
    {
        StartCoroutine(InitSpawn());  // �}�l��P�{�ǡA�ͦ���l���Ǫ�
        Debug.Log("�C���}�l�A��l�ƩǪ��ͦ�");  // �b����x��X���ܰT��
        GameManager.Instance.SpawnCharacter();  // �z�L GameManager ����ҨөI�s SpawnCharacter() ��k
    }

    // ��P�{�ǡA�Ω��l�ƥͦ��Ǫ�
    IEnumerator InitSpawn()
    {
        for (int i = 1; i <= StartUnitQuantity; i++)
        {
            InstantiateUnit();
            yield return new WaitForSeconds(1f);  // ���ݤ@����
        }
        isSpawning = true;  //�}�l�w���ͦ��Ǫ�
        StartCoroutine(SpawnLoop());  // �}�l�w���ͦ��Ǫ�����P�{��
    }

    // ��P�{�ǡA�Ω�w���ͦ��Ǫ�
    IEnumerator SpawnLoop()
    {
        while (isSpawning)
        {
            InstantiateUnit();
            yield return new WaitForSeconds(InstantiateTime);  // ���ݤ@�w���ɶ�
        }
    }

    // �ͦ��Ǫ�
    void InstantiateUnit()
    {
        if (/*Monsters.Count*/Monsters < UnitQuantityUpperLimit && Slime != null)  // �P�_�O�_�F��Ǫ��ƶq�W���H�μҪO�O�_�s�b
        {
            var monster = GameObject.Instantiate(Slime, new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)), Quaternion.identity);
            //Monsters.Add(monster);
            Monsters += 1;
            Debug.Log("�ͦ��@���Ǫ��A��e�Ǫ��ƶq: " + Monsters/*Monsters.Count*/);
        }
        else if (Slime == null)
        {
            Debug.LogError("�Ǫ��ҪO���bInspector���]�w"); 
        }
    }

    // �M�z�Ҧ��Ǫ�
    public void Clean()
    {
        for (int i = Monsters/*Monsters.Count*/ - 1; i >= 0; i--)
        {
            //Destroy(Monsters[i]);
            Monsters -= 1;
        }
        //Monsters.Clear();
        Monsters = 0;
        Debug.Log("�M�ũҦ��Ǫ�");
    }
}
