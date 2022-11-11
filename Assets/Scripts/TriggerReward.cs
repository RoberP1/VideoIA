using UnityEngine;

public class TriggerReward : MonoBehaviour
{
    public PingPongAgent agent;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Ball>(out Ball ball))
        {
            agent.AddReward(1f);
        }
    }
}
