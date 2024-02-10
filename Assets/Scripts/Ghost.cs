using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public Transform target;
    public float moveSpeed = 5f;

    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        if (target != null)
        {

            Vector3 direction = target.position - transform.position;
            direction.y = 0;

            direction.Normalize();

            transform.position += direction * moveSpeed * Time.deltaTime;
        }
    }


}
