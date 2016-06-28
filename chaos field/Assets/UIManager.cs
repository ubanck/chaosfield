using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class UIManager : MonoBehaviour {

    
    public Text score_text;
    public Text absorb_text;
    public Text pos_count_text;
    public Text nega_count_text;

	public Slider process;

	void Start () {
	
	}


	public void set_ui_value(string score,int absorb,int pos_count,int nega_count)
    {
		score_text.text = GameManager.Instance.timeStr;//score.ToString();
		absorb_text.text = GameManager.Instance.currentHp.ToString() +"/5";//absorb.ToString();
        pos_count_text.text = pos_count.ToString();
        nega_count_text.text = nega_count.ToString();
		process.value = GameManager.Instance.currentHp / 5f;
    }


	// Update is called once per frame
	void Update () {
	
	}
}
