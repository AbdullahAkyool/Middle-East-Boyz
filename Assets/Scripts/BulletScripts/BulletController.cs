using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletController : MonoBehaviour
{
   public Transform bulletTarget;
   public float bulletSpeed;
   public BulletSpawner bulletSpawner;
   public float bulletPower;

   protected virtual void Awake()
   {
      bulletSpawner = GetComponentInParent<BulletSpawner>();
   }

   private void OnEnable()
   {
      if(!bulletTarget) return;
      MoveToTarget();
   }

   protected abstract void MoveToTarget();

   protected void DamageToTarget(CharacterHealthBase characterHealthBase)
   {
      characterHealthBase.TakeDamage(bulletPower);
   }

   protected void Destroy()
   {
      bulletSpawner.DeSpawn(this);
   }
   protected abstract IEnumerator DestroyCo();
}
