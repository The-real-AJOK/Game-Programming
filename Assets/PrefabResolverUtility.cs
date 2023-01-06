using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabResolverUtility : MonoBehaviour

{
    [SerializeField]
    private GameObject enemyPrefab;

    private static GameObject enemyPrefabStatic;

    void Awake()
    {
        PrefabResolverUtility.enemyPrefabStatic = enemyPrefab;
    }

    public static GameObject EnemyPrefab
    {
        get
        {
            return PrefabResolverUtility.enemyPrefabStatic;
        }
    }

    void Start()
    {
        Debug.Log(PrefabResolverUtility.EnemyPrefab);
    }
}
