using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//使用シーン(Course)
//ゲームの進行を管理するクラス
public class GameController : MonoBehaviour {

    public GameObject Player;
    private PlayerController _controller;
    public GameObject ScoreLogger;
    private ScoreLogger _logger;
    private IEnumerator sceneChange;

    //更新を行うGUI
    public ClockGUI[] CGUI;
    int _cGUICount = 0;
    public ScoreGUI[] SGUI;
    int _sGUICount = 0;
    public ProgressGUI[] PGUI;

    //ノルマとなるスコアの量
    private int _quotaScore = 80;
    //取得中のスコア
    private int _score;

    private bool _isTimer = true;
    private float _timer;
    private float _elapsedTimer;
    private int _hour = 0;
    private int _minute = 0;

    //フェードアウト用の変数
    public GameObject[] GameOverText;
    public Image[] Panel;
    private Animator animator;
    public float FadeSpeed = 0.01f;  //透明化の速さ
    private float alfa;    //A値を操作するための変数
    private float red, green, blue;    //RGBを操作するための変数

    //進捗状況(1~5の5段階)
    private int progress = 1;

    public int QuotaScore
    {
        set
        {
            _quotaScore += value;
        }

        get
        {
            return _quotaScore;
        }
    }

    public int Hour
    {
        get
        {
            return _hour;
        }
    }

    public int Minute
    {
        get
        {
            return _minute;
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
        _controller = Player.GetComponent<PlayerController>();
        animator = Player.GetComponent<Animator>();
        _logger = ScoreLogger.GetComponent<ScoreLogger>();
        _logger.FirstQuota = _quotaScore;
        _score = _controller.Score;
        _cGUICount = CGUI.Length;
        _sGUICount = SGUI.Length;
        red = Panel[0].GetComponent<Image>().color.r;
        green = Panel[0].GetComponent<Image>().color.g;
        blue = Panel[0].GetComponent<Image>().color.b;
    }

    // Update is called once per frame
    void Update()
    {
        //スコアの取得
        _score = _controller.Score;
        //スコアの表示を更新
        for (int i = 0; i < _sGUICount; i++)
        {
            SGUI[i].ScoreTextUpdate(_quotaScore, _score);
            PGUI[i].ProgerssTextUpdate(progress);
        }

        if(_quotaScore -  _score <= 0)
        {
            GameOver();
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_isTimer == true)
        {
            //ゲーム内の時間と進捗状況の計算
            _timer += Time.deltaTime;
            _elapsedTimer += Time.deltaTime;
            _hour = (9 + (int)(_timer / 9f)) % 24;
            _minute = (int)(_timer / 0.15f) % 60;
            int elapsedhour = (int)(_elapsedTimer / 9f);
            progress = ProgressCheck(_score, _quotaScore, elapsedhour);
        }

        //GUIの時間の更新
        for (int i = 0; i < _cGUICount; i++)
        {
            CGUI[i].ClockTextUpdate(_hour, _minute);
        }

        

        //午前0時を過ぎるとゲームオーバー
        if (_hour >= 0 && _hour < 9)
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
        _isTimer = false;
        _logger.Score = _score;
        _logger.Hour = _hour;
        _logger.Minute = _minute;
        sceneChange = SceneChange();
        StartCoroutine(sceneChange);
    }

    private IEnumerator SceneChange()
    {
        animator.speed = 0;
        _controller.ContorolFlag = false;
        for (int i = 0; i < GameOverText.Length; i++)
        {
            GameOverText[i].SetActive(true);
        }
        yield return new WaitForSeconds(1f);
        while (alfa <= 1)
        {
            for (int i = 0; i < Panel.Length; i++)
            {
                Panel[i].GetComponent<Image>().color = new Color(red, green, blue, alfa);
                alfa += FadeSpeed;
            }
            yield return null;
        }
        SceneManager.LoadScene("Result");
    }
}
