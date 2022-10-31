using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //[SerializeField]
    private float speed = 12.0f;
    [SerializeField]
    private float speedMin = 0.0f;
    [SerializeField]
    private float speedMax = 40.0f;

    //speed is going to ghet used in other classes. Specificallly we want to link the camera speed to the player speed.
    //We make a property that only gets.
    public float Speed => speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TranslatePlayer();
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Moves the player
    /// </summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public void TranslatePlayer()
    {
        //check to see if any of the horizontal buttons (a, d, left arrow, right arrow) are pressed.
        float horizontalInput = Input.GetAxis("Horizontal");
        //are we going to speed up or down?
        Accelerator();

        //the Vector3 are screwy because the model was not rotated improperly when imported. I rotated the model in Unity, so the axses are rotated.
        //THis is why horizontal input is paired with Vector3.down and Vector3.right goes up and down
        //left right
        transform.Translate(Vector3.down * Time.deltaTime * speed * horizontalInput);
        //up down
        transform.Translate(Vector3.right * Time.deltaTime * speed);
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Checks for vertical input (w,s, up arrow, down arrow) and increases the speed. Thiss creates acceleration and deacceleration
    /// </summary>
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public void Accelerator()
    {
        //do we have vertical input
        float verticalInput = Input.GetAxis("Vertical");
        //if yes verticaInput will be a non-zero value, so we add it to speed
        speed += (0.05f * verticalInput);
        //speed += 0.01f;
        //speed += verticalInput;
        //we do not want the player to go backwards, so we clamp speed
        speed = Mathf.Clamp(speed, speedMin, speedMax);
    }

    private void OnCollisionEnter(Collision collision)
    {

    }
}
