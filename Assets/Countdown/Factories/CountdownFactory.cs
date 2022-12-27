using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownFactory : MonoBehaviour
{
    public CountdownComponent CreateCountdown()
    {
        var countdown = GameObject.Instantiate(
            PrefabResolverUtility.CountdownPrefab,
            Vector3.zero,
            Quaternion.identity
        );

        var countdownComponent = countdown.AddComponent<CountdownComponent>();
        return countdownComponent;
    }
}
