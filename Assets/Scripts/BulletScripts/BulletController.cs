using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletController : MonoBehaviour
{
   public Transform bulletTarget;
   public float bulletSpeed;
   public BulletSpawner bulletSpawner;

   private void Awake()
   {
      bulletSpawner = GetComponentInParent<BulletSpawner>();
   }

   private void OnEnable()
   {
      if(bulletTarget == null) return;
      MoveToTarget();
   }

   protected abstract void MoveToTarget();

   private void Destroy()
   {
      bulletSpawner.DeSpawn(this);
   }

   private void OnTriggerEnter(Collider other)
   {
      // if (other.TryGetComponent(out CharacterControlBase characterControlBase))
      // {
      //    Destroy();
      // }

      if (other.gameObject == bulletTarget.gameObject)
      {
            Destroy();         
      }
   }
}
