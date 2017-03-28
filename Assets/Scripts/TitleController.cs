using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//使用シーン(Title)
//タイトルの制御クラス
public class TitleController : MonoBehaviour {

    //フェードアウト用の変数
    public Image panel;
    public float speed = 0.01f;  //透明化の速さ
    float alfa;    //A値を操作するための変数
    float red, green, blue;    //RGBを操作するための変数
    private IEnumerator scenechange;

    void Start()
    {
        red = panel.GetComponent<Image>().color.r;
        green = panel.GetComponent<Image>().color.g;
        blue = panel.GetComponent<Image>().color.b;
    }

    // Update is called once per frame
    void Update ()
    {
		if(Input.GetButtonDown("Jump"))
        {
            scenechange = SceneChange();
            StartCoroutine(scenechange);
        }
	}

    private IEnumerator SceneChange()
    {
        while (alfa <= 1)
        {
            panel.GetComponent<Image>().color = new Color(red, green, blue, alfa);
            alfa += speed;
            yield return null;
        }

        SceneManager.LoadScene("Course");
    }

}
