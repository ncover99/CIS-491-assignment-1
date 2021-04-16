/*
 * Nathan Cover
 * SmartHomeFacade.cs
 * Assignment_11
 * Facade class to handle calling to other classes to simplify the process of enabling and disabling devices
 */

using Assets.Scripts.Assignment_11;
using UnityEngine;
using UnityEngine.UI;

public class SmartHomeFacade : MonoBehaviour
{
    [SerializeField] private JukeBoxManager _jukeBoxManager;

    [SerializeField] private DoorManager _doorManager;

    [SerializeField] private LightManager _lightManager;

    [SerializeField] private Text _statusText;

    private bool _isOn = true;

    public void EnableDevices()
    {
        _jukeBoxManager.TurnOn();
        _doorManager.OpenDoor();
        _lightManager.EnableLights();
        _isOn = true;
        _statusText.text = "ON";
        _statusText.color = new Color(0.07458396f, 0.9056604f, 0f);
    }

    public void DisableDevices()
    {
        _doorManager.CloseDoor();
        _jukeBoxManager.TurnOff();
        _lightManager.DisableLights();
        _isOn = false;
        _statusText.text = "OFF";
        _statusText.color = new Color(1f, 0.254442f, 0.240566f);
    }
    
    public void ToggleDevices()
    {
        if(_isOn)
            DisableDevices();
        else
            EnableDevices();
    }
}
