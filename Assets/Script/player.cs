using System;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class player : MonoBehaviour
{
    private Rigidbody2D rb;
    // Movement
    public float speed = 1.0f;
    Vector2 movement = Vector2.zero;
    // Tags
    private static string EnemyTag = "Enemy";
    private static string BlueCoinTag = "BlueCoin";
    private static string GreenCoinTag = "GreenCoin";
    private static string OrangeCoinTag = "OrangeCoin";
    // GameObjects
    public GameObject BlueCoin;
    public GameObject GreenCoin;
    public GameObject OrangeCoin;
    public GameObject CoinsHandler;
    // Coins value
    int BlueValue;
    int GreenValue;
    int OrangeValue;
    // Score
    public int ScoreToWin = 1000;
    private int score = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        BlueValue = BlueCoin.GetComponent<coin>().value;
        GreenValue = GreenCoin.GetComponent<coin>().value;
        OrangeValue = OrangeCoin.GetComponent<coin>().value;
        Debug.Log($"For the win, you should score: " + ScoreToWin + "\n The coins values are:" + " Blue coin value " + BlueValue + " ,Green coin value " + GreenValue + " ,Orange coin value " + OrangeValue);
    }

    // Update is called once per frame
    void Update()
    {
        // Read the Keyboard WASD input
        var wValue = Keyboard.current.wKey.value;
        var aValue = Keyboard.current.aKey.value;
        var sValue = Keyboard.current.sKey.value;
        var dValue = Keyboard.current.dKey.value;
        
        // Calculate movement
        movement += wValue * Vector2.up;
        movement += aValue * Vector2.left;
        movement += sValue * Vector2.down;
        movement += dValue * Vector2.right;

        // Winner
        if (score >= ScoreToWin)
        {
            Debug.Log("you won");
            EditorApplication.isPlaying = false;
        }
    }
    
    // Calculate FixedUpdate so that collision detection works correctly
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
    
    // Collisions
    private void OnTriggerEnter2D(Collider2D other)
    {
        // If the Enemy reached the player print you lose in the console and stop the game
        if (other.gameObject.CompareTag(EnemyTag))
        {
            Debug.Log("you lose");
            EditorApplication.isPlaying = false;
        }
        // If the player collides with a coin
        else if (other.gameObject.CompareTag(BlueCoinTag))
        {
            score += BlueValue;
            Debug.Log("Current Score: " + score);
            CoinsHandler.GetComponent<coinshandler>().DestroyCoin(other.gameObject);
        }
        else if (other.gameObject.CompareTag(GreenCoinTag))
        {
            score += GreenValue;
            Debug.Log("Current Score: " + score);
            CoinsHandler.GetComponent<coinshandler>().DestroyCoin(other.gameObject);
        }
        else if (other.gameObject.CompareTag(OrangeCoinTag))
        {
            score += OrangeValue;
            Debug.Log("Current Score: " + score);
            CoinsHandler.GetComponent<coinshandler>().DestroyCoin(other.gameObject);
        }
    }
}
