using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//使用シーン(Course)
//スピードアップアイテムのクラス
public class SpeedUpItem : MonoBehaviour {

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

}
