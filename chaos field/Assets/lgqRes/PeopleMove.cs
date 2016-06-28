using UnityEngine;
using System.Collections;


//[ExecuteInEditMode]
public class PeopleMove : MonoBehaviour {
	public float speed = 10;
	public bool isMove=false;
	public float turnDirectionTime = 2f;
	public float timer;
	public float waitTime=5f;
	public float waitTimer = 0;

	public int infectValue = 5;
	public int minInfectValue = 1;
	public int maxInfectValue = 10;

	public int addPerSec = 3;
	public int addCount = 0;
	public Vector3[] waypoints = new[] { 
	new Vector3(-536.0159f,269.8324f,-214.2462f), 
	new Vector3(-32.93466f,222.6351f,-433.533f), 
	new Vector3(276.2539f,129.4355f,-12.62604f), 
	new Vector3(168.6082f,18.96389f,-6.262604f) };

    public GameObject go;
	void Start () {
		GameManager.Instance.infect_count++;
	}

	void Update () {
		if(!GameManager.Instance.fp.isPalyAni)
		{
			return;
		}
		timer += Time.deltaTime;
		if (isMove) {
			waitTimer += Time.deltaTime;
			if (timer > turnDirectionTime) 
			{
				timer = 0;
				randomDrection ();
			}
			transform.position += transform.forward*speed*Time.deltaTime;
		}

		//当value达到最大值的时候，被转换为敌人
		if (infectValue >= ResourceManager.MAX_INFECT_VALUE)
		{
			//ResourceManager.load_enemy(this.transform);
			//ResourceManager.infect_count--;
			//GameObject.Destroy(this.gameObject);
		}


        set_float();
	}
	void randomDrection()
	{
		if (waitTimer > waitTime) {
			if (transform.position.x > -21f) {
				transform.rotation = Quaternion.Euler (new Vector3 (0, Random.Range (190, 350), 0));
			} else {
				transform.rotation = Quaternion.Euler (new Vector3 (0, Random.Range (0, 350), 0));
			}
		}

	}


	//触发碰撞
	void OnTriggerEnter(Collider col)
	{
		//感染者被主角碰到，值归一
		if (col.tag.Equals ("Player"))
		{
			infectValue = 1;
			GameManager.Instance.currentHp++;
			Debug.LogWarning ("infect triger");
		}
	}


	void Awake()
	{
		InvokeRepeating("func", 2, 1f);  //2秒后，没1.0f调用一次  
	}
	void func()
	{
		addCount++;
		if (addCount >= addPerSec)
		{
			infectValue++;

			addCount = 0;
		}
	}

    void set_float()
    {
		float processValue = (float)infectValue / ResourceManager.MAX_INFECT_VALUE;
		//Debug.LogWarning (processValue);
		go.transform.GetComponent<SkinnedMeshRenderer>().material.SetFloat("_process", processValue);
    }

}
