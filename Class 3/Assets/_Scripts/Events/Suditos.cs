using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suditos : MonoBehaviour {

	// Use this for initialization
	void OnEnable () {
        FindObjectOfType<Manager>().OnVolumeChanged += OnVolumeChanged;
	}
    void OnDisable()
    {
        FindObjectOfType<Manager>().OnVolumeChanged -= OnVolumeChanged;
    }

    void OnVolumeChanged (float f) {
        Debug.LogFormat("O volume mudou pra {0}", 3);	
	}
}
