using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealthBase : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    public bool isDead;
    public ParticleSystem damageEffect;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public virtual void TakeDamage(float damageValue)
    {
        if (currentHealth <= 0) return;
        currentHealth -= damageValue;
    }

    public virtual void DamageEffect()
    {
        damageEffect.Play();
    }
    
    public void CheckHealth(out bool isDie)
    {
        isDie = currentHealth <= 0;
        if (currentHealth <= 0)
        {
            GetComponent<CharacterControlBase>().Die();
            isDead = true;
        }
    }
}
