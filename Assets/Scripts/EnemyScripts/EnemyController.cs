using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : CharacterControlBase
{
    [Header("--Control--")] 
    public float enemyMoneyValue;
    
    public bool canAttack;
    public bool canWalk;
    public Transform weaponHolderTransform;
    public float enemyLookDistance;
    public float enemyAttackDistance;
    
    [Header("--Components--")] 
    public WeaponBaseCharacterFeature enemyWeapon;
    private Animator animatorOverrideController;
    private NavMeshAgent agent;
    private AnimationEventController animationEventController;
    
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animatorOverrideController = GetComponent<Animator>();
        animationEventController = GetComponent<AnimationEventController>();
        
        if (enemyWeapon.weaponPrefab)
        {
            animationEventController.currentWeapon = Instantiate(enemyWeapon.weaponPrefab,weaponHolderTransform);
        }
        animatorOverrideController.runtimeAnimatorController = enemyWeapon.gunStateMachine;
        enemyAttackDistance = enemyWeapon.enemyAttackDistance;
        enemyLookDistance = enemyWeapon.enemyLookDistance;
        damagePower = enemyWeapon.weaponDamagePower;
    }
    public override void LookTarget()
    {
        var target = ClosestTarget();
        if (!target) return;
        var distanceToTarget = Vector3.Distance(transform.position, target.transform.position);
        
        if (distanceToTarget <= enemyLookDistance && distanceToTarget > enemyAttackDistance && !target.GetComponent<CharacterHealthBase>().isDead)
        {
            agent.enabled = true;
            
            canWalk = true;
            canAttack = false;
            
            Vector3 direction = (target.transform.position - transform.position);
            Quaternion targetRot = Quaternion.LookRotation(direction, Vector3.up);
            
            Quaternion fixedTargetRot = Quaternion.Euler(transform.rotation.eulerAngles.x, targetRot.eulerAngles.y, transform.rotation.eulerAngles.z);
            
            transform.rotation = Quaternion.Lerp(transform.rotation, fixedTargetRot, Time.deltaTime * 25f);

        }
        else if (distanceToTarget <= enemyAttackDistance && !target.GetComponent<CharacterHealthBase>().isDead)
        {
            agent.enabled = false;

            canWalk = false;
            canAttack = true;
            
            Vector3 direction = (target.transform.position - transform.position);
            Quaternion targetRot = Quaternion.LookRotation(direction, Vector3.up);
            
            Quaternion fixedTargetRot = Quaternion.Euler(transform.rotation.eulerAngles.x, targetRot.eulerAngles.y, transform.rotation.eulerAngles.z);
            
            transform.rotation = Quaternion.Lerp(transform.rotation, fixedTargetRot, Time.deltaTime * 25f);

        }
        else if(distanceToTarget >= enemyLookDistance || target.GetComponent<CharacterHealthBase>().isDead)
        {
            RemoveTarget(target.GetComponent<CharacterControlBase>());
            
            agent.enabled = false;
            
            canWalk = false;
            canAttack = false;
        }
    }
    public override void Move()
    {
        var target = ClosestTarget();
        if (!target) return;
        
        if (canWalk && !canAttack)
        {
            Vector3 direction = target.transform.position - transform.position;

            direction.Normalize();

            Vector3 movement = direction * 50 * Time.deltaTime;

           // rb.MovePosition(transform.position + movement);

           agent.SetDestination(target.transform.position);
        }
    }

    public override void Die()
    {
        canAttack = false;
        canWalk = false;
        tag = "Untagged";
    }
}










// public List<GameObject> Soldiers = new List<GameObject>();
    // public GameObject targetSoldier;
    // public GameObject closestSoldier;
    //
    // public Animator anim;
    //
    // void Start()
    // {
    //     anim = GetComponent<Animator>();
    // }
    //
    //
    // void Update()
    // {
    //     FindTarget();
    //     MoveTarget();
    // }
    //
    // public void FindTarget()
    // {
    //     GameObject[] targetSoldiers = GameObject.FindGameObjectsWithTag("Soldier");
    //     foreach (var soldier in targetSoldiers)
    //     {
    //         if (!CheckTargetInList(soldier))
    //         {
    //             Soldiers.Add(soldier);
    //         }
    //     }
    // }
    //
    // bool CheckTargetInList(GameObject target)
    // {
    //     return Soldiers.Contains(target);
    // }
    //
    // GameObject ClosestSoldier()
    // {
    //     float minDistance = Mathf.Infinity;
    //     foreach (var soldier in Soldiers)
    //     {
    //         float distanceToSoldier = Vector3.Distance(transform.position, soldier.transform.position);
    //         if (distanceToSoldier < minDistance)
    //         {
    //             minDistance = distanceToSoldier;
    //             closestSoldier = soldier;
    //         }
    //     }
    //
    //     return closestSoldier;
    // }
    //
    // public void MoveTarget()
    // {
    //     targetSoldier = ClosestSoldier();
    //     float distanceToTarget = Vector3.Distance(transform.position, targetSoldier.transform.position);
    //
    //     if (distanceToTarget < 5)
    //     {
    //         StopMoveAnim();
    //         transform.LookAt(targetSoldier.transform);
    //     }
    //     else
    //     {
    //         MoveAnim();
    //         transform.position =
    //             Vector3.MoveTowards(transform.position, targetSoldier.transform.position, Time.deltaTime * 2f);
    //         transform.LookAt(targetSoldier.transform);
    //     }
    // }
    //
    // public void MoveAnim()
    // {
    //     anim.SetBool("isWalk", true);
    //     anim.SetBool("isIdle", false);
    // }
    //
    // public void StopMoveAnim()
    // {
    //     anim.SetBool("isWalk", false);
    //     anim.SetBool("isIdle", true);
    // }