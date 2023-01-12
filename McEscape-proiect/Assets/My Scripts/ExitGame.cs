using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitGame : MonoBehaviour
{
    public bool hasEnteredCorrectCode;
    // Start is called before the first frame update
    void Start()
    {
        hasEnteredCorrectCode = false;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collided with exit area");
        if (collision.gameObject.name == "ExitArea" && hasEnteredCorrectCode == true)
        {
            SceneManager.LoadScene("McEscape Exit");
        }
    }
}
