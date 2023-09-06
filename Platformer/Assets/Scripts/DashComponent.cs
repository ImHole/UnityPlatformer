using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashComponent : MovementComponent
{
    private TimeSince TimeSinceLastDash;

    public float DashTimeMax = 1f;

    public int DashSpeed = 7;
    public int DashDir = 0;
    public Boolean isDashing = false;

    public override void Simulate(PlayerController pc){

        if( Input.GetKeyDown( KeyCode.LeftShift ) && !isDashing ){
            
            isDashing = true;

            TimeSinceLastDash = 0;

            DashDir = (int) Mathf.Sign( Input.GetAxis("Horizontal") );
        }

        if(isDashing){

            pc.Velocity.x = DashSpeed * DashDir;
            pc.Velocity.y = 0;

            if(TimeSinceLastDash >= DashTimeMax){
                isDashing = false;
            }
        }

    }
    
}
