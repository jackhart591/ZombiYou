using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : Entity {

    private Vector2 moveVal;

    public override void Attack(Transform entity) {

    }

    public override void ReceiveDamage(float e_damage) {

    }

    private void OnMove(InputValue value) {
        moveVal = value.Get<Vector2>();
        Debug.Log(moveVal);
    }
}
