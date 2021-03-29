using UnityEditor;
using UnityEngine;

public class EditorGUILayoutSlider : EditorWindow
{
    static float scale = 0.0f;

    [MenuItem("Tools/Custom/Custom Object Scale")]
    static void Init()
    {
        EditorWindow window = GetWindow(typeof(EditorGUILayoutSlider));
        window.Show();
    }

    void OnGUI()
    {
        GameObject selectedObject = Selection.activeGameObject;
        float currentX = selectedObject.transform.localScale.x;
        float currentY = selectedObject.transform.localScale.y;
        float currentZ = selectedObject.transform.localScale.z;
        float scaleX = EditorGUILayout.Slider("X Scale", currentX, 1, 10);
        float scaleY = EditorGUILayout.Slider("Y Scale", currentY, 1, 10);
        float scaleZ = EditorGUILayout.Slider("Z Scale", currentZ, 1, 10);
    }

    void OnInspectorUpdate()
    {
        if (Selection.activeTransform)
            Selection.activeTransform.localScale = new Vector3(scale, scale, scale);
    }
}