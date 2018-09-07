using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : PlayerAttack {

    //To check if player is attacking
    private const int ATTACKING = 2;

    private bool enemyHit = false;

    [SerializeField]
    private float enemyHP = 10f;

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
