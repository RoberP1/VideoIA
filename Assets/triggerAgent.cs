using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerAgent : MonoBehaviour
{
    public AgentTest agent;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<ball>(out ball ball))
        {
            agent.AddReward(1f);
        }
    }
}
