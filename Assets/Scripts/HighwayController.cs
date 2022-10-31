using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighwayController : MonoBehaviour
{
    public List<GameObject> roads;
    public GameObject player;
    //last chunk of road in roads
    private int lastRoad;
    
    // Start is called before the first frame update
    void Start()
    {
        lastRoad = roads.Count - 1;
    }

    // Update is called once per frame
    void Update()
    {
        SetRoad();
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Lays downt the chunks of road in front of the player depending on how far away the player is
    /// </summary>
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public void SetRoad()
    {
        for(int i = 0; i < roads.Count; i++)
        {
            //Get the distance between this piece of road and the player
            float distance = Vector3.Distance(roads[i].transform.position, player.transform.position);
            //if this peice of road is far away and below the player it needs to be moved up
            if(distance >= 20.0f && roads[i].transform.position.z < player.transform.position.z)
            {
                //the last piece of road in the list will ALWAYS be moved above the first piece of road in the list hence I used roads[0]
                if (i == lastRoad)
                {
                    roads[i].transform.position = new Vector3(0.0f, 0.002919f, roads[0].transform.position.z + 20.0f);
                }
                else //any other piece of road will get reset relative to the posiotion of the piece of road that is behind it in the list hence roads[i + 1]
                {
                    roads[i].transform.position = new Vector3(0.0f, 0.002919f, roads[i + 1].transform.position.z + 15.0f);
                }
                //once we find the chunk of road that needs to be reset we can break the loop for the frame
                break;

            }
        }
    }
}
