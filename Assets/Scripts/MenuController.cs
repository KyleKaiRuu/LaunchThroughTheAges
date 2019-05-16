using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public MenuButton[] buttons;

    [ReadOnlyField]
    public int curButton = 0;
    [ReadOnlyField]
    public int maxButton = 0;
    private bool activeMove = false;
    public float delay = 0.5f;
    private bool loading = false;

    private void Start()
    {
        maxButton = buttons.Length - 1;
    }

    private void Update()
    {
        if(!activeMove && Input.GetAxis("Vertical") != 0 && !loading)
        {
            if (Input.GetAxis("Vertical") > 0)
            {
                UpButton();
                activeMove = true;
            }
            else
            {
                DownButton();
                activeMove = true;
            }
        }
        else if (activeMove && Input.GetAxis("Vertical") == 0 && !loading)
        {
            activeMove = false;
        }
        if (Input.GetButtonDown("Interact") && !loading)
        {
            StartCoroutine(LoadScene());
        }
    }

    void UpButton()
    {
        if (curButton == 0)
        {
            curButton = maxButton;
        }
        else
        {
            curButton--;
        }
    }

    void DownButton()
    {
        if (curButton == maxButton)
        {
            curButton = 0;
        }
        else
        {
            curButton++;
        }
    }

    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(delay);
        if (buttons[curButton].level == "None")
        {
            Debug.Log("Exit");
            Application.Quit();
        }
        else
        {
            SceneManager.LoadScene(buttons[curButton].level); 
        }
    }
}
