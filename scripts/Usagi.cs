using System.Collections;
using UnityEngine;

public class Usagi : MonoBehaviour
{

    public Animator anim;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            StartCoroutine(delay());
            anim.SetTrigger("Died");
        }
    }

    public IEnumerator delay() {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }

    void Start() {
        anim = gameObject.GetComponent<Animator>();
    }
}
