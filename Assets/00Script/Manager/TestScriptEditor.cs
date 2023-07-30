using UnityEditor;
using UnityEngine;

//GUI 不能放到物件上 設定按鍵測試功能
[CustomEditor(typeof(TestScript))] // 要在Inspector中自定義的腳本名稱
public class TestScriptEditor : Editor
{
    public override void OnInspectorGUI()
    {
        TestScript script = (TestScript)target;

        // 加入一個按鈕，點擊後呼叫YourTestScript的某個方法
        if (GUILayout.Button("Clean All Monster"))
        {
            script.CleanAllMonster();
        }

        // 加入另一個按鈕，點擊後呼叫YourTestScript的另一個方法
        if (GUILayout.Button("Random Monster Die"))
        {
            script.MonsterDie();
        }

        // 加入另一個按鈕，點擊後呼叫YourTestScript的另一個方法
        if (GUILayout.Button("重製場景"))
        {
            script.TeleportPlayer();
        }
        // 加入一個滑塊，用來調整YourTestScript中的一個數值
        //script.someValue = EditorGUILayout.Slider("Some Value", script.someValue, 0f, 1f);

        DrawDefaultInspector(); // 繼續顯示原本的Inspector內容
    }
}
