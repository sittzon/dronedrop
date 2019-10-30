using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class presentChimneyCollision : MonoBehaviour
{
    private Drone drone;
    private UnityEngine.UI.Text scoreText;

    void Start()
    {
        scoreText = GameObject.FindGameObjectWithTag("pointText").GetComponent<UnityEngine.UI.Text>();
        drone =  GameObject.FindGameObjectWithTag("Player").GetComponent<Drone>();
        int score = drone.getScore();
        scoreText.text = "Points: " + score;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "chimney")
        {
            int score = drone.getScore();
            score += 1;
            drone.setScore(score);
            scoreText.text = "Points: " + score;
            Destroy(this);
        }
    }
}
