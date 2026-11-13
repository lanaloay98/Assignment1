using UnityEngine;

public class coinshandler : MonoBehaviour
{
    // Coins
    public GameObject BlueCoin;
    public GameObject GreenCoin;
    public GameObject OrangeCoin;
    // Coins counting
    private int NumberOfCoins = 5;
    private int CurrentCoinsNumber = 0;
    // Ranges for spawning the coins
    public float XRange1;
    public float XRange2;
    public float YRange1;
    public float YRange2;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentCoinsNumber == 0) // If there is no coins spawn 5 coins
        {
            for (int i = 0; i < NumberOfCoins; i++)
            {
                SpawnCoin();
            }
            CurrentCoinsNumber = NumberOfCoins;
        }
        
    }
    
    // Spawn a random coin at a random place
    public void SpawnCoin()
    {
        // Pick random coin to instantiate
        int value = Random.Range(0, 3);
        GameObject RandomCoin = null;
        if (value == 0)
            RandomCoin = BlueCoin;
        else if (value == 1)
            RandomCoin = GreenCoin;
        else if (value == 2)
            RandomCoin = OrangeCoin;
        
        // Pick random position to instantiate the coin at it
        float x = Random.Range(XRange1, XRange2);
        float y = Random.Range(YRange1, YRange2);
        Vector3 position = new Vector3(x,y,0);
        
        // Instantiate
        Instantiate(RandomCoin , position, Quaternion.identity);
    }
    
    // Destroy a coin called by the player when there is a collision between them
    public void DestroyCoin(GameObject Coin)
    {
        Destroy(Coin);
        CurrentCoinsNumber --;
    }
}
