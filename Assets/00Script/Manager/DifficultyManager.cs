using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    // �w�q���׵���
    public enum Difficulty { Easy, Medium, Hard }

    // �x�s���e�����׵���
    public Difficulty currentDifficulty;

    // �b�C���}�l�ɳ]�w��l�����׵���
    void Awake()
    {
        // ��l�ƮɡA�C�����׳]������
        currentDifficulty = Difficulty.Easy;
        Debug.Log("�C���}�l�A��l���׳]�w���G " + currentDifficulty.ToString());
    }

    // �b�C�@�V�ե�
    void Update()
    {
        // �b�o�̥i�H�[�J�ھڹC���i�{�ܤ����ת��N�X
        // ���e�ܨҤ��]�A���\��
    }

    // �������׵��Ũýվ㪱�a�M�Ǫ����j��
    public void ChangeDifficulty(Difficulty newDifficulty)
    {
        currentDifficulty = newDifficulty;

        // �ھ����׵��Žվ㪱�a�M�Ǫ����j��
        switch (currentDifficulty)
        {
            case Difficulty.Easy:
                // ²�����פU���վ�
                // Player.Strength = easyStrength;
                // Monster.Strength = easyStrength;
                Debug.Log("���׳]�w���G " + currentDifficulty.ToString());
                break;
            case Difficulty.Medium:
                // �������פU���վ�
                // Player.Strength = mediumStrength;
                // Monster.Strength = mediumStrength;
                Debug.Log("���׳]�w���G " + currentDifficulty.ToString());
                break;
            case Difficulty.Hard:
                // �x�����פU���վ�
                // Player.Strength = hardStrength;
                // Monster.Strength = hardStrength;
                Debug.Log("���׳]�w���G " + currentDifficulty.ToString());
                break;
        }
    }
}
