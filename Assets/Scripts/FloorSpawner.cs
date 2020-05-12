using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSpawner : MonoBehaviour
{
    public GameObject floorPrefab, obstaclePrefab, floors, obstacles;
    public GameObject player, standbyCamera;
    public List<GameObject> floorVault, obstacleVault;
    public bool bGameStarted = false;

    private bool initialized= false;
    private GameObject playerClone;

    private void Start()
    {
        floorVault.Insert(0, Instantiate(floorPrefab, floors.transform));
        obstacleVault.Insert(0, Instantiate(obstaclePrefab, obstacles.transform));
        playerClone = Instantiate(player, player.transform.position, player.transform.rotation, null);
        Destroy(standbyCamera);
    }
    public void Update()
    {
        if((Input.GetKey(KeyCode.Space) || initialized) && bGameStarted == false)
        {
            bGameStarted = true;
            SpawnStarter();
            playerClone.GetComponent<Player>().Initialization();
        }
        if (bGameStarted)
        {
            DestroyBehind();
        }
    }
    public void Initialization(bool init)
    {
        initialized = init;
    }
    public void SpawnStarter()
    {
        InvokeRepeating("SpawnFloors", 0.1f, 3f);
        InvokeRepeating("SpawnObstacles", 0.1f, 1f);
    }
    public void SpawnStopper()
    {
        CancelInvoke("SpawnFloors");
        CancelInvoke("SpawnObstacles");
    }
    void SpawnFloors()
    {
        GameObject floorClone = Instantiate(floorPrefab, floorVault[floorVault.Count - 1].transform.position + new Vector3(0f, 0f, 15f),
            floorVault[floorVault.Count - 1].transform.rotation, floors.transform);
        floorVault.Add(floorClone);
    }
    void SpawnObstacles()
    {
        GameObject obstacleClone = Instantiate(obstaclePrefab, obstacleVault[obstacleVault.Count - 1].transform.position + new Vector3(0f, 0f, Random.Range(7f, 15f)),
            obstacleVault[obstacleVault.Count - 1].transform.rotation, obstacles.transform);
        obstacleVault.Add(obstacleClone);
    }
    void DestroyBehind()
    {
        if (floorVault.Count > 1 && ((floorVault[0].transform.position.z + 20f) < player.gameObject.transform.position.z))
        {
            Destroy(floorVault[0]);
            floorVault.RemoveAt(0);
        }
        if (obstacleVault.Count > 1 && ((obstacleVault[0].transform.position.z + 8f) < player.gameObject.transform.position.z))
        {
            Destroy(obstacleVault[0]);
            obstacleVault.RemoveAt(0);
        }
    }
}
