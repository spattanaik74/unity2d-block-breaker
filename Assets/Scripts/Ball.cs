
using UnityEngine;

public class Ball : MonoBehaviour
{
    //Config Parameter
    [SerializeField] Paddle paddle1;
    [SerializeField] float forMoveX = 4;
    [SerializeField] float forMoveY = 15;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor = 0.2f;
    [SerializeField] int heartCount;


    //State
    Vector2 paddleToTheVector;


    //For Not Having Error With The LoseCollider
    Rigidbody2D myRigidbody2d;
    GameStatus gameLive;
    



    bool hasStarted = false;

    //Cached Compo
    AudioSource myAudioSource;


    // Start is called before the first frame update
    void Start()
    {
        paddleToTheVector = transform.position - paddle1.transform.position;

        myAudioSource = GetComponent<AudioSource>();
       
        myRigidbody2d = GetComponent<Rigidbody2D>();
        myRigidbody2d.simulated = false;
        gameLive = FindObjectOfType<GameStatus>();

    }

    
    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            OnThePaddle();
            OnMouseClick();
        }

    }

    public void OnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            myRigidbody2d.velocity = new Vector2(forMoveX, forMoveY);
            myRigidbody2d.simulated = true; 
        }
    }

    public void OnThePaddle()
    {

        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToTheVector;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2(Random.Range(0f, randomFactor), Random.Range(0f, randomFactor));
        if(hasStarted)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
            myRigidbody2d.velocity += velocityTweak;
        }
        
    }
    public void HeartCounts()
    {
        heartCount++;
       
    }

    
    public void ResetToThePaddle()
    {
        gameLive.GameLiveCount();
        OnThePaddle();
        OnMouseClick();
        hasStarted = false;
    }
}
