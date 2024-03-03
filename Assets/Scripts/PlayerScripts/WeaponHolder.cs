using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    private WeaponBaseCharacterFeature currentWeapon;
    public Transform weaponHolderTransform;
    private PlayerController playerController;
    private AnimationEventController animationEventController;
    private Animator animatorOverrideController;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        animatorOverrideController = GetComponent<Animator>();
        animationEventController = GetComponent<AnimationEventController>();

        ActionManager.OnWeaponSelected += EquipWeapon;
    }

    public void EquipWeapon(WeaponBaseCharacterFeature newWeapon)
    {
        currentWeapon = newWeapon;

        int childCount = weaponHolderTransform.childCount;

        if (childCount >= 1)
        {
            for (int i = childCount - 1; i >= 0; i--)
            {
                Destroy(weaponHolderTransform.GetChild(i).gameObject);
            }
        }

        if (currentWeapon.weaponPrefab)
        {
            animationEventController.currentWeapon = Instantiate(currentWeapon.weaponPrefab,weaponHolderTransform);
        }

        animatorOverrideController.runtimeAnimatorController = currentWeapon.gunStateMachine;
        playerController.playerAttackDistance = currentWeapon.playerAttackDistance;
        playerController.damagePower = currentWeapon.weaponDamagePower;
        //playerController.currentWeapon = currentWeapon;
        //characterController.enemyAttackDistance = currentWeapon.enemyAttackDistance;
        //characterController.enemyLookDistance = currentWeapon.enemyLookDistance;
    }
}
