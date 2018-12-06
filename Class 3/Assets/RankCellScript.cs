using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankCellScript : MonoBehaviour {
    public Text PlayerNameInfo;
    public Text PlayerLevelInfo;
    public Text PlayerGoldInfo;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void SetPlayerProfile(ProfileInfo profile)
    {
        PlayerNameInfo.text = profile.playerName;
        PlayerLevelInfo.text = profile.playerLevel.ToString();
        PlayerGoldInfo.text = profile.playerGold.ToString();
    }
}
