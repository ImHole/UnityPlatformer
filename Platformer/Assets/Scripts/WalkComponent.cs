using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkComponent : MovementComponent
{
    public float MovementSpeed = 4.5f;

    public override void Simulate(PlayerController pc){

        base.Simulate(pc);

        var inputAxis = Input.GetAxis("Horizontal");
        pc.Velocity.x = inputAxis * MovementSpeed;

    }
}
