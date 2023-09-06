
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using System.Linq;
using System;

public class PlayerController : MonoBehaviour {

    public CharacterController Controller;
    public List<MovementComponent> MovementComponents;

    public Vector3 Velocity;

    void Start(){
        MovementComponents = new List<MovementComponent>();
        MovementComponents = gameObject.GetComponents<MovementComponent>().ToList();
    }

    void Update(){

        MovementComponents = MovementComponents.OrderBy(x => x.Priority).ToList();

        foreach(MovementComponent mc in MovementComponents){
            mc.Simulate(this);
        }

        Controller.Move(Velocity * Time.deltaTime);

    }

    public void Jump(){

        Velocity.y += 15;
    }
}

