using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class statusmanager : MonoBehaviour
{
    public GameObject Main;
    public int HP;
    public int MaxHP;
    public int Score;
    public Image HPgage;
    public float ResetTime = 0;
    public GameObject Effect;
    public AudioSource audioSource;
    public AudioClip HitSE;
    public AudioClip PowerUpSE;
    public bool heal;
    public bool timeplus;
    public bool attackplus;
    public GameSystemManager gamesystemmane;
    public GameTimer timer;
    public float Attackuptimer = 10;
    bool Attackupfirst = true;

    statusmanager p_status;



    Collider mycollider;

    void Start()
    {
        mycollider = GetComponent<Collider>();
        p_status = GameObject.Find("ToonRTS_demo_Knight")
        .GetComponentInChildren<statusmanager>();

    }

    public string TagName;

    private void Update()
    { 
       if(HP <= 0)
        {
            HP = 0;
            var effect = Instantiate(Effect);
            effect.transform.position = transform.position;
            gamesystemmane = GameObject.Find("GameMane").GetComponent<GameSystemManager>();
            gamesystemmane.Score += Score;
            Destroy(effect, 1);
            Destroy(Main);
        }

        if (gameObject.CompareTag("Player"))
        {
            if (heal)
            {
                audioSource.PlayOneShot(PowerUpSE);
                HP += 2;
                if (HP > MaxHP)
                {
                    HP = MaxHP;
                }
                heal = false;
            }
            if (timeplus)
            {
                audioSource.PlayOneShot(PowerUpSE);
                timer.Timer += 8;
                timeplus = false;
            }
        }

        if (attackplus)
        {

            if (Attackupfirst)
            {
                audioSource.PlayOneShot(PowerUpSE);
                Attackupfirst = false;
            }
            Attackuptimer -= Time.deltaTime;
           if (Attackuptimer <= 0)
             {
               Attackuptimer = 10;
               attackplus = false;
                Attackupfirst = true;
            }
        }

        float percent = (float)HP / MaxHP;
        HPgage.fillAmount = percent;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == TagName)
        {
            Damage();
            mycollider.enabled = false; // コライダーを無効化
            Invoke("ColliderReset", ResetTime); // Invoke("関数名", n) n秒後に関数を呼び出す
        }
    }

    void Damage()
    {
        audioSource.PlayOneShot(HitSE);
        if (p_status.attackplus && gameObject.CompareTag("ene"))
        {
            HP -= 2;
        }
        else
        {
            HP--;
        }
    }

    void ColliderReset()
    {
        mycollider.enabled = true;
    }
}
