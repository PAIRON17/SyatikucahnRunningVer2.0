using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//使用シーン(Course)
//ノルマ追加イベントのメッセージウィンドウを表示するクラス
public class EventGUI : MonoBehaviour {

    public GameObject MessageWindow;
    public Text EventText;
    private IEnumerator _eventTextEnabled;

    public void EventTextDisplay(int progress)
    {
        _eventTextEnabled = EventTextEnabled(progress);
        StartCoroutine(_eventTextEnabled);
    }

    private IEnumerator EventTextEnabled(int progress)
    {
        switch(progress)
        {
            case 1:
                EventText.text = "上司さん\nなかなか手こずっているね。\nすまないが、この仕事も頼むよ。";
                break;
            case 2:
                EventText.text = "上司さん\n少しペースが遅れてるね。\nすまないが、この仕事も頼むよ。";
                break;
            case 3:
                EventText.text = "上司さん\n順調そうだね。\nこの仕事も頼むよ。";
                break;
            case 4:
                EventText.text = "上司さん\n順調だね。\nこの仕事も任せたよ。";
                break;
            case 5:
                EventText.text = "上司さん\nだいぶ余裕だね。\nこの仕事も任せたよ。";
                break;
        }

        MessageWindow.SetActive(true);
        yield return new WaitForSeconds(3f);
        MessageWindow.SetActive(false);
    }
}
