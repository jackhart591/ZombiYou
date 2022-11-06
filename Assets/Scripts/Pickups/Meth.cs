using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meth : Pickup {

    protected override void pickupBehavior() {
        player.IncreaseDefense(10f);
        player.IncreaseSpeed(20f);
    }
}
