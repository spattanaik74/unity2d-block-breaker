using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour

{
    [SerializeField] float minX = 1;
    [SerializeField] float maxX = 15;
    [SerializeField] float screenWidth = 16f;

    //Cached Reference
    GameStatus thegameStatus;
    Ball theball;

    // Start is called before the first frame update
    void Start()
    {
        thegameStatus = FindObjectOfType<GameStatus>();
        theball = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
       
        Vector2 paddlePos = new Vector2 (transform.position.x ,transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPos(), minX, maxX);
        transform.position = paddlePos;
        
    }
    private float GetXPos()
    {
        if (thegameStatus.AutoPlayEnable())
        {
            return theball.transform.position.x;
        }
        else
        {
           return Input.mousePosition.x / Screen.width * screenWidth;
        }
    }
}
