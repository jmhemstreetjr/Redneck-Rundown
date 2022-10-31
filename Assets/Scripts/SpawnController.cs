using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject player;
    //public GameObject mainManager;
    public List<GameObject> civilians;
    public List<GameObject> police;

    [SerializeField]
    private float[] xValues = { -7.71f, -4.66f, -1.67f, 1.67f, 4.73f, 7.64f};
    [SerializeField]
    private float spawnY = 0.0f;
    [SerializeField]
    private float spawnZ = 5.0f;

    [SerializeField]
    private float civilianSpawnTime = 1.0f;
    [SerializeField]
    private float delayTime = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnCivilian", delayTime, civilianSpawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Spawns civilian vehcles in the apprpriate lanes of the hwy
    /// </summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    void SpawnCivilian()
    {
        //the position we wioll spawn a civilian in. A random x value is picked from the array of xValues so the vehicles line up in the hwy lanes
        Vector3 spawnPosition = new Vector3(xValues[Random.Range(0, xValues.Length)], spawnY, player.transform.position.z + 25.0f);
        
        //check which side of the hwy the vehicle will be on. If it is less than 0, the vehicle will be on the left side of hwy, so the model needs to get rotated.
        //this makes traffic flow both ways. We also pick a random vehicle from the civillians array.
        if (spawnPosition.x < 0)
        {
            Instantiate(civilians[Random.Range(0, civilians.Count)], spawnPosition, Quaternion.Euler(0.0f, 180.0f, 0.0f));
        }
        else
        {
            Instantiate(civilians[Random.Range(0, civilians.Count)], spawnPosition, civilians[0].transform.rotation);
        }
    }

    void SpawnPolice()
    {

    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Generates a random number. Is inclusive of the values past in.
    /// </summary>
    /// <param name="low"> Lowest value to pick </param>
    /// <param name="high"> Higherst value to pick </param>
    /// <returns></returns>
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    private int RandomInt(int low, int high)
    {
        return Random.Range(low, high);
    }
}
