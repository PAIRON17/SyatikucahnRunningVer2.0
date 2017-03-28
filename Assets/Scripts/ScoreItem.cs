using UnityEngine;
using System.Collections;

//使用シーン(Course)
//スコアアイテムのクラス
public class ScoreItem : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Destroy(gameObject);
        }

    }
    
}
