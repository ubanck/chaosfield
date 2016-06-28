using UnityEngine;
using System.Collections;

public class FollowPerson : MonoBehaviour {

    public Transform personTrans;
    // Use this for initialization
    private Vector3 offset; 
	public bool isPalyAni=false;

	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		if (isPalyAni) {
			transform.position = offset + personTrans.position;
		}
        
    }
	public void waitPalyAni()
	{
		isPalyAni = true;
		transform.position = new Vector3 (80f,82f,-41f);
		transform.rotation = Quaternion.Euler (new Vector3(62f,0.1f,0.0f));
//		transform.position = new Vector3 (99f,82f,-92f);
//		transform.rotation = Quaternion.Euler (new Vector3(36f,357.1f,0.0f));
		offset = transform.position - personTrans.position;
	}
}
