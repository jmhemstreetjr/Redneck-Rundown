using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

////////////////////////////////////////////////////////////////////////////////////////////
/// <summary>
/// We are going to use this class to pass info between the scenes. This is why it has a static member and only one will 
/// be created(Singleton).
/// </summary>
////////////////////////////////////////////////////////////////////////////////////////////
public class InformationManager : MonoBehaviour
{
    public static InformationManager Instance { get; private set; }

    public int currentScore;
    public int highScore;
    public string highScoreName;

    ////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// SaveData class is used to hold the info of the player who gets the highest score (name and score)
    /// </summary>
    ////////////////////////////////////////////////////////////////////////////////////////////
    [System.Serializable]
    class SaveData
    {
        public string highName;
        public int highScore;
    }

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// When the game scene loads we need a Information manger, so we use Awake. Also where we make it a Singleton
    /// </summary>
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public void Awake()
    {
        //If we go to another scene and comeback we do not need a new class(Singleton)
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        //set Instance to this and set the game object up so it can cross over to a new scene
        Instance = this;
        DontDestroyOnLoad(gameObject);

        //Get the info from the file if there is a previous high score
        LoadInfo();
    }

    ////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Saves the name and score of a player
    /// </summary>
    ////////////////////////////////////////////////////////////////////////////////////////////
    public void SaveInfo()
    {
        //Create a new SaveData and stick the current playter's name and high score in there 
        SaveData data = new SaveData();
        data.highName = highScoreName;
        data.highScore = highScore;

        //change the SaveData object to a json so we can write this to a file
        string json = JsonUtility.ToJson(data);
        //write it, Tony 
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Does the exact oppoosite of the SaveInfo(). It gets the name and score of high score player from a text file
    /// </summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////////
    public void LoadInfo()
    {
        //this is where the file lives
        string path = Application.persistentDataPath + "/savefile.json";
        //does it exist...good
        if (File.Exists(path))
        {
            //get it from the file, turn it into a json, and convert it to a SaveData
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            //get the info out of the SaveData and assign it to the vartiables
            highScoreName = data.highName;
            highScore = data.highScore;
        }
        else //if not we fill up with junk info
        {
            highScore = 0;
            highScoreName = "***";
        }


    }


}
