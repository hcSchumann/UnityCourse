using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {

    public delegate void CallbackFloat(float value);
    public event CallbackFloat OnVolumeChanged;


}
