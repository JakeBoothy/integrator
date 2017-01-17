using UnityEngine;
using System.Collections;
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
    public bigObject[] bigObjects = new bigObject[0];
    public smallObject[] smallObjects = new smallObject[0];
    public Transform bigObjectParent;
    public Transform smallObjectParent;

    void Start()
    {
        bigObjectParent = gameObject.transform.GetChild(0);
        smallObjectParent = gameObject.transform.GetChild(1);
    }

    void Update()
    {

    }

    public void addBigObject()
    {
        bigObject [] old = bigObjects;
        GameObject g = new GameObject();
        bigObject b = g.AddComponent<bigObject>();
        g.transform.SetParent(World.Instance.bigObjectParent);
        bigObjects = new bigObject[old.Length + 1];
        for (int i = 0; i < old.Length + 1; i++)
        {
            if (i < old.Length)
            {
                bigObjects[i] = old[i];
            }
            else
            {
                bigObjects[i] = b;
            }
        }
    }

    public void removeBigObject(int a)
    {
        bigObject[] old = bigObjects;
        
        if (old.Length > 0)
        {
            bigObjects = new bigObject[old.Length - 1];
            DestroyImmediate(old[a-1].gameObject);
            for (int i = 0; i < old.Length - 1; i++)
            {
                if (i < a)
                {
                    bigObjects[i] = old[i];
                }
                else
                {
                    bigObjects[i - 1] = old[i];
                }
            }
        }
    }

    public smallObject addSmallObject()
    {
        smallObject[] old = smallObjects;
        GameObject g = new GameObject();
        smallObject s = g.AddComponent<smallObject>();
        g.transform.SetParent(World.Instance.smallObjectParent);
        smallObjects = new smallObject[old.Length + 1];
        for (int i = 0; i < old.Length + 1; i++)
        {
            if (i < old.Length)
            {
                smallObjects[i] = old[i];
            }
            else
            {
                smallObjects[i] = s;
            }
        }
        return s;
    }

    public void removeSmallObject(int a)
    {
        if (a >= 0)
        {
            smallObject[] old = smallObjects;
            if (old.Length > 0)
            {
                DestroyImmediate(old[a - 1].gameObject);
                smallObjects = new smallObject[old.Length - 1];
                for (int i = 0; i < old.Length - 1; i++)
                {
                    if (i < a)
                    {
                        smallObjects[i] = old[i];
                    }
                    else
                    {
                        smallObjects[i - 1] = old[i];
                    }
                }
            }
        }
    }

    public void simulate()
    {
        double t1 = EditorApplication.timeSinceStartup;
       
        for (int i = 0; i < smallObjects.Length; i++)
        {
            smallObjects[i].path = pathCalculate.integrate(smallObjects[i]);
        }
        Debug.Log("Time to execute: " + (EditorApplication.timeSinceStartup - t1) * 1000 + "ms");
    }

}
