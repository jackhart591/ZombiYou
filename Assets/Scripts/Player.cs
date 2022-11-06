using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : Entity {
    public float MaxThirst { get; private set; }
    public float Thirst { get; private set; }

    private void Awake() {
        MaxThirst = 30.0f;
        Thirst = 30.0f;
    }

    public override void Attack(Transform entity) {
        entity.GetComponent<Enemy>().ReceiveDamage(Damage);
    }

    public override void ReceiveDamage(float e_damage) {
        if (Defense == 0) {
            Health -= e_damage;
            return;
        }

        float healthToTake = e_damage - (e_damage * (((Defense >= 90) ? 90 : Defense) / 100));

        Health -= healthToTake;

        if (Health <= 0) Death();
    }

    protected override void Death() {

    }

    public void IncreaseMaxHealth(float percentage) {
        float toAdd = MaxHealth * (percentage / 100);

        MaxHealth += toAdd;
    }

    public void ResetThirst() { Thirst = MaxThirst; }

    private void Update() {

        if (Health <= 1) {
            MoveSpeed = 4f;
            Damage = 10f;
            Thirst -= Time.deltaTime * 2;
        } else if (Health <= 4) {
            MoveSpeed = 3f;
            Damage = 7f;
            Thirst -= Time.deltaTime * 1.5f;
        } else {
            MoveSpeed = 2f;
            Damage = 5f;
            Thirst -= Time.deltaTime;
        }

        if (Thirst <= 0) {
            Death();
        }

    }
}
