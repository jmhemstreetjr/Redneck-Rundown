using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CivilianController : MonoBehaviour
{
    [SerializeField]
    private float speed = 10.0f;

    private GameObject mainManager;

    //if you want to trigger an event when a civilian gets destoyed you need this guy
    public UnityEvent<int> onDestroyed;

    // Start is called before the first frame update
    void Start()
    {
        //attach a listener for when each civi is destoyed. The function we want called is Addpernt()
        this.onDestroyed.AddListener(AddPernt);
    }

    // Update is called once per frame
    void Update()
    {
        TranslateCivillian();
        //once the civikian makes it off the screen we need to remove from play.
        if(transform.position.y < -1.0f)
        {
            //if a civi gets this far down it means the player has passed him up, so the point value for doing so is 1. We iinvoke the function we named when we AddListener(AddPernt)
            onDestroyed.Invoke(1);
            //we have passed the civi, so get rid of him.
            Destroy(this.gameObject);
        }
    }

    /////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Moves civilian cars around up and down the highway
    /// </summary>
    /////////////////////////////////////////////////////////////////////////////////////////////
    public void TranslateCivillian()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    /////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// What to do if the civilian collides collide with something.
    /// </summary>
    /// <param name="collision"></param>
    /////////////////////////////////////////////////////////////////////////////////////////////
    void OnCollisionEnter(Collision collision)
    {
        //did this to stop the civillians from bumping into each other.
        if(collision.gameObject.name == "Player")
            Destroy(this.gameObject);
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Sends the point value for each civilian over to the MainManager.
    /// </summary>
    /// <param name="pernt">The point value of each civilian vehicle</param>
    /// //////////////////////////////////////////////////////////////////////////////////////////////////////
    void AddPernt(int pernt)
    {
        mainManager = GameObject.Find("MainManager");

        mainManager.GetComponent<MainManager>().AddPoint(pernt);
    }
}
