using UnityEngine;
using System.Collections;

public class infect : MonoBehaviour {

    public float minX = -400;
    public float maxX = 400;
    public float minZ = 0;
    public float maxZ = 700;

    public float speed = 22.1f;
    public int frameCount = 0;
    public int maxFrame = 300;

    private Rigidbody rig;

    private Transform tf;

    public int type;

    public int infectValue = 5;
    public int minInfectValue = 1;
    public int maxInfectValue = 10;

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController cc;
    public float speedEx = 6f;

    public int addPerSec = 30;
    public int addCount = 0;

    void Start()
    {
        this.transform.position = new Vector3(Random.Range(minX, maxX), this.transform.position.y, Random.Range(minZ, maxZ));
        maxFrame = Random.Range(100, 300);
        infectValue = Random.Range(minInfectValue,maxInfectValue);

        tf = this.transform;
        rig = GetComponent<Rigidbody>();
        cc = GetComponent<CharacterController>();

        float ranx = Random.Range(-1, 1) * 10;
        float ranz = Random.Range(-1, 1) * 10;

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

        //当value达到最大值的时候，被转换为敌人
        if (infectValue >= ResourceManager.MAX_INFECT_VALUE)
        {
            ResourceManager.load_enemy(this.transform);
            ResourceManager.infect_count--;
            GameObject.Destroy(this.gameObject);
        }

        
    }



    void OnCollisionEnter(Collision collision)
    {
        float rangeNum = 0;
        while (rangeNum == 0)
        {
            rangeNum = Random.Range(-1.0f, 1.0f) * 10;
        }
        if (tf != null)
        {
            tf.forward = new Vector3(rangeNum, 0, rangeNum);
            moveDirection = new Vector3(rangeNum, 0, rangeNum);

        }

        if (collision.gameObject.name == ResourceManager.PERSON_NAME)
        {
            infectValue = 1;
        }
    }


    //触发碰撞
    void OnTriggerEnter(Collider col)
    {
        //感染者被主角碰到，值归一
        if (col.gameObject.name == ResourceManager.PERSON_NAME)
        {
            //infectValue = 1;
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
            ResourceManager.update_ui
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
    void Awake()
    {
        InvokeRepeating("func", 2, 1f);  //2秒后，没1.0f调用一次  
    }
    void func()
    {
        Debug.LogWarning("1 second---");
        addCount++;
        if (addCount >= addPerSec)
        {
            infectValue++;
            addCount = 0;
        }
    }

}
