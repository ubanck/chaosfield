using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

//[ExecuteInEditMode]
public class GameManager : MonoBehaviour {
	public GameObject peoplePrefab;//产生的人物的预设
	public float timer;//全局计时器
	public float spawnTime=5f;
	public Transform enterPoint;
	public Transform container;
	public int queueNum=5;
	public float disQueue=3;//排队的距离间隔
	public Queue<GameObject> peopleQueue;
	public int spawnCount=0;
	public GameObject playerGo;

	public Transform uitrans;
	public int second;
	public string timeStr="0:00";

	public int infect_count, enemy_count;

	//记分相关
	public int currentHp=0;
	public int maxHp = 5;
	public float selfHealTimer=0;
	public float selfHealTime=5;//自愈时间间隔

	public int doorOpenCount = 0;

	public bool isPlay = false;
	public Transform maiUI;
	public GameObject dieUI;
	public GameObject teamUI;
	public GameObject passUI;

	public FollowPerson fp;
	private static GameManager instance;
	public static  GameManager Instance
	{
		get
		{ 
			if (!instance)
			{
				instance = GameObject.FindObjectOfType (typeof(GameManager)) as GameManager;
				if (!instance)
				{
					GameObject container = new GameObject ();
					container.name = "GameManager";
					instance = container.AddComponent(typeof(GameManager)) as GameManager;
				}
			}
			return instance;
		}

	}
	void Start () {
		InitGame ();
	}
	void InitGame ()
	{
		InvokeRepeating("func", 0, 1f);
		//fp.enabled = false;
		peopleQueue = new Queue<GameObject> ();
		for (int i = 0; i < queueNum; i++) {
			GameObject go=Instantiate(peoplePrefab,enterPoint.position+new Vector3(disQueue,0,0)*i,Quaternion.Euler(new Vector3(0f,270f,0f))) as GameObject;
			spawnCount++;
			go.name += spawnCount;
			go.transform.SetParent(container);
			peopleQueue.Enqueue (go);
		}


	}

	void Update () {
		timer += Time.deltaTime;
		selfHealTimer += Time.deltaTime;
		if (selfHealTimer > selfHealTime) {
			selfHealTimer = 0;
			if(currentHp>0)
			currentHp -= 1;
		}

		if (currentHp > maxHp) {
			//dieUI.SetActive (true);
			gameOver();
		}

		if (timer > spawnTime) {
			timer = 0;
			GameObject go=peopleQueue.Dequeue ();
			go.GetComponent<PeopleMove> ().isMove = true;
			//新创建一个
			GameObject newgo=Instantiate(peoplePrefab,enterPoint.position+new Vector3(disQueue,0,0)*queueNum,Quaternion.Euler(new Vector3(0f, 270f, 0f))) as GameObject;
			spawnCount++;
			newgo.name += spawnCount;
			newgo.transform.SetParent(container);
			peopleQueue.Enqueue (newgo);
		
			foreach (GameObject g in peopleQueue)
			{
				g.transform.DOMoveX (g.transform.position.x -disQueue, 1);
			}
		}

		updateUI ();

		if (doorOpenCount == 4) 
		{
			//Debug.LogWarning ("all door is open");
		}

		if (currentHp < 0) 
		{
			dieUI.SetActive (true);

			//fp.isPalyAni = false;
		}
	}

	void updateUI()
	{
		uitrans.GetComponent<UIManager>().set_ui_value(timeStr, currentHp, infect_count, enemy_count);
	}

	void func()
	{
		if (!fp.isPalyAni) {
			return;
		}
		second++;

		int h = second / 3600;
		int m = (second % 3600) / 60;
		int s = (second % 3600) % 60;

		timeStr = h+":"+m+":"+s;

	}
	public void beginGame()
	{
		isPlay = true;
		//fp.enabled = true;
		maiUI.gameObject.SetActive (false);
		Camera.main.GetComponent<DOTweenPath> ().DOPlay();
		Camera.main.GetComponent<DOTweenAnimation> ().DOPlay();
	}

	public void gameOver()
	{
		currentHp = -1;
	}

	public void showTeam()
	{
		maiUI.gameObject.SetActive (false);
		teamUI.gameObject.SetActive (true);
	}

	public void closeTeam()
	{
		maiUI.gameObject.SetActive (true);
		teamUI.gameObject.SetActive (false);
	}

//	public void restartGame()
//	{
//		/*
//		for (int i = 0; i<container.childCount; i++) {
//			Destroy (container.GetChild (i));
//		}
//
//		isPlay = false;
//		fp.isPalyAni = false;
//		InitGame ();
//*/
//
//	}
}
