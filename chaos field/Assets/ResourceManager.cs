using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
public static class ResourceManager
{
    public static int POSITIVE_FACTOR_COUNT;
    public static int NAGETIVE_FACTOR_COUNT;

    public static string positive_model_name = "Role_Type2";
    public static string negative_model_name = "Role_Type3";

    public static string PERSON_NAME = "Player";

    public static int MAX_INFECT_VALUE=10;
    public static int MAX_PERSON_VALUE = 10;

    public static UnityEngine.Object pos_res;
    public static UnityEngine.Object nega_res;

    public static List<GameObject> pos_factors;
    public static List<GameObject> nega_factors;

    public static GameObject container;

    public static string timeStr="00:00:00";
    public static int personValue = 0;
    public static int infect_count = 0;
    public static int enemy_count = 0;

    public static GameObject uim;
    public static GameObject door;

    public static MainLogic ml;
    public static bool isOver=false;
    public static void init(GameObject con,GameObject ui,GameObject d,bool isO,MainLogic m)
    {
        container = con;
        uim = ui;
        door = d;
        isOver = isO;
        ml = m;
        pos_res=Resources.Load(positive_model_name);
        nega_res = Resources.Load(negative_model_name);
    }

    public static void load_infect()
    {

    }

    public static void load_enemy(Transform tr)
    {
        GameObject _model;
        _model = (GameObject)UnityEngine.Object.Instantiate(ResourceManager.pos_res);
        _model.GetComponent<enemy>().type = 1;
        enemy_count++;
        _model.transform.position = tr.position;
        _model.transform.SetParent(ResourceManager.container.transform);
    }



    //34,1.4,5.5
    public static void load_model(int num)
    {
        for (int i = 0; i < num; i++)
        {
            GameObject _model;
            if (i % 2 == 0)
            //if (i != 0)
            {
                _model = (GameObject)UnityEngine.Object.Instantiate(ResourceManager.pos_res);
                _model.GetComponent<enemy>().type=1;
                enemy_count++;
            }
            else
            {
                _model = (GameObject)UnityEngine.Object.Instantiate(ResourceManager.nega_res);
                _model.GetComponent<infect>().type = -1;
                infect_count++;
            }
            
            _model.transform.SetParent(ResourceManager.container.transform);

            //_model.transform.position = new Vector3(34.0f,1.4f,5.5f);
            //_model.transform.localScale = new Vector3(4.0f, 4.0f, 4.0f);
            //pos_factors.Add(_model);
        }
        update_ui();
    }

    public static void update_ui()
    {
        
        uim.transform.GetComponent<UIManager>().set_ui_value(timeStr, personValue, infect_count, enemy_count);
        /*
        if (score == 0)
        {
            //door.SetActive(false);
        }
        else
        {
            //door.SetActive(true);
        }
        */
        
    }


}

