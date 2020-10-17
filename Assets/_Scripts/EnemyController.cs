using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float horizontalSpeed;
    public float verticalSpeed;
    public float horizontalBoundary;

    public EnemyManager enemyManager;

    private float direction;

    // Start is called before the first frame update
    void Start()
    {
        direction = 1; 
        enemyManager = FindObjectOfType<EnemyManager>();
    }

    // Update is called once per frame
    void Update()
    {
        _Move();
        _CheckBounds();
    }

    private void _Move()
    {
        transform.Translate(new Vector3(horizontalSpeed * direction * Time.deltaTime, -verticalSpeed * Time.deltaTime, 0));
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log(other.gameObject.name);
        enemyManager.ReturnEnemy(gameObject);
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
