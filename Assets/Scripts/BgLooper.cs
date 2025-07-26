using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BgLooper : MonoBehaviour
{
    public int ObstacleCount = 0; // �Ľ�Į������ ����
    public Vector3 ObstacleLastPosition = Vector3.zero; // �Ľ�Į������ ����

    void Start()
    {
        Obstacle[] obstacles = GameObject.FindObjectsOfType<Obstacle>();
        ObstacleLastPosition = obstacles[0].transform.position;
        ObstacleCount = obstacles.Length;

        for (int i = 0; i < ObstacleCount; i++)
        {
            ObstacleLastPosition = obstacles[i].SetRandomPlace(ObstacleLastPosition, ObstacleCount);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Triggered: " + collision.name);

        Obstacle obstacle = collision.GetComponent<Obstacle>();
        if (obstacle)
        {
            ObstacleLastPosition = obstacle.SetRandomPlace(ObstacleLastPosition, ObstacleCount);
        }
    }
}