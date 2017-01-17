using UnityEngine;
using System.Collections;
using UnityEngine.Serialization;

[System.Serializable]
public struct double3
{
    public double x;
    public double y;
    public double z;

    public double3(double _x, double _y, double _z)
    {
        x = _x;
        y = _y;
        z = _z;
    }

    public static double3 cross(double3 a, double3 b)
    {
        return new double3(a.y * b.z - a.z * b.y, a.z * b.x - a.x * b.z, a.x * b.y - a.y * b.z);
    }

    public static double3 normalize(double3 a)
    {
        return new double3(0, 0, 0);
    }

    public static double3 operator -(double3 a, double3 b)
    {
        return new double3(a.x - b.x, a.y - b.y, a.z - b.z);
    }

    public static double3 operator +(double3 a, double3 b)
    {
        return new double3(a.x + b.x, a.y + b.y, a.z + b.z);
    }

    public static double3 operator *(double a, double3 b)
    {
        return new double3(a * b.x, a * b.y, a * b.z);
    }

    public static double3 operator *(double3 a, double3 b)
    {
        return new double3(a.x * b.x, a.y * b.y, a.z * b.z);
    }

    public static double3 operator *(double3 a, float b)
    {
        return new double3(a.x * b, a.y * b, a.z * b);
    }

    public static double3 operator /(double3 a, double b)
    {
        return new double3(a.x / b, a.y / b, a.z / b);
    }

    public static bool operator ==(double3 a, double3 b)
    {
        if (a.x == b.x && a.y == b.y && a.z == b.z)
        {
            return true;
        }
        return false;
    }

    public static bool operator !=(double3 a, double3 b)
    {
        if (a.x != b.x || a.y != b.y || a.z != b.z)
        {
            return true;
        }
        return false;
    }


    public static implicit operator Vector3(double3 a)
    {
        return new Vector3((float)a.x, (float)a.y, (float)a.z);
    }
    public static implicit operator double3(Vector3 a)
    {
        return new double3((double)a.x, (double)a.y, (double)a.z);
    }

    public override string ToString()
    {
        return (x + ", " + y + ", " + z);
    }

}

