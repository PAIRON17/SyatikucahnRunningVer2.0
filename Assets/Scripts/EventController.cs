using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//使用シーン(Course)
//ノルマ追加イベントのクラス
public class EventController : MonoBehaviour {

    private GameController _gameController;
    public GameObject PenaltyRoom;
    private PenaltyRoom _penalty;
    public EventGUI EventGUI;

    private int _hour;
    private int _minute;
    private bool[] _isSubEvent = new bool[3];
    private int _progerss;
    private bool _isPenalty;

	// Use this for initialization
	void Start ()
    {
        _gameController = GetComponent<GameController>();
        _penalty = PenaltyRoom.GetComponent<PenaltyRoom>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        _hour = _gameController.Hour;
        _minute = _gameController.Minute;
        _progerss = _gameController.Progress;
        _isPenalty = _penalty.Flag;

        if (_hour >= 14 && _minute >= 30 && _isSubEvent[0] == false && _isPenalty == false)
        {
            EventGUI.EventTextDisplay(_progerss);
            QuotaAddEventCall(5,10,20,30,35,_progerss);
            _isSubEvent[0] = true;
        }


    }

    void QuotaAddEventCall(int quota1,int quota2,int quota3,int quota4,int quota5,int progress)
    {

        switch (_progerss)
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
        _gameController.QuotaScore = quota;
    }

}
