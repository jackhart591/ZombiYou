using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoyCreatorScript : MonoBehaviour
{

    public GameObject center;
    public float size = 20f;
    bool boyMadeForMe = false;
    public GameObject[] grounds;
    public GameObject[] zombies;
    public GameObject[] foods;
    public GameObject[] items;
    public List<Vector3> currentPossiblePositions = new List<Vector3>();

    void Start()
    {
        size = transform.localScale.x;
    }

    void MakeTwoOtherBois(Vector3 relativepos)
    {

        Component[] sps = transform.parent.gameObject.GetComponentsInChildren<spawnPoint>();
        for (int i = 0; i < sps.Length; i++)
        {
            if (sps[i].transform.GetComponent<spawnPoint>().spawnType == "ground")
            {
                if (relativepos.x > 0)
                {
                    if (sps[i].transform.GetComponent<spawnPoint>().LeftUpRight == 2 || sps[i].transform.GetComponent<spawnPoint>().LeftUpRight == 3)
                    {
                        currentPossiblePositions.Add(sps[i].transform.GetComponent<spawnPoint>().location);
                    }
                }
                if (relativepos.x < 0)
                {
                    if (sps[i].transform.GetComponent<spawnPoint>().LeftUpRight == 2 || sps[i].transform.GetComponent<spawnPoint>().LeftUpRight == 1)
                    {
                        currentPossiblePositions.Add(sps[i].transform.GetComponent<spawnPoint>().location);
                    }
                }
                if (relativepos.y > 0)
                {
                    if (sps[i].transform.GetComponent<spawnPoint>().LeftUpRight == 1 || sps[i].transform.GetComponent<spawnPoint>().LeftUpRight == 3)
                    {
                        currentPossiblePositions.Add(sps[i].transform.GetComponent<spawnPoint>().location);
                    }
                }
            }
        }

        Instantiate(grounds[Mathf.RoundToInt(Random.Range(0f, 3f))], currentPossiblePositions[0], transform.rotation);
        Instantiate(grounds[Mathf.RoundToInt(Random.Range(0f, 3f))], currentPossiblePositions[1], transform.rotation);
        currentPossiblePositions.Clear();
    }

    void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(center.transform.position, transform.localScale.x);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.transform.gameObject.tag == "Player")
            {
                if (!boyMadeForMe)
                {
                    MakeTwoOtherBois(center.transform.position - hitCollider.transform.position);
                    boyMadeForMe = true;
                }
            }
        }
    }
}
