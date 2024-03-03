using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventController : MonoBehaviour
{
   private CharacterControlBase characterController;
   public GameObject currentWeapon;

   private void Awake()
   {
      characterController = GetComponent<CharacterControlBase>();
   }

   public void PunchAndKnife()
   {
      if (characterController.closestTarget == null) return;
      characterController.closestTarget.GetComponent<CharacterHealthBase>().TakeDamage(characterController.damagePower);
      characterController.closestTarget.GetComponent<CharacterHealthBase>().DamageEffect();
   }
   
   public void Pistol()
   {
      if (currentWeapon.TryGetComponent(out BulletSpawner bulletSpawner))
      {
         bulletSpawner.Spawn();
      }
   }

   public void Riffle()
   {
      if (currentWeapon.TryGetComponent(out BulletSpawner bulletSpawner))
      {
         bulletSpawner.Spawn();
      }
   }

   public void Bazooka()
   {
      if (currentWeapon.TryGetComponent(out BulletSpawner bulletSpawner))
      {
         bulletSpawner.Spawn();
      }
   }
}
