using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//使用シーン(Course)
//無敵時間クラス
public class UnrivaledTime : MonoBehaviour {

    [SerializeField]
    private float endingTime;//無敵時間の設定
    private bool stayFlag;//障害物の接触判定
    private bool endFlag;//無敵時間終了判定

    public GameObject[] Renderer;
    private int RenderderRange;
    private float interval = 0.25f;

    void OnEnable()
    {
        RenderderRange = Renderer.Length;
        StartCoroutine(unrivaledOn(endingTime));
        StartCoroutine(Blink());
    }

    void OnDisable()
    {
        endFlag = false;
    }

    void OnTriggerStay(Collider collider)
    {
        //プレイヤーが障害物に接触しているか
        if (collider.tag == "ObstacleStay")
        {
            stayFlag = true;
            Debug.Log("in");
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "ObstacleStay")
        {
            stayFlag = false;
            Debug.Log("out");
        }
    }

    //無敵時の障害物の透過処理
    private IEnumerator unrivaledOn(float endingTime)
    {
        gameObject.layer = LayerName.UnrivaledPlayer;
        yield return new WaitForSeconds(endingTime);
        while (true)
        {
            if (stayFlag == false)
            {
                endFlag = true;
                gameObject.layer = LayerName.Player;
                yield break;
            }
            yield return null;
        }
    }

    private IEnumerator Blink()
    {
        while (true)
        {
            if (endFlag == true)
            {
                GetComponent<UnrivaledTime>().enabled = false;
                yield break;
            }
            else
            {
                for (int i = 0; i < RenderderRange; i++)
                {
                    Renderer[i].SetActive(false);
                }
                yield return new WaitForSeconds(interval);

                for (int i = 0; i < RenderderRange; i++)
                {
                    Renderer[i].SetActive(true);
                }
                yield return new WaitForSeconds(interval);
            }
            yield return null;
        }
    }
}
