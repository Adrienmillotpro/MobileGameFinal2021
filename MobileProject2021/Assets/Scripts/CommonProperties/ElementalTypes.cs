using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ElementalTypes
{
    Fire,
    Water,
    Air,
    Thunder,
}

public static class TypeChart
{
    static float[][] chart =
    {
        //                    Fir Wat Air Thu
        /*Fir*/ new float[] { 0.5f, 0f, 2f, 1f},
        /*Wat*/ new float[] { 2f, 0.5f, 1f, 0f},
        /*Air*/ new float[] { 0f, 1f, 0.5f, 2f},
        /*Thu*/ new float[] { 1f, 2f, 0f, 0.5f}

    };

    public static float DefineElementalReaction(ElementalTypes heroType, ElementalTypes enemyType)
    {
        int row = (int)heroType;
        int column = (int)enemyType;

        return chart[row][column];
    }
}
