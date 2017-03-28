﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//使用シーン(Course)
//画面に時間を表示するクラス
public class ClockGUI : MonoBehaviour {

    public Text clockText;

    public void ClockTextUpdate(int hour,int minute)
    {
        clockText.text = hour + ":" + minute;
    }

}
