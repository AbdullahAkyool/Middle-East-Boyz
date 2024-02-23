using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateSystem : CharacterStateSystem
{
    private EnemyController enemyController;
    private EnemyHealthSystem enemyHealthSystem;

    private void Awake()
    {
        enemyController = GetComponent<EnemyController>();
        enemyHealthSystem = GetComponent<EnemyHealthSystem>();
    }

    public override void CharacterIdleState()
    {
        enemyController.FindTarget();
        enemyController.LookTarget();
        enemyHealthSystem.CheckHealth();

        if (enemyHealthSystem.isDead)
        {
            isIdle = false;
            isDie = true;
        }

        if (enemyController.canWalk)
        {
            isIdle = false;
            isWalk = true;
        }

        if (enemyController.canAttack)
        {
            isIdle = false;
            isAttack = true;
        }
    }

    public override void CharacterWalkState()
    {
        enemyController.FindTarget();
        enemyController.LookTarget();
        enemyController.Move();
        enemyHealthSystem.CheckHealth();

        if (enemyHealthSystem.isDead)
        {
            isWalk = false;
            isDie = true;
        }

        if (!enemyController.canWalk)
        {
            isIdle = true;
            isWalk = false;
        }
    }

    public override void CharacterAttackState()
    {
        enemyController.Move();
        enemyController.LookTarget();
        enemyHealthSystem.CheckHealth();

        if (enemyHealthSystem.isDead)
        {
            isAttack = false;
            isDie = true;
        }

        if (!enemyController.canAttack)
        {
            isAttack = false;

            isIdle = true;

        }
    }

    public override void CharacterDieState()
    {
        enemyController.Die();
    }
}