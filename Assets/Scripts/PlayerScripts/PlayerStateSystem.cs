using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateSystem : CharacterStateSystem
{
    private PlayerController playerController;
    protected override void Awake()
    {
        base.Awake();
        playerController = characterControlBase as PlayerController;
    }

    public override void CharacterIdleState()
    {
        playerController.JoystickCheck();
        playerController.FindTarget();
        playerController.LookTarget();
        characterHealthBase.CheckHealth(out bool isDie);

        if (isDie)
        {
            isIdle = false;
                this.isDie = true;
        }

        if (playerController.isMoving)
        {
            isIdle = false;
            isWalk = true;
        }

        if (playerController.hasTarget)
        {
            isIdle = false;
            isAttack = true;
        }
    }

    public override void CharacterWalkState()
    {
        playerController.JoystickCheck();
        playerController.Move();
       // playerController.FindTarget();
        playerController.LookTarget();
        characterHealthBase.CheckHealth(out bool isDie);

        if (isDie)
        {
            isWalk = false;
                this.isDie = true;
        }

        if (!playerController.isMoving)
        {
            isIdle = true;
            isWalk = false;
        }

        if (playerController.hasTarget)
        {
            isAttack = true;
        }
    }

    public override void CharacterAttackState()
    {
        playerController.JoystickCheck();
        playerController.LookTarget();
        characterHealthBase.CheckHealth(out bool isDie);

        if (isDie)
        {
            isAttack = false;
                this.isDie = true;
        }

        if (!playerController.hasTarget)
        {
            isAttack = false;
            isIdle = true;
        }
    }

    public override void CharacterDieState()
    {
        playerController.Die();
    }
}