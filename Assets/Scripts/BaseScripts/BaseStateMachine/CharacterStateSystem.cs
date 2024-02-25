using System;
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

    protected CharacterControlBase characterControlBase;
    protected CharacterHealthBase characterHealthBase;

    protected virtual void Awake()
    {
        characterControlBase = GetComponent<CharacterControlBase>();
        characterHealthBase = GetComponent<CharacterHealthBase>();
    }

    void Start()
    {
        isIdle = true;
    }
    public abstract void CharacterIdleState();
    public abstract void CharacterWalkState();
    public abstract void CharacterAttackState();
    public abstract void CharacterDieState();
    
    
    
}
