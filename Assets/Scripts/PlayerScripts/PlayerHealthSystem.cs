using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthSystem : CharacterHealthBase
{
    public void CheckHealth()
    {
        if (currentHealth <= 0)
        {
            GetComponent<CharacterControlBase>().Die();
            isDead = true;
        }
    }
}
