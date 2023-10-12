using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    private Sphere[] _spheres;
    private PlaneCollider[] _planes;
    private void FixedUpdate()
    {
        _spheres = FindObjectsOfType<Sphere>();
        _planes = FindObjectsOfType<PlaneCollider>();

        foreach (var s1 in _spheres)
        {
            foreach (var s2 in _spheres)
            {
                CollisionDetection.ApplyCollisionResolution(s1,s2);
            }

            foreach (var plane in _planes)
            {
                CollisionDetection.ApplyCollisionResolution(s1,plane);
            }
        }
    }
}
