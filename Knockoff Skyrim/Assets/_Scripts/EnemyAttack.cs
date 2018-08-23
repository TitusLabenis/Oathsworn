using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : EnemyDetection {

    [SerializeField]
    private Transform player;

    [SerializeField]
    private GameObject enemySword;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (attackingPlayer == true)
        {
            AttackPlayer();
        }
	}

    void AttackPlayer()
    {
        transform.LookAt(player);
        enemySword.GetComponent<Animation>().Play("EnemyAttack");
        Debug.Log("Attacking Player");
    }
}
