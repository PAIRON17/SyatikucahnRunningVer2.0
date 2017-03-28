using UnityEngine;
using System.Collections;

public class ScorePosition : MonoBehaviour {

    public GameObject score;

    // Use this for initialization
    void Start()
    {
        GameObject sc = (GameObject)Instantiate(
                        score,
                        Vector3.zero,
                        Quaternion.identity);

        sc.transform.SetParent(transform, false);
    }

    void OnDrawGizmos()
    {
        Vector3 offset = new Vector3(0, 0.5f, 0);

        Gizmos.color = new Color(255, 255, 255, 0.5f);
        Gizmos.DrawSphere(transform.position + offset, 0.5f);

        if (score != null)
            Gizmos.DrawIcon(transform.position + offset, score.name, true);

    }
}


