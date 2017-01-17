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

    public static double3 accel(double3 pos, orbitObject[] b)
    {
        //calculates the acceleration acting on smallobject a from bigobjects b 
        double3 accel = new double3();
        for (int i = 0; i < b.Length; i++)
        {
            double3 bPos = b[i].path.posPath[b[i].path.pathLength-1];
            accel += -b[i].mu * distance(pos,bPos) / (Math.Pow(mag(distance(pos,  bPos)), 3));
        }
        return accel;
    }

    /*public static orbitPath integrate(smallObject obj)
    {
        orbitPath p = obj.path;
        for (int i = 1; i < obj.pathLength; i++)
        {
            p.posPath[i] = p.posPath[i - 1] + p.velPath[i - 1] * obj.pathResolution;
            p.velPath[i] = p.velPath[i - 1] + accel(p.posPath[i], World.Instance.bigObjects);
        }
        return p;
    }*/

    public static void integrate(orbitObject[] objs, double targetTime)
    {
        int numOfObjs = objs.Length;
        float[] currentIntegrationTime = new float[numOfObjs];
        orbitPath[] paths = new orbitPath[numOfObjs];
        for (int i = 0; i < numOfObjs; i++)
        {
            paths[i] = new orbitPath(objs[i].pos, objs[i].vel);
            objs[i].forcingObj = World.Instance.GetForcingObjects(objs[i]);
        }

        float globalTime = 0;
        while (globalTime < targetTime)
        {
            //While we aren't at our target time
            for (int i = 0; i < numOfObjs; i++)
            {
                //Go through each object
                if (i < objs.Length)
                {
                    //integrate small object up to or greater than the current global time
                    orbitObject s = objs[i];
                    while (currentIntegrationTime[i] <= globalTime)
                    {
                        //if we arent at the current global time we can just integrate one more step
                        orbitPath p = paths[i];
                        double3 newAccel = accel(p.posPath[p.pathLength - 1], s.forcingObj);
                        double3 newVel = p.velPath[p.pathLength - 1] + newAccel;
                        double3 newPos = p.posPath[p.pathLength - 1] + p.velPath[p.pathLength - 1] * s.pathResolution;
                        p.addNewPoint(newPos, newVel, newAccel);
                        currentIntegrationTime[i] += s.pathResolution;
                        paths[i] = p;
                    }
                    globalTime = currentIntegrationTime[i];
                }
            }
        }
        for (int i = 0; i < numOfObjs; i++)
        {
            if (i < objs.Length)
            {
                objs[i].path = paths[i];
                objs[i].updatePath();
            }
        }
    }
}
