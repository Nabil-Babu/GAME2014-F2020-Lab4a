using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public EnemyFactory enemyFactory;
    public int MaxEnemies; 
    private Queue<GameObject> m_EnemyPool;

    void Start()
    {
        _BuildEnemyPool();
    }

    void Update()
    {
        _SpawnEnemy();
    }


    private void _SpawnEnemy()
    {
        if(Time.frameCount % 60 == 0 && HasEnemies())
        {
            GetBullet(new Vector3(transform.position.x+(Random.Range(-2,2)), transform.position.y, 0));
        }
    }

    private void _BuildEnemyPool()
    {
        // create empty Queue structure
        m_EnemyPool = new Queue<GameObject>();

        for (int count = 0; count < MaxEnemies; count++)
        {
            var tempEnemy = enemyFactory.createEnemy();
            m_EnemyPool.Enqueue(tempEnemy);
        }
    }

    public GameObject GetBullet(Vector3 position)
    {
        var newEnemy = m_EnemyPool.Dequeue();
        newEnemy.SetActive(true);
        newEnemy.transform.position = position;
        return newEnemy;
    }

    public bool HasEnemies()
    {
        return m_EnemyPool.Count > 0;
    }

    public void ReturnEnemy(GameObject returnedEnemy)
    {
        returnedEnemy.SetActive(false);
        m_EnemyPool.Enqueue(returnedEnemy);
    }
}
