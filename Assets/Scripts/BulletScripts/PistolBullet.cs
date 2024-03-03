using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PistolBullet : BulletController
{
    protected override void MoveToTarget()
    {
        transform.DOMove(new Vector3(bulletTarget.position.x,bulletTarget.position.y +1.5f, bulletTarget.position.z), bulletSpeed);
    }
}
