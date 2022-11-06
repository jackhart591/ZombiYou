using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour {
    public List<Enemy> enemies;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            foreach (Enemy meme in enemies) {
                meme.awake = true;
            }
        }
    }
}
