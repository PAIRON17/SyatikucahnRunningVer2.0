﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//使用シーン(Course)
//プレイヤーに関するクラス
public class PlayerController : MonoBehaviour
{
    //プレイヤーの移動に必要なの変数
    const int _minLane = -3;
    const int _maxLane = 3;
    const float _laneWidth = 1.0f;

    CharacterController controller;
    Animator animator;

    Vector3 moveDirection = Vector3.zero;
    private int _targetLane;

    public float Gravity;
    private float _speedZ;
    public float SpeedX;
    public float SpeedJump;
    public float AccelerationZ;
    private bool _isControl = true;


    //プレイヤーが障害物に接触した処理に必要な変数
    public Camera playerCamera;
    public GameObject penaltyRoom;
    PenaltyRoom penalty;

    //プレイヤーがスコアを取得した処理に必要な変数
    private int score = 0;

    //フェードアウト用の変数
    public Image panel;
    public float speed = 0.01f;  //透明化の速さ
    private float alfa;    //A値を操作するための変数
    private float red, green, blue;    //RGBを操作するための変数


    public float SpeedZ
    {
        set
        {
            _speedZ = value;
        }
    }

    public int Score
    {
        get
        {
            return score;
        }
    }

    public bool ContorolFlag
    {
        set
        {
            _isControl = value;
        }
    }



	// Use this for initialization
	void Start ()
    {
	    controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        red = panel.GetComponent<Image>().color.r;
        green = panel.GetComponent<Image>().color.g;
        blue = panel.GetComponent<Image>().color.b;
        penalty = penaltyRoom.GetComponent<PenaltyRoom>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (_isControl == true)
        {
            if (Input.GetButtonDown("Left"))
                MoveToLeft();
            if (Input.GetButtonDown("Right"))
                MoveToRight();
            if (Input.GetButtonDown("Jump"))
                Jump();
        }
        else
        {
            moveDirection.z = 0;
        }
        //徐々に加速しZ方向に常に前進させる
        float acceleratedZ = moveDirection.z + (AccelerationZ * Time.deltaTime);
        moveDirection.z = Mathf.Clamp(acceleratedZ, 0, _speedZ);

        //X方向は目標のポジションまでの差分の割合で速度を計算
        float ratioX = (_targetLane * _laneWidth - transform.position.x) / _laneWidth;
        moveDirection.x = ratioX * SpeedX;

        //重力分の力を毎フレーム追加
        moveDirection.y -= Gravity * Time.deltaTime;

        //移動実行
        Vector3 globalDirecton = transform.TransformDirection(moveDirection);
        controller.Move(globalDirecton * Time.deltaTime);
        
        //移動後接地してたらY方向の速度はリセットする。
        if (controller.isGrounded)
        {
            moveDirection.y = 0;
            animator.SetBool("jump", false);
            animator.SetBool("run", true);
        }



	}

    //当たり判定
    void OnTriggerEnter(Collider collider)
    {
        //障害物に接触した時
        if (collider.tag == "Obstacle")
        {
            penalty.Flag = true;
            StartCoroutine(CameraChange());
        }

        //スコア入手時
        if (collider.tag == "ScoreItem")
        {
            score += 1;
        }
    }
    

    //カメラの切り替え
    private IEnumerator CameraChange()
    {
        _isControl = false;
        animator.SetBool("blowoff", true);
        while (alfa <= 1)
        {
            panel.GetComponent<Image>().color = new Color(red, green, blue, alfa);
            alfa += speed;
            yield return null;
        }
        penaltyRoom.SetActive(true);
        playerCamera.enabled = false;
        animator.SetBool("blowoff", false);
        alfa = 0;
        panel.GetComponent<Image>().color = new Color(red, green, blue, alfa);
        enabled = false;
        _isControl = true;
    }

    public void MoveToLeft()
    {
        if (_targetLane > _minLane)
            _targetLane--;
    }

    public void MoveToRight()
    {
        if (_targetLane < _maxLane)
            _targetLane++;
    }

    public void Jump()
    {
        if (controller.isGrounded)
        {
            moveDirection.y = SpeedJump;
            animator.SetBool("run", false);
            animator.SetBool("jump", true);
        }
    }

    
}


