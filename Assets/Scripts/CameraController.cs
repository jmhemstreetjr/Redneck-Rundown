using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private float speed = 15.0f;

    [SerializeField]
    private float yMinBoundary = 10.0f;
    [SerializeField]
    private float yMaxBoundary = 15.0f;

    //need the player because we want to use his speed to move the camera
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        CameraMovement();
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Determines how we move the camera up and down on th y axis(global) z axis (local). THis is due to the rotation of the camera 
    /// looking down onn the playter
    /// </summary>
    /// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////     
    private void CameraMovement()
    {
        RestrictMovement();
        float verticalInput = Input.GetAxis("Vertical");
        //transform.Translate(Vector3.back * Time.deltaTime * player.GetComponent<PlayerController>().Speed * verticalInput);
        transform.Translate(Vector3.back * Time.deltaTime * speed * verticalInput);
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Need to keep the camera between the ymin and the ymax boundary
    /// </summary>
    /// /////////////////////////////////////////////////////////////////////////////////////////////
    void RestrictMovement()
    {
        //clamp the y betwwwn the min and max. Mathf.Clamp returns y if in between min and max, but it will return min or max if y
        //is outside those bounds
        float yCLamp = Mathf.Clamp(transform.position.y, yMinBoundary, yMaxBoundary);

        //reset the transform
        transform.position = new Vector3(transform.position.x, yCLamp, transform.position.z);
    }
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
///ALL OPF THIS MESS DOWN HERE IS ME TRYING TO FIGURE OUT HOW TO GET THE CAMER A TO MOVE UP AND DOWN WHEN THE PLAYER MOVES.
//TURNS OUT I HAD THE BOUNDS BACKWARDS(<> IN THE CLAMPS)
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/*
    void CameraMovementThree()
    {
        
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.back * Time.deltaTime * speed * verticalInput);

        Debug.Log("X: " + transform.position.x + " Y: " + transform.position.y + " Z: " + transform.position.z);
    }
  
    void CameraMovementTwo()
    {
        float verticalInput = Input.GetAxis("Vertical");

        
        transform.Translate(Vector3.back * Time.deltaTime * speed * verticalInput);

        float zPos = Mathf.Clamp(transform.position.z, zMinBoundary, zMaxBoundary);

        transform.position = new Vector3(transform.position.x, transform.position.y, zPos);
    }
  
//////////////////////////////////////////////////////////////////////////////////////////////////
/// <summary>
/// Determines how we move the camera up and down on th y axis
/// </summary>
/// ///////////////////////////////////////////////////////////////////////////////////////////// 
void CameraMovement()
{
    //check to see if the camera is too high or too low.......
    RestrictMovement();

    //Returns the value of the virtual axis identified by axisName.
    //The value will be in the range -1...1 for keyboard and joystick input devices.
    float verticalInput = Input.GetAxis("Vertical");

    //Alright we want to move the camera up and down to create the sensation of slowing down and speeding up
    //Thius wasa a mess. Some way Some where the axis are screwed up(maybe local???), so I had to move the camera re;ative
    //to world space to get this to work without moving it along thew z axis. Really wierd
    transform.Translate((Vector3.up * Time.deltaTime * speed * verticalInput), Space.World);

}

//////////////////////////////////////////////////////////////////////////////////////////////////
/// <summary>
/// Need to keep the camera between the ymin and the ymax boundary
/// </summary>
/// /////////////////////////////////////////////////////////////////////////////////////////////
void RestrictMovement()
{
    //clamp the y betwwwn the min and max. Mathf.Clamp returns y if in between min and max, but it will return min or max if y
    //is outside those bounds
    float yCLamp = Mathf.Clamp(transform.position.y, yMinBoundary, yMaxBoundary);

    //reset the transform
    transform.position = new Vector3(transform.position.x, yCLamp, transform.position.z);
}

private void MyOwnClamp()
{
    if (transform.position.y < 10.0f)
    {
        Debug.Log("Here.");
        transform.position = new Vector3(transform.position.x, 10.0f, transform.position.z);
    }

    if (transform.position.y > 35.0f)
    {
        Debug.Log("Or Here.");
        transform.position = new Vector3(transform.position.x, 35.0f, transform.position.z);
    }
}

*/
