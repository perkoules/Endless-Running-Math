using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class FloorSpawner : MonoBehaviour
{
    [SerializeField] GameObject floor;

    public List<GameObject> floorHolder;
    //int spawnerCounter = 0;

    public void SpawnStarter()
    {

        floorHolder.Insert(0, floor);
        InvokeRepeating("SpawnFloor", 0.1f, 3f);
        InvokeRepeating("DestroyFloorBehind", 9f, 4f);
    }

    void SpawnFloor()
    {
        //spawnerCounter++;
        GameObject floorClone = Instantiate(floor, floorHolder[floorHolder.Count - 1].transform.position + new Vector3(0f, 0f, 15f),
            floorHolder[floorHolder.Count - 1].transform.rotation, gameObject.transform);
        print((floorHolder.Count).ToString());
        floorHolder.Add(floorClone);
    }

    void DestroyFloorBehind()
    {
        Destroy(floorHolder[1]);
        floorHolder.RemoveAt(1);
    }
}
