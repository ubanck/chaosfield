using UnityEngine;
using System.Collections;
using  DG.Tweening;
public class factor : MonoBehaviour
{
    /*
    Random ro;
    //x(-41,41)
    //z(-31,25)
    public float minX = -41;
    public float maxX = 41;
    public float minZ = -31;
    public float maxZ = 25;

    float speed = 22.1f;
    // Use this for initialization
    private int frameCount = 3000;
    private int maxFrame = 300;

    public Vector3 dir;
    private FastMoveControl fmc;

    private Rigidbody rig;

    private Transform tf;

    public int type;
    void Start()
    {
        this.transform.position = new Vector3(Random.Range(minX, maxX), this.transform.position.y,Random.Range(minZ, maxZ));
        maxFrame = Random.Range(100, 300);

        tf = this.transform;
        rig = GetComponent<Rigidbody>();
      
        float ranx = Random.Range(-1, 1)*10;
        float ranz = Random.Range(-1, 1)*10;

        tf.forward = new Vector3(ranx, 0, ranz);
    }

    // Update is called once per frame
    void Update()
    {
        rig.AddForce(tf.forward * Time.deltaTime * speed, ForceMode.Force);
        moveEx();
    }

    void OnCollisionEnter(Collision collision)
    {
        float rangeNum = 0;
        while (rangeNum == 0)
        {
            rangeNum = Random.Range(-1, 1)*10;
        }
        if (tf != null)
        {
            tf.forward = new Vector3(rangeNum, 0, rangeNum);
        }
    }


    //触发碰撞
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "person")
        {
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
        }
    }

    void moveEx()
    {
       frameCount++;
       if (frameCount >= maxFrame)
       {
           frameCount = 0;
           float ranx = Random.Range(-1, 1)*10;
           float ranz = Random.Range(-1, 1)*10;
           tf.forward = new Vector3(ranx, 0, ranz);
       }
    }
    */


}
