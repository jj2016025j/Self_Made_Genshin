using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���骫��
public class EntityManager : MonoBehaviour
{
    //UI
    //material
    //attackable
    //register
    //mapPosition
    //do data
    //do input
    //do move

    public GameManager GameManager; // �C���޲z��
    public EntityData objectData; // ���󪺼ƾ�
    public SkillManager SkillManager; // �ޯ�޲z�� �άO�令skill
    public CrowdManagement CrowdManager;  // �s��޲z��

    public GameObject target; // �ؼЪ���
    public GameObject damagePopupPrefab; // �ˮ`�u�X���w�s����


    public void Awake()
    {
        // �q�������������޲z�������
        CrowdManager = FindObjectOfType<CrowdManagement>();
    }

    // �b����}�l�ɪ�l��
    public virtual void Start()
    {
        Initialize();
        Debug.Log("�Ǫ��Q�i�Ыءj�A�ثe�`�ơG" + CrowdManager.monsters.Count);

    }

    // �b�C�@�V��sUI
    public virtual void Update()
    {
        UpdateUI();
    }

    // ��Ǫ��������
    public void TakeDamage(int damage)
    {

    }

    // ���`��k
    public void Dead()
    {
        DropLoot();
    }

    //�Ǫ��Q�P��
    void OnDestroy()
    {
        Debug.Log(gameObject.name + " �w�g���`");
        Debug.Log("�Ǫ��Q�i�P���j�A�ثe�`�ơG" + (CrowdManager.monsters.Count));
    }

    // �������~��k
    public void DropLoot()
    {
        foreach (LootData loot in objectData.lootTable)
        {
            int roll = Random.Range(0, 100);
            if (Random.value < loot.dropChance)
            {
                Instantiate(loot.item, transform.position, Quaternion.identity);
            }
        }
    }

    // ��ܶˮ`�ƭȪ���k
    public void DamagePopup(GameObject enemy, int damageAmount)
    {
        GameObject popupInstance = Instantiate(damagePopupPrefab, enemy.transform.position, Quaternion.identity);
        DamagePopup damagePopup = popupInstance.GetComponent<DamagePopup>();
        if (damagePopup != null)
        {
            damagePopup.Setup(damageAmount);
        }
    }

    // ��l�Ƥ�k�A�i�H�b�l���O���мg
    public virtual void Initialize()
    {

    }

    // �������󪺪��A
    public void ObjectStateSwitch()
    {
        switch (objectData.objectState)
        {
            case ObjectState.Guard:
                break;
            case ObjectState.Patrol:
                break;
            case ObjectState.Dead:
                break;
        }
        UpdateUI();
    }


    // ��sUI����k�A�i�H�b�l���O���мg
    public virtual void UpdateUI()
    {

    }

}
