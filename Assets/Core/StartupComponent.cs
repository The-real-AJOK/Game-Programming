using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class StartupComponent : MonoBehaviour
{
    [SerializeField]
    private float timeBeforeGameStartInSeconds = 5f;
    // private SphereComponent sphereComponent;
    // private List<ObstacleComponent> obstacleComponents = new List<ObstacleComponent>();
    private ScoreCounterComponent scoreCounterComponent;
    private CountdownComponent countdownComponent;
    // private RandomizeComponent randomizeComponent;

    // Start is called before the first frame update
    void Start()
    {
        // var obstacleFactory = new ObstacleFactory();
        // var sphereFactory = new SphereFactory();
        // var scoreCounterFactory = new ScoreCounterFactory();
        var countdownFactory = new CountdownFactory();
        // var randomizeFactory = new RandomizeFactory();

        // this.sphereComponent = sphereFactory.CreateSphere(new Vector3(0, 4, 0), false);
        // this.obstacleComponents.Add(obstacleFactory.CreateObstacle(new Vector3(0, 2, 0)));
        // this.obstacleComponents.Add(obstacleFactory.CreateObstacle(new Vector3(0, 0, 0)));
        // this.obstacleComponents.Add(obstacleFactory.CreateObstacle(new Vector3(0, -2, 0)));
        // this.scoreCounterComponent = scoreCounterFactory.CreateScoreCounter();
        this.countdownComponent = countdownFactory.CreateCountdown();
        // this.randomizeComponent = randomizeFactory.CreateRandomize();

        this.RegisterEvents();

        this.StartCoroutine("StartGameAfterSeconds", this.timeBeforeGameStartInSeconds);
    }

    private void RegisterEvents()
    {
        this.obstacleComponents.ForEach(component => 
        {
            component.onObstacleCollidedObservable.Subscribe((x) => 
            {
                this.scoreCounterComponent.Increase();
                this.randomizeComponent.Randomize();
                component.enlarge();

            });
        });

        this.randomizeComponent.onRandomizeObservable.Subscribe((x) => {
            this.sphereComponent.ChangeColor();
        });

        
    }

    IEnumerator StartGameAfterSeconds(float timeInSeconds)
    {
        yield return new WaitForSecondsRealtime(timeInSeconds);
        this.sphereComponent.EnableGravity();
    }
}
