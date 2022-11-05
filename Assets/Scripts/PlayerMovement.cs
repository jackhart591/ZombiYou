using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    private Vector3 moveInputVal;

    private void OnMove(InputValue value) {
        moveInputVal = new Vector3(value.Get<Vector2>().x, 0, value.Get<Vector2>().y);
    }

    public void FixedUpdate() {
        GetComponent<Rigidbody>().AddForce(moveInputVal * GetComponent<Player>().MoveSpeed, ForceMode.VelocityChange);
    }
}
