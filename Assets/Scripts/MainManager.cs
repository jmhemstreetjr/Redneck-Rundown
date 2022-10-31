using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public GameObject ScoreText;
    public GameObject GameOverText;

    private int _score = 0;
    private bool _gameOver = false;

    
    public int Score
    {
        get
        {
            return _score;
        }

        set
        {
            _score = value;
        }
    }

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.H))
        {
            InformationManager.Instance.currentScore = _score;
            SceneManager.LoadScene(2);
        }

        if(_gameOver)
        {
            GameOverText.SetActive(true);
        }
    }

    /////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Increases the value of _score and updates the score text on th UI.
    /// </summary>
    /// <param name="point">The number of points to aadd to the total score</param>
    ///////////////////////////////////////////////////////////////////////////////////////////////
    public void AddPoint(int point)
    {
        Debug.Log("Adding a point");
        
        _score += point;

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///Finding the text box was a pain. This took me a while to get straightened out, so I will just copy pasta the straight forward answer from Stack Overflow.
        ///There are two TextMesh Pro components... the normal component is of type <TextMeshPro> and works with the MeshRenderer and a replacement for the old TextMesh. 
        ///Then the UGUI component is of type <TextMeshProUGUI> and works with the CanvasRenderer.
        ///THe ScoreText is on the UI Canvas, so this is how you get to it.
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ScoreText.GetComponent<TMPro.TextMeshProUGUI>().text = $"Score: {_score}";
    }
}
