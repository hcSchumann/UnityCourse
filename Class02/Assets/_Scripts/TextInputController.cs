using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextInputController : MonoBehaviour {

    public InputField inputField;
    public PlayerController playerController;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Return))
        {
            string message = inputField.text;
            if (message.Length > 0)
            {
                inputField.text = "";
                playerController.CmdSendMessage(message);
            }

        }
    }


}
