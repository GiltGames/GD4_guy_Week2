using UnityEngine;

public class ShotControl : MonoBehaviour
{
    bool f_HitPlayer =false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Dust")

        {
            if (gameObject != null)
            {
                Destroy(gameObject);
            }
        
        }

        if (f_HitPlayer ==true)

        {


            if (gameObject != null)
            {
                Destroy(gameObject);
            }
        }

        if (collision.gameObject.tag == "Player")

        { f_HitPlayer = true; 




        }





    }
}
