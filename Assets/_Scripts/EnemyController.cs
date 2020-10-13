using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float horizontalSpeed;
    public float horizontalBoundary;

    private float direction;

    // Start is called before the first frame update
    void Start()
    {
        direction = 1; 
    }

    // Update is called once per frame
    void Update()
    {
        _Move();
        _CheckBounds();
    }

    private void _Move()
    {
        transform.Translate(new Vector3(horizontalSpeed * direction * Time.deltaTime, 0, 0));
    }

    private void _CheckBounds()
    {
        if(transform.position.x >= horizontalBoundary)
        {
            direction = -1.0f;
        } 

        if(transform.position.x <= -horizontalBoundary)
        {
            direction = 1.0f;
        }
    }
}
