using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpComponent : MovementComponent
{
    public int JumpSpeed = 7;

    public override void Simulate(PlayerController pc){

        if(Input.GetKeyDown(KeyCode.Space)){
            
            pc.Velocity.y += JumpSpeed;
        }
    }
    
}
