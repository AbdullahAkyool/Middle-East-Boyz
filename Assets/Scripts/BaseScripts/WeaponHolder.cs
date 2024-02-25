using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    public WeaponBaseCharacterFeature currentWeapon;
    public Transform weaponHolderTransform;
    private PlayerController playerController;
    public Animator animatorOverrideController;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        animatorOverrideController = GetComponent<Animator>();

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
            Instantiate(currentWeapon.weaponPrefab,weaponHolderTransform);
        }

        animatorOverrideController.runtimeAnimatorController = currentWeapon.gunStateMachine;
        playerController.playerAttackDistance = currentWeapon.playerAttackDistance;
        //characterController.enemyAttackDistance = currentWeapon.enemyAttackDistance;
        //characterController.enemyLookDistance = currentWeapon.enemyLookDistance;
    }
}
