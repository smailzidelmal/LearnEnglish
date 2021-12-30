using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 5f;
    public float deadz = -10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GeneralInfo.isWalk()){
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        }
        if (transform.position.z < deadz){
            Destroy(gameObject);
        }   
    }
}
