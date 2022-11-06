using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pickup : MonoBehaviour {

    protected GameObject player;

    protected abstract void pickupBehavior();

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            player = other.gameObject;
            pickupBehavior();
            Destroy(gameObject);
        }
    }


}
