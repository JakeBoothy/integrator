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
            World.Instance.addBigObject();
        }
        else if (GUILayout.Button("Remove Big Object"))
        {
            World.Instance.removeBigObject(World.Instance.bigObjects.Length);
        }
        EditorGUILayout.EndHorizontal();
        bigObject[] b = World.Instance.bigObjects;
        for (int i = 0; i < b.Length; i++)
        {
            GUILayout.BeginHorizontal();
            b[i].pos = EditorGUILayout.Vector3Field("Pos", b[i].pos);
            b[i].vel = EditorGUILayout.Vector3Field("Vel", b[i].vel);
            GUILayout.EndHorizontal();
            EditorGUILayout.EndFadeGroup();
        }

        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("Add small Object"))
        {
            World.Instance.addSmallObject();
        }
        else if (GUILayout.Button("Remove small Object"))
        {
            World.Instance.removeSmallObject(World.Instance.smallObjects.Length);
        }
        EditorGUILayout.EndHorizontal();

        smallObject[] s = World.Instance.smallObjects;
        for (int i = 0; i < s.Length; i++)
        {
            GUILayout.BeginHorizontal();
            s[i].pos = EditorGUILayout.Vector3Field("Pos", s[i].pos);
            s[i].vel = EditorGUILayout.Vector3Field("Vel", s[i].vel);
            GUILayout.EndHorizontal();
        }

        if (GUILayout.Button("Calculate Paths"))
        {
            World.Instance.simulate();
        }

        EditorGUILayout.EndVertical();

    }


}
