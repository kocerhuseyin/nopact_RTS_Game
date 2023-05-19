using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameEntity : MonoBehaviour
{
    public Material DeadMaterial;
    public Material SelectedMaterial;
    public Material DeselectedMaterial;

    protected bool isDead = false;
    public bool IsDead { get { return isDead; } }

    public virtual int HitPoints { get; set; }
    public Vector3 Position { get { return transform.position; } }

    public void TakeDamage(int damage)
    {
        HitPoints -= damage;
        if (HitPoints <= 0)
        {
            DestroyEntity();
        }
    }
    protected virtual void DestroyEntity()
    {
        GetComponent<Renderer>().material = DeadMaterial;
        this.enabled = false;
        isDead = true;
    }
}
