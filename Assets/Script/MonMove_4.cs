using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonMove_4 : MonoBehaviour
{

    public Transform[] path;
    public float speed;
    public float reachDist;
    public int currentPoint;

    private static bool check;

    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

        check = Boss.move_5;

        if (check == true)
        {

            float dist = Vector3.Distance(path[currentPoint].position, transform.position);

            transform.position = Vector3.MoveTowards(transform.position, path[currentPoint].position, Time.deltaTime * speed);

            if (dist <= reachDist)
            {

                currentPoint++;

            }

            if (currentPoint >= path.Length)
            {

                currentPoint = 0;

            }
        }
    }

    void OnDrawGizmos()
    {

        for (int i = 0; i < path.Length; i++)
        {

            if (path[i] != null)
            {

                Gizmos.DrawSphere(path[i].position, reachDist);

            }

        }

    }
}
