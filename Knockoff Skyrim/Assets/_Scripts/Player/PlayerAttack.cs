using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : EnemyDetection {

    //Mouse Inputs
    private const int LEFTCLICK = 0;
    private const int RIGHTCLICK = 1;
    private const int MIDDLECLICK = 2;

    private float speed = 100f;

    private bool hasShield = true;

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
            StartCoroutine(SwingSwordFunction()); //attacks when lmouse is clicked
        }

        if (Input.GetMouseButtonDown(RIGHTCLICK) && swordStatus == IDLE)
        {
            StartCoroutine(BlockSwordFunction()); //raises sword to parry when rmouse is clicked
        }

        if (Input.GetMouseButtonUp(RIGHTCLICK) && swordStatus == BLOCKING)
        {
            StartCoroutine(UnBlockSwordFunction()); //drops sword once the player releases rmouse
        }
    }

    IEnumerator UnBlockSwordFunction()
    {
        swordStatus = UNBLOCK; //informs the script that the player is about to unblocking
        playerSword.GetComponent<Animation>().Play("SwordUnblock");
        swordStatus = UNBLOCKING; //informs the script that the player is in the process of unblocking
        yield return new WaitForSeconds(0.5f);
        swordStatus = IDLE; //the player has now dropped his sword and is ready to do whatever
    }

    IEnumerator BlockSwordFunction()
    {
        swordStatus = BLOCK; //player about to raise sword
        playerSword.GetComponent<Animation>().Play("SwordBlock");
        swordStatus = BLOCKING; //sword is raised
        yield return new WaitForSeconds(0.25f);
    }

    IEnumerator SwingSwordFunction()
    {
        swordStatus = ATTACK; //player going to attack
        playerSword.GetComponent<Animation>().Play("SwordAttack");
        swordStatus = ATTACKING; //player swinging sword
        yield return new WaitForSeconds(0.75f);
        swordStatus = IDLE; //player done swinging sword
    }
}
