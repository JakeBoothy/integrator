using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(World))]
public class WorldEditor : Editor
{
    public override void OnInspectorGUI()
    {
        EditorGUILayout.BeginVertical();
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("Add Big Object"))
        {
            World.Instance.addNewObj(true);
        }

        EditorGUILayout.EndHorizontal();
        

        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("Add small Object"))
        {
            World.Instance.addNewObj(false);
        }
        
        EditorGUILayout.EndHorizontal();
        orbitObject[] orbs = World.Instance.objects.ToArray();
        for (int i = 0; i < orbs.Length; i++)
        {
            GUILayout.BeginHorizontal();
            GUILayout.Toggle(orbs[i].forcing, "Forcing: ");
            if (GUILayout.Button("Remove Object"))
            {
                DestroyImmediate(orbs[i].gameObject);
                World.Instance.objects.RemoveAt(i);
            }
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
            orbs[i].pos = EditorGUILayout.Vector3Field("Pos", orbs[i].pos);
            orbs[i].vel = EditorGUILayout.Vector3Field("Vel", orbs[i].vel);
            GUILayout.EndHorizontal();
            EditorGUILayout.EndFadeGroup();
        }

        if (GUILayout.Button("Calculate Paths"))
        {
            World.Instance.simulate();
        }

        EditorGUILayout.EndVertical();

    }


}
