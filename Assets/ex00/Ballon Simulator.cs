using UnityEngine;
using UnityEngine.Rendering.Universal;

public class BallonSimulator : MonoBehaviour
{
    public bool isInflating = false;
    public Transform ballonTransform;
    public float timeToInflate = 1.0f;
    public float timeToResetKey = 0;
    public float maxBallonSize = 4.0f;
    public float breathingSpeed = 1.0f;
    private float gameTime = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ballonTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        gameTime += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && breathingSpeed > 0.3f)
        {
            isInflating = true;
            timeToResetKey = Time.time + timeToInflate;
            breathingSpeed -= 0.3f;
        }

        InflateBallon();

        if(breathingSpeed < 1)
            breathingSpeed += Time.deltaTime * 0.1f;
    }

    void InflateBallon()
    {
        if (isInflating)
        {
            if (timeToResetKey >= Time.time)
            {
                ballonTransform.localScale += Vector3.one * Time.deltaTime;
                if (ballonTransform.localScale.x > maxBallonSize)
                { 
                    Debug.Log("Ballon life time: " + Mathf.RoundToInt(gameTime) + "s");
                    Destroy(this.gameObject);
                }
            }
            else
            {
                isInflating = false;
            }
        }
        else if (!isInflating && ballonTransform.localScale.x > 1f)
        {
            ballonTransform.localScale += -Vector3.one * Time.deltaTime;
        }
    }
}
