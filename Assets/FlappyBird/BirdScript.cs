using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    GameManagerScript gameManagerScript;
    public bool alive = true;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Space)) { myRigidbody.velocity = Vector2.up * flapStrength; } // Vector2.up = (0, 1)
        if (Input.touchCount > 0 && alive) { myRigidbody.velocity = Vector2.up * flapStrength; } // Vector2.up = (0, 1)
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameManagerScript.gameOver();
        alive = false;
    }
}