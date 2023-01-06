using System.Collections;
using System.Collections.Generic;
using Player_Controller.Player_Behaviours;
using UnityEngine;

public class FaceDirection : AbstractBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var right = inputState.GetButtonValue(inputButtons[0]);
        var left = inputState.GetButtonValue(inputButtons[1]);

        if (right)
        {
            inputState.direction = Directions.FaceRight;
        }
        else if(left)
        {
            inputState.direction = Directions.FaceLeft;
        }

        transform.localScale = new Vector3((float)inputState.direction, 1,1);
    }
}