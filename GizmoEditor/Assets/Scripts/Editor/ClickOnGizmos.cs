using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.EventSystems;

using technical.test.editor;

[CustomEditor(typeof(GameObject))]
public class ClickOnGizmos : Editor
{
    private static List<Vector3> originalPos;
    private static bool checkGizmo = false;
    private static GameObject selected = null;

    void OnEnable()
    {
        originalPos = new List<Vector3>();
        originalPos.Add(new Vector3((float)-0.076,(float)1.65,(float)0.038));
        originalPos.Add(new Vector3(-15,2,-1));
        originalPos.Add(new Vector3((float)-6.425,1,(float)-0.3));
        originalPos.Add(new Vector3((float)-10.06,2,(float)-0.53));
        originalPos.Add(new Vector3((float)-13.68,(float)1.921,-1));

        SceneView.duringSceneGui += OnSceneGUI;
        if(target.name != null && isAGizmo(target.name)){
            checkGizmo = true;
            selected = (GameObject)target;
        } 
    }

    private bool isAGizmo(string name){
        SceneGizmoAsset asset = (SceneGizmoAsset)AssetDatabase.LoadAssetAtPath("Assets/Data/Editor/Scene Gizmo Asset.asset", typeof(SceneGizmoAsset));
        bool res = false;
        foreach(Gizmo gizmo in asset._gizmos){
            if(gizmo.Name == name) res = true;
        }
        return res;
    }

    void OnDisable(){
        SceneView.duringSceneGui -= OnSceneGUI;
        checkGizmo = false;
    }

    static void OnSceneGUI(SceneView scene){
        Event e = Event.current;
        if (checkGizmo && e.type == EventType.MouseUp && e.button == 1){
            GenericMenu menu = new GenericMenu();
            menu.AddItem(new GUIContent("Reset"), false, Reset, 1);
            menu.AddItem(new GUIContent("Delete"), false, Delete, 2);
            menu.ShowAsContext(); 
        }
    }

    static void Reset(object obj){
        SceneGizmoAsset asset = (SceneGizmoAsset)AssetDatabase.LoadAssetAtPath("Assets/Data/Editor/Scene Gizmo Asset.asset", typeof(SceneGizmoAsset));
        for(int i = 0 ; i<5 ; i++){
            if(selected.name == asset._gizmos[i].Name){
                selected.transform.position = originalPos[i];
            }
        }
    }

    static void Delete(object obj){
         DestroyImmediate(selected);
         selected = null;
    }
}
