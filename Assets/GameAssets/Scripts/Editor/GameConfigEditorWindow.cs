using UnityEditor;
using UnityEngine;

public class GameConfigEditorWindow : EditorWindow
{
    private GameConfig config;
    private const string CONFIG_PATH = "Assets/GameAssets/Resources/GameConfig.asset";
    // Ctrl + T
    [MenuItem("Tools/Game Config %t")] 
    public static void ShowWindow()
    {
        var window = GetWindow<GameConfigEditorWindow>("Game Config");
        window.Show();
    }

    private void OnEnable()
    {
        config = AssetDatabase.LoadAssetAtPath<GameConfig>(CONFIG_PATH);
    }

    private void OnGUI()
    {
        if (config == null)
        {
            EditorGUILayout.HelpBox("GameConfig Not Found.", MessageType.Error);
            if (GUILayout.Button("TRY AGAIN"))
            {
                OnEnable();
            }
            return;
        }

        SerializedObject so = new SerializedObject(config);
        so.Update();
        SerializedProperty prop = so.GetIterator();

        prop.NextVisible(true);

        while (prop.NextVisible(false))
        {
            EditorGUILayout.PropertyField(prop, true);
        }

        so.ApplyModifiedProperties();
    }
}
