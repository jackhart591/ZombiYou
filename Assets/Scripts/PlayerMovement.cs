using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    private Vector3 moveInputVal;
    private Vector3 mousePos;

    public GameObject bulletPrefab;

    private void OnMove(InputValue value) {
        moveInputVal = new Vector3(value.Get<Vector2>().x, 0, value.Get<Vector2>().y);
    }

    private void OnFire(InputValue value) {
        GameObject bulletInst = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bulletInst.GetComponent<Bullet>().playerInst = GetComponent<Player>();

        Ray cameraRay = Camera.main.ScreenPointToRay(new Vector3(Mouse.current.position.ReadValue().x, Mouse.current.position.ReadValue().y, 0));
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if (groundPlane.Raycast(cameraRay, out rayLength)) {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);

            bulletInst.GetComponent<Bullet>().direction = Vector3.Normalize(new Vector3(pointToLook.x, transform.position.y, pointToLook.z) - transform.position);
        }
    }

    public void FixedUpdate() {
        GetComponent<Rigidbody>().AddForce(moveInputVal * GetComponent<Player>().MoveSpeed, ForceMode.VelocityChange);
    }

    public void Update() {

        Ray cameraRay = Camera.main.ScreenPointToRay(new Vector3(Mouse.current.position.ReadValue().x, Mouse.current.position.ReadValue().y, 0));
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if (groundPlane.Raycast(cameraRay, out rayLength)) {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);

            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }
    }
}
