using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : Entity {

    public void Awake() {
        MoveSpeed = 2f;
    }

    public override void Attack(Transform entity) {

    }

    public override void ReceiveDamage(float e_damage) {

    }
}
