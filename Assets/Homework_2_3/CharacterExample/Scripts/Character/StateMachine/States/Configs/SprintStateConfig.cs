using System;
using UnityEngine;

[Serializable]
public class SprintStateConfig
{
    [field: SerializeField, Range(5, 15)] public float SprintSpeed { get; private set; }
}
