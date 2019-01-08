using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TestLINQ : MonoBehaviour
{
    class MatchData
    {
        public int   id;
        public int   player1;
        public int   player2;
        public int   arenaId;
        public float score1;
        public float score2;
    };

    class PlayerData
    {
        public int      id;
        public string   name;
    }

    List<MatchData>     matchData;
    List<PlayerData>    playerData;

    // Start is called before the first frame update
    void Start()
    {
        matchData = new List<MatchData>();
        playerData = new List<PlayerData>();

        for (int i = 0; i < 20; i++)
        {
            PlayerData pd = new PlayerData();
            pd.id = i + 1;
            pd.name = "Player " + pd.id;

            playerData.Add(pd);
        }

        for (int i = 0; i < 10000; i++)
        {
            MatchData md = new MatchData();
            md.id = i + 1;
            md.player1 = Random.Range(1, 20);
            md.player2 = Random.Range(1, 20);
            md.arenaId = Random.Range(1, 6);
            md.score1 = Random.Range(0.0f, 10000.0f);
            md.score2 = Random.Range(0.0f, 10000.0f);

            matchData.Add(md);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
