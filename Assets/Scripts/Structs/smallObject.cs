using UnityEngine;
using System.Collections;
using System;

public class smallObject : MonoBehaviour
{
    public double3 pos;
    public double3 vel;
    public orbitPath path;
    public float pathResolution;
    public int pathLength;
    public bigObject[] forcingObj;

    public void smallObjectConstructor(double _x, double _y, double _z, double _vX, double _vY, double _vZ, bigObject[] _forcingObj)
    {
        pos.x = _x;
        pos.y = _y;
        pos.z = _z;
        vel.x = _vX;
        vel.y = _vY;
        vel.z = _vZ;
        pathResolution = 1f;//once per second
        pathLength = 500;//500 * 1 seconds
        path = new orbitPath(pathLength);
        path.posPath[0] = pos;
        path.velPath[0] = vel;
        forcingObj = _forcingObj;
    }

    void Start()
    {
        pos = new Vector3();
        vel = new Vector3();
        pathLength = 500;
        path = new orbitPath(pathLength);
        forcingObj = World.Instance.bigObjects;

    }
}
