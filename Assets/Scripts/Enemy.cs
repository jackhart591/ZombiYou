using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity {

    public bool awake;

    private void Awake() {
        isMoving = false;
        MoveSpeed = 15f;
        awake = false;
    }
    
    public override void Attack(Transform e_entity) {
        if (e_entity.TryGetComponent(out Player player)) {
            player.ReceiveDamage(Damage);
        }
    }

    public override void ReceiveDamage(float e_damage) {
        Health -= e_damage;

        if (Health <= 0) {
            Death();
        }
    }

    protected override void Death() {
        Destroy(gameObject);
    }

    public void OnCollisionEnter(Collision other) {
        Attack(other.transform);
    }
}
