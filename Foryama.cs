using UnityEngine;

public class Foryama : MonoBehaviour
{
    private int[] numbers = { 8, 9, 1, 5, 2, 3, 4 };
    private int smolNumber;
    public int bigNumber;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bigNumber = numbers[0];
        smolNumber = numbers[0];


        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] > bigNumber)
            {
                bigNumber = numbers[i];
            }

            if (numbers[i] < smolNumber)
            {
                smolNumber = numbers[i];
            }
        }

        Debug.Log(smolNumber);
        Debug.Log(bigNumber);


    }

    // Update is called once per frame
    void Update()
    {

    }
}
