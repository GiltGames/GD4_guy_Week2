using UnityEngine;

public class Autocar : MonoBehaviour
{


    public float v_speed;
    public int v_limit;
    public int v_count;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (v_count < v_limit)
        {
            v_count += 1;
            transform.Translate(Vector3.forward * Time.deltaTime * v_speed);
        }
        else
        {
            v_count = 0;
            v_speed = v_speed * -1;
        }

    }
}
