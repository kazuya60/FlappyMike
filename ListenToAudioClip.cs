using UnityEngine;

public class ListenToAudioClip : MonoBehaviour
{
    public int sampleWindow = 64;
    private AudioClip microphoneClip;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Debug microphone devices
        Debug.Log("Total Microphones: " + Microphone.devices.Length);
        foreach (string device in Microphone.devices)
        {
            Debug.Log("Microphone Device: " + device);
        }


        GetMicrophoneInputData();

        Debug.Log("Checking microphone permissions...");
        Debug.Log("Has permission: " + Application.HasUserAuthorization(UserAuthorization.Microphone));
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GetMicrophoneInputData()
    {

        if (Microphone.devices.Length > 0)
        {
            // Use the first detected microphone (likely your laptop's built-in mic)
            string microphoneName = Microphone.devices[0];
            Debug.Log("Using Microphone: " + microphoneName);
            // Adjust parameters if needed
            int sampleRate = AudioSettings.outputSampleRate; // Default sample rate for many microphones
            int duration = 5; // Reduce recording duration
            Debug.Log("The Sample rate of microdick is: " + sampleRate);


            try
            {
                microphoneClip = Microphone.Start(microphoneName, true, duration, sampleRate);
                if (microphoneClip == null)
                {
                    Debug.LogError("Microphone.Start() returned null. Check device compatibility.");
                }
                else
                {
                    Debug.Log("Microphone started successfully.");
                }
            }

            
            catch (System.Exception e)
            {
                Debug.LogError("Error initializing microphone: " + e.Message);
            }

            Debug.Log("Recording started: " + Microphone.IsRecording(microphoneName));

        }
        else
        {
            Debug.LogError("No microphones found on this device!");
        }
    }





    public float GetLoudnessFromAudioClip(int clipPosition, AudioClip clip)
    {
        int startPosition = clipPosition - sampleWindow;

        if (startPosition < 0)
            return 0;

        float[] waveData = new float[sampleWindow];
        clip.GetData(waveData, startPosition);

        //compute loudness
        float totalLoudness = 0;

        for (int i = 0; i < sampleWindow; i++)
        {

            totalLoudness += Mathf.Abs(waveData[i]);

        }

        return totalLoudness / sampleWindow;



    }

    public float GetLoudnessFromMicrophone()
    {
        return GetLoudnessFromAudioClip(Microphone.GetPosition(Microphone.devices[0]), microphoneClip);
    }
}
