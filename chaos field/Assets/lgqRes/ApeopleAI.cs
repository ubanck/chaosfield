using UnityEngine;
using System.Collections;
using DG.Tweening;

public class ApeopleAI : MonoBehaviour {
	public float trackTime=0.5f;
	public float trackTimer;
	public bool  isNeedTrack=true;
	public float trackDis = 20f;
	public Transform playerTf;
	public float toPlayerDis=0;
	public float stopDis=0.5f;
	void Start () 
	{
		playerTf = GameManager.Instance.playerGo.transform;
		GameManager.Instance.enemy_count++;
	}

	void Update () {

		if(!GameManager.Instance.fp.isPalyAni)
		{
			return;
		}

		trackTimer += Time.deltaTime;
		toPlayerDis = Vector3.Distance (transform.position, playerTf.position);
		if (isNeedTrack) 
		{
			if (trackTimer > trackTime) 
			{
				trackTimer = 0;
				if (toPlayerDis<trackDis)
				{
					transform.DOLookAt (playerTf.position, 1f);
//					if (stopDis < toPlayerDis) {
//						transform.DOKill ();
//					} else {
//						
//					}
					transform.DOMove (playerTf.position,5);
				}

			}
		}
	}
	void OnTriggerStay(Collider other)
	{
		
		if (other.tag.Equals ("Player"))
		{
			isNeedTrack = false;
			transform.DOLookAt (other.transform.position, 1f);
			if (stopDis < toPlayerDis) {
				transform.DOMove (playerTf.position,5);
			}


		}
	}
	void OnTriggerExit(Collider other)
	{
		if (other.tag.Equals ("Player"))
		{
			isNeedTrack = true;
		}
	}

	void OnTriggerEnter(Collider col)
	{
		// call a ui for game stop
		//感染者被主角碰到，值归一
		if (col.tag.Equals ("Player"))
		{
			GameManager.Instance.currentHp = -1;
		}
	}

}
