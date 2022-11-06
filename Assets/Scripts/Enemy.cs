using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity {
    
    public override void Attack(Transform e_entity) {
        if (e_entity.TryGetComponent(out Player player)) {
            player.ReceiveDamage(Damage);
        }
    }

    public override void ReceiveDamage(float e_damage) {
        
    }

    protected override void Death() {

    }

    public void OnCollisionEnter(Collision other) {
        Attack(other.transform);
    }
}
