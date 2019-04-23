using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTrigger : MonoBehaviour
{
    private GameObject _player;
    private GameObject _GD;
    Animator anim;
    bool temp = false;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player");
        _GD = GameObject.Find("God");
    }

    private void Update()
    {
        if (_GD.transform.position.y <= 319)
        {
            temp = false;
            anim = _GD.GetComponent<Animator>();
            StartCoroutine(ThumbsUP());
            
        }
        if (temp)
        {
            _GD.transform.Translate(Vector2.down*Time.deltaTime, Space.World);
            GameObject.Find("MainCamera").GetComponent<Camera>().orthographicSize += .0055f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        temp = true;
        GameObject.Find("Canvas").active = false;


        _player.GetComponent<Animator>().SetTrigger("LookUp");
    }

    private IEnumerator ThumbsUP()
    {
        yield return new WaitForSeconds(1f);
        anim.SetTrigger("thumbsUp");
        StartCoroutine(ReturnToMenu());
    }
    private IEnumerator ReturnToMenu()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("MainMenu");
    }
}
