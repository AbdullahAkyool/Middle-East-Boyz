using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Rocket : BulletController
{
    public List<GameObject> charactersInRocketSphere = new List<GameObject>();

    protected override void MoveToTarget()
    {
        transform.DOLookAt(bulletTarget.position, 1f);
        transform.DOJump(bulletTarget.position, 1f, 1, bulletSpeed);

        StartCoroutine(DestroyCo());
    }

    protected override IEnumerator DestroyCo()
    {
        yield return new WaitForSeconds(bulletSpeed - .1f);
        StartCoroutine(Explosion());
    }

    private IEnumerator Explosion()
    {
        charactersInRocketSphere.Clear();

        Collider[] characters = Physics.OverlapSphere(transform.position, 2f);

        foreach (var character in characters)
        {
            if (character.GetComponent<CharacterHealthBase>())
            {
                charactersInRocketSphere.Add(character.gameObject);
            }
        }

        foreach (var rocketSphereObject in charactersInRocketSphere)
        {
            if (rocketSphereObject.TryGetComponent(out CharacterHealthBase characterHealthBase))
            {
                DamageToTarget(characterHealthBase);
            }
        }
        
        yield return new WaitForSeconds(1f);
        
        Destroy();
    }

    // private void OnDrawGizmos()
    // {
    //     Gizmos.DrawSphere(transform.position,2f);
    // }
}