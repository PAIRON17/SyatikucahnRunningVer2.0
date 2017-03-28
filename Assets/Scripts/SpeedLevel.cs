using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//使用シーン(Course)
//プレイヤーの前進速度レベルのクラス
public class SpeedLevel : MonoBehaviour
{
    
    public int[] Speed = new int[] { };
    //限界レベル
    private int MaxLevel;
    //現在のレベル
    private int Level = 0;

    PlayerController pController;

    void Start()
    {
        pController = GetComponent<PlayerController>();
        //限界レベルの設定
        MaxLevel = Speed.Length - 1;
        //初期スピードの設定
        pController.SpeedZ = Speed[Level];
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "SpeedUp")
        {
            //アイテム入手時、レベルをあげる
            SpeedUp();
        }
        
        if(collider.tag == "Obstacle")
        {
            SpeedDown();
        }
    }
    

    void SpeedUp()
    {
        if(MaxLevel > Level)
        {
            Level++;
            pController.SpeedZ = Speed[Level];
        }
    }

    void SpeedDown()
    {
        if (0 < Level)
        {
            Level--;
            pController.SpeedZ = Speed[Level];
            Debug.Log(Level);
        }
    }

}
