using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpMane : MonoBehaviour
{
    public GameObject HealArea;
    public GameObject AttackArea;
    public GameObject TimeArea;
    float TimeCount;
    public int MaxCount;
    public int Count;
    private GameObject[] Areas;
    public LayerMask GroundLayer;

    void Start()
    {
        Areas = new GameObject[]
    {
        HealArea,
        AttackArea,
        TimeArea
    };
    }

    void Update()
    {
        if (MaxCount <= Count)
        {
            return;
        }

        TimeCount += Time.deltaTime;
        if (TimeCount > 3)
        {
            SpawnArea();
            Count++;
            TimeCount = 0;
        }
    }

    void SpawnArea()
    {
        float x = Random.Range(57, 73);
        float z = Random.Range(97, 132);
        Vector3 pos = new Vector3(x,300, z);

        RaycastHit hit;
        if (Physics.Raycast(pos, Vector3.down, out hit, 500f, GroundLayer))
        {
            Vector3 spawnPos = hit.point;
            GameObject area =Areas[Random.Range(0, Areas.Length)];
            Instantiate(
                area,
                spawnPos,
                Quaternion.identity
            );
            Debug.Log("âÒïúÉGÉäÉAê∂ê¨:" + spawnPos);
        }
    }
}