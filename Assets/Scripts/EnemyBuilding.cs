using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBuilding : Building
{
    [SerializeField]
    protected int hitPoints = 500;
    public override int HitPoints { get { return hitPoints; } set { hitPoints = value; } }
}
