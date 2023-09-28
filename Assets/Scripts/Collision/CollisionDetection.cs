using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CollisionDetection
{
    public static void GetNormalAndPenetration(Sphere s1, Sphere s2, out Vector3 normal, out float penetration)
    {
        // TODO: YOUR CODE HERE
        normal = Vector3.zero;
        penetration = 0;
    }

    public static void GetNormalAndPenetration(Sphere s, PlaneCollider p, out Vector3 normal, out float penetration)
    {
        // TODO: YOUR CODE HERE
        normal = Vector3.zero;
        penetration = 0;
    }

    public static void ApplyCollisionResolution(Sphere s1, Sphere s2)
    {
        // TODO: YOUR CODE HERE
    }

    public static void ApplyCollisionResolution(Sphere s, PlaneCollider p)
    {
        // TODO: YOUR CODE HERE
    }
}
