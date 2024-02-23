using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterStateManager : MonoBehaviour
{
    public CharacterStateSystem characterStateSystem;
    private Animator anim;

    private void Awake()
    {
        characterStateSystem = GetComponent<CharacterStateSystem>();
        anim = GetComponent<Animator>();
    }
    
    public void SetStateTransition()
    {
        anim.SetBool("isIdle",characterStateSystem.isIdle);
        anim.SetBool("isWalk",characterStateSystem.isWalk);
        anim.SetBool("isAttack",characterStateSystem.isAttack);
        anim.SetBool("isDie",characterStateSystem.isDie);
    }
    
    public void ResetAllConditions()
    {
        anim.SetBool("isIdle", false);
        anim.SetBool("isWalk", false);
        anim.SetBool("isAttack", false);
        anim.SetBool("isDie", false);
    }
}
