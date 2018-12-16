
using UnityEngine;

public class Ball : MonoBehaviour {
    bool hasStarted = false;

    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;
    [SerializeField] float randomFactor = 0.2f;

    Rigidbody2D myRigidbody2D;

    //state
    Vector2 paddleToBallVector;
    Rigidbody2D myRigidBody2D;
    
    // Use this for initialization
    void Start () {
        paddleToBallVector = transform.position - paddle1.transform.position;
        myRigidBody2D = GetComponent<Rigidbody2D>();
        myRigidBody2D.simulated = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        
        if (hasStarted == false)
        {
            LockBallToPadlle();
            LaunchOnMouseClick();
        }
    }

    private void LaunchOnMouseClick()
    {
       
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            myRigidBody2D.velocity = new Vector2(xPush, yPush);
            myRigidBody2D.simulated = true; // <-------- add this
           
        }
    }

    private void LockBallToPadlle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2(
            Random.Range(0f, randomFactor),
            Random.Range(0f, randomFactor));

        if (hasStarted)
        {
            myRigidBody2D.velocity += velocityTweak;
        }
    }
}
