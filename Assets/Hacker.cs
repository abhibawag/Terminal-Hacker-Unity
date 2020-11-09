
using UnityEngine;


public class Hacker : MonoBehaviour
{
    //Game configurations
    string[] level1Passwords = { "books", "aisle", "self", "password", "font", "borrow" };
    string[] level2Passwords = { "prisoner", "handcuffs", "holster", "uniform", "arrest" };
    string[] level3Passwords = { "astronauts", "starfield", "spaceship", "milkywaygalaxy", "universe"};
    const string menuHint = "You may type menu at any time";
    //Game State
    int level;
    string password;
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen = Screen.MainMenu;

    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();
    }

    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("Press 1 for local library");
        Terminal.WriteLine("Press 2 for Polic Station");
        Terminal.WriteLine("Press 3 for NASA");
        Terminal.WriteLine("Enter you selection: ");
        Terminal.WriteLine(menuHint);
    }

    void OnUserInput(string input)
    {
        if(input == "menu")
        {
            ShowMainMenu();
        }
        else if(currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }

    }

    void RunMainMenu(string input)
    {
        bool isValidLevel = (input == "1" || input == "2" || input == "3");
        if(isValidLevel)
        {
            level = int.Parse(input);
            StartGame();
        }
        else
        {
            Terminal.WriteLine("Select valid level");
        }
    }

    void StartGame()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        PickRandomPassword();
    }

    void PickRandomPassword()
    {
        switch (level)
        {
            case 1:
                password = level1Passwords[Random.Range(0, level1Passwords.Length)];
                break;
            case 2:
                password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                break;
            case 3:
                password = level3Passwords[Random.Range(0, level3Passwords.Length)];
                break;
            default:
                Debug.LogError("Invalid level");
                break;
        }
        Terminal.WriteLine("Please enter your password: ");
        Terminal.WriteLine("Hint: " + password.Anagram());
        Terminal.WriteLine(menuHint);
    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
            DisplayWinScreen();
        }
        else
        {
            StartGame();
            Terminal.WriteLine(menuHint);
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
    }

    void ShowLevelReward()
    {
        switch(level)
        {
            case 1:
                Terminal.WriteLine("Have a book...");
                Terminal.WriteLine(@"
    ______
   /     //
  /     //
 /_____//
(_____(/
"
               );
                Terminal.WriteLine(menuHint);
                break;
            case 2:
                Terminal.WriteLine("You got the prison key");
                Terminal.WriteLine(@"
 ___
/0  \__________
\___/-='--='--/
"
               );
                Terminal.WriteLine(menuHint);
                break;
            case 3:
                Terminal.WriteLine("Welcome to ");
                Terminal.WriteLine(@"
 _ __   __ _ ___  ___ _           
| '_ \ / _' / __|/  _' |
| | | | (_| \__  \ (_| | 
|_| |_|\__,_|___) \__,_|
"
               );
                Terminal.WriteLine(menuHint);
                break;
            default:
                Debug.LogError("Invalid level reached");
                break;
        }
    }
}
