using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HeroParticlesPool : MonoBehaviour
{
    [SerializeField] private GameObject[] fireParticles;
    [SerializeField] private GameObject[] airParticles;
    [SerializeField] private GameObject[] thunderParticles;
    [SerializeField] private GameObject[] waterParticles;

    public static HeroParticlesPool Instance { get; private set; }

    private Queue<GameObject>[] fireQueue = new Queue<GameObject>[3];
    private Queue<GameObject>[] airQueue = new Queue<GameObject>[3];
    private Queue<GameObject>[] thunderQueue = new Queue<GameObject>[3];
    private Queue<GameObject>[] waterQueue = new Queue<GameObject>[3];

    private int intensityOfParticle;
    private Queue<GameObject> queueToPoolFrom;
    private GameObject currentParticleSystem;

    private void Awake()
    {
        Instance = this;
        for (int i = 0; i < fireQueue.Length; i++)
        {
            fireQueue[i] = new Queue<GameObject>();
        }
        for (int i = 0; i < airQueue.Length; i++)
        {
            airQueue[i] = new Queue<GameObject>();
        }
        for (int i = 0; i < thunderQueue.Length; i++)
        {
            thunderQueue[i] = new Queue<GameObject>();
        }
        for (int i = 0; i < waterQueue.Length; i++)
        {
            waterQueue[i] = new Queue<GameObject>();
        }
    }

    public GameObject Get(ElementalTypes element, float elementalReactionStrength)
    {
        DetermineIntensity(elementalReactionStrength);
        DetermineQueue(element);
        DetermineParticleSystem(element);

        if (queueToPoolFrom.Count == 0)
        {
            AddObject(currentParticleSystem, queueToPoolFrom);
        }
        return queueToPoolFrom.Dequeue();
    }

    public void ReturnToPool(GameObject objectToReturn, ElementalTypes particleElement, int intensityOfParticle)
    {
        DetermineIntensity(intensityOfParticle);
        DetermineQueue(particleElement);
        objectToReturn.gameObject.SetActive(false);
        this.queueToPoolFrom.Enqueue(objectToReturn);
    }

    private void DetermineIntensity(float intensity)
    {
        if (intensity == 0)
        {
            intensityOfParticle = 0;
        }
        else if (intensity == 0.5 || intensity == 1)
        {
            intensityOfParticle = 1;
        }
        else if (intensity == 2)
        {
            intensityOfParticle = 2;
        }
    }
    public void DetermineQueue(ElementalTypes type)
    {
        switch (type)
        {
            case ElementalTypes.Fire:
                queueToPoolFrom =  fireQueue[intensityOfParticle];
                break;
            case ElementalTypes.Air:
                queueToPoolFrom = airQueue[intensityOfParticle];
                break;

            case ElementalTypes.Thunder:
                queueToPoolFrom =  thunderQueue[intensityOfParticle];
                break;

            case ElementalTypes.Water:
                queueToPoolFrom = waterQueue[intensityOfParticle];
                break;
        }
    }
    public void DetermineParticleSystem(ElementalTypes type)
    {
        switch (type)
        {
            case ElementalTypes.Fire:
                currentParticleSystem =  fireParticles[intensityOfParticle];
                break;
            case ElementalTypes.Air:
                currentParticleSystem = airParticles[intensityOfParticle];
                break;

            case ElementalTypes.Thunder:
                currentParticleSystem = thunderParticles[intensityOfParticle];
                break;
            case ElementalTypes.Water:
                currentParticleSystem = waterParticles[intensityOfParticle];
                break;
        }
    }

    private GameObject AddObject(GameObject particleSystem, Queue<GameObject> queue)
    {
        var newPS = Instantiate(particleSystem);
        newPS.gameObject.SetActive(false);
        queue.Enqueue(newPS);
        return newPS;
    }
}
