using UnityEngine;
using System.Collections;

//使用シーン(Course)
//カメラがプレイヤーを背後から追いかけるクラス
public class CameraFollow : MonoBehaviour {

    private Vector3 _diff;

    public GameObject Target;
    public float FollowSpeed;

	// Use this for initialization
	void Start () {
        _diff = Target.transform.position - transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = Vector3.Lerp(
            transform.position,
            Target.transform.position - _diff,
            Time.deltaTime * FollowSpeed
        );
	}
}
