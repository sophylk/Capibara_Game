using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextforStudy : MonoBehaviour
{
    public Transform TextOfStudy;
    public KeyCode OnText = KeyCode.W;
    public KeyCode OnText1 = KeyCode.A;
    public KeyCode OnText2 = KeyCode.D;
    public KeyCode OnText3 = KeyCode.S;
    private Vector3 pos;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(OnText) || Input.GetKeyUp(OnText1) || Input.GetKeyUp(OnText2) || Input.GetKeyUp(OnText3))
        {
            pos = TextOfStudy.position;
            pos.z = -2;
            TextOfStudy.transform.position = Vector3.Lerp(transform.position, pos, 1);
        }
    }
}
