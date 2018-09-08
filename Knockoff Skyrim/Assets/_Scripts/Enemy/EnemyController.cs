using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : PlayerAttack {

    //To check if player is attacking
    private const int ATTACKING = 2;

    private bool enemyHit = false;

    private float knockBackForce = 100f;

    private Rigidbody rb;

    [SerializeField]
    private GameObject enemy;

    [SerializeField]
    private float enemyHP = 10f;

    #region Attributes

    private Animator animator;

    private const string KNOCKBACK_ANIMATION_BOOL = "EnemyKnockback";
    private const string ATTACK_ANIMATION_BOOL = "EnemyAttack";

    #endregion

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerSword")
            && enemyHit == false
            && swordStatus == ATTACKING
            )
        {
            enemyHP = enemyHP - 5f;
            Debug.Log("Player Hit Enemy");
            enemyHit = true;
            StartCoroutine(CheckSwordSwingFunction());
        }

        if (enemyHP <= 0)
        {
            gameObject.SetActive(false);
        } 

    }

    IEnumerator CheckSwordSwingFunction()
    {
            yield return new WaitForSeconds(0.5f);
            enemyHit = false;
    }
}
