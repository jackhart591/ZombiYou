using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAnimations : MonoBehaviour
{
    public Animator anim;
    public GameObject parentEnemy;
    float moveSpd = 1f;
    bool isWalking = false;
    bool playerEntered = false;

    void Start()
    {

        if (parentEnemy == null)
        {
            parentEnemy = transform.parent.gameObject;
        }

        anim = GetComponent<Animator>();
        moveSpd = parentEnemy.GetComponent<Enemy>().MoveSpeed;
        isWalking = parentEnemy.GetComponent<Enemy>().isMoving;
    }

    void Update()
    {

        moveSpd = parentEnemy.GetComponent<Enemy>().MoveSpeed;
        playerEntered = parentEnemy.GetComponent<Enemy>().awake;

        if (playerEntered)
        {
            anim.SetBool("playerInProximity", true);
            anim.SetBool("isWalking", true);
            anim.SetFloat("walkSpeed", (1 + Mathf.Sqrt(moveSpd)));
        }
    }
}
