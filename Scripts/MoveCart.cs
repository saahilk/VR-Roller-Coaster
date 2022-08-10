using UnityEngine;
using PathCreation;


    // Moves along a path at constant speed.
    // Depending on the end of path instruction, will either loop, reverse, or stop at the end of the path.
    public class MoveCart : MonoBehaviour
    {
        public PathCreator pathCreator;

        public float accelertion = 0.0f;
        public EndOfPathInstruction endOfPathInstruction;
        public float speed = 0;
        float distanceTravelled;

        void Start() {
            if (pathCreator != null)
            {
                // Subscribed to the pathUpdated event so that we're notified if the path changes during the game
                pathCreator.pathUpdated += OnPathChanged;
            }
        }

        void Update()
        {
            if (pathCreator != null)
            {
                speed+=accelertion;
                Debug.Log(speed);
                if(speed<0){
                    speed=1.0f;
                    Debug.Log("Speed 0");
                }
                distanceTravelled += speed * Time.deltaTime;
                transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
                transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
            }
        }

        // If the path changes during the game, update the distance travelled so that the follower's position on the new path
        // is as close as possible to its position on the old path
        void OnPathChanged() {
            distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
        }

        public void changeAcceleration(float acc){
            accelertion = acc;
        }

        public void changeSpeed(float newSpeed){
            speed = newSpeed;
        }
    }
