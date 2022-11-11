using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;

public class AgentTest : Agent
{
    public float speed = 1f;
    public ball ball;

    public Vector3 startPosition;

    public AgentTest enemy;
    public override void OnEpisodeBegin()
    {
        transform.localPosition = startPosition;
        ball.Initialize();
    }
    public override void OnActionReceived(ActionBuffers actions)
    {
        float moveZ = actions.DiscreteActions[0] == 2 ? -1f : actions.DiscreteActions[0];
        Debug.Log(moveZ);
        moveZ *= speed * Time.deltaTime;

        Vector3 move = new Vector3(0, 0, moveZ) + transform.localPosition;
        if (move.z <= 20 && move.z >= -20)
        {
            transform.localPosition = move;
        }
    }
    public override void Heuristic(in ActionBuffers actionsOut)
    {
        ActionSegment<int> discreteActions = actionsOut.DiscreteActions;

        if (Input.GetAxis("Vertical") > 0) discreteActions[0] = 1;
        if (Input.GetAxis("Vertical") < 0) discreteActions[0] = 2;
        
        //discreteActions[0] = Input.GetAxis("Horizontal");
    }
    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.localPosition);
        sensor.AddObservation(ball.transform.localPosition);
        sensor.AddObservation(ball.rb.velocity);
        sensor.AddObservation(enemy.transform.localPosition);
    }
}
