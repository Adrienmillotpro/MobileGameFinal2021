using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapParticleSystem : MonoBehaviour
{
    [SerializeField] private GameObject particuleHit;

    public static TapParticleSystem Instance { get; private set; }
    private Queue<GameObject> tapParticleQueue = new Queue<GameObject>();

    private void Awake()
    {
        Instance = this;
    }
    public GameObject Get()
    {
        if (this.tapParticleQueue.Count == 0)
        {
            AddObject();
        }
        return this.tapParticleQueue.Dequeue();
    }

    private GameObject AddObject()
    {
        var newPS = Instantiate(particuleHit);
        newPS.gameObject.SetActive(false);
        this.tapParticleQueue.Enqueue(newPS);
        return newPS;
    }

    public void ReturnToPool(GameObject objectToReturn)
    {
        objectToReturn.gameObject.SetActive(false);
        this.tapParticleQueue.Enqueue(objectToReturn);
    }
}
