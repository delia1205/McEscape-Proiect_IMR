using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForkScript : MonoBehaviour
{
    public GameObject baloon;
    public GameObject key;
    private Animator BaloonAnimator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "baloon")
        {
            // Debug.Log("Collided fork with baloons.");
            BaloonAnimator = baloon.GetComponent<Animator>();
            BaloonAnimator.SetBool("isActive", true);

            key.SetActive(true);
        }
    }
}
