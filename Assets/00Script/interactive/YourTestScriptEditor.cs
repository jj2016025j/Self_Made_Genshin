using UnityEditor;
using UnityEngine;

//GUI
[CustomEditor(typeof(YourTestScript))] // 要在Inspector中自定義的腳本名稱
public class YourTestScriptEditor : Editor
{
    public override void OnInspectorGUI()
    {
        YourTestScript script = (YourTestScript)target;

        // 加入一個按鈕，點擊後呼叫YourTestScript的某個方法
        if (GUILayout.Button("Run Test"))
        {
            script.RunTest();
        }

        DrawDefaultInspector(); // 繼續顯示原本的Inspector內容
    }
}
