using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : Pickup {
    
    protected override void pickupBehavior() {
        player.ResetThirst();
    }
}
