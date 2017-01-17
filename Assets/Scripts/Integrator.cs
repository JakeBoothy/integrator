using UnityEngine;
using System.Collections;
using System;

/*public class Integrator : MonoBehaviour {

    //public Vector4[] bigObjects;//x,y,z,mu
    //bigObject[] world = new bigObject[2];
    public Gradient g;
    public smallObject test;
    public LineRenderer p;
    public GameObject empty;
    // Use this for initialization
    void Start () {
       
        //test = World.Instance.addSmallObject(new smallObject(1, 1, 1, 1, 0, 0, World.Instance.bigObjects));
        p = gameObject.AddComponent<LineRenderer>();
        for (int i = 0; i < World.Instance.bigObjects.Length; i++)
        {
            GameObject a = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            a.GetComponent<Renderer>().material.color = Color.blue;
            a.transform.position = World.Instance.bigObjects[i].pos;
        }
        //test = World.Instance.smallObjects[0];
        
    }

    // Update is called once per frame
    void Update () {
        test.pos = empty.transform.position;
        test.path.posPath[0] = empty.transform.position;
        orbitCalculate.integrate(test);

        
        p.SetVertexCount(test.pathLength);
        for (int i = 0; i < test.pathLength; i++)
        {
            p.SetPosition(i, test.path.posPath[i]);
            
        }
    }

}*/

