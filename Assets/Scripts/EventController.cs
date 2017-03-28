using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//使用シーン(Course)
//ノルマ追加イベントのクラス
public class EventController : MonoBehaviour {

    GameController gController;
    public GameObject PRoom;
    PenaltyRoom penalty;
    public EventGUI EGUI;

    int hour;
    int minute;
    bool[] subEventFlag = new bool[3];
    int progerss;
    bool penaltyFlag;

	// Use this for initialization
	void Start ()
    {
        gController = GetComponent<GameController>();
        penalty = PRoom.GetComponent<PenaltyRoom>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        hour = gController.Hour;
        minute = gController.Minute;
        progerss = gController.Progress;
        penaltyFlag = penalty.Flag;

        if (hour >= 14 && minute >= 30 && subEventFlag[0] == false && penaltyFlag == false)
        {
            EGUI.EventTextDisplay(progerss);
            QuotaAddEventCall(5,10,20,30,35,progerss);
            subEventFlag[0] = true;
        }


    }

    void QuotaAddEventCall(int quota1,int quota2,int quota3,int quota4,int quota5,int progress)
    {

        switch (progerss)
        {
            case 1:
                QuotaAdd(quota1);
                break;
            case 2:
                QuotaAdd(quota2);
                break;
            case 3:
                QuotaAdd(quota3);
                break;
            case 4:
                QuotaAdd(quota4);
                break;
            case 5:
                QuotaAdd(quota5);
                break;
        }

    }

    void QuotaAdd(int quota)
    {
        gController.QuotaScore = quota;
    }

}
