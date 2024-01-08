using System.Security.Cryptography;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float speed = 3;
    Vector3 direction;
    Alien alien;
    public void setDirection(Vector3 dir)
    {
        direction = dir;
    }

    void FixedUpdate()
    {
        transform.position += direction * speed * Time.deltaTime;
        speed += 0.05f;

        
    }
    
    void OnCollisionEnter(Collision collision) {
        // Fetch/cache the GameObject you collided with
        GameObject other = collision.collider.gameObject;

        // Check if the object you collided with is the "chosen" object
        if (collision.collider.CompareTag("Enemy")) { // or use tags, layers or GetComponent<SomeEnemyComponent> for more flexibility/reusability
            // Delete the other object
            Destroy(collision.gameObject);
            // Delete the bullet last (assuming the bullet holds this script)
            //Destroy(gameObject); // or Destroy(this)
        }
    }
}
