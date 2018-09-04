using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : EnemyDetection {

    [SerializeField]
    private Transform player;

    [SerializeField]
    private GameObject enemySword;

    private bool attackedPlayer = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (attackingPlayer == true && attackedPlayer == false)
        {
            AttackPlayer();
        }
	}

    void AttackPlayer()
    {
        transform.LookAt(player);
        enemySword.GetComponent<Animation>().Play("EnemyAttack");
        Debug.Log("Attacking Player");
        attackedPlayer = true;
    }
}
