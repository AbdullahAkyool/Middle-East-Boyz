using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public List<GameObject> Soldiers = new List<GameObject>();
    public GameObject targetSoldier;
    public GameObject closestSoldier;

    public Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        FindTarget();
        MoveTarget();
    }

    public void FindTarget()
    {
        GameObject[] targetSoldiers = GameObject.FindGameObjectsWithTag("Soldier");
        foreach (var soldier in targetSoldiers)
        {
            if (!CheckTargetInList(soldier))
            {
                Soldiers.Add(soldier);
            }
        }
    }

    bool CheckTargetInList(GameObject target)
    {
        return Soldiers.Contains(target);
    }

    GameObject ClosestSoldier()
    {
        float minDistance = Mathf.Infinity;
        foreach (var soldier in Soldiers)
        {
            float distanceToSoldier = Vector3.Distance(transform.position, soldier.transform.position);
            if (distanceToSoldier < minDistance)
            {
                minDistance = distanceToSoldier;
                closestSoldier = soldier;
            }
        }

        return closestSoldier;
    }

    public void MoveTarget()
    {
        targetSoldier = ClosestSoldier();
        float distanceToTarget = Vector3.Distance(transform.position, targetSoldier.transform.position);

        if (distanceToTarget < 5)
        {
            StopMoveAnim();
            transform.LookAt(targetSoldier.transform);
        }
        else
        {
            MoveAnim();
            transform.position =
                Vector3.MoveTowards(transform.position, targetSoldier.transform.position, Time.deltaTime * 2f);
            transform.LookAt(targetSoldier.transform);
        }
    }

    public void MoveAnim()
    {
        anim.SetBool("isWalk", true);
        anim.SetBool("isIdle", false);
    }

    public void StopMoveAnim()
    {
        anim.SetBool("isWalk", false);
        anim.SetBool("isIdle", true);
    }
}