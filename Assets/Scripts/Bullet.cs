using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 direction;
    public float speed;

    private float timeToDelete = 3.0f;

    public void Update() {
        transform.Translate(direction * speed * Time.deltaTime);

        if (timeToDelete <= 0) {
            Destroy(gameObject);
        } else {
            timeToDelete -= Time.deltaTime;
        }
    }
}
