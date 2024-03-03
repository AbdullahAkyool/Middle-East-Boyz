using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Weapon",menuName = "Weapons")]
public class WeaponBaseCharacterFeature : ScriptableObject
{
   public AnimatorOverrideController gunStateMachine;

   public GameObject weaponPrefab;
   public Sprite weaponImage;
   public string weaponName;
   public float weaponDamagePower;
   
   public float playerAttackDistance;
   public float enemyLookDistance;
   public float enemyAttackDistance;
}
