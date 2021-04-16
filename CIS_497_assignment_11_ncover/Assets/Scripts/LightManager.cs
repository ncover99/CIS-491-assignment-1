/*
 * Nathan Cover
 * LightManager.cs
 * Assignment_11
 * Gets all the point lights in a scene and adds them to a list, has a public method to toggle the lights on and off
 */

using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Assignment_11
{
    public class LightManager : MonoBehaviour
    {
        [SerializeField] private List<Light> _pointLights = new List<Light>();

        // Start is called before the first frame update
        private void Start()
        {
            var lights = GameObject.FindObjectsOfType<Light>();
            foreach (var lightComponent in lights)
            {
                if (lightComponent.type == LightType.Point)
                {
                    _pointLights.Add(lightComponent);
                }
            }
        }

        public void ToggleLights()
        {
            foreach (var lights in _pointLights)
            {
                lights.enabled = !lights.enabled;
            }
        }

        public void EnableLights()
        {
            foreach (var lights in _pointLights)
            {
                lights.enabled = true;
            }
        }

        public void DisableLights()
        {
            foreach (var lights in _pointLights)
            {
                lights.enabled = false;
            }
        }
    }
}
