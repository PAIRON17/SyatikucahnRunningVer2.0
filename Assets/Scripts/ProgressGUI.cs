using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//使用シーン(Course)
//画面に進捗状況を表示するクラス
public class ProgressGUI : MonoBehaviour {

    public Text progressText;

    public void ProgerssTextUpdate(int progress)
    {
        switch (progress)
        {
            case 1:
                progressText.text = "大幅な遅れ";
                break;
            case 2:
                progressText.text = "遅れあり";
                break;
            case 3:
                progressText.text = "計画通り";
                break;
            case 4:
                progressText.text = "好調";
                break;
            case 5:
                progressText.text = "絶好調";
                break;
            default:
                progressText.text = "計画通り";
                break;
        } 

    }
}
