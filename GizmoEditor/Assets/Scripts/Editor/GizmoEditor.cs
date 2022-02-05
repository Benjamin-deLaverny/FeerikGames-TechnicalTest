using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

using technical.test.editor;

public class GizmoEditor : EditorWindow
{
    private SceneGizmoAsset gizmoAsset = null;
    public List<GameObject> spheres = new List<GameObject>();

    [MenuItem("Window/Custom/Show Gizmos in Scene")]
    public static void openWindow(){
        GizmoEditor gizmoEditor = EditorWindow.GetWindow<GizmoEditor>("Gizmo Editor");
        SceneGizmoAsset asset = (SceneGizmoAsset)AssetDatabase.LoadAssetAtPath("Assets/Data/Editor/Scene Gizmo Asset.asset", typeof(SceneGizmoAsset));
        gizmoEditor.gizmoAsset = asset;
        gizmoEditor.displayGizmos();

    } 

    private void displayGizmos(){
        if(spheres.Count == 0){
            foreach(Gizmo gizmo in gizmoAsset._gizmos){
                GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                sphere.transform.position = new Vector3(gizmo.Position.x, gizmo.Position.y, gizmo.Position.z);
                sphere.name = gizmo.Name;
                spheres.Add(sphere);
            }
        }
    }

    private void moveSphere(int id, SceneGizmoAsset gizmoAsset){
        Vector3 position = new Vector3(gizmoAsset._gizmos[id].Position.x, gizmoAsset._gizmos[id].Position.y, gizmoAsset._gizmos[id].Position.z);
        spheres[id].transform.position = position;
    }

    private void OnGUI(){
        if(gizmoAsset != null){
            int i = 0;
            GUI.Label(new Rect(30,5,100,20),"Text");
            GUI.Label(new Rect(250,5,100,20),"Position");
            for(int cpt = 0; cpt<gizmoAsset._gizmos.Length; cpt++){
                gizmoAsset._gizmos[cpt].Name = GUI.TextArea (new Rect (10,40+i,80,20), gizmoAsset._gizmos[cpt].Name, 200);
                GUI.Label(new Rect (100,40+i,80,20),"x"); 
                gizmoAsset._gizmos[cpt].Position.x = float.Parse(GUI.TextArea (new Rect (120,40+i,80,20), gizmoAsset._gizmos[cpt].Position.x.ToString(), 200));
                GUI.Label(new Rect (210,40+i,80,20),"y");
                gizmoAsset._gizmos[cpt].Position.y = float.Parse(GUI.TextArea (new Rect (230,40+i,80,20), gizmoAsset._gizmos[cpt].Position.y.ToString(), 200));
                GUI.Label(new Rect (320,40+i,80,20),"z");
                gizmoAsset._gizmos[cpt].Position.z = float.Parse(GUI.TextArea (new Rect (340,40+i,80,20), gizmoAsset._gizmos[cpt].Position.z.ToString(), 200));
                if(GUI.Button(new Rect (440,40+i,80,20),"Edit")){
                    moveSphere(cpt,gizmoAsset);
                }
                i+=25;
            }
        }
    }

    void Update(){
        for(int i = 0; i<spheres.Count; i++){
            if(spheres[i].transform.hasChanged){
                gizmoAsset._gizmos[i].Position = spheres[i].transform.position;
                spheres[i].transform.hasChanged = false;
            }
        }
    }

    void OnDestroy()
    {
        foreach(GameObject sphere in spheres){
            DestroyImmediate(sphere);
        }
    }
}
