using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//使用シーン(Result)
//画面に働きぶりの評価を表示するクラス
public class WorkLoadRankDisplay : MonoBehaviour {

    public Text workLoadRankText;

    public void WorkHourRankUpdate(int hourRank)
    {
        switch (hourRank)
        {
            case 1:
                workLoadRankText.text = "C";
                break;
            case 2:
                workLoadRankText.text = "B";
                break;
            case 3:
                workLoadRankText.text = "A";
                break;
            case 4:
                workLoadRankText.text = "S";
                break;

        }
    }
}
