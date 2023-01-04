using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    public GameObject locker;
    private Animator LockerAnimator;
    public GameObject book;
    private Animator BookAnimator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator wait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Locker")
        {
            LockerAnimator = locker.GetComponent<Animator>();
            LockerAnimator.SetBool("isActive", true);
            wait(3);
            BookAnimator = book.GetComponent<Animator>();
            BookAnimator.SetBool("isActive", true);
        }
    }
}
