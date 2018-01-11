using UnityEngine;

public class Hacker : MonoBehaviour
{

    //game config data
    const string menuHint = "Type menu anytime to go back to menu";
    string[] level1passwords = { "books", "aisle", "shelf", "password", "font", "borrow" };
    string[] level2passwords = { "prisoner", "handcuffs", "holster", "uniform", "arrest" };
    string[] level3passwords = { "starfield", "telescope", "environment", "exploration", "astronauts" };

    //game state
    int level; 
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;
    int rando;
    string password;


    // Use this for initialization
    void Start()
    {
        print(level1passwords[0]);
        ShowMainMenu();
    }

    void Update()
    {
        int index = Random.Range(0, level1passwords.Length);
        print(index);   
    }

    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("Press [1] for the local library");
        Terminal.WriteLine("Press [2] for the police station");
        Terminal.WriteLine("Press [3] for the space station");
        Terminal.WriteLine("Enter your selection: ");
    }

    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            ShowMainMenu();
        }

        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }

        else
        {
            RunMainMenu(input);
        }

    }

    void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");

        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            AskForPassword();
           
        }

        else if (input == "lol")
        {

            Terminal.WriteLine("luls");
            Terminal.WriteLine(menuHint);
        }

        else
        {
            Terminal.WriteLine("Try again");
            Terminal.WriteLine(menuHint);
        }
    }

    void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Please enter password, hint: " + password.Anagram());
        Terminal.WriteLine(menuHint);
    }

    void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                password = level1passwords[Random.Range(0, level1passwords.Length)];
                break;

            case 2:
                password = level2passwords[Random.Range(0, level2passwords.Length)];
                break;

            case 3:
                password = level3passwords[Random.Range(0, level3passwords.Length)];
                break;

            default:
                Debug.LogError("bad level number");
                break;

        }
    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
            DisplayWinScreen();
        }

        else if (input == "menu")
        {
            ShowMainMenu(); 
        }
        else 
        {
            AskForPassword();
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
        Terminal.WriteLine(menuHint);
    }

    void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Here's a book:");
                Terminal.WriteLine(@"
     ,  ,
    ////|
   |~~| |
   |==| |
   |  | /
   |==|/
   '--'
                ");
                break;

            case 2:
                Terminal.WriteLine("Here's a key!");
                Terminal.WriteLine(@"
    
              ____
             | =, \___________
             | ='  ,_/VvvVvV--'
             |____/

                ");
                break;

            case 3:
                Terminal.WriteLine("Here's a spaceship!");
                Terminal.WriteLine(@"  
     
 _,       
 | \
 =|[_|])--._____
 =|[+--,-------'
   [|_/
             ");
                break;


            default:
                Debug.LogError("invalid level reached");
                break;
        }
    }
}
