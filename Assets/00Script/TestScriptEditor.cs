using UnityEditor;
using UnityEngine;

//GUI �����쪫��W �]�w������ե\��
[CustomEditor(typeof(TestScript))] // �n�bInspector���۩w�q���}���W��
public class TestScriptEditor : Editor
{
    public override void OnInspectorGUI()
    {
        TestScript script = (TestScript)target;

        // �[�J�@�ӫ��s�A�I����I�sYourTestScript���Y�Ӥ�k
        if (GUILayout.Button("Clean All Monster"))
        {
            script.CleanAllMonster();
        }

        // �[�J�t�@�ӫ��s�A�I����I�sYourTestScript���t�@�Ӥ�k
        if (GUILayout.Button("Random Monster Die"))
        {
            script.MonsterDie();
        }

        // �[�J�t�@�ӫ��s�A�I����I�sYourTestScript���t�@�Ӥ�k
        if (GUILayout.Button("���s����"))
        {
            script.TeleportPlayer();
        }
        // �[�J�@�ӷƶ��A�Ψӽվ�YourTestScript�����@�Ӽƭ�
        //script.someValue = EditorGUILayout.Slider("Some Value", script.someValue, 0f, 1f);

        DrawDefaultInspector(); // �~����ܭ쥻��Inspector���e
    }
}
