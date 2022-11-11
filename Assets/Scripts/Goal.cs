using UnityEngine;
using TMPro;

public class Goal : MonoBehaviour
{
    public PingPongAgent agent;
    public PingPongAgent opponent;
    public TMP_Text textScore;

    private int score;

    private void Start()
    {
        score = 0;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Ball>(out Ball ball))
        {
            agent.SetReward(-1f);
            agent.EndEpisode();
            opponent.EndEpisode();
        }

        score++;
        textScore.text = "Score: " + score;
    }
}
