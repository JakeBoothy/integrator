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
            World.Instance.addBigObject(new bigObject());
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
            GUILayout.EndHorizontal();
        }



        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("Add small Object"))
        {
            World.Instance.addSmallObject(new smallObject());
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
            if (GUILayout.Button("Calculate Orbit"))
            {
                s[i].
            }
            s[i].pos = EditorGUILayout.Vector3Field("Pos", s[i].pos);
            GUILayout.EndHorizontal();
        }


        EditorGUILayout.EndVertical();
    }
}
