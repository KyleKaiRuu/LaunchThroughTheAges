using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public MenuButton[] buttons;
    public Sprite[] hoveredSprites;
    [ReadOnlyField]
    public Sprite[] defaultSprites;

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
        for (int i = 0; i < buttons.Length; i++)
        {
            defaultSprites[i] = buttons[i].GetComponent<SpriteRenderer>().sprite;
        }
    }

    private void Update()
    {
        buttons[curButton].GetComponent<SpriteRenderer>().sprite = hoveredSprites[curButton];
        if(!activeMove && Input.GetAxis("Vertical") != 0 && !loading)
        {
            if (Input.GetAxis("Vertical") > 0)
            {
                buttons[curButton].GetComponent<SpriteRenderer>().sprite = defaultSprites[curButton];
                UpButton();
                activeMove = true;
            }
            else
            {
                buttons[curButton].GetComponent<SpriteRenderer>().sprite = defaultSprites[curButton];
                DownButton();
                activeMove = true;
            }
        }
        else if (activeMove && Input.GetAxis("Vertical") == 0 && !loading)
        {
            activeMove = false;
        }
        if (Input.GetButtonDown("Submit") && !loading)
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
