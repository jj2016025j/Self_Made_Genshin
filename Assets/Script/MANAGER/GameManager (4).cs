//This script handles the logic and UI for our game. It controls how much time the player has,
//how many points they have scored, and it detects when the player has won or lost the game

using UnityEngine;
using UnityEngine.UI;    //Enable UI items in script
using UnityEngine.SceneManagement; //Enable scene management in script

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int scoreToWin = 4;  //Amount of points the player needs to lower the wall
    public float timeAmount = 60f; //How long the player has to reach the goal
    //public WallMover wall;   //A reference to the wall script that lowers it
                              //the wall lowering to the player. This is optional

    [Header("UI Elements")]
    public Text timeText;   //The UI element that shows the amount of time
    public Text collectText;  //The UI element that shows the player's score

    public int score;  //Player's current score
    bool gameover; //Is the game over?


    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    void Start()
    {
        //Set our initial UI text for score and the amount of time
        collectText.text = score + " / " + scoreToWin;//顯示分數
    }
    public void PlayerScored()
    {
        if (score >= scoreToWin)
            return;

        score++;
        collectText.text = score + " / " + scoreToWin;

        if (score < scoreToWin)
            return;

    }
}

