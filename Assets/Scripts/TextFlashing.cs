using UnityEngine;
using UnityEngine.UI;

//使用シーン(汎用)
//テキストを点滅させるクラス
public class TextFlashing : MonoBehaviour {
    public Text text;
    float color;
    bool flag;
    // Use this for initialization
    void Start()
    {
        color = 0;
    }
    // Update is called once per frame
    void Update()
    {
        //テキストの透明度を変更する
        text.color = new Color(0, 0, 0, color);
        if (flag)
        {
            color -= Time.deltaTime;
        }
        else
        {
            color += Time.deltaTime;
        }

        if (color < 0)
        {
            color = 0;
            flag = false;
        }
        else if (color > 1)
        {
            color = 1;
            flag = true;
        }
    }
}