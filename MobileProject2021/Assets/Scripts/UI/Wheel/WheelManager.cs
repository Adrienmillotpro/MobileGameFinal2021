using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelManager : MonoBehaviour
{
    [SerializeField] private Animator wheelAnimator;
    
    public void WheelFireAnimation()
    {
        wheelAnimator.SetBool("FirePosition", true);

        wheelAnimator.SetBool("WaterPosition", false);
        wheelAnimator.SetBool("ThunderPosition", false);
        wheelAnimator.SetBool("AirPosition", false);
    }
    public void WheelAirAnimation()
    {
        wheelAnimator.SetBool("AirPosition", true);

        wheelAnimator.SetBool("FirePosition", false);
        wheelAnimator.SetBool("WaterPosition", false);
        wheelAnimator.SetBool("ThunderPosition", false);
        
    }
    public void WheelWaterAnimation()
    {
        wheelAnimator.SetBool("WaterPosition", true);

        wheelAnimator.SetBool("FirePosition", false);
        wheelAnimator.SetBool("ThunderPosition", false);
        wheelAnimator.SetBool("AirPosition", false);
    }
    public void WheelThunderAnimation()
    {
        wheelAnimator.SetBool("ThunderPosition", true);

        wheelAnimator.SetBool("FirePosition", false);
        wheelAnimator.SetBool("WaterPosition", false);
        wheelAnimator.SetBool("AirPosition", false);
    }

}
