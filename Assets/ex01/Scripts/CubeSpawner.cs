using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;

public class CubeSpawner : MonoBehaviour
{
    public Transform[] spawnPos;
    public GameObject[] cubePrefabs;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CreateCube();
        }
    }

    void CreateCube()
    {
        int x = Random.Range(0, 3);
        char key = ' ';

        switch (x)
        {
            case 0:
                key = 'A';
                break;
            case 1:
                key = 'D';
                break;
            case 2:
                key = 'S';
                break;
        }

        GameObject cube = cubePrefabs[x];
        cube.GetComponent<Cube>().ConstructCube(key);

        Instantiate(cube, spawnPos[x]);
    }
}
