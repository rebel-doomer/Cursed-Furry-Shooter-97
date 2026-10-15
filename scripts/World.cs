using System.Collections;
using UnityEngine;

public class World : MonoBehaviour
{
    // We want two boxes such that enemies can spawn within one, but now within the other
    // SerializeField - brings this variable from code into something you can change in real time in the editor!
    [SerializeField]
    [Tooltip("The (x, y) size of the box in Unity units that include enemy spawns.")]
    public Vector2 outerBoxBoundsX;
    public Vector2 outerBoxBoundsY;
    [Tooltip("The (x, y) size of the box in Unity units that exlude enemy spawns.")]
    public Vector2 innerBoxBoundsX;
    public Vector2 innerBoxBoundsY;
    [Tooltip("Time between each random enemy spawn.")]
    public float timer;
    [Tooltip("Enemy prefab to use.")]
    public GameObject enemy;



    //IEnumerator is just the standard way Unity does coroutines - which I just think of as timers
    public IEnumerator repeat() {
        //Infinite loop
        while (true)
        {
            //Call Usagi creation method
            spawnUsagi();

            //Wait for some amount of seconds before looping again
            yield return new WaitForSeconds(timer);
        }
    }



    //Calls only on the first frame of scene startup
    void Start() {
        StartCoroutine(repeat());
    }



    //Method for spawning Usagi
    public void spawnUsagi() {

        //Create an arbitrary random position for the Usagi to spawn (between outer box and inner box)
        float randX = Random.Range(outerBoxBoundsX.x, outerBoxBoundsX.y);
        float randY = Random.Range(outerBoxBoundsY.x, outerBoxBoundsY.y);
        Debug.Log(randX + " " + randY);

        //Create a vector from the random position - This represents Usagi's position
        Vector2 pos = new Vector2(randX, randY);

        //Check if the position is between the outer box and inner box - If it isn't, don't spawn the Usagi there
        //If it is, continue with the next steps
        if (!((pos.x >= innerBoxBoundsX.x && pos.x <= innerBoxBoundsX.y) || (pos.y >= innerBoxBoundsY.x && pos.y <= innerBoxBoundsY.y))) {

            //Instantiate Usagi - Copy Usagi object that we have assigned in editor to be spawned at this new position
            GameObject usag = Instantiate(enemy);

            //Set Usagi position
            usag.transform.position = new Vector3(pos.x, pos.y, 0f);

            //Create a random vector representing the direction Usagi will move towards
            Vector2 direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));


            Debug.Log("usagi spawned, prepare to die.");

            //Add velocity to Usagi according to its random vector
            usag.GetComponent<Rigidbody2D>().linearVelocity = direction;
        }
    }
}
