using System.Collections;
using System.Collections.Generic;
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
}
