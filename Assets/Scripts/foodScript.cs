using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foodScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            ScoreBoard.GetInstance().addScore(10);
            ScoreBoard.GetInstance().updateScoreUI();
            Debug.Log("score increased");
            Destroy(gameObject);
        }
    }
}
