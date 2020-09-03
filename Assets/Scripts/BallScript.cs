using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{

    [SerializeField] GameObject paddleGameObject;
    [SerializeField] float xLaunchSpeed, yLaunchSpeed;
    [SerializeField] float randomPushFactor = 0.2f;
    Rigidbody2D myRigidBody;

    private Vector2 paddleToBallVector;
    private bool isLaunched = false;

    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddleGameObject.transform.position;
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLaunched) { 
            lockBallToPaddle();
            launchOnMouseClick();
        }
    }

    private void launchOnMouseClick() {
        if (Input.GetMouseButtonDown(0)) {
            myRigidBody.velocity = new Vector2(xLaunchSpeed, yLaunchSpeed);
            isLaunched = true;
        }   
    }

    private void lockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddleGameObject.transform.position.x, paddleGameObject.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isLaunched)
        {
            GetComponent<AudioSource>().Play();
            myRigidBody.velocity += new Vector2(Random.Range(0, randomPushFactor), Random.Range(0, randomPushFactor));
        }
    }
}
