using UnityEngine;

public class coin : MonoBehaviour
{
    SpriteRenderer sr;
    // e can change the values in the editor
    public Color color;
    public int value = 10;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.color = color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
