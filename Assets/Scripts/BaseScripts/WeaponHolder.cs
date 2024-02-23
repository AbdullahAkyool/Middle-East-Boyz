using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    public WeaponBaseCharacterFeature currentWeapon;
    public Transform weaponHolderTransform;
    private CharacterControlBase characterController;
    private Animator animatorOverrideController;

    private void Start()
    {
        characterController = GetComponent<CharacterControlBase>();
        animatorOverrideController = GetComponent<Animator>();
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
        characterController.playerAttackDistance = currentWeapon.playerAttackDistance;
        characterController.enemyAttackDistance = currentWeapon.enemyAttackDistance;
        characterController.enemyLookDistance = currentWeapon.enemyLookDistance;
    }
}
