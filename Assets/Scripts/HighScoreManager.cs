using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class HighScoreManager : MonoBehaviour
{
    public GameObject TextHat;
    public GameObject TextSpeechBubble;
    public GameObject TextSpeechBubbleTwo;
    public GameObject InputFieldInitials;
    public GameObject ButtonSendIt;

    private int _score = 0;

    // Start is called before the first frame update
    void Start()
    {
        SetUp();
    }

    // Update is called once per frame
    void Update()
    {
        //if the player has a high score he gets to put his initials in the hat. We sit and wait for ENTER to get pressed then we set the new high score and user,
        //change the speech bubble and hat, and turn on the button to exit the high score menu.
        if (Input.GetKey(KeyCode.Return))
        {
            InformationManager.Instance.highScore = InformationManager.Instance.currentScore;
            InformationManager.Instance.highScoreName = InputFieldInitials.GetComponent<TMPro.TMP_InputField>().text;

            TextHat.GetComponent<TMPro.TextMeshProUGUI>().text = $"{InformationManager.Instance.highScoreName}\n{InformationManager.Instance.highScore}";
            TextHat.SetActive(true);
            TextSpeechBubble.SetActive(true);

            InputFieldInitials.SetActive(false);
            TextSpeechBubbleTwo.SetActive(false);

            ButtonSendIt.GetComponent<Button>().interactable = true;
        }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Checks to see if the current score is better than the high score and sets up the High Score scene with the approproate text and input boxes
    /// </summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    private void SetUp()
    {
        //is the current high score better than the player's current score, if yes, display specific dialog and display the highscore and turn on the button to return to menu
        if(InformationManager.Instance.highScore >= InformationManager.Instance.currentScore)
        {
            TextHat.GetComponent<TMPro.TextMeshProUGUI>().text = $"{InformationManager.Instance.highScoreName}\n{InformationManager.Instance.highScore}";
            TextHat.SetActive(true);
            TextSpeechBubble.SetActive(true);
            Debug.Log($"HIGH: {InformationManager.Instance.highScore} LOW: {InformationManager.Instance.currentScore}");
            ButtonSendIt.GetComponent<Button>().interactable = true;
        }
        else //..if no, display a specific dialog and put up an input field so player can enter initials 
        {
            InputFieldInitials.SetActive(true);
            TextSpeechBubbleTwo.SetActive(true);
            Debug.Log($"LOW: {InformationManager.Instance.currentScore} HIGH: {InformationManager.Instance.highScore}");
        }
    }

    public void SendItButton()
    {
        InformationManager.Instance.SaveInfo();
        SceneManager.LoadScene(0);
    }
}
