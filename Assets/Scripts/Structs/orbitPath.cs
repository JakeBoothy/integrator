using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;


[Serializable]
public struct orbitPath
{
    public int i;
    private int _pathLength;
    public int pathLength
    {
        get
        {
            return _pathLength;
        }
    }
    public List<double3> acclPath;
    public List<double3> velPath;
    public List<double3> posPath;

    public orbitPath(double3 initPos,double3 initVel)
    {
        acclPath = new List<double3>();
        velPath = new List<double3>();
        posPath = new List<double3>();
        posPath.Add(initPos);
        velPath.Add(initVel);
        _pathLength = 1;
        i = 0;
    }

    public void addNewPoint(double3 pos, double3 vel, double3 accel)
    {
        posPath.Add(pos);
        velPath.Add(vel);
        acclPath.Add(accel);
        _pathLength = _pathLength + 1;
        i++;
    }

    
}
