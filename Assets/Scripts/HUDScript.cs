using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDScript : MonoBehaviour {
    [SerializeField] private Player player;

    [SerializeField] private Text HealthText;

    public void Update() {
        HealthText.text = $"Health: {player.Health}/{player.MaxHealth}";
    }
}
