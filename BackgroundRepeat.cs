using UnityEngine;
using System.Collections;

public class BackgroundRepeat : MonoBehaviour
{
    private Vector3 startPosition;
    private float repeatDistance;
    [SerializeField] private int speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = startPosition;
        repeatDistance = GetComponent<BoxCollider>().size.x / 2;

        StartCoroutine(Moveback());
    }

    private IEnumerator Moveback()
    {
        while (true)
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime, Space.World);

            // If background moves left by its repeat width, move it back to start position
            if (transform.position.z < startPosition.z - repeatDistance)
            {
                transform.position = startPosition;
            }


            yield return new WaitForFixedUpdate();

        }
    }

    // Update is called once per frame
    void Update()
    {





    }
}
