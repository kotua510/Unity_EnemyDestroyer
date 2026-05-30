using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class enemanager : MonoBehaviour
{
    public GameObject ene1;
    public GameObject ene2;
    public Transform enePleace1;
    public Transform enePleace2;

    float TimeCount;
    public int MaxCount;
    public int Count;
    void Start()
    {
        
    }

    void Update()
    {
        if (MaxCount <= Count) 
        {
            return;
        }
        TimeCount += Time.deltaTime;
        if (TimeCount > 5)
        {
            Instantiate(ene1, enePleace1.position, Quaternion.identity);
            Count++;
            Instantiate(ene2, enePleace2.position, Quaternion.identity);

            Count++;
            TimeCount = 0;
        }
        
    }
}
