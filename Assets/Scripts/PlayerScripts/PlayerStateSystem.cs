using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateSystem : CharacterStateSystem
{
    private PlayerController playerController;
    private PlayerHealthSystem playerHealthSystem;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        playerHealthSystem = GetComponent<PlayerHealthSystem>();
    }

    public override void CharacterIdleState()
    {
        playerController.JoystickCheck();
        playerController.FindTarget();
        playerController.LookTarget();
        playerHealthSystem.CheckHealth();

        if (playerHealthSystem.isDead)
        {
            isIdle = false;
            isDie = true;
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
        playerController.FindTarget();
        playerController.LookTarget();
        playerHealthSystem.CheckHealth();

        if (playerHealthSystem.isDead)
        {
            isWalk = false;
            isDie = true;
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
        playerHealthSystem.CheckHealth();

        if (playerHealthSystem.isDead)
        {
            isAttack = false;
            isDie = true;
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