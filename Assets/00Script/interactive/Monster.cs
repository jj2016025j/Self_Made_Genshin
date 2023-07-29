using UnityEngine;
using UnityEngine.Localization.SmartFormat.PersistentVariables;
using UnityEngine.SceneManagement;

public class Monster : MonoBehaviour
{
    public int health;  // �Ǫ����ͩR��
    public int attackPower;  // �Ǫ��������O


    void Start()
    {
        SceneManager sceneManager = FindObjectOfType<SceneManager>();
        Debug.Log("�Ǫ��Q�ЫءA�ثe�`�ơG" + sceneManager.Monsters);
    }

    void OnDestroy()
    {
        SceneManager sceneManager = FindObjectOfType<SceneManager>();
        Debug.Log("�Ǫ��Q�P���A�ثe�`�ơG" + sceneManager.Monsters);
    }


    // �Ǫ���s
    void Update()
    {
        // ��s�Ǫ����欰�Ϊ��A
    }

    /*public override void Initialize()
    {
        base.Initialize();
        //��q
        maxHealth = 100;
        currentMaxHealth = 100;
        currentHealth = 100;
        //�^�_
        baseHealthRestore = 1;
        currentHealthRestore = 1;
        //���m
        baseDefense = 10;
        currentDefense = 10;

        //����
        baseDamage = 10;
        currentDamage = 10;
        //��L
        attackRange = 10;
        criticalMultiplier = 50;//�z���[��
        criticalChance = 10;//�z�����v
        variable = 1;//Balance
        name = "NO." + Random.Range(0, 100).ToString() + " Slime";
    }*/

    // �Ǫ��������
    public void TakeDamage(int damage)
    {
        // �B�z�Ǫ���������ɪ��欰
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    // �Ǫ�����
    public void Attack()
    {
        // �B�z�Ǫ��i������ɪ��欰
    }

    // �Ǫ����`
    private void Die()
    {
        // �B�z�Ǫ����`�ɪ��欰
        Destroy(gameObject);
    }
}
