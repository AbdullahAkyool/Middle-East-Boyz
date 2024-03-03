using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public BulletController bulletPrefab;
    public Transform spawnPosition;
    [SerializeField] private int poolSize;
    Queue<BulletController> bulletPool;

    private CharacterControlBase characterControlBase;

    private void Awake()
    {
        bulletPool = new Queue<BulletController>();

        characterControlBase = GetComponentInParent<CharacterControlBase>();
    }

    void Start()
    {
        GrowPool();
    }

    private void GrowPool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            var bulletObject = Instantiate(bulletPrefab, spawnPosition);
            bulletObject.gameObject.SetActive(false);
            bulletPool.Enqueue(bulletObject);
        }
    }

    public void Spawn()
    {
        if (bulletPool.Count <= 0)
        {
            GrowPool();
        }

        var bulletObject = bulletPool.Dequeue();
        bulletObject.transform.position = spawnPosition.position;

        bulletObject.transform.parent = null;
        bulletObject.GetComponent<BulletController>().bulletTarget = characterControlBase.closestTarget.transform;
        
        bulletObject.gameObject.SetActive(true);

    }

    public void DeSpawn(BulletController bullet)
    {
        bullet.gameObject.SetActive(false);
        bullet.transform.parent = spawnPosition;
        bulletPool.Enqueue(bullet);
    }
}
