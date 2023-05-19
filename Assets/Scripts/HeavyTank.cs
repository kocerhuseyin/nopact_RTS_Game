using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyTank : Unit
{
    [SerializeField]
    protected float speed = 5;
    public override float Speed { get { return speed; } }

    [SerializeField]
    protected float fireRate = 1.5f;
    public override float FireRate { get { return fireRate; } }

    [SerializeField]
    protected float attackRange = 30;
    public override float AttackRange { get { return attackRange; } }

    [SerializeField]
    protected int damagePerShot = 20;
    public override int DamagePerShot { get { return damagePerShot; } }

    [SerializeField]
    protected int hitPoints = 900;
    public override int HitPoints { get { return hitPoints; } set { hitPoints = value; } }


}
