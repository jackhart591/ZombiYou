using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDScript : MonoBehaviour {
    [SerializeField] private Player player;

    [SerializeField] private Text HealthText;
    [SerializeField] private Text ThirstText;

    public void Update() {
        HealthText.text = $"Health: {player.Health}/{player.MaxHealth}";
        ThirstText.text = $"Thirst: {(int)player.Thirst}/{player.MaxThirst}";
    }
}
