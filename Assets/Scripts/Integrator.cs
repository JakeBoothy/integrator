using UnityEngine;
using System.Collections;
using System;

public class Integrator : MonoBehaviour {

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
        //Debug.Log(World.Instance.bigObjects.Length);
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

}

public static class orbitCalculate
{

    public const double G = 6.67408E-11;
    public static double3 distance(double3 a, double3 b)
    {
        //returns the distance between two objects
        //double d = Math.Sqrt(Math.Pow((a.x - b.x),2)  + Math.Pow((a.y - b.y), 2) + Math.Pow((a.z - b.z), 2));
        return (a - b);
    }

    public static double mag(double3 a)
    {
        //returns magnitude of a double3
        return Math.Sqrt(Math.Pow(a.x,2) + Math.Pow(a.y, 2) + Math.Pow(a.z, 2));
    }

    public static double3 accel(smallObject a, bigObject[] b)
    {
        //calculates the acceleration acting on smallobject a from bigobjects b 
        double3 accel = new double3();
        for (int i = 0; i < b.Length; i++)
        {
            accel += -b[i].mu*distance(a.pos,b[i].pos)/(Math.Pow(mag(distance(a.pos,b[i].pos)),3));
        }
        return accel;
    }

    public static void integrate(smallObject obj)
    {
        for (int i = 1; i < obj.pathLength; i++)
        {
            obj.path.posPath[i] = obj.path.posPath[i - 1] + obj.path.velPath[i - 1] * obj.pathResolution;
            obj.path.velPath[i] = obj.path.velPath[i - 1] + orbitCalculate.accel(obj, obj.forcingObj);
            obj.pos = obj.path.posPath[i];
            obj.vel = obj.path.velPath[i];
        }
    }
}



