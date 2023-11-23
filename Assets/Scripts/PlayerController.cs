using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private FloatingJoystick joystick;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotationSpeed;
    private Rigidbody rb;
    private Vector3 moveVector;

    public Animator anim;
    public AnimatorController originalAnim;
    public AnimatorOverrideController animRiffle;
    public AnimatorOverrideController animPistol;

    [SerializeField] private List<GameObject> Enemies = new List<GameObject>();
    [SerializeField] private GameObject target;
    [SerializeField] private float lookDistance = 10f;
    [SerializeField] private GameObject soldierModel;
    [SerializeField] private GameObject closestEnemy;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
        FindTarget();
        LookTarget();

        if (Input.GetKeyDown(KeyCode.A))
        {
            anim.runtimeAnimatorController = animRiffle;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            anim.runtimeAnimatorController = animPistol;
        }
    }

    public void FindTarget()
    {
        GameObject[] targetEnemies = GameObject.FindGameObjectsWithTag("Terrorist");
        foreach (var enemy in targetEnemies)
        {
            if (!CheckTargetInList(enemy))
            {
                Enemies.Add(enemy);
            }
        }
    }

    bool CheckTargetInList(GameObject target)
    {
        return Enemies.Contains(target);
    }

    GameObject ClosestEnemy()
    {
        float minDistance = Mathf.Infinity;
        foreach (var enemy in Enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < minDistance)
            {
                minDistance = distanceToEnemy;
                closestEnemy = enemy;
            }
        }

        return closestEnemy;
    }

    public void LookTarget()
    {
        target = ClosestEnemy();

        float distanceToTarget = Vector3.Distance(transform.position, target.transform.position);

        if (distanceToTarget <= lookDistance)
        {
            Vector3 direction = (target.transform.position - transform.position);
            Quaternion targetRot = Quaternion.LookRotation(direction, Vector3.up);
            soldierModel.transform.rotation =
                Quaternion.Lerp(soldierModel.transform.rotation, targetRot, Time.deltaTime * 8f);
        }
        else if (distanceToTarget >= lookDistance)
        {
            soldierModel.transform.rotation =
                Quaternion.Lerp(soldierModel.transform.rotation, transform.rotation, Time.deltaTime * 8f);
        }
    }

    public void Move()
    {
        moveVector = Vector3.zero;
        moveVector.x = joystick.Horizontal * moveSpeed * Time.deltaTime;
        moveVector.z = joystick.Vertical * moveSpeed * Time.deltaTime;
        
        anim.SetFloat("walkSpeedValue", moveVector.magnitude * 100);

        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            Vector3 direction =
                Vector3.RotateTowards(transform.forward, moveVector, rotationSpeed * Time.deltaTime, 0f);
            transform.rotation = Quaternion.LookRotation(direction);
            
            MoveAnim();
        }
        else if (joystick.Horizontal == 0 || joystick.Vertical == 0)
        {
            StopMoveAnim();
        }

        rb.MovePosition(rb.position + moveVector);
    }

    public void MoveAnim()
    {
        anim.SetBool("isWalk", true);
        anim.SetBool("isIdle", false);
    }

    public void StopMoveAnim()
    {
        anim.SetBool("isWalk", false);
        anim.SetBool("isIdle", true);
    }
}