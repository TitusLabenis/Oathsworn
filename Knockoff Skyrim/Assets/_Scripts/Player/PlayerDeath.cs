using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour {

    [SerializeField]
    private float playerHP = 1.0f;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (playerHP <= 0f)
        {
            //Death();
        }
    }

    private void OnTriggerEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EnemySword"))
        {
            TakeDamage();
        }
    }

    private void TakeDamage()
    {
        playerHP = playerHP - 1.0f;
    }

    private void Death()
    {

    }
}
