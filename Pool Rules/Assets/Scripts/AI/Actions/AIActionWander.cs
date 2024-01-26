using UnityEngine;

public class AIActionWander : AIAction
{
    [SerializeField] private float wanderRadius = 5f;
    [SerializeField] private float wanderTimer = 5f;

    private float timer;

    public override void Initialization()
    {
        base.Initialization();
        timer = wanderTimer;
    }

    public override void PerformAction()
    {
        Debug.Log("Wandering");

        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            Vector3 newPosition = RandomWanderPosition();
            MoveToPosition(newPosition);
            timer = wanderTimer;
        }
    }

    private void MoveToPosition(Vector3 newPosition)
    {
        transform.position = newPosition;
    }

    private Vector3 RandomWanderPosition()
    {
        Vector3 randomDirection = Random.insideUnitSphere * wanderRadius;
        randomDirection += transform.position;
        return new Vector3(randomDirection.x, transform.position.y, randomDirection.z);
    }
}
