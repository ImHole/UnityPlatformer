
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public CharacterController Controller;
    public TimeSince timeSinceDash = 0f;

    //movement

    public Vector3 Velocity;

    public float gravity = 100f;
    public float playerSpd = 4f;
    private float playerInputTarget;


    //states
    public enum PlayerState {

        idle = 0,
        dash = 1,
        attack = 2

    }

    public PlayerState state;



    void Idle() {
        
        playerInputTarget = Input.GetAxis("Horizontal");

        //jumping

        if( Input.GetKeyDown(KeyCode.Space) && Controller.isGrounded ) {

            Velocity.y = 5f;
        }

        //dash transition

        if( Input.GetKeyDown(KeyCode.LeftShift) ) {

            state = PlayerState.dash;
            timeSinceDash = 0f;
            Velocity = Vector3.zero;
        }

    }

    void Dash() {

        if( timeSinceDash < 1f ) {

            Velocity.x = 6f * Mathf.Sign(Input.GetAxis("Horizontal"));
        }
        else {

            state = PlayerState.idle;
        }
    }

    void Attack() {
        
    }

    void HandleInput() {

        switch( state ){

            case PlayerState.idle: Idle();

            break;

            case PlayerState.dash: Dash();

            break;

            case PlayerState.attack: Attack();

            break;
        }

    }

    void HandleMovement() {

        if(Controller.isGrounded) {

            Velocity.y = -10f;
        }
        else{

            if(state != PlayerState.dash){

                Velocity.y += gravity*Time.deltaTime;
            }
        }

        Velocity.x = playerInputTarget * playerSpd;

        HandleInput();

        Controller.Move(Velocity*Time.deltaTime);
    }



    void Start() {

        if(Controller == null) {

            Controller = GetComponent<CharacterController>();
        }

        state = PlayerState.idle;
    }

    void Update() {
        
        HandleMovement();
    }
}

