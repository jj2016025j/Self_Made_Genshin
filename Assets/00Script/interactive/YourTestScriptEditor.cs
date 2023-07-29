using UnityEditor;
using UnityEngine;

//GUI
[CustomEditor(typeof(YourTestScript))] // �n�bInspector���۩w�q���}���W��
public class YourTestScriptEditor : Editor
{
    public override void OnInspectorGUI()
    {
        YourTestScript script = (YourTestScript)target;

        // �[�J�@�ӫ��s�A�I����I�sYourTestScript���Y�Ӥ�k
        if (GUILayout.Button("Run Test"))
        {
            script.RunTest();
        }

        DrawDefaultInspector(); // �~����ܭ쥻��Inspector���e
    }
}
