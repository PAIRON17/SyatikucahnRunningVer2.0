using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//使用シーン(Course)
//障害物接触後のペナルティのクラス
public class PenaltyRoom : MonoBehaviour
{
    public SpeedLevel speedlevel;
    public Camera penaltyCamera;
    public GameObject penaltyRoom;
    public Camera playerCamera;
    public PlayerController playerController;
    public Animator animator;
    public UnrivaledTime UTime;
    float timer = 0f;
    float penaltyTime = 9f;
    private bool penaltyFlag;

    //フェードアウト用の変数
    public Image panel;
    public float speed = 0.01f;  //透明化の速さ
    float alfa;    //A値を操作するための変数
    float red, green, blue;    //RGBを操作するための変数
    private IEnumerator cameraChange;

    public bool Flag
    {
        get
        {
            return penaltyFlag;
        }

        set
        {
            penaltyFlag = value;
        }
    }

    void Start()
    {
        red = panel.GetComponent<Image>().color.r;
        green = panel.GetComponent<Image>().color.g;
        blue = panel.GetComponent<Image>().color.b;
    }

	// Update is called once per frame
	void Update ()
    {
        timer += Time.deltaTime;

        if (Input.GetButtonDown("Jump"))
        {
            timer += 0.5f;
        }

        if (penaltyTime <= timer)
        {
            cameraChange = CameraChange();
            StartCoroutine(cameraChange);
            timer = 0f;
        }
	}



    private IEnumerator CameraChange()
    {
        animator.SetBool("sleep", false);
        animator.SetBool("awake", true);
        while (alfa <= 1)
        {
            panel.GetComponent<Image>().color = new Color(red, green, blue, alfa);
            alfa += speed;
            yield return null;
        }
        alfa = 0;
        panel.GetComponent<Image>().color = new Color(red, green, blue, alfa);
        UTime.enabled = true;
        playerCamera.enabled = true;
        playerController.enabled = true;
        alfa = 0;
        panel.GetComponent<Image>().color = new Color(red, green, blue, alfa);
        animator.SetBool("sleep", true);
        animator.SetBool("awake", false);
        penaltyRoom.SetActive(false);
        penaltyFlag = false;
    }
}
