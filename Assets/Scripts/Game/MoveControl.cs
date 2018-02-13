using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveControl : MonoBehaviour {
    public GameObject Path;
    public float Dump, curDist;
    float curSpeed;
    WayPoint[] wayPoints;
    NavMeshAgent loco;
    int curWayPoint = 0;
    Transform TF;

	// Use this for initialization
	void Start () {
        wayPoints = Path.GetComponentsInChildren<WayPoint>();
        loco = GetComponent<NavMeshAgent>();
        loco.SetDestination(wayPoints[curWayPoint].transform.position);
        TF = transform;
	}
	
	void Update () {
        curDist = (TF.position - loco.destination).sqrMagnitude;

        if ((TF.position - loco.destination).sqrMagnitude < Dump)
        {
            curWayPoint++;
            if (curWayPoint > wayPoints.Length - 1)
                curWayPoint = 0;
            loco.SetDestination(wayPoints[curWayPoint].transform.position);
        }
        loco.speed = Mathf.Lerp(loco.speed, curSpeed, Time.deltaTime * (1f / 2f));
        loco.angularSpeed = loco.speed * loco.speed;
    }
    public void SetSpeed(float speed)
    {
        speed = Mathf.Clamp(speed, 0, 10f);
        curSpeed = speed;
    }
    public float GetSpeed()
    {
        return loco.speed;
    }
    public void Pause(bool state)
    {
        if (state)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        if (Application.isPlaying)
        {
            Gizmos.DrawSphere(wayPoints[curWayPoint].transform.position, 1);
        }
    }
}
