/*
 * Nathan Cover
 * JukeBoxManager.cs
 * Assignment_11
 * Class to handle turning on and off the jukebox object
 */

using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Assignment_11
{
    public class JukeBoxManager : MonoBehaviour
    {
        private ParticleSystem _particleSystem;
        private AudioSource _audioSource;
        private bool _isOn = true;

        private void Start()
        {
            _particleSystem = GetComponent<ParticleSystem>();
            _audioSource = GetComponent<AudioSource>();
        }
    
        public void TurnOff()
        {
            _particleSystem.Stop();
            _audioSource.Pause();
            _isOn = false;
        }

        public void TurnOn()
        {
            _particleSystem.Play();
            _audioSource.Play();
            _isOn = true;
        }

        public void ToggleJukeBox()
        {
            if(_isOn)
                TurnOff();
            else
                TurnOn();
        }
    }
}
