// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class PrefabResolverUtility : MonoBehaviour

// {
//     [SerializeField]
//     private GameObject enemyPrefab;

//     [SerializeField]
//     private GameObject playerPrefab;

//     private static GameObject enemyPrefabStatic;
//     private static GameObject playerPrefabStatic;

//     void Awake()
//     {
//         PrefabResolverUtility.enemyPrefabStatic = enemyPrefab;
//         PrefabResolverUtility.playerPrefabStatic = playerPrefab;
//     }

//     public static GameObject EnemyPrefab
//     {
//         get
//         {
//             return PrefabResolverUtility.enemyPrefabStatic;
//         }
//     }

//     public static GameObject PlayerPrefab
//     {
//         get
//         {
//             return PrefabResolverUtility.playerPrefabStatic;
//         }
//     }

//     void Start()
//     {
//         Debug.Log(PrefabResolverUtility.EnemyPrefab);
//     }
// }
