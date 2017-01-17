/*using UnityEngine;
using System.Collections;
using System;
 

[ExecuteInEditMode]
public class bigObject : MonoBehaviour
{
    public double3 pos;
    public double3 vel;
    public double mu;
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
            }
        }
    }
    public float pathResolution;
    public bigObject[] forcingObj;
    public LineRenderer lineRenderer;

    void Start()
    {
        mu = 1;
        pos = new Vector3();
        vel = new Vector3();
        pathResolution = 0.1f;
        forcingObj = World.Instance.bigObjects;
        if (!lineRenderer)
        {
            lineRenderer = gameObject.AddComponent<LineRenderer>();
        }
        path = new orbitPath(pos,vel);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawRay(transform.position, vel);
        Gizmos.DrawSphere(pos, 1f);
    }

    public void updatePath()
    {
        lineRenderer.SetVertexCount(_path.pathLength);
        for (int i = 0; i < _path.pathLength; i++)
        {
            lineRenderer.SetPosition(i, _path.posPath[i]);
        }
    }
}*/