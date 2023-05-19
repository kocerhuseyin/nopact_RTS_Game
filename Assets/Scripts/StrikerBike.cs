using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrikerBike : Unit
{
    [SerializeField]
    protected float speed = 10;
    public override float Speed { get { return speed; } }

    [SerializeField]
    protected float fireRate = 0.5f;
    public override float FireRate { get { return fireRate; } }

    [SerializeField]
    protected float attackRange = 10;
    public override float AttackRange { get { return attackRange; } }

    [SerializeField]
    protected int damagePerShot = 5;
    public override int DamagePerShot { get { return damagePerShot; } }

    [SerializeField]
    protected int hitPoints = 100;
    public override int HitPoints { get { return hitPoints; } set { hitPoints = value; } }

}
