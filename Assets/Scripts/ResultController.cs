using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//使用シーン(Result)
//Resultシーンの制御クラス
public class ResultController : MonoBehaviour {

    public GameObject scoreLogger;
    ScoreLogger logger;
    public WorkingHourTextDisplay workingHourText;
    public WorkingHourRankDisplay workingHourRankText;
    public WorkLoadTextDisplay workLoadText;
    public WorkLoadRankDisplay workLoadRankText;
    public EvaluationRankDisplay evaluationRankText;
    int score;
    int quptaScore;
    int hour;
    int minute;
    int hourRank;
    int workingRank;
    int evaluationRank;


	// Use this for initialization
	void Start () {
        scoreLogger = GameObject.Find("ScoreLogger");
        logger = scoreLogger.GetComponent<ScoreLogger>();
        score = logger.Score;
        quptaScore = logger.FirstQuota;
        hour = logger.Hour;
        minute = logger.Minute;
        logger.DestoroyScoreLogger();
        workingHourText.WorkingHourTextUpdate(hour, minute);
        workLoadText.WorkLoadTextUpdate(score);
        hourRank = WorkingHourRanking(hour, minute);
        workingHourRankText.WorkHourRankUpdate(hourRank);
        workingRank = WorkLoadRanking(score, quptaScore);
        workLoadRankText.WorkHourRankUpdate(workingRank);
        evaluationRank = EvaluationRanking(hourRank, workingRank);
        evaluationRankText.EvaluationRankUpdate(evaluationRank);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Jump"))
        {
            SceneManager.LoadScene("Title");
        }
        Debug.Log(WorkingHourRanking(hour,minute));
	}

    int WorkingHourRanking(int hour,int minute)
    {
        if(hour >= 0 && (hour <= 8 && minute <= 59))
        {
            return 1;
        }else if(hour >= 9 && (hour <= 16 && minute <=59))
        {
            return 3;
        }else if((hour == 17 && minute >= 1) && (hour == 17 && minute <= 59))
        {
            return 4;
        }else
        {
            return 2;
        }

    }

    int WorkLoadRanking(int score,int quota)
    {
        if(score < quota)
        {
            return 1;
        }else if(quota <= score && score <= quota + 20)
        {
            return 2;
        }else if(quota + 20 < score && score <= quota + 30)
        {
            return 3;
        }else
        {
            return 4;
        }
    }

    int EvaluationRanking(int hRank,int wRank)
    {
        double ave = ((double)hRank + wRank)/2 + 0.5;
        return (int)ave;
    }

}
