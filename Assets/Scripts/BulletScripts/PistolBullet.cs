using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PistolBullet : BulletController
{
    protected override void MoveToTarget()
    {
        transform.DOMove(new Vector3(bulletTarget.position.x,bulletTarget.position.y +1.5f, bulletTarget.position.z), bulletSpeed);

        StartCoroutine(DestroyCo());
    }

    protected override IEnumerator DestroyCo()
    {
        yield return new WaitForSeconds(bulletSpeed - .1f); 
        Destroy();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out CharacterControlBase characterControlBase))
        {
            Destroy();
            
            if(characterControlBase.targetTag == bulletTarget.GetComponent<CharacterControlBase>().targetTag)
            {
                if (other.gameObject.TryGetComponent(out CharacterHealthBase characterHealthBase))
                {
                    DamageToTarget(characterHealthBase);
                }
            }
        }
    }
}
