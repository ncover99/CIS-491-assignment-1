/*
 * Nathan Cover
 * ParticleSystemInstancer.cs
 * Assignment_10
 * checks if the particle system on the current object has stopped playing and then sends it back to the innactive list of effect pools
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Assignment_10
{
    public class ParticleSystemInstancer : MonoBehaviour
    {
        private ObjectPooler objectPooler;
        private ParticleSystem ps;
        [SerializeField] private String instanceTag = "explosion";
        
        void Start()
        {
            ps = GetComponent<ParticleSystem>();
        }
        
        void Awake()
        {
            objectPooler = ObjectPooler.instance;
        }

        // Update is called once per frame
        void Update()
        {
            if(!ps.isPlaying)
                objectPooler.Destroy(instanceTag, this.gameObject);
        }
    }

}