using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimations : MonoBehaviour
{
    //the mesh being animated is not the player itself, just the visuals for the player
    //the actual player is an invisible cube
    public GameObject player;// has to have the player parent assigned
    public Animator anim;
    public float rotationSpeed = 800f;
    Quaternion lookdir = new Quaternion();
    Vector3 moveInputVal;

    void Start()
    {
        if (player == null)
        {
            player = transform.parent.gameObject;
        }
        anim = GetComponent<Animator>();
        anim.SetBool("isWalking", false);
        anim.SetFloat("walkSpeed", 1f);

    }

    private void OnMove(InputValue value)
    {

        moveInputVal = new Vector3(value.Get<Vector2>().x, 0, value.Get<Vector2>().y);
        if (moveInputVal.magnitude == 0)
        {
            anim.SetBool("isWalking", false);
        }
        else
        {
            anim.SetBool("isWalking", true);
            anim.SetFloat("walkSpeed", (moveInputVal.magnitude + 1));
        }

    }

    void Update()
    {
        bool anyKey = (moveInputVal.magnitude != 0);
        float xVel = moveInputVal.x;
        float yVel = moveInputVal.y;
        int lastX = 0;
        int lastY = 0;
        if (anyKey)
        {
            //Switch to the 8 directions to face
            int x = Mathf.RoundToInt(xVel);
            int y = Mathf.RoundToInt(yVel);
            switch (x, y)
            {
                case (0, 0):
                    break;
                case (0, 1):
                    lookdir = Quaternion.LookRotation(player.transform.forward, Vector3.up);
                    lastX = 0;
                    lastY = 1;
                    break;
                case (1, 1):
                    lookdir = Quaternion.LookRotation(((player.transform.forward + player.transform.right) / 2), Vector3.up);
                    lastX = 1;
                    lastY = 1;
                    break;
                case (0, -1):
                    lookdir = Quaternion.LookRotation(player.transform.forward * -1, Vector3.up);
                    lastX = 0;
                    lastY = -1;
                    break;
                case (1, 0):
                    lookdir = Quaternion.LookRotation(player.transform.right, Vector3.up);
                    lastX = 1;
                    lastY = 0;
                    break;
                case (-1, 0):
                    lookdir = Quaternion.LookRotation(player.transform.right * -1, Vector3.up);
                    lastX = -1;
                    lastY = 0;
                    break;
                case (-1, 1):
                    lookdir = Quaternion.LookRotation((player.transform.forward + (player.transform.right * -1) / 2), Vector3.up);
                    lastX = -1;
                    lastY = 1;
                    break;
                case (1, -1):
                    lookdir = Quaternion.LookRotation((player.transform.right + (player.transform.forward * -1) / 2), Vector3.up);
                    lastX = 1;
                    lastY = -1;
                    break;
                case (-1, -1):
                    lookdir = Quaternion.LookRotation(((player.transform.right * -1) + (player.transform.forward * -1) / 2), Vector3.up);
                    lastX = -1;
                    lastY = -1;
                    break;
                default:
                    break;
            }
        }
        else
        {
            switch (lastX, lastY)
            {
                case (0, 0):
                    break;
                case (0, 1):
                    lookdir = Quaternion.LookRotation(player.transform.forward, Vector3.up);
                    break;
                case (1, 1):
                    lookdir = Quaternion.LookRotation(((player.transform.forward + player.transform.right) / 2), Vector3.up);
                    break;
                case (0, -1):
                    lookdir = Quaternion.LookRotation(player.transform.forward * -1, Vector3.up);
                    break;
                case (1, 0):
                    lookdir = Quaternion.LookRotation(player.transform.right, Vector3.up);
                    break;
                case (-1, 0):
                    lookdir = Quaternion.LookRotation(player.transform.right * -1, Vector3.up);
                    break;
                case (-1, 1):
                    lookdir = Quaternion.LookRotation((player.transform.forward + (player.transform.right * -1) / 2), Vector3.up);
                    break;
                case (1, -1):
                    lookdir = Quaternion.LookRotation((player.transform.right + (player.transform.forward * -1) / 2), Vector3.up);
                    break;
                case (-1, -1):
                    lookdir = Quaternion.LookRotation(((player.transform.right * -1) + (player.transform.forward * -1) / 2), Vector3.up);
                    break;
                default:
                    break;
            }
        }
        if (lookdir != null)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, lookdir, rotationSpeed * Time.deltaTime);
        }
    }
}
