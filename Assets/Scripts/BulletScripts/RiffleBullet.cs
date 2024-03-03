using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class RiffleBullet : BulletController
{

    protected override void MoveToTarget()
    {
        transform.DOMove(new Vector3(bulletTarget.position.x,bulletTarget.position.y + 1.5f, bulletTarget.position.z), bulletSpeed);
    }
}
