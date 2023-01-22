using UnityEngine;

public class Fruits : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ScoreBoard.GetInstance().addScore(10);
            ScoreBoard.GetInstance().updateScoreUI();
            Destroy(gameObject);
            Debug.Log("Player Col");
        }
        else
        {
            Debug.Log("No collision");
        }
    }
}
