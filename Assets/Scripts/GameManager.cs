using Assets.Scripts.MachineState;
using Assets.Scripts.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private List<Player> _players;
        [SerializeField]
        private Player _curentPlayer;
        private IState currentState;
        public static GameManager Instance;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void StartGame(List<Player> players)
        {
            _players = players;
        }
        //    public GameObject humanPrefab; // Префаб для создания фишки человека
        //    public GameObject zombiePrefab; // Префаб для создания фишки зомби
        //    public GameObject characterCardPrefab; // Префаб для создания карточки персонажа

        //    public GameObject[] spawnPoints; // Точки спауна для размещения фишек людей
        //    public GameObject map; // Карта для размещения фишек людей

        //    private List<GameObject> humans = new List<GameObject>(); // Список фишек людей
        //    private List<GameObject> zombies = new List<GameObject>(); // Список фишек зомби

        //    void Start()
        //    {
        //        Определение ролей
        //        DetermineRoles();

        //        Раздача фишек
        //        DistributeTokens();

        //        Распределение персонажей
        //        DistributeCharacters();

        //        Раздача карт
        //        DealCards();

        //        Определение фишек людей на карте
        //        PlaceHumans();
        //    }

        //    Метод для определения ролей
        //    private void DetermineRoles()
        //    {
        //        Если игроков двое
        //        if (PlayerManager.Instance.GetPlayerCount() == 2)
        //        {
        //            Один игрок играет за людей, а другой за зомби
        //            PlayerManager.Instance.AssignRoles(PlayerRole.Human, PlayerRole.Zombie);
        //        }
        //        else
        //        {
        //            Один игрок играет за зомби
        //            PlayerManager.Instance.AssignRoles(PlayerRole.Zombie);

        //            Все остальные игроки играют за людей
        //            PlayerManager.Instance.AssignRoles(PlayerRole.Human, PlayerManager.Instance.GetPlayerCount() - 1);
        //        }
        //    }

        //    Метод для раздачи фишек
        //    private void DistributeTokens()
        //    {
        //        Игроки - люди берут себе фишки людей
        //        PlayerManager.Instance.AssignHumanTokens();

        //        Игрок - зомби берет себе в четыре раза больше фишек зомби
        //        PlayerManager.Instance.AssignZombieTokens();
        //    }

        //    Метод для распределения персонажей
        //    private void DistributeCharacters()
        //    {
        //        Раздаем участвующим в игре людям карточки персонажей
        //        PlayerManager.Instance.AssignCharacterCards();
        //    }

        //    Метод для раздачи карт
        //    private void DealCards()
        //    {
        //        Игрок - зомби набирает из колоды карт зомби 3 карты за каждого участвующего в игре персонажа
        //        PlayerManager.Instance.DealZombieCards();
        //    }

        //    Метод для определения фишек людей на карте
        //    private void PlaceHumans()
        //    {
        //        foreach (GameObject human in humans)
        //        {
        //            Определение случайной точки спауна для фишки человека
        //           GameObject spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        //            Помещение фишки человека на карту в указанную точку спауна
        //            human.transform.position = spawnPoint.transform.position;
        //        }
        //    }
    }

}
