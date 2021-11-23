using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User : MonoBehaviour
{
    Rigidbody rigid;
    public float FrontSpeed; // 입력받을 캐릭터의 정면 속도
    public float SideSpeed; // 입력받을 캐릭터의 좌우 속도
    public float JumpPower; // 입력받을 캐릭터의 점프 높이
    float[] SpeedRate = { 1.2f, 1.4f, 1.8f, 2 }; // 거리에 따른 이동속도
    bool Jumping;

    private AudioSource audioSource;

    public float rmsVal;
    public float dbVal;
    public float pitchVal;

    private const int QSamples = 1024;
    private const float RefValue = 0.1f;
    private const float Threshold = 0.02f;

    float[] _samples;
    private float[] _spectrum;
    private float _fSample;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
        Jumping = false;

        audioSource = GetComponent<AudioSource>();
        audioSource.clip = Microphone.Start(null, false, 999, 44100);
        while (!(Microphone.GetPosition(null) > 0)) ;
        audioSource.Play();

        _samples = new float[QSamples];
        _spectrum = new float[QSamples];
        _fSample = AudioSettings.outputSampleRate;
    }

    void Update()
    {
        //if (Input.GetButtonDown("Jump") && !Jumping) // 스페이스를 누르면 점프
        //{
        //    Jumping = true;
        //    Jump();
        //}

        AnalyzeSound();

        if(dbVal > -90f && !Jumping)
        {
            Jumping = true;
            Jump();
        }

        //Debug.Log("RMS: " + rmsVal.ToString("F2"));
        //Debug.Log(dbVal.ToString("F1") + " dB");
        //Debug.Log(pitchVal.ToString("F0") + " Hz");
    }

    void FixedUpdate()
    {
        Move();

    }

    void Jump()
    {
        rigid.AddForce(Vector3.up * JumpPower, ForceMode.Impulse); // y축으로 점프할 높이

    }

    private void OnCollisionEnter(Collision collision)
    {
        Jumping = false;
    }

    public void Move()
    {
        float moveSpeed = Time.fixedDeltaTime * FrontSpeed; // 캐릭터의 속도 계산
        Vector3 dir = Vector3.zero;

        dir.x = Input.acceleration.x;

        if (dir.sqrMagnitude > 1)
            dir.Normalize();

        dir *= Time.deltaTime;

        if (transform.position.z >= 100 && transform.position.z < 300)
        {
            moveSpeed *= SpeedRate[0];
            //Debug.Log("첫 번째 배속");
        }
        else if (transform.position.z >= 300 && transform.position.z < 500)
        {
            moveSpeed *= SpeedRate[1];
            //Debug.Log("두 번째 배속");
        }
        else if (transform.position.z >= 500 && transform.position.z < 700)
        {
            moveSpeed *= SpeedRate[2];
            //Debug.Log("세 번째 배속");
        }
        else if (transform.position.z >= 700)
        {
            moveSpeed *= SpeedRate[3];
            //Debug.Log("네 번째 배속");
        }

        rigid.position += Vector3.forward * moveSpeed;
        transform.Translate(dir.x * SideSpeed, 0, 0);


    }

    void AnalyzeSound()
    {
        GetComponent<AudioSource>().GetOutputData(_samples, 0); // fill array with samples
        int i;
        float sum = 0;
        for (i = 0; i < QSamples; i++)
        {
            sum += _samples[i] * _samples[i]; // sum squared samples
        }
        rmsVal = Mathf.Sqrt(sum / QSamples); // rms = square root of average
        dbVal = 20 * Mathf.Log10(rmsVal / RefValue); // calculate dB
        if (dbVal < -160) dbVal = -160; // clamp it to -160dB min
                                        // get sound spectrum
        GetComponent<AudioSource>().GetSpectrumData(_spectrum, 0, FFTWindow.BlackmanHarris);
        float maxV = 0;
        var maxN = 0;
        for (i = 0; i < QSamples; i++)
        { // find max 
            if (!(_spectrum[i] > maxV) || !(_spectrum[i] > Threshold))
                continue;

            maxV = _spectrum[i];
            maxN = i; // maxN is the index of max
        }
        float freqN = maxN; // pass the index to a float variable
        if (maxN > 0 && maxN < QSamples - 1)
        { // interpolate index using neighbours
            var dL = _spectrum[maxN - 1] / _spectrum[maxN];
            var dR = _spectrum[maxN + 1] / _spectrum[maxN];
            freqN += 0.5f * (dR * dR - dL * dL);
        }
        pitchVal = freqN * (_fSample / 2) / QSamples; // convert index to frequency
    }


}
