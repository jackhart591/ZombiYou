using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Textbook : Pickup
{
    protected override void pickupBehavior() {
        player.IncreaseMaxHealth(10f);
    }
}
