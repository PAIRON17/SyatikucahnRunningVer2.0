using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//使用シーン(Result)
//画面に就業時間を表示するクラス
public class WorkingHourTextDisplay : MonoBehaviour {

    public Text workingHourText;

    public void WorkingHourTextUpdate(int hour,int minute)
    {
        workingHourText.text = hour + ":" + minute;
    }

}
