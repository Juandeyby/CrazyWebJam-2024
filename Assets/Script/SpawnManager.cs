using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject objectToSpawn;
    [SerializeField] Transform startPosition;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       SpawnBall(); 
    }

    private void SpawnBall()
    {
        Vector3 spawnPosition = startPosition.position;

        Instantiate(objectToSpawn, spawnPosition, Quaternion.identity); 
    }
}
