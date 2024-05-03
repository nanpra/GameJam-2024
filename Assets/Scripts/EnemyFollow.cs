using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    public float moveSpeed = 3.5f;
    public float attackRange = 2.0f;
    public float attackCooldown = 1.0f;
    public Transform player;
    private bool isAttacking = false;
    private float lastAttackTime;


    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer > attackRange)
        {
            moveSpeed = 3.5f;
            isAttacking = false;
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * moveSpeed * Time.deltaTime;
            transform.LookAt(player.position);
        }
        else
        {
            if (!isAttacking && Time.time - lastAttackTime > attackCooldown)
            {
                isAttacking = true;
                lastAttackTime = Time.time;
                AttackPlayer();
            }
        }
    }

    void AttackPlayer()
    {
        Debug.Log("Attacking Player!");
        moveSpeed = 0f;
    }
}
