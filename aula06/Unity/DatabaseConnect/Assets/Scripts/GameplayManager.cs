using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour {

    public Canvas               mainMenuCanvas;
    public Canvas               starmapCanvas;
    public GameObject           planetInfoPrefab;

    [Header("Game Parameters")]
    public  int                 nPlanets = 20;

    void Start()
    {
        mainMenuCanvas.gameObject.SetActive(true);
        starmapCanvas.gameObject.SetActive(false);
    }

    public void NewGame()
    {
        if (!DatabaseInterface.Instance.Connect()) return;
        if (!DatabaseInterface.Instance.InitializeGame(nPlanets)) return;

        mainMenuCanvas.gameObject.SetActive(false);

        UpdateStarmap();
    }

    public void ContinueGame()
    {
        if (!DatabaseInterface.Instance.Connect()) return;
        if (!DatabaseInterface.Instance.UpdateData()) return;

        mainMenuCanvas.gameObject.SetActive(false);

        UpdateStarmap();
    }

    void UpdateStarmap()
    {
        starmapCanvas.gameObject.SetActive(true);

        PlanetInfo[] planetInfos = starmapCanvas.gameObject.GetComponentsInChildren<PlanetInfo>();
        
        for (int i = planetInfos.Length; i < DatabaseInterface.GetPlanetCount(); i++)
        {
            GameObject go = Instantiate(planetInfoPrefab, starmapCanvas.transform);
            PlanetInfo planetInfo = go.GetComponent<PlanetInfo>();

            planetInfo.planetID = i;
        }
    }
}
