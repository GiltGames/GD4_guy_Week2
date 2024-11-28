using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{

    public float v_timer=0;
    public float v_timeShow=0;
    public TextMeshProUGUI textT;

    public PlayerMove PlayerMove;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerMove.f_finish == false)
        {
            v_timer = v_timer + Time.deltaTime;
        }
            
            v_timeShow = Mathf.RoundToInt(v_timer*100);

       textT.text = "Time: " + v_timeShow/100;

    }
}
