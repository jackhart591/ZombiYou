using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour {

    public float Health;
    public float Thirst;
    public float MoveSpeed { get; protected set; }
    protected float Defense;
    protected float Damage;
    protected float AtkSpeed;

    public abstract void Attack(Transform entity);
    public abstract void ReceiveDamage(float e_damage);
}
