using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Dialog : MonoBehaviour
{
    public Text title;
    public Image image;
    public Text nameofdragon;
    public Image first;
    public Image second;
    public Image third;
    public Image fourth;
    public Image fifth;
    public string message_0;
    public string message_1;
    public string message_2;
    public string message_3;
    public string message_4;
    public string message_5;
    private bool Jump = false;
    private bool Slash = false;
    private bool Run = false;
    private bool Attack = false;
    private bool Walk = false;
    private bool Stop_Dialog = false;
    private bool Start_Dialog = true;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.V) && Start_Dialog)
        {
            title.text = message_5;
            Start_Dialog = false;
            Walk = true;

        }
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) && Walk)
        {

            title.text = message_0;
            Jump = true;
            Walk = false;

        }
        if (Input.GetKey(KeyCode.Space) && Jump)
        {

            title.text = message_1;
            Slash = true;
            Jump = false;
        }
        if ((Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.Q)) && Slash)
        {

            title.text = message_2;
            Run = true;
            Slash = false;
        }
        if (Input.GetKey(KeyCode.LeftShift) && Run)
        {

            title.text = message_3;
            Attack = true;
            Run = false;


        }
        if (Input.GetKey(KeyCode.F) && Attack)
        {

            title.text = message_4;
            Attack = false;
            Stop_Dialog = true;


        }
        if (Input.GetKey(KeyCode.V) && Stop_Dialog)
        {
            title.enabled = false;
            image.enabled = false;
            nameofdragon.enabled = false;
            first.enabled = false;
            second.enabled = false;
            third.enabled = false;
            fourth.enabled = false;
            fifth.enabled = false;
        }

    }
}