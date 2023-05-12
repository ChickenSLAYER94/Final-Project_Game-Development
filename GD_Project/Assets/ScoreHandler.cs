using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHandler : MonoBehaviour
{
    //here in this script we are updating score on the top left corner of the screen
    public static ScoreHandler instance;
    public int points = 0;
    public Text scoreText;


    private void Awake() {
        //after creating instance the buttom code is important else it will throw NullReferenceException.
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        //at first the score will be zero
        scoreText.text = points.ToString();    
    }
    // Update is called once per frame
    //this will update score
    public void Update_Score(int score)
    {
        points += score;
        scoreText.text = points.ToString();  
    }
}
