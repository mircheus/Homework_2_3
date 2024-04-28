using System;
using UnityEngine;

[Serializable]
public class WalkingStateConfig
{
    [field: SerializeField, Range(1, 3)] public float WalkSpeed { get; private set; }
}