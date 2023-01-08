using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMovementScript : MonoBehaviour
{
    public float moveSpeed = 5;
    public float deadZone = -45;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // do not need delta time because physics engine has its own clock(#velocity)
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
    
        if (transform.position.x < deadZone) { Destroy(gameObject); }
    }
}
