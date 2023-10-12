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
        var sOffset = Vector3.Dot(s.Center, normal);
        var distance = sOffset - pOffset;
        if (distance < 0)
        {
            distance = Mathf.Abs(distance);
            normal *= -1;
        }
        penetration = s.Radius - distance;
    }

    public static void ApplyCollisionResolution(Sphere s1, Sphere s2)
    {
        GetNormalAndPenetration(s1,s2,out var normal,out var penetration);
        
        if(penetration <= 0) { return; }
        if(s1.invMass == 0 && s2.invMass == 0) { return; }
        
        var sm = Mathf.Pow(s1.invMass + s2.invMass, -1);
        var pm1 = s1.invMass * sm;
        var pm2 = s2.invMass * sm;
        
        // Fix Position
        var s1Delta = normal * (penetration * pm1);
        var s2Delta = normal * (-1 * penetration * pm2);
        s1.position += s1Delta;
        s2.position += s2Delta;
        
        // Fix Velocity
        var Vt = s1.velocity - s2.velocity;
        var sepVel = Vector3.Dot(normal,Vt);
        if (sepVel < 0)
        {
            var vDelta = -2 * sepVel;
            s1.velocity += normal * (vDelta * pm1);
            s2.velocity += normal * (-1 * vDelta * pm2);
        }
    }

    public static void ApplyCollisionResolution(Sphere s, PlaneCollider p)
    {
        GetNormalAndPenetration( s, p,out var normal,out var penetration);

        // Fix Position
        if(penetration <= 0) { return; }
        var sDelta = penetration * normal;
        s.position += sDelta;
        
        // Fix Velocity
        //s.velocity = Vector3.Reflect(s.velocity, normal);
        var sepVel = Vector3.Dot(normal,s.velocity);
        if (sepVel < 0)
        {
            var vDelta = -2 * sepVel;
            s.velocity += vDelta * normal;
        }

    }
}
