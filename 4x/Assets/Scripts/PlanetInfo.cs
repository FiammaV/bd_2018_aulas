using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetInfo : MonoBehaviour
{
    public int                      planetID;
    public DatabaseInterface.Planet planetData;

    [Header("UI Elements")]
    public Image                    selectionSquare;

    RectTransform   rectTransform;
    Image           image;


    // Use this for initialization
    void Start()
    {
        image = GetComponent<Image>();
        rectTransform = GetComponent<RectTransform>();

        Refresh();
    }

    void Refresh()
    { 
        planetData = DatabaseInterface.GetPlanetData(planetID);

        if (planetData == null)
        {
            Destroy(gameObject);
            return;
        }

        Color color = new Color
        {
            r = 0.5f + 0.5f * (planetData.metal / 100.0f),
            g = 0.5f + 0.5f * (planetData.bio / 100.0f),
            b = 0.5f + 0.5f * (planetData.water / 100.0f),
            a = 1.0f
        };

        image.color = color;

        rectTransform.anchoredPosition = planetData.position;

        if (selectionSquare != null)
        {
            selectionSquare.gameObject.SetActive(planetData.playerOwned);
        }
	}
	
}
