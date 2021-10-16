using System.Collections;
using UnityEngine;

public class PatrolCoroutines : MonoBehaviour
{

    public Transform[] waypoints;
    private int _currentWaypointIndex = 0;
    private float _speed = 2f;

    private float _waitTime = 1f; // in seconds

    private void Start()
    {
        StartCoroutine(_MovingToNextWaypoint());
    }

    private IEnumerator _MovingToNextWaypoint()
    {
        Transform wp = waypoints[_currentWaypointIndex];

        while (Vector3.Distance(transform.position, wp.position) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, wp.position, _speed * Time.deltaTime);
            yield return null;
        }

        transform.position = wp.position;
        yield return new WaitForSeconds(_waitTime);
        _currentWaypointIndex = (_currentWaypointIndex + 1) % waypoints.Length;

        StartCoroutine(_MovingToNextWaypoint());
    }

}
