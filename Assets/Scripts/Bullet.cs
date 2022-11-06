using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 direction;
    public float speed;
    public Player playerInst;

    private float timeToDelete = 3.0f;

    public void Update() {
        transform.Translate(direction * speed * Time.deltaTime);

        if (timeToDelete <= 0) {
            Destroy(gameObject);
        } else {
            timeToDelete -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.transform.TryGetComponent(out Enemy enemy)) {
            playerInst.Attack(enemy.transform);
        }
    }
}
