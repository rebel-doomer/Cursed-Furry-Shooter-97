using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ChiikawaMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //transform is the main component, and can be referenced by just calling it like this 
        rigidbody = transform.GetComponent<Rigidbody2D>();
    }

    //Header writes a header in the inspector
    //Serialize Field exposes this variable to the editor so you can easily edit it. This can be done with public as well
    [Header("Refernce variables")] 
    public Rigidbody2D rigidbody;
    public GameObject projectile; 


    [Header("Movement Settings")]
    [SerializeField] float rotateSpeed = 15f;
    [SerializeField] float movementSpeed = 60f; 


    // Update is called once per frame
    void Update()
    {
        //Rotate left and right
        //Unity has lots of different methods for reading inputs! This is the simplest current one
        if (Keyboard.current.dKey.IsPressed())
        {
            //Time.deltaTime is the time between frames, which normalizes the code for different frame rates
            rigidbody.AddTorque(rotateSpeed * -1 * Time.deltaTime);
        }

        if (Keyboard.current.aKey.IsPressed())
        {
            rigidbody.AddTorque(rotateSpeed * Time.deltaTime);
        }
        
        //Move Forward
        if (Keyboard.current.wKey.IsPressed())
        {
            rigidbody.AddForce(transform.up * movementSpeed * Time.deltaTime);
        }

        //Shooting 
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Debug.Log("Pew!"); 
            //Clone a projectile
            //Setting its parent to null means it won't be attached to and follow anything 
            //We also set its rotation to match Chiikawa's
            GameObject clone = GameObject.Instantiate(projectile);
            clone.transform.parent = null;
            clone.transform.rotation = transform.rotation; 
            clone.transform.position = transform.position; 

        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Usagi")
        {
            SceneManager.LoadScene(0); 
        }
    }
}
