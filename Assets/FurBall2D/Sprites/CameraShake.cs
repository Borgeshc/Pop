using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
    public bool Shaking;
    public float ShakeDecay;
    public float ShakeIntensity;
    public float shakeSpeed;
    private Vector3 OriginalPos;
    private Quaternion OriginalRot;

    void Start()
    {
        Shaking = false;
    }

    void Update()
    {
        if (ShakeIntensity > 0)
        {
            transform.position = OriginalPos + Random.insideUnitSphere * ShakeIntensity;
            transform.rotation = new Quaternion(OriginalRot.x + Random.Range(-ShakeIntensity, ShakeIntensity) * shakeSpeed,
                                      OriginalRot.y + Random.Range(-ShakeIntensity, ShakeIntensity) * shakeSpeed,
                                      OriginalRot.z + Random.Range(-ShakeIntensity, ShakeIntensity) * shakeSpeed,
                                      OriginalRot.w + Random.Range(-ShakeIntensity, ShakeIntensity) * shakeSpeed);

            ShakeIntensity -= ShakeDecay;
        }
        else if (Shaking)
        {
            Shaking = false;
        }
    }

    public void DoShake()
    {
        OriginalPos = transform.position;
        OriginalRot = transform.rotation;
        Shaking = true;
    }
}
