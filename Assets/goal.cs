using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goal : MonoBehaviour
{
    public AgentTest agent;
    public AgentTest enemyAgent;
    public void OnBallEnter()
    {
        agent.SetReward(-1f);
        agent.EndEpisode();
        enemyAgent.EndEpisode();
    }
}
