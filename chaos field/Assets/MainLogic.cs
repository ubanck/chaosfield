using UnityEngine;
using System.Collections;

/// <summary>
/// author:ubanck
/// desc:游戏主逻辑，主要负责障碍物的加载，碰撞处理，积分，通关处理等等！
/// </summary>

public class MainLogic : MonoBehaviour {

    public GameObject container;
    public GameObject uim;
    public GameObject door;

    public int infectCount = 5;
    public int minInfectCount = 5;
    public int maxInfectCount = 15;

    public int enemyCount = 2;
    public int minEnemyCount = 1;
    public int maxEnemyCount = 5;
    // Use this for initialization
    private int second = 0;
    public bool isOver = false;        

    void Start () {

        infectCount = Random.Range(minInfectCount, maxInfectCount);
        enemyCount = Random.Range(minEnemyCount, maxEnemyCount);

        ResourceManager.init(container, uim,door,isOver,this);
        ResourceManager.load_model(15);
	}
	
	// Update is called once per frame
	void Update () {
        if (isOver)
        {
            Time.timeScale = 0;
        }

        //InvokeRepeating("func", 2, 1f);  //2秒后，没1.0f调用一次  
    }

    void Awake()
    {
        InvokeRepeating("func", 2, 1f);  //2秒后，没1.0f调用一次  
    }

    void func()
    {
        second++;
        
        int h = second / 3600;
        int m = (second % 3600) / 60;
        int s = (second % 3600) % 60;

        string timeStr = h+":"+m+":"+s;
        ResourceManager.timeStr = timeStr;

        ResourceManager.update_ui();
    }
    
}
