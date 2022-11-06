using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour {
    //among us
    public float Health;
    public float MaxHealth;
    public float Thirst;
    public float MoveSpeed { get; protected set; }
    [SerializeField] protected float Defense;
    [SerializeField] protected float Damage;
    [SerializeField] protected float AtkSpeed;

    public abstract void Attack(Transform entity);
    public abstract void ReceiveDamage(float e_damage);
    protected abstract void Death();
}
