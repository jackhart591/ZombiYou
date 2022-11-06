using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : Pickup
{
    protected override void pickupBehavior()
    {
        player.IncreaseCurrentHealth(1f);
    }
}
