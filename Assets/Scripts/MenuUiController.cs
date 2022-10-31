using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//if the app is runniong in the editor include UnityEditor
//If it is standalone [player the compiler won't put it in the code
//If you didn’t add an if statement for the compiler, then when you tried to build a standalone player, you’d get an error that it can’t find UnityEditor 
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUiController : MonoBehaviour
{
    public AudioSource canvassAudioSource;
    public AudioClip startSound;
    public AudioClip exitSound;
    public AudioClip hiScoreSound;

    public GameObject startButton;
    public GameObject exitButton;
    public GameObject hiScoreButton;

    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
 
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Gets called when you press the start button(git r dun) in the menu
    /// </summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public void StartNew()
    {
        canvassAudioSource.PlayOneShot(startSound);
        //must deactiovate all other buttons so they can't get pressed while waiting for sound to play
        exitButton.SetActive(false);
        hiScoreButton.SetActive(false);
        StartCoroutine("LoadGameScene", 1);
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Gets called whe you hit the exit button(skee daddle) in the menu
    /// </summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public void Exit()
    {
        canvassAudioSource.PlayOneShot(exitSound);
        //must deactiovate all other buttons so they can't get pressed while waiting for sound to play
        startButton.SetActive(false);
        hiScoreButton.SetActive(false);
        StartCoroutine("ExitGame");
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Gets called whenb you click the hi score button in the menu
    /// </summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public void HiScore()
    {
        canvassAudioSource.PlayOneShot(hiScoreSound);
        //must deactiovate all other buttons so they can't get pressed while waiting for sound to play
        startButton.SetActive(false);
        exitButton.SetActive(false);
        StartCoroutine("LoadGameScene", 2);
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Waits for three seconds then loads a scene
    /// </summary>
    /// <param name="sceneNumber">The number of the scene you want loaded</param>
    /// <returns>IEnmumerator cuz it is used as a corouttine</returns>
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    IEnumerator LoadGameScene(int sceneNumber)
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(sceneNumber);
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Waits for three seconds then exits the game. Has the code that exits properly whether you are i game or editor
    /// </summary>
    /// <returns>IEnmumerator cuz it is used as a corouttine</returns>
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    IEnumerator ExitGame()
    {
        yield return new WaitForSeconds(3);
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}
