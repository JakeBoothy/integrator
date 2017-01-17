using UnityEngine;
using System.Collections;
using System;

[ExecuteInEditMode]
public class orbitObject : MonoBehaviour
{

    public bool forcing;
    public double mu;

    [SerializeField]
    private double3 _pos;
    [SerializeField]
    public double3 pos
    {
        get
        {
            return _pos;
        }
        set
        {
            if (value != _pos)
            {
                _pos = value;
                path.posPath[0] = _pos;
            }
        }
    }
    [SerializeField]
    private double3 _vel;
    [SerializeField]
    public double3 vel
    {
        get
        {
            return _vel;
        }
        set
        {
            if (value != _vel)
            {
                _vel = value;
                path.velPath[0] = _vel;
            }
        }
    }
    private orbitPath _path;
    public orbitPath path
    {
        get
        {
            return _path;
        }
        set
        {
            _path = value;
            /*lineRenderer.SetVertexCount(_path.pathLength);
            for (int i = 0; i < _path.pathLength; i++)
            {
                lineRenderer.SetPosition(i, _path.posPath[i]);
            }*/
        }
    }
    public float pathResolution;
    public orbitObject[] forcingObj;
    public LineRenderer lineRenderer;
    /*public void smallObjectConstructor(double _x, double _y, double _z, double _vX, double _vY, double _vZ, bigObject[] _forcingObj)
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
    }*/

    void Start()
    {
        _pos = Vector3.right * 10;
        _vel = Vector3.up;
        pathResolution = 0.1f;
        forcingObj = World.Instance.GetForcingObjects(this);
        if (!lineRenderer)
        {
            lineRenderer = gameObject.AddComponent<LineRenderer>();
            lineRenderer.SetWidth(0.1f, 0.1f);
        }
        path = new orbitPath(pos, vel);

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawRay(pos, vel);
        if (forcing)
        {
            Gizmos.DrawSphere(pos, 1f);
        }
        else
        {
            Gizmos.DrawSphere(pos, 0.1f);
        }
    }

    public void updatePath()
    {
        lineRenderer.SetVertexCount(_path.pathLength);
        for (int i = 0; i < _path.pathLength; i++)
        {
            lineRenderer.SetPosition(i, _path.posPath[i]);
        }
    }
}
