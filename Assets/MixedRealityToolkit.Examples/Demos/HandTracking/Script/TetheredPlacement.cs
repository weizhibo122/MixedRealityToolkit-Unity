﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using UnityEngine;

namespace Microsoft.MixedReality.Toolkit.Examples.Demos
{
    /// <summary>
    /// Helper script to respawn objects if they go too far from their original position. Useful for objects that will fall forever etc.
    /// </summary>
    public class TetheredPlacement : MonoBehaviour
    {
        [Tooltip("The distance from the GameObject's spawn position at which will trigger a respawn ")]
        public float DistanceThreshold = 20.0f;

        private Vector3 RespawnPoint;
        private Quaternion RespawnOrientation;

        private void Start()
        {
            LockSpawnPoint();
        }

        private void LateUpdate()
        {
            float distanceSqr = (RespawnPoint - this.transform.position).sqrMagnitude;

            if (distanceSqr > DistanceThreshold * DistanceThreshold)
            {
                this.transform.SetPositionAndRotation(RespawnPoint, RespawnOrientation);
            }
        }

        public void LockSpawnPoint()
        {
            RespawnPoint = this.transform.position;
            RespawnOrientation = this.transform.rotation;
        }
    }

}