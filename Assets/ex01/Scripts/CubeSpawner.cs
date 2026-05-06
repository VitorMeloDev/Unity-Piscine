using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CubeSpawner : MonoBehaviour
{
    public Transform[] spawnPos;
    public Transform bottomTransform;
    public GameObject[] cubePrefabs;
    public List<Cube> cubes = new List<Cube>();
    private float spawnTime = 2;

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= spawnTime)
        {
            spawnTime = Time.time + Random.Range(2f, 5f);
            CreateCube();
        }

        if (Input.GetKeyDown(KeyCode.A))
            SearchForCube('A');
        if (Input.GetKeyDown(KeyCode.S))
            SearchForCube('S');
        if (Input.GetKeyDown(KeyCode.D))
            SearchForCube('D');

        CleanCubeList();
    }

    void SearchForCube(char key)
    {
        foreach (var cube in cubes)
        {
            if(cube.GetKey() == key && cube.transform.localPosition.y > -7.5f)
            {
                CalculatePrecision(cube);
                break;
            }
        }
    }

    void CalculatePrecision(Cube cube)
    { 
        string message = "Precision: ";
        float precision = cube.GetPositionY() - bottomTransform.position.y;
        Debug.Log(message + precision.ToString("F2"));
    }

    void CleanCubeList()
    {
        for (int i = cubes.Count - 1; i >= 0; i--)
        {
            if (cubes[i] == null)
                cubes.RemoveAt(i);
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

        GameObject cube = Instantiate(cubePrefabs[x], spawnPos[x]);
        cube.GetComponent<Cube>().ConstructCube(key);
        cubes.Add(cube.GetComponent<Cube>());
    }
}
