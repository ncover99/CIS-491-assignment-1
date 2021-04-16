/*
 * Nathan Cover
 * DoorManager.cs
 * Assignment_11
 * Implements the ability to open and close a door
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Assignment_11
{
    public class DoorManager : MonoBehaviour
    {
        [SerializeField] private GameObject _door;

        [SerializeField] private float _openAngle = -90f;

        [SerializeField] private float _closedAngle = 0;
        [SerializeField] private float _moveTime = 1f;

        private void Start()
        {
            if(_door == null)
            {
                _door = this.gameObject;
            }
        }
        public void OpenDoor()
        {
            StopAllCoroutines();
            StartCoroutine(RotateDoor(_openAngle));
        }

        public void CloseDoor()
        {
            StopAllCoroutines();
            StartCoroutine(RotateDoor(_closedAngle));
        }

        private IEnumerator RotateDoor(float angle)
        {
            float elapsedTime = 0;
            while (elapsedTime < _moveTime)
            {
                float newAngle = Mathf.LerpAngle(_door.transform.eulerAngles.z, angle, (elapsedTime / _moveTime));
                transform.eulerAngles = new Vector3(0, 0, newAngle);
                elapsedTime += Time.deltaTime;
                yield return null;
            }
            _door.transform.eulerAngles = new Vector3(_door.transform.eulerAngles.x,
                _door.transform.eulerAngles.y,angle);
        }
    }

}