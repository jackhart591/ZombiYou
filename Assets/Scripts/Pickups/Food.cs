using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : Pickup
{
    public float healthBoost = 100f;
    protected override void pickupBehavior()
    {
        player.IncreaseCurrentHealth(healthBoost);
    }
}
