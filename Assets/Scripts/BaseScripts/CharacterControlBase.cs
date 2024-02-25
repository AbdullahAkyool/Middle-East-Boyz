using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class CharacterControlBase : MonoBehaviour
{
    [Header("--Attack--")] 

    public string targetTag;
    private List<GameObject> Targets = new List<GameObject>();
    public GameObject closestTarget;
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