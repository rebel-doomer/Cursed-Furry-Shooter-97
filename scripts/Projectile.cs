using System.Threading;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float speed = 15f;
    private Vector2 direction;

    public float lifetime = 5f;
    // Update is called once per frame

    private float timer = 0;
    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;

        //Each update, add the time that's passed between frames so we can time the projectile's lifetime 
        timer += Time.deltaTime; 
        if (timer > lifetime)
        {
            Destroy(gameObject); 
        }
    }


    //Unity gives some things built in functions which get called at certain events, like this one
    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag != "Player")
        Destroy(gameObject);
    }

    public void SetShootDirection(Vector2 dir)
    {

    }
}
