using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMover : MonoBehaviour
{
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] GameObject ball;
    private float movementX;
    public float minX, maxX;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector2 paddlePos;
        //Vector2 paddlePos = new Vector2(Mathf.Clamp(movementX, minX, maxX), transform.position.y);

        //Vector2 paddlePosBall = new Vector2(ball.transform.position.x, transform.position.y);

        if (FindObjectOfType<GameStatus>().isAutoPlayEnabled())
        {
            paddlePos = new Vector2(ball.transform.position.x, transform.position.y);
        }
        else {
            movementX = (Input.mousePosition.x / Screen.width * screenWidthInUnits);
            paddlePos = new Vector2(Mathf.Clamp(movementX, minX, maxX), transform.position.y);
        }

        transform.position = paddlePos;
    }
}
