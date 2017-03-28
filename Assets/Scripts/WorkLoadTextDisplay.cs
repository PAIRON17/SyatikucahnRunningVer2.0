using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//使用シーン(Result)
//画面に働きぶりを表示するクラス
public class WorkLoadTextDisplay : MonoBehaviour {

    public Text workLoadText;

    public void WorkLoadTextUpdate(int score)
    {
        workLoadText.text = score.ToString();
    }
}
