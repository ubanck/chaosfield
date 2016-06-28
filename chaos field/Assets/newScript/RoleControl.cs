using UnityEngine;
using System.Collections;

public class RoleControl : MonoBehaviour {
    public float speed = 6f;
    public float gravity = 20f;

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController cc;
    private Transform tf;
    public Animator ani;

	// Use this for initialization
	void Start () {
        cc = GetComponent<CharacterController>();
        tf = transform;
    }
	
	// Update is called once per frame
	void Update () {

        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        moveDirection *= speed;

        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            ani.SetBool("run", true);

            
            tf.rotation = Quaternion.LookRotation(moveDirection);

            cc.Move(moveDirection * Time.deltaTime);
        }
        else
        {
            ani.SetBool("run", false);
        }
    }
}
