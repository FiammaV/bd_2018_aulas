using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour {

    public Canvas               mainMenuCanvas;
    public Canvas               starmapCanvas;
    public Canvas               gameUICanvas;
    public GameObject           planetInfoPrefab;

    [Header("Game Parameters")]
    public  int                 nPlanets = 20;
    public  float               secondsPerTurn = 10.0f;

    float turnTime = 0.0f;
    bool  gameRunning = false;

    void Start()
    {
        if (mainMenuCanvas) mainMenuCanvas.gameObject.SetActive(true);
        if (starmapCanvas) starmapCanvas.gameObject.SetActive(false);
        if (gameUICanvas) gameUICanvas.gameObject.SetActive(false);
    }

    public void NewGame()
    {
        if (!DatabaseInterface.instance.Connect()) return;
        if (!DatabaseInterface.instance.InitializeGame(nPlanets)) return;

        if (mainMenuCanvas) mainMenuCanvas.gameObject.SetActive(false);

        gameRunning = true;

        UpdateStarmap();
    }

    public void ContinueGame()
    {
        if (!DatabaseInterface.instance.Connect()) return;
        if (!DatabaseInterface.instance.FetchData()) return;

        if (mainMenuCanvas) mainMenuCanvas.gameObject.SetActive(false);

        gameRunning = true;

        UpdateStarmap();
    }

    void UpdateStarmap()
    {
        if (starmapCanvas) starmapCanvas.gameObject.SetActive(true);
        if (gameUICanvas) gameUICanvas.gameObject.SetActive(true);

        PlanetInfo[] planetInfos = starmapCanvas.gameObject.GetComponentsInChildren<PlanetInfo>();
        
        for (int i = planetInfos.Length; i < DatabaseInterface.GetPlanetCount(); i++)
        {
            GameObject go = Instantiate(planetInfoPrefab, starmapCanvas.transform);
            PlanetInfo planetInfo = go.GetComponent<PlanetInfo>();

            planetInfo.planetID = i;
        }
    }

    private void Update()
    {
        if (gameRunning)
        {
            turnTime += Time.deltaTime;
            if (turnTime > secondsPerTurn)
            {
                turnTime = 0.0f;
                RunTurn();
            }
        }
    }

    void RunTurn()
    {
        DatabaseInterface.instance.UpdateDatabase();
    }
}
