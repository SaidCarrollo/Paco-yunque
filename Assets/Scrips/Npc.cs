using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : MonoBehaviour
{
    public Transform[] waypoints; 
    public float moveSpeed = 3f;
    public float pauseDuration = 2f;

    public float collisionPauseDuration = 5f; 

    private int currentWaypointIndex = 0;
    private bool isPaused = false;

    void Start()
    {
        StartCoroutine(MoveToNextWaypoint());
    }

    IEnumerator MoveToNextWaypoint()
    {
        while (true)
        {
            if (!isPaused)
            {
                Vector3 targetPosition = waypoints[currentWaypointIndex].position;
                while (transform.position != targetPosition)
                {
                    transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
                    yield return null;
                }

                yield return new WaitForSeconds(pauseDuration);
                currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
            }
            else
            {
               
                yield return new WaitForSeconds(collisionPauseDuration);
                isPaused = false; 
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Jugador"))
        {
            isPaused = true; 
            StartCoroutine(ResumeMovementAfterPause());
        }
    }

    IEnumerator ResumeMovementAfterPause()
    {
       
        yield return new WaitForSeconds(collisionPauseDuration);
        isPaused = false; 
    }
}
