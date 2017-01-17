using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

[ExecuteInEditMode]
public class World : MonoBehaviour {

    private static World _instance;

    public static World Instance {
        get
        {
            if (_instance == null)
            {
                _instance = (World)FindObjectOfType(typeof(World));
            }
            return _instance;
        }
    }
    public List<orbitObject> objects = new List<orbitObject>();
    public Transform bigObjectParent;
    public Transform smallObjectParent;

    void Start()
    {
        bigObjectParent = gameObject.transform.GetChild(0);
        smallObjectParent = gameObject.transform.GetChild(1);
    }

    public void addNewObj(bool forcing)
    {
        GameObject g = new GameObject();
        if (forcing)
        {
            g.transform.SetParent(bigObjectParent);
        }
        else
        {
            g.transform.SetParent(smallObjectParent);
        }
        orbitObject o = g.AddComponent<orbitObject>();
        o.forcing = forcing;
        o.mu = 1;
        objects.Add(o);
    }

    public void simulate()
    {
        double t1 = EditorApplication.timeSinceStartup;

        pathCalculate.integrate(objects.ToArray(), 100d);
        
        Debug.Log("Time to execute: " + (EditorApplication.timeSinceStartup - t1) * 1000 + "ms");
    }

    public orbitObject[] GetForcingObjects(orbitObject b)
    {
        List<orbitObject> bigObjs = new List<orbitObject>();
        for (int i = 0; i < objects.Count; i++)
        {
            if (objects[i].forcing && objects[i] != b)
            {
                bigObjs.Add(objects[i]);
            }
        }
        return bigObjs.ToArray();
    }
}
