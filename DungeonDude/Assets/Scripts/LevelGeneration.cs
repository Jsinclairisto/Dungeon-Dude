using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    [SerializeField] private Transform levelPart_Start;
    [SerializeField] private Transform platform;
    private void Awake()
    {
        Instantiate(platform, new Vector3(4,4), Quaternion.identity);
    }
    private void SpawnLevelPart(Vector3 spawnPosition)
    {
        Instantiate(platform, spawnPosition, Quaternion.identity);
    }
}
