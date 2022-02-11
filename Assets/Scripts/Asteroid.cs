using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public Sprite[] sprites; 
    public float size = 1.0f;
    public float minSize = 0.4f;
    public float maxSize = 1.0f; 
    public float speed = 50.0f;
    public float maxLifetime = 30.0f;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigidbody;

    private void Awake() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody = GetComponent<Rigidbody2D>();
    } 

    private void Start() 
    {
        spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];

        this.transform.eulerAngles = new Vector3(0.0f, 0.0f, Random.value * 360.0f);
        this.transform.localScale = Vector3.one * this.size;

        rigidbody.mass = this.size;
    } 

    public void SetTrojectory(Vector2 direction) 
    {
        rigidbody.AddForce(direction * speed); 
        Destroy(this.gameObject, maxLifetime);
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.tag == "Bullet") {
            if ((this.size * 0.5f) >= this.minSize) {
                SplitAsteroid();
                SplitAsteroid();
            }
            Destroy(this.gameObject);
        }
        Debug.Log("hit"); 
    } 

    private void SplitAsteroid() {
        Vector2 position = this.transform.position;
        position +=  Random.insideUnitCircle * 0.5f;

        Asteroid half = Instantiate(this, position, this.transform.rotation);
        half.size = this.size * 0.5f;
        half.SetTrojectory(Random.insideUnitCircle.normalized * this.speed); 
    }
}
