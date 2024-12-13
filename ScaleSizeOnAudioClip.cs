using UnityEngine;

public class ScaleSizeOnAudioClip : MonoBehaviour
{
    public ListenToAudioClip detector;
    public AudioSource source;
    public Vector3 minScale;
    public Vector3 maxScale;

    public float loudnessSensitivity = 100f;
    public float threshold = 0.1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float loudness = detector.GetLoudnessFromAudioClip(source.timeSamples, source.clip) * loudnessSensitivity;
        if (loudness < threshold)
        {
            loudness = 0;
        }
        transform.localScale = Vector3.Lerp(minScale,maxScale,loudness);
    }
}
