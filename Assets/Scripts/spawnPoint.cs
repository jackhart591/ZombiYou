using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnPoint : MonoBehaviour
{
    [Tooltip("enemy, food, ground")]
    [SerializeField] public string spawnType;
    public Vector3 location;
    [SerializeField] public int LeftUpRight;

    private void Start()
    {
        location = transform.position;
    }
}
