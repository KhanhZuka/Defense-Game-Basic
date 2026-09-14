using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UDEV.DefenseBasic
{
    public class GameManager : MonoBehaviour, IComponentChecking
    {
        public float spawnTime;
        public Enemy[] enemyPrefabs;
        public GUIManager guiMng;
        private Player m_curPlayer;
        public ShopManager shopMng;
        public AudioController auCtr;
        private bool m_isGameover;
        private int m_score;

        public int Score { get => m_score; set => m_score = value; }

        // Start is called before the first frame update
        void Start()
        {
             
            if (IsComponentsNull()) return;

            guiMng.ShowGameGUI(false);
            guiMng.UpdateMainCoins();
        }

        public bool IsComponentsNull()
        {
            return guiMng == null || shopMng == null || auCtr == null;
        }

        public void PlayGame()
        {
            if(IsComponentsNull()) return;

            ActivePlayer();

            StartCoroutine(SpawnEnemy());
            guiMng.ShowGameGUI(true);
            guiMng.UpdateGameplayCoins();
            auCtr.PlayBmg();
        }

        public void ActivePlayer()
        {
            if(IsComponentsNull()) return;

            if(m_curPlayer)
                Destroy(m_curPlayer.gameObject);

            var shopItems = shopMng.items;

            if(shopItems == null || shopItems.Length <= 0) return;

            var newPlayerPb = shopItems[Pref.curPlayerId].playerPrefab;

            if(newPlayerPb)
                m_curPlayer = Instantiate(newPlayerPb, new Vector3(-10f,-1f,0f),Quaternion.identity);
        }

        public void Gameover()
        {
            if (m_isGameover) return;

            m_isGameover = true;

            Pref.bestScore = m_score;

            if(guiMng.gameoverDialog)
                guiMng.gameoverDialog.Show(true);

            auCtr.PlaySound(auCtr.gameover);
        }

        IEnumerator SpawnEnemy()
        {
            if (enemyPrefabs != null && enemyPrefabs.Length > 0)
            {
                while (!m_isGameover)
                {
                    int randIdx = Random.Range(0, enemyPrefabs.Length);
                    Enemy enemyPrefab = enemyPrefabs[randIdx];

                    if (enemyPrefab)
                    {
                        Instantiate(enemyPrefab, new Vector3(8, 0, 0), Quaternion.identity);
                    }
                    yield return new WaitForSeconds(spawnTime);
                }

                
            }
            
        }


    }
}

