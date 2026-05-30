using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HealAreaMana : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip PowerUpSe;
    PowerUpMane pwm;
    void Start()
    {
        pwm =
        GameObject.Find("powerupmane")
        .GetComponent<PowerUpMane>();
    }

    void Update()
    {

    }

    void OnTriggerEnter(Collider collider)
    {
        statusmanager status =
            collider.GetComponent<statusmanager>();

        if (status != null && collider.CompareTag("Player"))
        {
            status.heal = true;
            audioSource.PlayOneShot(PowerUpSe);

            Destroy(gameObject);
            pwm.GetComponent<PowerUpMane>().Count -= 1;
        }
    }
}
