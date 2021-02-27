using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGear : MonoBehaviour
{
    [SerializeField] private SO_Gear[] so_handGears = new SO_Gear[2];
    [SerializeField] private SO_Gear[] so_ankleGears = new SO_Gear[2];

    public SO_Gear[] SO_HandGears { get { return so_handGears; } }
    public SO_Gear[] SO_AnkleGears { get { return so_ankleGears; } }

    public static PlayerGear Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void OnEnable()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void UpdateGear(GearType gearType, int index)
    {

    }
}
