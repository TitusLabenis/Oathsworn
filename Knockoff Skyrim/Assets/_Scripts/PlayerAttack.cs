using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : EnemyDetection {

    //Mouse Inputs
    private const int LEFTCLICK = 0;
    private const int RIGHTCLICK = 1;
    private const int MIDDLECLICK = 2;

    public int swordStatus = IDLE;

    //Sword Statuses
    private const int IDLE = 0;
    private const int ATTACK = 1;
    private const int ATTACKING = 2;
    private const int BLOCK = 3;
    private const int BLOCKING = 4;
    private const int UNBLOCK = 5;
    private const int UNBLOCKING = 6;


    [SerializeField]
    private GameObject playerSword;

	void Update () {
		if (Input.GetMouseButtonDown(LEFTCLICK) && swordStatus == IDLE)
        {
            StartCoroutine(SwingSwordFunction());
        }

        if (Input.GetMouseButtonDown(RIGHTCLICK) && swordStatus == IDLE)
        {
            StartCoroutine(BlockSwordFunction());
        }

        if (Input.GetMouseButtonUp(RIGHTCLICK) && swordStatus == BLOCKING)
        {
            StartCoroutine(UnBlockSwordFunction());
        }
    }

    IEnumerator UnBlockSwordFunction()
    {
        swordStatus = UNBLOCK;
        playerSword.GetComponent<Animation>().Play("SwordUnblock");
        swordStatus = UNBLOCKING;
        yield return new WaitForSeconds(0.5f);
        swordStatus = IDLE;
    }

    IEnumerator BlockSwordFunction()
    {
        swordStatus = BLOCK;
        playerSword.GetComponent<Animation>().Play("SwordBlock");
        swordStatus = BLOCKING;
        yield return new WaitForSeconds(0.25f);
    }

    IEnumerator SwingSwordFunction()
    {
        swordStatus = ATTACK;
        playerSword.GetComponent<Animation>().Play("SwordAttack");
        swordStatus = ATTACKING;
        yield return new WaitForSeconds(0.75f);
        swordStatus = IDLE;
    }
}
