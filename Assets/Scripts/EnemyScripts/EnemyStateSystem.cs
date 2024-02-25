using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateSystem : CharacterStateSystem
{
    private EnemyController enemyController;

    protected override void Awake()
    {
        base.Awake();
        enemyController = characterControlBase as EnemyController;
    }

    public override void CharacterIdleState()
    {
        enemyController.FindTarget();
        enemyController.LookTarget();
        characterHealthBase.CheckHealth(out bool isDie);

        if (isDie)
        {
            isIdle = false;
                this.isDie = true;
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
        characterHealthBase.CheckHealth(out bool isDie);

        if (isDie)
        {
            isWalk = false;
                this.isDie = true;
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
        characterHealthBase.CheckHealth(out bool isDie);

        if (isDie)
        {
            isAttack = false;
                this.isDie = true;
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