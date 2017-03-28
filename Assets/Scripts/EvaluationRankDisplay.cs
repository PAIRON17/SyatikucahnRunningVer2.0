using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//使用シーン(Result)
//画面に総合評価を表示するクラス
public class EvaluationRankDisplay : MonoBehaviour {
    public Text EvaluationRankText;

    public void EvaluationRankUpdate(int evaluationRank)
    {
        switch (evaluationRank)
        {
            case 1:
                EvaluationRankText.text = "C";
                break;
            case 2:
                EvaluationRankText.text = "B";
                break;
            case 3:
                EvaluationRankText.text = "A";
                break;
            case 4:
                EvaluationRankText.text = "S";
                break;

        }
    }
}
