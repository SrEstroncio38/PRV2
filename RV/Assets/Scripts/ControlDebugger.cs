using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlDebugger : MonoBehaviour
{

    public List<ButtonReference> buttons;

    [Serializable]
    public class ButtonReference
    {
        public string keyboardLetter;
        public ButtonScript button;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        foreach(ButtonReference br in buttons)
        {
            if (Input.GetKeyDown(br.keyboardLetter))
            {
                br.button.TryPressing();
            }
        }
        
    }
}
