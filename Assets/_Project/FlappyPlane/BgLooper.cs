using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BgLooper : MonoBehaviour
{

    public int obstacleCount = 0;
    public int numBgCount = 5;
    public Vector3 obstacleLastPosition = Vector3.zero;
    
    
    void Start()
    {
        Obstacle[] obstacles = FindObjectsOfType<Obstacle>();
        obstacleLastPosition = obstacles[0].transform.position;
        obstacleCount = obstacles.Length;

        for (int i = 0; i < obstacleCount; i++)
        {
            obstacleLastPosition = obstacles[i].SetRandomPlace(obstacleLastPosition, obstacleCount);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);

        if (collision.CompareTag("Background"))
        {
            /* 어떤 Collider2D든 공통으로 있는 AABB bounds 이용
            float width = collision.GetComponent<SpriteRenderer>().bounds.size.x; // 또는 parent로

            var t = collision.transform;
            t.position = new Vector3(t.position.x + width * numBgCount, t.position.y, t.position.z);*/

            float widthOfBgObject = ((BoxCollider2D)collision).size.x;
            Vector3 pos = collision.transform.position;

            pos.x += widthOfBgObject * numBgCount;
            collision.transform.position = pos;
            
            return;
        }

        
        Obstacle obstacle = collision.GetComponent<Obstacle>();
        if (obstacle)
        {
            obstacleLastPosition = obstacle.SetRandomPlace(obstacleLastPosition, obstacleCount);
        }
        
    }

}