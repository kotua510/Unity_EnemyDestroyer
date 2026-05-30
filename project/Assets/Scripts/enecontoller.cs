using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enecontoller : MonoBehaviour
{
    public float EnemySpeed;
    GameObject Target;
    float Timer;
    public float ChangeTime;
    void Start()
    {

    }
    void Update()
    {
        var speed = Vector3.zero;
        speed.z = EnemySpeed;
        var rot = transform.eulerAngles;

        if (Target)
        {
            transform.LookAt(Target.transform); // ターゲットの方向を向く
            rot = transform.eulerAngles;
        }
        else
        {
            Timer += Time.deltaTime;      
            if(ChangeTime <= Timer)
            {
                float rand = Random.Range(0, 360);
                rot.y = rand;
                Timer = 0;
            }
        }
        rot.x = 0;
        rot.z = 0;
        transform.eulerAngles = rot;
        //y軸以外の回転を0にすることで、敵が常に水平に移動するようにする
        this.transform.Translate(speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Target = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other) //範囲から出たらの処理
    { 
         if (other.tag == "Player")
        {
        Target = null;
          }
    }

}

