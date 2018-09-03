using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewindAttack : PlayerAttack {

    [SerializeField]
    private Transform startPos;

    [SerializeField]
    private Transform sword;

    private bool isRewinding = false;

    private const float BLOCKING = 4;

    List<Vector3> positions;

	// Use this for initialization
	void Start () {
        positions = new List<Vector3>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.CompareTag("PlayerSword") && swordStatus == BLOCKING)
        {
            StartRewind();
        }

        if (sword == startPos)
        {
            StopRewind();
        }
    }

    void StartRewind()
    {
        isRewinding = true;
    }

    void StopRewind()
    {

    }

    private void FixedUpdate()
    {
        if (isRewinding == true)
        {
            Rewind();
        }

        else
        {
            Record();
        }
    }

    private void Rewind()
    {
        transform.position = positions[0];
        positions.RemoveAt(0);
    }

    private void Record()
    {
        positions.Insert(0, transform.position);
    }
}
