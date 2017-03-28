using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//使用シーン(Course)
//取得スコア、就業時間を記録するためのクラス
public class ScoreLogger : MonoBehaviour {

    private int score;
    private int firstQuota;
    private int hour;
    private int minute;

    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
        }
    }

    public int FirstQuota
    {
        get
        {
            return firstQuota;
        }
        set
        {
            firstQuota = value;
        }
    }

    public int Hour
    {
        get
        {
            return hour;
        }
        set
        {
            hour = value;
        }
    }

    public int Minute
    {
        get
        {
            return minute;
        }
        set
        {
            minute = value;
        }
    }


	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
	}
	
    public void DestoroyScoreLogger()
    {
        Destroy(gameObject);
    }

}
