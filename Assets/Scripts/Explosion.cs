using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    void Start()
    {
        ParticleSystem[] systems = GetComponentsInChildren<ParticleSystem>();

        float maxTime = 0f;

        foreach (var ps in systems)
        {
            float totalTime = ps.main.duration + ps.main.startLifetime.constantMax;

            if (totalTime > maxTime)
                maxTime = totalTime;
        }

        Destroy(gameObject, maxTime);
    }
}