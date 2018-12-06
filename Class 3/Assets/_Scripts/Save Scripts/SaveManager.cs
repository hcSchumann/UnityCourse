using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour {

    SaveInfo save;

    static SaveManager _instance;
    public static SaveManager Instance
    {
        get
        {
            return _instance ?? (_instance = FindObjectOfType<SaveManager>());
        }
    }

    public void OnDestroy()
    {
        if(_instance == this)
        {
            _instance = null;
        }
    }

    void Awake () 
    {
        LoadGame();
	}

    public void SaveGame()
    {
        var savedGame = JsonUtility.ToJson(save);
        PlayerPrefs.SetString("Save", savedGame);
    }

    public void LoadGame()
    {
        var loadedGame = PlayerPrefs.GetString("Save", string.Empty);
        save = JsonUtility.FromJson<SaveInfo>(loadedGame);

        if(save == null) save = new SaveInfo();

    }

    public void AddProfile(ProfileInfo profile)
    {
        save.profiles.Add(profile);
    }

    public List<ProfileInfo> GetProfileList()
    {
        return save.profiles;
    }
}
