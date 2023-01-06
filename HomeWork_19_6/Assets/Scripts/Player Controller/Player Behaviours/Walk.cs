using System.Collections;
using System.Collections.Generic;
using Player_Controller.Player_Behaviours;
using UnityEngine;

public class Walk : AbstractBehaviour
{
    public float speed = 5f;
    public float runMultiplier = 2f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var right = inputState.GetButtonValue(inputButtons[0]);
        var left = inputState.GetButtonValue(inputButtons[1]);
        var run = inputState.GetButtonValue(inputButtons[2]);

        if (right || left)
        {
            var tempSpeed = speed;

            if (run && runMultiplier > 0)
            {
                tempSpeed *= runMultiplier;
            }
            
            var velocityX = tempSpeed * (float)inputState.direction;

            rigidbody2D.velocity = new Vector2(velocityX, rigidbody2D.velocity.y);
        }
    }
}
