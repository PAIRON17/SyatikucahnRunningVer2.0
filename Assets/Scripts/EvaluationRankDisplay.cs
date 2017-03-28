using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//使用シーン(Result)
//画面に総合評価を表示するクラス
public class EvaluationRankDisplay : MonoBehaviour {
    public Text evaluationRankText;

    public void EvaluationRankUpdate(int evaluationRank)
    {
        switch (evaluationRank)
        {
            case 1:
                evaluationRankText.text = "C";
                break;
            case 2:
                evaluationRankText.text = "B";
                break;
            case 3:
                evaluationRankText.text = "A";
                break;
            case 4:
                evaluationRankText.text = "S";
                break;

        }
    }
}
