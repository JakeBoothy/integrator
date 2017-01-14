using UnityEngine;
using System.Collections;
using System;

[Serializable]
public struct orbitPath
{
    public int pathlength;
    public double3[] acclPath;
    public double3[] velPath;
    public double3[] posPath;

    public orbitPath(int length)
    {
        pathlength = length;
        acclPath = new double3[length];
        velPath = new double3[length];
        posPath = new double3[length];
    }
}
