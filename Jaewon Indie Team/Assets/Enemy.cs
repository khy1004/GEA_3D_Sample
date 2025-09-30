using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    public enum EnemyState { Idle, Trace, Attack, RunAway }
    public EnemyState state = EnemyState.Idle;
    
    public float moveSpeed = 2f;

    public float traceRange = 15f;

    public float attackRange = 6f;

    public float attackcooldown = 1.5f;

    public GameObject projectilePrefab;

    public Transform firePoint;

    private Transform player;

    public float lasAttackTime;

    public int maxHP = 5;

    public int currentHP;
    // Start is called before the first frame update
    public Slider hpSlider;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        lasAttackTime = attackcooldown;
        currentHP = maxHP;
        hpSlider.value = 1f;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) return;

        float dist = Vector3.Distance(player.position, transform.position);

        if (currentHP == 1 && state != EnemyState.Idle)
        {
            state = EnemyState.RunAway;
        }
        else if (dist < traceRange) { Debug.Log("µ¼È²Ã­ ¼º°ø"); }

        switch (state)
        {
            case EnemyState.Idle:
                if (dist < traceRange)
                    state = EnemyState.Trace;
                break;
            case EnemyState.Trace:
                if (dist < attackRange)
                    state = EnemyState.Attack;
                else if (dist > traceRange)
                    state = EnemyState.Idle;
                else
                    TracePlayer();
                break;
            case EnemyState.Attack:
                if (dist > attackRange)
                    state = EnemyState.Trace;
                else
                    AttackPlayer();
                break;
            case EnemyState.RunAway:
                if (dist < traceRange && currentHP == 1)
                    RRunaway();
                else
                    state = EnemyState.Idle;
                break;
        }

    }

    void TracePlayer()
    {
        Vector3 dir = (player.position - transform.position).normalized;
        transform.position += dir * moveSpeed * Time.deltaTime;
        transform.LookAt(player.position);
    }

    void AttackPlayer()
    {
        if (Time.time >= lasAttackTime + attackcooldown)
        {
            lasAttackTime = Time.time;
            ShootProjectile();
        }
    } 
    
    void ShootProjectile()
    {
        if (projectilePrefab != null && firePoint != null)
        {
            transform.LookAt(player.position);
            GameObject proj = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            EnemyProjectile ep = proj.GetComponent<EnemyProjectile>();
            if (ep != null)
            {
                Vector3 dir = (player.position -firePoint.position).normalized;
                ep.SetDirection(dir);
            }
        }
    }

    void RRunaway()
    {
        Vector3 dir = (player.position - transform.position).normalized;
        transform.position += dir * -moveSpeed * Time.deltaTime;
        transform.LookAt(player.position);
    }

    public void TakeDamage(int damage)
    {
       currentHP -= damage;
        hpSlider.value = (float)currentHP / maxHP;

        if (currentHP <= 0)
        {
            Dead();
        }
    }

    void Dead()
    {
        Destroy(gameObject);
    }
}
