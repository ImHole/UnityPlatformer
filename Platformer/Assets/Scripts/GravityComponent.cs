using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityComponent : MovementComponent
{
    public float Accel = 10f;

    public override void Simulate(PlayerController pc){

        base.Simulate(pc);
        if(!pc.Controller.isGrounded){
            pc.Velocity += Vector3.down * Accel * Time.deltaTime;
        }
        else{
            pc.Velocity.y = 0;
        }

    }
}
