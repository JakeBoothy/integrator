using UnityEngine;
using System.Collections;
using System;

public class bigObject : MonoBehaviour
{
    public double3 pos;
    public double3 vel;
    public double mu;
    public orbitPath path;
    public float pathResolution;
    public int pathLength;
    public bigObject[] forcingObj;

    public void bigObjectConstructor(double _x, double _y, double _z, double _vX, double _vY, double _vZ, double _mu)
    {
        pos.x = _x;
        pos.y = _y;
        pos.z = _z;
        vel.x = _vX;
        vel.y = _vY;
        vel.z = _vZ;
        mu = _mu;
        pathResolution = 1f;//once per second
        pathLength = 500;//500 * 1 seconds
        path = new orbitPath(pathLength);
    }

    void Start()
    {
        pos = new Vector3();
        vel = new Vector3();
        pathLength = 500;
        mu = 1;
        path = new orbitPath(pathLength);
        forcingObj = World.Instance.bigObjects;
    }
}