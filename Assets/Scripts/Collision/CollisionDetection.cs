using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CollisionDetection
{
    public static void GetNormalAndPenetration(Sphere s1, Sphere s2, out Vector3 normal, out float penetration)
    {
        var vector = s1.Center - s2.Center;

        normal = vector.normalized;
        penetration = s1.Radius + s2.Radius - vector.magnitude;
    }

    public static void GetNormalAndPenetration(Sphere s, PlaneCollider p, out Vector3 normal, out float penetration)
    {
        normal = p.Normal;
        var pOffset = p.Offset;
        var sOffset = Vector3.Dot(s.position, normal);
        var distance = sOffset - pOffset;
        if (distance < 0)
        {
            distance *= -1;
            normal *= -1;
        }
        penetration = s.Radius - distance;
    }

    public static void ApplyCollisionResolution(Sphere s1, Sphere s2)
    {
        GetNormalAndPenetration(s1,s2,out var normal,out var penetration);

        var sm = Mathf.Pow(s1.invMass * s2.invMass, -1);
        var pm1 = s1.invMass * sm;
        var pm2 = s2.invMass * sm;
        
        var s1Delta = normal * penetration * pm1;
        var s2Delta = (normal*-1) * penetration * pm2;

        s1.position += s1Delta;
        s2.position += s2Delta;
    }

    public static void ApplyCollisionResolution(Sphere s, PlaneCollider p)
    {
        // TODO: YOUR CODE HERE
    }
}
