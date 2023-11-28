﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectEntity : MonoBehaviour
{
    public float lifeTime;
    public bool spawnRelateToTransform;

    // Use this for initialization
    void Start()
    {
        var particles = GetComponentsInChildren<ParticleSystem>();
        foreach (var particle in particles)
            particle.Play();
        var audioSources = GetComponentsInChildren<AudioSource>();
        foreach (var audioSource in audioSources)
            audioSource.Play();
        Destroy(gameObject, lifeTime);
    }

    public static void PlayEffect(EffectEntity prefab, Transform transform)
    {
        PlayEffect(prefab, transform.position, transform.rotation, transform);
    }

    public static void PlayEffect(EffectEntity prefab, Vector3 position, Quaternion rotation, Transform transform = null)
    {
        if (prefab != null)
        {
            var effectEntity = Instantiate(prefab, position, rotation, prefab.spawnRelateToTransform ? transform : null);
            // Just in case the game object might be not activated by default
            effectEntity.gameObject.SetActive(true);
        }
    }
}
