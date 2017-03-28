using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//使用シーン(Course)
//ゲームの進行を管理するクラス
public class GameController : MonoBehaviour {

    public GameObject player;
    PlayerController controller;
    public GameObject scoreLogger;
    ScoreLogger logger;
    private IEnumerator sceneChange;

    //更新を行うGUI
    public ClockGUI[] CGUI;
    int cGUICount = 0;
    public ScoreGUI[] SGUI;
    int sGUICount = 0;
    public ProgressGUI[] PGUI;

    //ノルマとなるスコアの量
    private int quotaScore = 80;
    //取得中のスコア
    int score;

    bool timerFlag = true;
    float timer;
    private float elapsedtimer;
    private int hour = 0;
    private int minute = 0;

    //フェードアウト用の変数
    public GameObject[] gameOverText;
    public Image[] panel;
    Animator animator;
    public float fadeSpeed = 0.01f;  //透明化の速さ
    float alfa;    //A値を操作するための変数
    float red, green, blue;    //RGBを操作するための変数

    //進捗状況(1~5の5段階)
    private int progress = 1;

    public int QuotaScore
    {
        set
        {
            quotaScore += value;
        }

        get
        {
            return quotaScore;
        }
    }

    public int Hour
    {
        get
        {
            return hour;
        }
    }

    public int Minute
    {
        get
        {
            return minute;
        }
    }

    public int Progress
    {
        get
        {
            return progress;
        }

    }
     
    // Use this for initialization
    void Start()
    {
        controller = player.GetComponent<PlayerController>();
        animator = player.GetComponent<Animator>();
        logger = scoreLogger.GetComponent<ScoreLogger>();
        logger.FirstQuota = quotaScore;
        score = controller.Score;
        cGUICount = CGUI.Length;
        sGUICount = SGUI.Length;
        red = panel[0].GetComponent<Image>().color.r;
        green = panel[0].GetComponent<Image>().color.g;
        blue = panel[0].GetComponent<Image>().color.b;
    }

    // Update is called once per frame
    void Update()
    {
        //スコアの取得
        score = controller.Score;
        //スコアの表示を更新
        for (int i = 0; i < sGUICount; i++)
        {
            SGUI[i].ScoreTextUpdate(quotaScore, score);
            PGUI[i].ProgerssTextUpdate(progress);
        }

        if(quotaScore -  score <= 0)
        {
            GameOver();
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (timerFlag == true)
        {
            //ゲーム内の時間と進捗状況の計算
            timer += Time.deltaTime;
            elapsedtimer += Time.deltaTime;
            hour = (9 + (int)(timer / 9f)) % 24;
            minute = (int)(timer / 0.15f) % 60;
            int elapsedhour = (int)(elapsedtimer / 9f);
            progress = ProgressCheck(score, quotaScore, elapsedhour);
        }

        //GUIの時間の更新
        for (int i = 0; i < cGUICount; i++)
        {
            CGUI[i].ClockTextUpdate(hour, minute);
        }

        

        //午前0時を過ぎるとゲームオーバー
        if (hour >= 0 && hour < 9)
        {
            GameOver();
        }

    }


    //進捗状況の計算
    int ProgressCheck(int score, int quota, int elapsedhour)
    {
        int hourquota = quota / 8;
        int progress = hourquota * elapsedhour;
        if (score - progress <= -15)
        {
            return 1;
        }else if (score - progress >= -14 && score - progress <= -6)
        {
            return 2;
        }else if (score - progress >= -5 && score - progress <= 5)
        {
            return 3;
        }else if (score - progress >= 6 && score - progress <= 14)
        {
            return 4;
        }else
        {
            return 5;
        }

    }

    void GameOver()
    {
        timerFlag = false;
        logger.Score = score;
        logger.Hour = hour;
        logger.Minute = minute;
        sceneChange = SceneChange();
        StartCoroutine(sceneChange);
    }

    private IEnumerator SceneChange()
    {
        animator.speed = 0;
        controller.ContorolFlag = false;
        for (int i = 0; i < gameOverText.Length; i++)
        {
            gameOverText[i].SetActive(true);
        }
        yield return new WaitForSeconds(1f);
        while (alfa <= 1)
        {
            for (int i = 0; i < panel.Length; i++)
            {
                panel[i].GetComponent<Image>().color = new Color(red, green, blue, alfa);
                alfa += fadeSpeed;
            }
            yield return null;
        }
        SceneManager.LoadScene("Result");
    }
}
