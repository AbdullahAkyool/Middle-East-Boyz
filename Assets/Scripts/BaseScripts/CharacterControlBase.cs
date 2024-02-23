using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterControlBase : MonoBehaviour
{
    protected Rigidbody rb;

    public string targetTag;
    public List<GameObject> Targets = new List<GameObject>();
    public GameObject closestTarget;
    protected float distanceToTarget;
    
    public float playerAttackDistance;
    public float enemyLookDistance;
    public float enemyAttackDistance;
    
    private WeaponHolder weaponHolder;
    public WeaponBaseCharacterFeature defaultNoWeapon;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        weaponHolder = GetComponent<WeaponHolder>();
        weaponHolder.EquipWeapon(defaultNoWeapon);
    }

    public void FindTarget()
    {
        GameObject[] targetCharacters = GameObject.FindGameObjectsWithTag(targetTag);
        foreach (var trgt in targetCharacters)
        {
            if (targetCharacters.Length >= 1)
            {
                if (!CheckTargetInList(trgt))
                {
                    Targets.Add(trgt);
                }
            }
        }
    }

    public void RemoveTarget(CharacterControlBase character)
    {
        Targets.Remove(character.gameObject);
    }

    bool CheckTargetInList(GameObject target)
    {
        return Targets.Contains(target);
    }

    protected GameObject ClosestTarget()
    {
        float minDistance = Mathf.Infinity;
        foreach (var trgt in Targets)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, trgt.transform.position);
            if (distanceToEnemy < minDistance)
            {
                minDistance = distanceToEnemy;
                closestTarget = trgt;
            }
        }

        return closestTarget;
    }

    public abstract void LookTarget();


    public abstract void Move();


    public abstract void Die();
}