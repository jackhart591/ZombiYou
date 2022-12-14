using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pickup : MonoBehaviour {

    protected Player player;

    protected abstract void pickupBehavior();

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            player = other.gameObject.GetComponent<Player>();
            pickupBehavior();
            Destroy(gameObject);
        }
    }


}
