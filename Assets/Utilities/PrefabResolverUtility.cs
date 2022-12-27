using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabResolverUtility : MonoBehaviour

{
    // [SerializeField]
    // private GameObject obstaclePrefab;

    // [SerializeField]
    // private GameObject spherePrefab;

    // [SerializeField]
    // private GameObject scoreCounterPrefab;

    [SerializeField]
    private GameObject countdownPrefab;

    // [SerializeField]
    // private GameObject randomizePrefab;

    // private static GameObject obstaclePrefabStatic;

    // private static GameObject spherePrefabStatic;

    // private static GameObject scoreCounterPrefabStatic;

    private static GameObject countdownPrefabStatic;

    // private static GameObject randomizePrefabStatic;

    void Awake()
    {
        // PrefabResolverUtility.obstaclePrefabStatic = obstaclePrefab;
        // PrefabResolverUtility.spherePrefabStatic = spherePrefab;
        // PrefabResolverUtility.scoreCounterPrefabStatic = scoreCounterPrefab;
        PrefabResolverUtility.countdownPrefabStatic = countdownPrefab;
        // PrefabResolverUtility.randomizePrefabStatic = randomizePrefab;
    }

    // public static GameObject RandomizePrefab
    // {
    //     get
    //     {
    //         return PrefabResolverUtility.randomizePrefabStatic;
    //     }
    // }

    public static GameObject CountdownPrefab
    {
        get
        {
            return PrefabResolverUtility.countdownPrefabStatic;
        }
    }

    // public static GameObject ObstaclePrefab
    // {
    //     get 
    //     {
    //         return PrefabResolverUtility.obstaclePrefabStatic;
    //     }
    // }

    // public static GameObject SpherePrefab
    // {
    //     get 
    //     {
    //         return PrefabResolverUtility.spherePrefabStatic;
    //     }
    // }

    // public static GameObject ScoreCounterPrefab
    // {
    //     get 
    //     {
    //         return PrefabResolverUtility.scoreCounterPrefabStatic;
    //     }
    // }
}