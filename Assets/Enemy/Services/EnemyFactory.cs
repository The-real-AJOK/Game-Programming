using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory
{
    public EnemyComponent CreateEnemy(Vector3 position, bool mustUseGravity)
    {
        // var enemy = GameObject.Instantiate(PrefabResolverUtility.EnemyPrefab, position, Quaternion.identity);

        // var rigidbody = enemy.AddComponent<Rigidbody>();
        // rigidbody.useGravity = mustUseGravity;

        // var enemyComponent = enemy.AddComponent<EnemyComponent>();
        // var attackComponent = enemy.AddComponent<AttackComponent>();
        // var chaseComponent = enemy.AddComponent<ChaseComponent>();
        // var patrolComponent = enemy.AddComponent<PatrolComponent>();

        // return enemyComponent;
        return null;
    }
}
