using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelSpin : MonoBehaviour
{
    Rigidbody2D myrb2d;
    [SerializeField] private float speed;


    void Start()
    {
        myrb2d = this.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        myrb2d.AddTorque(speed, ForceMode2D.Force);
    }
}
