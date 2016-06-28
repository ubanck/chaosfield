using UnityEngine;
using System.Collections;

public class RandomMove : MonoBehaviour {
    public int minX = -34;
    public int maxX = 35;

    public int minZ = -24;
    public int MaxZ = 24;

    public float speed = 1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        move();
    }

    public void move()
    {       
        speed = Random.Range(-1, 1)/10;
        Debug.LogWarning("speed:"+speed);
        this.transform.localPosition = new Vector3(this.transform.position.x+speed, this.transform.position.y, this.transform.position.z+speed);
        
    }
}
