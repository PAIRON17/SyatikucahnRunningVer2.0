using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//使用シーン(Course)
//画面に残りノルマを表示するクラス
public class ScoreGUI : MonoBehaviour {

    public Text scoreText;

    public void ScoreTextUpdate(int quotaScore,int score)
    {
        scoreText.text = (quotaScore - score) + "/" + quotaScore;
    }
}
