using UnityEditor;
using UnityEngine;

public class EditorGUILayoutSlider : EditorWindow
{
    static float scale = 0.0f;

    [MenuItem("Examples/Editor GUILayout Slider usage")]
    static void Init()
    {
        EditorWindow window = GetWindow(typeof(EditorGUILayoutSlider));
        window.Show();
    }

    void OnGUI()
    {
        scale = EditorGUILayout.Slider(scale, 1, 10);
    }

    void OnInspectorUpdate()
    {
        if (Selection.activeTransform)
            Selection.activeTransform.localScale = new Vector3(scale, scale, scale);
    }
}