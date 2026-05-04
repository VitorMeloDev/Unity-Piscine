using UnityEngine;
using UnityEngine.Rendering;

public class Cube : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private char key;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void ConstructCube(char value)
    {
        key = value;
    }

    private void Start()
    {
        speed = Random.Range(-2.0f, -1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, speed * Time.deltaTime, 0);
    }
}
