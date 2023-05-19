using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttack
{
    public interface IAttack
    {
        float AttackRange { get; }
        int DamagePerShot { get; }
        float FireRate { get; }

        void SetTarget(GameEntity target);
        void AttackTarget();
    }
}
