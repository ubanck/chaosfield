using UnityEngine;
using System.Collections;

public class rolePerson : MonoBehaviour {


    public int personValue = 0;

    public int addPerSec = 3;
    public int addCount = 0;
    //public 

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (personValue >= ResourceManager.MAX_PERSON_VALUE)
        {
            ResourceManager.ml.isOver = true;
        }
        else
        {
            //InvokeRepeating("func", 2, 1f);  //2秒后，没1.0f调用一次 
        }
    }

    void OnTriggerEnter(Collider col)
    {
        //主角碰到感染者，吸收一单位的值
        if (col.gameObject.name == ResourceManager.PERSON_NAME)
        {
            personValue++;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.name == ResourceManager.PERSON_NAME)
        if (collision.gameObject.name.Contains("Role_Type3"))
        {
            personValue++;
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
            personValue--;
            addCount = 0;
        }

    }
}
