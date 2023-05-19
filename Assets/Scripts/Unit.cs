using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : GameEntity, IAttack, ISelectable
{
    public virtual float Speed { get; protected set; }
    public virtual float AttackRange { get; protected set; }
    public virtual int DamagePerShot { get; protected set; }
    public virtual float FireRate { get; protected set; }
    public bool IsSelected { get; set; }

    protected GameEntity target;
    private Vector3 targetPosition;
    protected float fireCooldown;
    private bool isMoving = false;

    private Coroutine rotationCoroutine; 
    private float rotationspeed = 500;

    protected virtual void Update()
    {
        fireCooldown -= Time.deltaTime;

        if (target)
        {
            // Check if the target is dead
            if (target.IsDead)
            {
                // Deselect the target (stop attacking)
                target = null;
            }
            // Check if the target is in range
            if (Vector3.Distance(transform.position, target.Position) <= AttackRange)
            {
                isMoving = false;
                AttackTarget();
            }
            else if (!isMoving)
            {
                // Get closer to shoot
                Move(target.Position);
            }
        }

        if (isMoving)
        {
            float step = Speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

            if (target && Vector3.Distance(transform.position, targetPosition) < 0.001f)
            {
                // If the unit has reached the target's position but the target is still out of range,
                // keep moving towards the target
                Move(target.Position);
            }
            else if (Vector3.Distance(transform.position, targetPosition) < 0.001f)
            {
                isMoving = false;
            }
        }
    }

    public void Move(Vector3 destination)
    {
        targetPosition = destination;

        // Stop the previous rotation coroutine if it is still running
        if (rotationCoroutine != null)
        {
            StopCoroutine(rotationCoroutine);
        }
        rotationCoroutine = StartCoroutine(RotateAndMove(destination));
    }
    IEnumerator RotateAndMove(Vector3 destination)
    {
        Quaternion targetRotation = Quaternion.LookRotation(destination - transform.position);
        while (Quaternion.Angle(transform.rotation, targetRotation) > 0.01f)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationspeed * Time.deltaTime);
            yield return null;
        }

        isMoving = true;
    }

    public void SetTarget(GameEntity target)
    {
        // Only target entities that are not dead
        if (target != null && !target.IsDead)
        {
            this.target = target;

            // Stop the previous rotation coroutine if it is still running
            if (rotationCoroutine != null)
            {
                StopCoroutine(rotationCoroutine);
            }

            rotationCoroutine = StartCoroutine(RotateAndAttack(target));
        }
        else
        {
            // Deselect the target (stop attacking)
            this.target = null;
        }
    }
    IEnumerator RotateAndAttack(GameEntity target)
    {
        Quaternion targetRotation = Quaternion.LookRotation(target.Position - transform.position);
        while (Quaternion.Angle(transform.rotation, targetRotation) > 0.01f)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationspeed * Time.deltaTime);
            yield return null;
        }

        AttackTarget();
    }

    public void AttackTarget()
    {
        // Only attack if the target is not null and not dead
        if (target != null && !target.IsDead && fireCooldown <= 0f)
        {
            // Reset fire cooldown
            fireCooldown = FireRate;

            // Deal damage to the target
            target.TakeDamage(DamagePerShot);
        }
        else if (target.IsDead)
        {
            // Deselect the target (stop attacking)
            target = null;
        }

    }

    public void Select()
    {
        IsSelected = true;
        GetComponent<Renderer>().material = SelectedMaterial;
    }

    public void Deselect()
    {
        IsSelected = false;
        GetComponent<Renderer>().material = DeselectedMaterial;
    }

    
}
