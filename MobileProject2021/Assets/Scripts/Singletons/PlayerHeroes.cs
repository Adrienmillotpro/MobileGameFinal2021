using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHeroes : MonoBehaviour
{
    [SerializeField] private GameObject[] playerHeroes = new GameObject[4];
    private GameObject[] instantiatedHeroes;
    public GameObject[] equippedPlayerHeroes { get { return playerHeroes; } }
    public GameObject[] InstantiatedHeroes { get { return instantiatedHeroes; } }

    public static PlayerHeroes Instance { get; private set; }

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
        if (SceneManager.GetActiveScene().name == "MAIN")
        {
            //instantiatedHeroes = new GameObject[4];
            //for (int i = 0; i < playerHeroes.Length; i++)
            //{
            //    instantiatedHeroes[i] = Instantiate(playerHeroes[i]);
            //}
        }
        else if (SceneManager.GetActiveScene().name == "CommunionSceneUI")
        {
            HeroesSlots.OnUpdateHeroesSlots += OnEquipHeroesUpdatePlayerHeroes;
        }

        DontDestroyOnLoad(this.gameObject);
    }

    private void OnDisable()
    {
        if (SceneManager.GetActiveScene().name == "CommunionSceneUI")
        {
            HeroesSlots.OnUpdateHeroesSlots -= OnEquipHeroesUpdatePlayerHeroes;
        }
    }

    private void OnEquipHeroesUpdatePlayerHeroes(OnUpdateHeroesSlotsEventArgs slotsArgs)
    {
        playerHeroes[slotsArgs.slotIndex] = slotsArgs.equippedHero;
    }
}
