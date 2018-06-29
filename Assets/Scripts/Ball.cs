using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    private Paddle paddle;

    bool hasStarted = false;

    private Vector3 paddleToBallVector;

    private void Start() {
        paddle = GameObject.FindObjectOfType<Paddle>();
        paddleToBallVector = this.transform.position - paddle.transform.position;
        
    }

    private void Update() {

        if (!hasStarted) {
            this.transform.position = paddle.transform.position + paddleToBallVector;

            //before mouse press
            if (Input.GetMouseButtonDown(0)) {
                var rb = this.GetComponent<Rigidbody2D>();

                //this.rigidbody2d.velocity is deprecated, use this way instead to impart velocity
                rb.velocity = new Vector2(2f, 10f);

                hasStarted = true;
            }

        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {

        Vector2 tweak = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));

        AudioSource audio = GetComponent<AudioSource>();
        if (hasStarted) {
            audio.Play();
            Rigidbody2D ball = GetComponent<Rigidbody2D>();
            ball.velocity += tweak;
        }
    }

}
