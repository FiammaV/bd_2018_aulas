using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameUI : MonoBehaviour
{
    public TextMeshProUGUI     metalText;
    public TextMeshProUGUI     bioText;
    public TextMeshProUGUI     waterText;

	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        metalText.text = "Metal: " + DatabaseInterface.GetMetal();
        bioText.text = "Bio: " + DatabaseInterface.GetBio();
        waterText.text = "Water: " + DatabaseInterface.GetWater();
    }
}
