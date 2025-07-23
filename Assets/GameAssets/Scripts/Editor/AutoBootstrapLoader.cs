#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

[InitializeOnLoad]
public static class AutoBootstrapLoader
{
    private const string BootstrapperScenePath = "Assets/GameAssets/Scenes/Bootstrapper.unity";
    private const string GameSceneName = "Bootstrapper";

    static AutoBootstrapLoader()
    {
        EditorApplication.playModeStateChanged += OnPlayModeChanged;
    }

    private static void OnPlayModeChanged(PlayModeStateChange state)
    {
        if (state == PlayModeStateChange.ExitingEditMode)
        {
            var activeScene = SceneManager.GetActiveScene();

            if (activeScene.name != GameSceneName)
            {
                EditorApplication.isPlaying = false;
                EditorSceneManager.OpenScene(BootstrapperScenePath, OpenSceneMode.Single);
                EditorApplication.delayCall += () => EditorApplication.isPlaying = true;
            }
        }
    }
}
#endif
