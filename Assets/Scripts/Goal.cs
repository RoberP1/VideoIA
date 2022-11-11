using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public PingPongAgent agent;
    public PingPongAgent opponent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Ball>(out Ball ball))
        {
            agent.SetReward(-1f);
            agent.EndEpisode();
            opponent.EndEpisode();
        }
    }
}
