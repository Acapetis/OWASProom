using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotMovement : MonoBehaviour
{
    public Transform[] waypoints;   // an array of waypoints for the bot to move towards
    public float speed = 5f;        // the speed at which the bot moves

    private int currentWaypoint = 0;    // the index of the current waypoint

    private Rigidbody2D rb;           // reference to the Rigidbody component
    public Animator animator;
    Vector2 movement;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();    // get a reference to the Rigidbody component on this GameObject
        Debug.Log("BotMovement script started");
        // move towards the first waypoint
        Vector3 direction = waypoints[currentWaypoint].position - transform.position;
        rb.velocity = direction.normalized * speed;
    }

    void FixedUpdate()
    {
        Vector3 direction = waypoints[currentWaypoint].position - transform.position;
        movement = direction.normalized;
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        if (direction.magnitude < 0.1f)
        {
            rb.velocity = Vector3.zero;
            if (currentWaypoint == waypoints.Length - 1)
            {
                
                // We have reached the last waypoint, so wait for 2 seconds
                // and then restart the waypoint loop
                StartCoroutine(WaitAndRestart());
            }
            else
            {
                // Move towards the next waypoint
                currentWaypoint++;
                Debug.Log("reach");

                direction = waypoints[currentWaypoint].position - transform.position;
                rb.velocity = direction.normalized * speed;
            }
        }
    }

    IEnumerator WaitAndRestart()
    {
        // Wait for 2 seconds
        yield return new WaitForSeconds(2f);

        // Restart the waypoint loop
        currentWaypoint = 0;
        Vector3 direction = waypoints[currentWaypoint].position - transform.position;
        rb.velocity = direction.normalized * speed;
    }

}

