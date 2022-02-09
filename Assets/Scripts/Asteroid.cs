using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public Sprite[] sprites; 
    public float size = 1.0f;
    public float minSize = 0.5f;
    public float maxSize = 1.5f; 

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigidbody;

    private void Awake() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody = GetComponent<Rigidbody2D>();
    } 

    private void Start() {
        spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];

        this.transform.eulerAngles = new Vector3(0.0f, 0.0f, Random.value * 360.0f);
        this.transform.localScale = Vector3.one * this.size;

        rigidbody.mass = this.size;
    } 
}
