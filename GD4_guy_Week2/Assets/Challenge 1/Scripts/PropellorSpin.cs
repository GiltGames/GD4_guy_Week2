using UnityEngine;
//script added to rotate propellor
public class PropellorSpin : MonoBehaviour
{

    public float vRotSpeed =100;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      //propellor rotates in z axis relative to the parent
        
        transform.Rotate(0, 0, vRotSpeed * Time.deltaTime);
    }
}
