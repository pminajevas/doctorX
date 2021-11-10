using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Narrator : MonoBehaviour
{
    public string []Messages;
    public Text Text;
    public GameObject Template;
    private bool TemplateOn;
    private int i;
    
    void Start()
    {
        i = 0;
        Template.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            if (Messages.Length <= i)
            {
                Template.SetActive(false);
                Destroy(this.gameObject);
                i = 0;
            }
            else if (TemplateOn)
            {
                i++;
                Text.text = Messages[i];
            }

        }
     
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            Template.SetActive(true);
            TemplateOn = true;
            Text.text = Messages[0];

        }
    }
}
