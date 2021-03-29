using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CustomEditorWindow : EditorWindow
{
    static CustomEditorWindow instance;
    UnityEngine.SceneManagement.Scene currentScene;

    bool hasData = false;
    int meshCount = -1;

    [MenuItem("Tools/Custom/Custom Editor Window")]
    
    static void Init()//public static void CreateWindow()
    {
        instance = EditorWindow.GetWindow<CustomEditorWindow>();
        instance.Show();
    }

    private void OnGUI()
    {
        //Display a count of mesh renderers in the current scene, from class lecture
        GUILayout.Label("Counting Section", EditorStyles.boldLabel);

        currentScene = UnityEditor.SceneManagement.EditorSceneManager.GetActiveScene();
        GUILayout.Space(15);
        GUILayout.Label("Active Scene: " + currentScene.name);

        if(GUILayout.Button("Count"))
        {
            DoCount();
        }

        if(hasData)
        {
            GUILayout.Label("Mesh Renderer Count: " + meshCount);
        }

        GUILayout.Space(15);

        //Clone the current selection
        GUILayout.Label("Clone Selection Section", EditorStyles.boldLabel);

        if(GUILayout.Button("Clone Selection"))
        {
            DoClone(Selection.activeGameObject);
        }

        GUILayout.Space(15);

        //Apply a random color to the current selection
        GUILayout.Label("Randomize Color Section", EditorStyles.boldLabel);

        if(GUILayout.Button("Randomize Selected Color"))
        {
            DoRandomizeColor(Selection.activeGameObject);
        }

        GUILayout.Space(15);

        //Resize the current selection
        // This code doesn't work, however when placed in it's own window/file it does
        //  which is the same issue I had with EditorGUILayout.Slider
        GUILayout.Label("Resize Current Selection", EditorStyles.boldLabel);
        float sizeMultiplier2 = 1.0f;
        sizeMultiplier2 = EditorGUILayout.FloatField("Increase scale by: ", sizeMultiplier2);

        if(GUILayout.Button("Resize"))
        {
            Selection.activeTransform.localScale *= sizeMultiplier2;
        }      
    }

    private void DoCount()
    {
        meshCount = 0;
        hasData = true;

        foreach(GameObject go in currentScene.GetRootGameObjects())
        {
            CheckForMesh(go);
        }
    }

    private void CheckForMesh(GameObject go)
    {
        meshCount += go.GetComponentsInChildren<MeshRenderer>().Length;
        meshCount += go.GetComponents<MeshRenderer>().Length;
    }

    private void DoClone(GameObject selectedObject)
    {
        //Clone current selection
        GameObject clonedObject = Instantiate(selectedObject, new Vector3(selectedObject.transform.position.x + 2.0F, selectedObject.transform.position.y, selectedObject.transform.position.z), Quaternion.identity);
    }

    private void DoRandomizeColor(GameObject selectedObject)
    {
        //Randomize color of current selection
        Renderer objectRenderer;
        Color[] colorArray = {Color.red, Color.blue, Color.cyan, Color.magenta, Color.yellow, Color.black};
        objectRenderer = selectedObject.GetComponent<Renderer>();
        var tempMaterial = new Material(objectRenderer.sharedMaterial);
        tempMaterial.color = colorArray[Random.Range(0,colorArray.Length)];
        objectRenderer.sharedMaterial = tempMaterial;
    }
}
