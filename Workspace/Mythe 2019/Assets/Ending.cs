using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            doEndAnim();
            StartCoroutine(End());
        }
    }

    IEnumerator End()
    {
     
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("MainMenu");

    }

    private void doEndAnim()
    {
        anim.SetTrigger("Thumb");
    }
}
