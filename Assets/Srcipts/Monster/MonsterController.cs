using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public float speed;
    private Waypoint waypoint;
    private int waypointIndex;
    // Start is called before the first frame update
    void Start()
    {
        waypoint = GameObject.FindGameObjectWithTag("waypoint").GetComponent<Waypoint>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, waypoint.waypoints[waypointIndex].position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, waypoint.waypoints[waypointIndex].position) < 0.1f)
        {
            waypointIndex++;
        }
    }

   
}
