using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

using technical.test.editor;

[CustomEditor(typeof(SceneGizmoAsset))]
public class ManageClick : Editor
{
    private bool toOpen = true;

    void OnEnable()
    {
        if(toOpen){
            open();
            toOpen = false;
        }
    }
    
    void OnDisable()
    {
        toOpen = true;
    }

    static void open () {
        GizmoEditor gizmoEditor = EditorWindow.GetWindow<GizmoEditor>("Gizmo Editor");
        SceneGizmoAsset asset = (SceneGizmoAsset)AssetDatabase.LoadAssetAtPath("Assets/Data/Editor/Scene Gizmo Asset.asset", typeof(SceneGizmoAsset));
        gizmoEditor.gizmoAsset = asset;
        gizmoEditor.displayGizmos();

    }
}
