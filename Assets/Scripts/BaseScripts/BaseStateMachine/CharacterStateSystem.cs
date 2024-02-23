using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterStateSystem : MonoBehaviour
{
    [Header("--States--")] 
    public bool isIdle;
    public bool isWalk;
    public bool isAttack;
    public bool isDie;
    void Start()
    {
        isIdle = true;
    }

    public abstract void CharacterIdleState();
    public abstract void CharacterWalkState();
    public abstract void CharacterAttackState();
    public abstract void CharacterDieState();
}
