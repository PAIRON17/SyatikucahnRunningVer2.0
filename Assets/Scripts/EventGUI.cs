using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//使用シーン(Course)
//ノルマ追加イベントのメッセージウィンドウを表示するクラス
public class EventGUI : MonoBehaviour {

    public GameObject messageWindow;
    public Text eventText;
    private IEnumerator eventTextEnabled;

    public void EventTextDisplay(int progress)
    {
        eventTextEnabled = EventTextEnabled(progress);
        StartCoroutine(eventTextEnabled);
    }

    private IEnumerator EventTextEnabled(int progress)
    {
        switch(progress)
        {
            case 1:
                eventText.text = "上司さん\nなかなか手こずっているね。\nすまないが、この仕事も頼むよ。";
                break;
            case 2:
                eventText.text = "上司さん\n少しペースが遅れてるね。\nすまないが、この仕事も頼むよ。";
                break;
            case 3:
                eventText.text = "上司さん\n順調そうだね。\nこの仕事も頼むよ。";
                break;
            case 4:
                eventText.text = "上司さん\n順調だね。\nこの仕事も任せたよ。";
                break;
            case 5:
                eventText.text = "上司さん\nだいぶ余裕だね。\nこの仕事も任せたよ。";
                break;
        }

        messageWindow.SetActive(true);
        yield return new WaitForSeconds(3f);
        messageWindow.SetActive(false);
    }
}
