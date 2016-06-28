using UnityEngine;
using System.Collections;

public class door : MonoBehaviour {


    //门的设计代码
    /// <summary>
    /// 四个门，生成随机大小的值
    /// 
    /// </summary>

    public int minValue = 2;
    public int maxValue = 8;

    public int doorValue = 2;
	public bool isActive=false;
	// Use this for initialization
	void Start () {
	    //doorValue= Random.Range(minValue, maxValue);
    }
	
	// Update is called once per frame
	void Update () {
	
	}


    void OnTriggerEnter(Collider col)
    {
        //确定碰撞方为主角
		if (col.tag.Equals ("Player"))
		{
			// show a ui for valua tips
			if (GameManager.Instance.currentHp == doorValue && isActive==false) 
			{
				//set active for cur door
				this.transform.GetComponent<MeshRenderer>().material.color=Color.green;
				isActive = true;
				GameManager.Instance.doorOpenCount++;
			}
		}
    }
}
