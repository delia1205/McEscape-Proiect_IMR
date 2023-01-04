using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegisterScript : MonoBehaviour
{
    public GameObject button;
    int cnt;
    int code;
    // Start is called before the first frame update
    void Start()
    {
        cnt = 0;
        code = 0;
    }

    // Update is called once per frame
    void Update()
    {
           
    }

    void ButtonPressed()
    {
        if (cnt < 4)
        {
            cnt++;
            if (button.name == "Button1")
                code = code * 10 + 1;
            if (button.name == "Button2")
                code = code * 10 + 2;
            if (button.name == "Button3")
                code = code * 10 + 3;
            if (button.name == "Button4")
                code = code * 10 + 4;
            if (button.name == "Button5")
                code = code * 10 + 5;
            if (button.name == "Button6")
                code = code * 10 + 6;
            if (button.name == "Button7")
                code = code * 10 + 7;
            if (button.name == "Button8")
                code = code * 10 + 8;
            if (button.name == "Button9")
                code = code * 10 + 9;
            if (button.name == "Button0")
                code = code * 10 + 0;
            if (button.name == "Enter")
                if (cnt == 3)
                    if (code == 1617)
                        trueCode();
                    else
                        falseCode();
        }
    }

    void trueCode()
    {

    }

    void falseCode()
    {

    }
}
