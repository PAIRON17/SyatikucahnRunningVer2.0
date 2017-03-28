using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//使用シーン(Result)
//画面に就業時間の評価を表示するクラス
public class WorkingHourRankDisplay : MonoBehaviour {

    public Text workingHourRankText;

    public void WorkHourRankUpdate(int hourRank)
    {
        switch(hourRank)
        {
            case 1:
                workingHourRankText.text = "C";
                break;
            case 2:
                workingHourRankText.text = "B";
                break;
            case 3:
                workingHourRankText.text = "A";
                break;
            case 4:
                workingHourRankText.text = "S";
                break;

        }
    }
}
