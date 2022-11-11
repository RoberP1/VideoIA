using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;

public class PingPongAgent : Agent
{
    public float speed;
    public float maxZ, minZ;

    public Ball ball;

    public Vector3 startingPosition;

    public PingPongAgent opponent;
    public override void OnEpisodeBegin()
    {
        transform.localPosition = startingPosition;
        ball.Initialize();
    }
    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.localPosition);
        sensor.AddObservation(ball.transform.localPosition);
        sensor.AddObservation(ball.rb.velocity);
        sensor.AddObservation(opponent.transform.position);
    }
    public override void OnActionReceived(ActionBuffers actions)
    {
        float moveZ = (actions.DiscreteActions[0] == 2) ? -1 : actions.DiscreteActions[0];
        moveZ *= speed * Time.deltaTime;
        moveZ += transform.localPosition.z;
        if (moveZ <= maxZ && moveZ >= minZ)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, moveZ);
        }
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        ActionSegment<int> discretsActions = actionsOut.DiscreteActions;
        switch (Input.GetAxisRaw("Vertical"))
        {
            case 1: discretsActions[0] = 1; break;
            case 0: discretsActions[0] = 0; break;
            case -1: discretsActions[0] = 2; break;
        }
    }
}
