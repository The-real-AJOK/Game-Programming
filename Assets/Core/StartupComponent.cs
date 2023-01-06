using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class StartupComponent : MonoBehaviour
{
    [SerializeField]
    private float timeBeforeGameStartInSeconds = 5f;

    private EnemyComponent enemyComponent;

    // private List<ObstacleComponent> obstacleComponents = new List<ObstacleComponent>();

    // private ScoreCounterComponent scoreCounterComponent;

    // private JumpscareComponent jumpscareComponent;

    // private FireworkComponent fireworkComponent;

    private int didSubscribe;

    // private List<CapsuleComponent> capsuleComponents = new List<CapsuleComponent>();

    // private TimerComponent timerComponent;

    void Start()
    {
        var enemyFactory = new EnemyFactory();
        // var sphereFactory = new SphereFactory();
        // var scoreCounterFactory = new ScoreCounterFactory();
        // var capsuleFactory = new CapsuleFactory();
        // var timerFactory = new TimerFactory();
        didSubscribe = 0;

        this.enemyComponent = enemyFactory.CreateEnemy(new Vector3(4, 1, 4), false);

        // this.obstacleComponents.Add(obstacleFactory.CreateObstacle(new Vector3(0, 2, 0)));
        // this.obstacleComponents.Add(obstacleFactory.CreateObstacle(new Vector3(0, 0, 0)));
        // this.obstacleComponents.Add(obstacleFactory.CreateObstacle(new Vector3(0, -2, 0)));

        // this.scoreCounterComponent = scoreCounterFactory.CreateScoreCounter();

        // this.capsuleComponents.Add(capsuleFactory.CreateCapsule(new Vector3(2.0f, 0.5f, -2.0f), true));
        // this.capsuleComponents.Add(capsuleFactory.CreateCapsule(new Vector3(1.5f, 0.5f, -1.5f), true));
        // this.capsuleComponents.Add(capsuleFactory.CreateCapsule(new Vector3(-1.5f, 0.5f, 1.5f), true));
        // this.capsuleComponents.Add(capsuleFactory.CreateCapsule(new Vector3(-2.0f, 0.5f, 2.0f), true));

        // this.timerComponent = timerFactory.CreateTimer();

        this.RegisterEvents();

        this.StartCoroutine("StartGameAfterSeconds", this.timeBeforeGameStartInSeconds);
    }

    private void RegisterEvents()
    {
        this.obstacleComponents.ForEach(component =>
        {
            component.OnObstacleCollidedObservable.Subscribe((_) =>
            {
                Debug.Log("Obstacle collided");
                //decrease score by 1
                this.scoreCounterComponent.UpdateScore();
                //should start timer 5 sec
                // this.timerComponent.Timer();
            });
        });

        this.sphereComponent.SphereFalling.Subscribe((_) =>
        {
            Debug.Log("Sphere fell");
            var jumpscareFactory = new JumpscareFactory();

            this.jumpscareComponent = jumpscareFactory.CreateJumpScare(new Vector3(0, 0, 0));
        });


        this.sphereComponent.SphereJumping.Subscribe((_) =>
        {
            Debug.Log("Sphere jumped");
            var fireworkFactory = new FireworkFactory();

            this.fireworkComponent = fireworkFactory.CreateFirework(this.sphereComponent.transform.position);
        });

        // Observable
        //         .EveryUpdate()
        //         .Where(_ => Input.GetKeyDown(KeyCode.Space))
        //         .Subscribe(_ => sphereComponent.SphereJumps());



        // this.timerComponent.TimerReachedObservable.Subscribe((_) =>
        // {
        //     Debug.Log("Time remaining");
        //     // if timer runs out the obstacle dies
        //     this.timerComponent.Timer();
        // });

        // this.capsuleComponents.ForEach(component =>
        // {
        //     component.OnCapsuleCollidedObservable.Subscribe((_) =>
        //     {
        //         Debug.Log("Capsule collided");
        //         //should add score by 1
        //         this.scoreCounterComponent.UpdateScore();
        //         //should add to timer
        //         this.timerComponent.AddTime();
        //     });
        // });
    }

    IEnumerator StartGameAfterSeconds(float timeInSeconds)
    {
        yield return new WaitForSecondsRealtime(timeInSeconds);

        // this.sphereComponent.EnableGravity();
    }

    void Update()
    {

    }
}
