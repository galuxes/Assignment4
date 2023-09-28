using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AttractorForce : ForceGenerator
{
    public Vector3 targetPos;
    public float power = 150f;

    // TODO: YOUR CODE HERE

    public override void UpdateForce(Particle2D particle)
    {
        Vector2 displacement = targetPos - particle.transform.position;
        float inv_r2 = 1.0f / displacement.sqrMagnitude;
        Vector2 force = power * inv_r2 * displacement.normalized;

        particle.AddForce(force);
    }
}
