using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

using technical.test.editor;

public class GizmoEditor : EditorWindow
{
    private SceneGizmoAsset gizmoAsset = null;

    [MenuItem("Window/Custom/Show Gizmos in Scene")]
    public static GizmoEditor openWindow(){
        return EditorWindow.GetWindow<GizmoEditor>("Gizmo Editor");
    }    

    [UnityEditor.Callbacks.OnOpenAsset(1)]
    public static bool openGizmoAsset(int id, int line){
        SceneGizmoAsset asset = EditorUtility.InstanceIDToObject(id) as SceneGizmoAsset;
        if(asset != null){
            GizmoEditor gizmoEditor = openWindow();
            gizmoEditor.gizmoAsset = asset;
            return true;
        }
        return false;
    }

    private void OnGUI(){
        if(gizmoAsset != null){
            int i = 0;
            foreach(var gizmo in gizmoAsset._gizmos){
                GUI.Label(new Rect(10,10+i,100,20),gizmo.Name);
                i+=20;
            }
        }
    }
}
