using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Rocket : BulletController
{
    protected override void MoveToTarget()
    {
        transform.DOJump(new Vector3(bulletTarget.position.x,bulletTarget.position.y,bulletTarget.position.z + 1f), 1f, 1, bulletSpeed);
    }
}
