using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyListManager : MonoBehaviour
{
    // 敵リストの初期化
    public List<Transform> EnemyList = new List<Transform>();
    void Update()
    {
        //リスト内で重複しないようにする
        for (int i = 0; i < EnemyList.Count; i++)
        {
            //次のやつから比較
            for (int k = i + 1; k < EnemyList.Count; k++)
            {
                //重複していたら削除
                if (EnemyList[i] == EnemyList[k])
                {
                    EnemyList.RemoveAt(k);
                }
            }

            //敵が削除済みならリストからも削除
            if (!EnemyList[i])
            {
                EnemyList.RemoveAt(i);
            }
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "ene")
        {
            //敵のtransformをリストに追加(位置や大きさ、回転)
            EnemyList.Add(collider.gameObject.transform);
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if(collider.tag == "ene")
        {
            //リスト名.Countでリストの数を取得
            for (int i = 0; i < EnemyList.Count; i++)
            {
                //リストの同じ敵を削除
                if (EnemyList[i] == collider.gameObject.transform)
                {
                    EnemyList.RemoveAt(i);
                }
            }
        }
    }
}
