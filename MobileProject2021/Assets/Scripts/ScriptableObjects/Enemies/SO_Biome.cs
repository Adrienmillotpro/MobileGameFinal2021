using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SO_Biome", menuName = "Biome")]

public class SO_Biome : ScriptableObject
{
    [SerializeField] private WaveOfEnemies[] waveOfEnemies;
    #region Getters
    public WaveOfEnemies[] Waves { get { return waveOfEnemies; } }
    #endregion
}

    [System.Serializable]
    public class WaveOfEnemies
    {
        [SerializeField] private FloorTier waveTier;
        [SerializeField] private List<SO_Enemy> potentialEnemies;
        [SerializeField] private SO_Boss potentialBoss;
        #region Getters
        public FloorTier WaveTier { get { return waveTier; } }
        public List<SO_Enemy> PotentialEnemies { get { return potentialEnemies; } }
        public SO_Boss PotentialBoss { get { return potentialBoss; } }
        #endregion
    }
