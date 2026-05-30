using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoller : MonoBehaviour
{
    public Transform Camera;
    public float PlayerSpeed;
    public float RotationSpeed;

    Vector3 speed = Vector3.zero;
    Vector3 rot = Vector3.zero;
    float cameraX;

    public Animator PlayerAnimator;
    bool isrun;

    public Collider WeaponCollider;
    public AudioSource audioSource;
    public AudioClip AttackSE;
    public GameTimer timer;

    public EnemyListManager EnemyListManager;
    public Transform Target;
    int TargetCount;

    void Start()
    {
        WeaponCollider.enabled = false;
    }

    void Update()
    {
        if (timer.Timer > 0)
        {
            Move();
            Rotation();
            Attack();
            TargetLook();
            Camera.transform.position = transform.position;
        }
    }

    void Move()
    {
        speed = Vector3.zero;
        rot = Vector3.zero;
        isrun = false;

        if (Input.GetKey(KeyCode.W))
        {
            rot.y = 0;
            MoveSet();
        }

        if (Input.GetKey(KeyCode.S))
        {
            rot.y = 180;
            MoveSet();
        }

        if (Input.GetKey(KeyCode.A))
        {
            rot.y = -90;
            MoveSet();
        }

        if (Input.GetKey(KeyCode.D))
        {
            rot.y = 90;
            MoveSet();
        }

        transform.Translate(speed);
        PlayerAnimator.SetBool("run", isrun);

    }

    void MoveSet()
    {
        speed.z = PlayerSpeed;
        Vector3 angle = transform.eulerAngles;
        angle.y = Camera.transform.eulerAngles.y + rot.y;
        transform.eulerAngles = angle;
        isrun = true;
    }

    void Rotation()
    {
        var speed = Vector3.zero;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            speed.y = -RotationSpeed;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            speed.y = RotationSpeed;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            cameraX -= RotationSpeed;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            cameraX += RotationSpeed;
        }

        cameraX = Mathf.Clamp(cameraX, -45, 30);
        Camera.transform.eulerAngles =
        new Vector3(
            cameraX,
            Camera.transform.eulerAngles.y + speed.y,
            0
        );
    }

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerAnimator.SetBool("attck", true);
            audioSource.PlayOneShot(AttackSE);
        }
    }

    public void WeaponON()
    {
        WeaponCollider.enabled = true;
        Debug.Log("ON");
    }

    public void WeaponOFF()
    {
        WeaponCollider.enabled = false;
        Debug.Log("OFF");
        PlayerAnimator.SetBool("attck", false);
    }

    void TargetLook()
    {
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            if (EnemyListManager.EnemyList.Count == 0)
            {
                return;
            }
        
            if (EnemyListManager.EnemyList.Count <= TargetCount)
             {
                TargetCount = 0;
             }
            Target = EnemyListManager.EnemyList[TargetCount];
            TargetCount++;
        }

        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            Target = null;
        }

        if (Target)
        {
            //ターゲットの座標を保管
            var pos = Vector3.zero;
            pos = Target.position;
            //カメラが上下しないようにy軸のみカメラ準拠
            pos.y = Camera.transform.position.y;
            Camera.transform.LookAt(pos);
        }
    }
}

