using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    // 定義難度等級
    public enum Difficulty { Easy, Medium, Hard }

    // 儲存當前的難度等級
    public Difficulty currentDifficulty;

    // 在遊戲開始時設定初始的難度等級
    void Awake()
    {
        // 初始化時，遊戲難度設為中等
        currentDifficulty = Difficulty.Easy;
        Debug.Log("遊戲開始，初始難度設定為： " + currentDifficulty.ToString());
    }

    // 在每一幀調用
    void Update()
    {
        // 在這裡可以加入根據遊戲進程變化難度的代碼
        // 當前示例不包括此功能
    }

    // 改變難度等級並調整玩家和怪物的強度
    public void ChangeDifficulty(Difficulty newDifficulty)
    {
        currentDifficulty = newDifficulty;

        // 根據難度等級調整玩家和怪物的強度
        switch (currentDifficulty)
        {
            case Difficulty.Easy:
                // 簡單難度下的調整
                // Player.Strength = easyStrength;
                // Monster.Strength = easyStrength;
                Debug.Log("難度設定為： " + currentDifficulty.ToString());
                break;
            case Difficulty.Medium:
                // 中等難度下的調整
                // Player.Strength = mediumStrength;
                // Monster.Strength = mediumStrength;
                Debug.Log("難度設定為： " + currentDifficulty.ToString());
                break;
            case Difficulty.Hard:
                // 困難難度下的調整
                // Player.Strength = hardStrength;
                // Monster.Strength = hardStrength;
                Debug.Log("難度設定為： " + currentDifficulty.ToString());
                break;
        }
    }
}
