using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{

    public float v_timer=0;
    public float v_timeShow=0;
    public TextMeshProUGUI textT;

    public PlayerMove PlayerMove;
    public StartScript StartScript;
    public string v_winnerindex = "";
    public float v_winningTime;
    public bool vGameOver = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (StartScript.v_GAMESTART == true)
        {
            v_timer = v_timer + Time.deltaTime;

            if (vGameOver == false)
            {
                v_timeShow = Mathf.RoundToInt(v_timer * 100);

                textT.text = "Time: " + (Mathf.Round(v_timer * 100) / 100);
            }

            else
            {

                textT.text = "Winner is Player " + v_winnerindex + " in " + v_winningTime + " seconds";
            }

        }
    }
}
