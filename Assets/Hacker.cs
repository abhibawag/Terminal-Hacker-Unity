using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu("Hello Abhi");
    }

    void ShowMainMenu(string greeting)
    {
        Terminal.ClearScreen();
        Terminal.WriteLine(greeting);
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("Press 1 for local library");
        Terminal.WriteLine("Press 2 for Polic Station");
        Terminal.WriteLine("Enter you selection: ");
    }

    void OnUserInput(string input)
    {
        print(input);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
