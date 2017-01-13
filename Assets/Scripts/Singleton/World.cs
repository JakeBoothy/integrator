using UnityEngine;
using System.Collections;


public class World : MonoBehaviour {

    private static World _instance;

    public static World Instance {
        get
        {
            if (_instance == null)
            {
                _instance = (World)FindObjectOfType(typeof(World));
                
            }
            return _instance;
        }
    }

    public bigObject[] bigObjects = new bigObject[0];
    public smallObject[] smallObjects = new smallObject[0];

    public void addBigObject(bigObject b)
    {
        bigObject [] old = bigObjects;

        bigObjects = new bigObject[old.Length + 1];
        for (int i = 0; i < old.Length + 1; i++)
        {
            if (i < old.Length)
            {
                bigObjects[i] = old[i];
            }
            else
            {
                bigObjects[i] = b;
            }
        }
    }

    public void removeBigObject(int a)
    {
        bigObject[] old = bigObjects;
        if (old.Length > 0)
        {
            bigObjects = new bigObject[old.Length - 1];
            for (int i = 0; i < old.Length - 1; i++)
            {
                if (i < a)
                {
                    bigObjects[i] = old[i];
                }
                else
                {
                    bigObjects[i - 1] = old[i];
                }
            }
        }
    }

    public void addSmallObject(smallObject b)
    {
        smallObject[] old = smallObjects;
        smallObjects = new smallObject[old.Length + 1];
        for (int i = 0; i < old.Length + 1; i++)
        {
            if (i < old.Length)
            {
                smallObjects[i] = old[i];
            }
            else
            {
                smallObjects[i] = b;
            }
        }
    }

    public void removeSmallObject(int a)
    {
        if (a >= 0)
        {
            smallObject[] old = smallObjects;
            if (old.Length > 0)
            {
                smallObjects = new smallObject[old.Length - 1];
                for (int i = 0; i < old.Length - 1; i++)
                {
                    if (i < a)
                    {
                        smallObjects[i] = old[i];
                    }
                    else
                    {
                        smallObjects[i - 1] = old[i];
                    }
                }
            }
        }
    }

}
