using UnityEngine;
using System.Collections;
using System;

public static class pathCalculate
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
        return Math.Sqrt(Math.Pow(a.x, 2) + Math.Pow(a.y, 2) + Math.Pow(a.z, 2));
    }

    public static double3 accel(double3 pos, bigObject[] b)
    {
        //calculates the acceleration acting on smallobject a from bigobjects b 
        double3 accel = new double3();
        for (int i = 0; i < b.Length; i++)
        {
            accel += -b[i].mu * distance(pos, b[i].pos) / (Math.Pow(mag(distance(pos, b[i].pos)), 3));
        }
        return accel;
    }

    public static orbitPath integrate(smallObject obj)
    {
        orbitPath p = obj.path;
        for (int i = 1; i < obj.pathLength; i++)
        {
            p.posPath[i] = p.posPath[i - 1] + p.velPath[i - 1] * obj.pathResolution;
            p.velPath[i] = p.velPath[i - 1] + accel(p.posPath[i], World.Instance.bigObjects);
        }
        return p;
    }

    public static void integrate(smallObject[] objs, bigObject[] bigObjs)
    {
        
    }
}
