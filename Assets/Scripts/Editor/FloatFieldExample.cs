using UnityEngine;
using UnityEditor;

// Editor Script that multiplies the scale of the current selected GameObject

public class FloatFieldExample : EditorWindow
{
    float sizeMultiplier = 1.0f;

    [MenuItem("Tools/Custom/Scale selected Object")]
    static void Init()
    {
        var window = (FloatFieldExample)GetWindow(typeof(FloatFieldExample));
        window.Show();
    }

    void OnGUI()
    {
        sizeMultiplier = EditorGUILayout.FloatField("Increase scale by:", sizeMultiplier);

        if (GUILayout.Button("Scale"))
        {
            if (!Selection.activeGameObject)
            {
                Debug.Log("Select a GameObject first");
                return;
            }

            Selection.activeTransform.localScale *= sizeMultiplier;
        }
    }
}