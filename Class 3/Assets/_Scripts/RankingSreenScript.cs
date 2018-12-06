using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


public class RankingSreenScript : MonoBehaviour {

    public delegate void Callback();
    private Callback _callback;

    public InputField PlayerNameField;
    public InputField PlayerLevelField;
    public InputField PlayerGoldField;

    public GameObject RankCellPrefab;
    public RectTransform RankScrollContent;


    private void Start()
    {
        List<ProfileInfo> profileList = SaveManager.Instance.GetProfileList();
        List<ProfileInfo> rankedProfileList = profileList.OrderByDescending(x=>x.playerLevel).ToList();
        foreach (ProfileInfo profile in rankedProfileList)
        {
            AddCellToScroll(profile);
        }

    }

    public void OnAddSaveButtonClick()
    {
        var playerName = PlayerNameField.text;
        var playerLevel = int.Parse(PlayerLevelField.text);
        var playerGold = int.Parse(PlayerGoldField.text);
        PlayerNameField.text = PlayerLevelField.text = PlayerGoldField.text = string.Empty;

        var playerProfileEntry = new ProfileInfo
        {
            playerName = playerName,
            playerLevel = playerLevel,
            playerGold = playerGold
        };

        AddCellToScroll(playerProfileEntry);
        SaveManager.Instance.AddProfile(playerProfileEntry);
        SaveManager.Instance.SaveGame();


    }

    void AddCellToScroll(ProfileInfo profile)
    {
        var rankCell = Instantiate(RankCellPrefab, RankScrollContent);
        var rankCellScript = rankCell.GetComponent<RankCellScript>();
        rankCellScript.SetPlayerProfile(profile);
    }
}
