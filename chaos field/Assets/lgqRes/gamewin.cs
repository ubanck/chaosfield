using UnityEngine;
using System.Collections;

public class gamewin : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        //确定碰撞方为主角
        if (col.tag.Equals("Player"))
        {
            if (GameManager.Instance.doorOpenCount==4)
            {
                //set game win's tag
				GameManager.Instance.passUI.SetActive(true);
				GameManager.Instance.fp.isPalyAni = false;
            }
        }
    }

}
