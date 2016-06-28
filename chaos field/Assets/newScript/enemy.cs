using UnityEngine;
using System.Collections;

public class enemy : MonoBehaviour {

    public float minX = -400;
    public float maxX = 400;
    public float minZ = 0;
    public float maxZ = 700;

    public float speed = 5000.0f;
    public int frameCount = 0;
    public int maxFrame = 300;

    private Rigidbody rig;

    private Transform tf;

    public int type;

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController cc;
    public float speedEx = 6f;


    /// <summary>
    /// 敌人属性
    /// 1.初始会有随机个数的敌人
    /// 2.感染者会进阶成敌人
    /// 3.与主角相撞会杀死主角
    /// </summary>

    void Start()
    {
        this.transform.position = new Vector3(Random.Range(minX, maxX), this.transform.position.y, Random.Range(minZ, maxZ));
        maxFrame = Random.Range(100, 300);

        tf = this.transform;
        rig = GetComponent<Rigidbody>();
        cc = GetComponent<CharacterController>();

        float ranx = Random.Range(-1, 1) * 100;
        float ranz = Random.Range(-1, 1) * 100;

        tf.forward = new Vector3(ranx, 0, ranz);
        moveDirection = new Vector3(ranx, 0, ranz);
    }

    // Update is called once per frame
    void Update()
    {
        rig.AddForce(tf.forward * Time.deltaTime * speed, ForceMode.Force);
        moveEx();

        //moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //moveDirection *= speedEx;
        //tf.rotation = Quaternion.LookRotation(moveDirection);

        //cc.Move(moveDirection * Time.deltaTime);
        InvokeRepeating("func", 2, 1f);  //2秒后，没1.0f调用一次  
    }

    void OnCollisionEnter(Collision collision)
    {
        float rangeNum = 0;
        while (rangeNum == 0)
        {
            rangeNum = Random.Range(-1, 1) * 10;
        }
        if (tf != null)
        {
            tf.forward = new Vector3(rangeNum, 0, rangeNum);
            moveDirection = new Vector3(rangeNum, 0, rangeNum);
            
        }
    }


    //触发碰撞
    void OnTriggerEnter(Collider col)
    {
        Debug.LogWarning(col.gameObject.name);
        if (col.gameObject.name == "Role_Type1")
        {
            ResourceManager.ml.isOver = true;
            /*
            ResourceManager.score += type;
            GameObject.Destroy(this.gameObject);
            ResourceManager.absorb++;
            if (type == 1)
            {
                ResourceManager.pos_count--;
            }
            else
            {
                ResourceManager.nega_count--;
            }
            ResourceManager.update_ui();
            */
        }
    }

    void moveEx()
    {
        frameCount++;
        if (frameCount >= maxFrame)
        {
            frameCount = 0;
            float ranx = Random.Range(-1.0f, 1.0f) * 10;
            float ranz = Random.Range(-1.0f, 1.0f) * 10;
            tf.forward = new Vector3(ranx, 0, ranz);
        }
    }

    void func()
    {

    }
}
