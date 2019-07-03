using UnityEngine;

public class Hacker : MonoBehaviour
{
    int level;
    int input;
    string password;
    enum Screen { MainMenu, Password, Win }
    Screen currentScreen = Screen.MainMenu;

    string[] level1Passwords = { "desk", "homework", "teacher", "project", "chair" };
    string[] level2Passwords = { "passport", "visa", "inspector", "travel", "paperwork" };
    string[] level3Passwords = { "dementia", "alzheimers", "prosopagnosia", "epilepsy", "influenza" };


    void Start()
    {
        ShowMainMenu("Rayan");
    }

    void ShowMainMenu(string name)
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine($"Greetings, Agent {name}.");
        Terminal.WriteLine("What would you like to hack into today?");
        Terminal.WriteLine("Press 1 for School");
        Terminal.WriteLine("Press 2 for Embassy");
        Terminal.WriteLine("Press 3 for Hospital");
    }

    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            ShowMainMenu("Rayan");
        }
        else if (input == "quit" || input == "exit" || input == "close")
        {
            Application.Quit();
            Terminal.WriteLine("Aw, wanna stop hacking so fast? Well, if you're on a browser, just close the tab to exit the game.");
        }
        else if (currentScreen == Screen.MainMenu)
        {
            StartGame(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }

    void StartGame (string input)
    {
        if (input == "1") {
            level = 1;
            TextOfStartGame(input);
            startPassword();
        }
        else if (input == "2"){
            level = 2;
            TextOfStartGame(input);
            startPassword();
        }
        else if (input == "3"){
            level = 3;
            TextOfStartGame(input);
            startPassword();
        }
    }

    void TextOfStartGame(string input)
    {
        Terminal.WriteLine("You have selected Level " + input);
    }

    void startPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
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
                Terminal.WriteLine("Game brok :/");
                break;
        }
        Terminal.WriteLine("C'mon, start cracking the password! Hint:"+ password.Anagram());
    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
        DisplayWinScreen();
        Terminal.WriteLine("Wanna try another level? Just type in menu!");
        BackToMenu(input);
        }
        else if (input != password)
        {
            ShowMainMenu(name);
        }
    }

    void BackToMenu(string input)
    {
        if (input == "menu")
        {
            ShowMainMenu(name);
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
        var sklWin = new[]
        {
          @"            _______       ",
          @"            ___    |_____ ",
          @"            __  /| |__/ /_",
          @"            _  ___ /_  __/",
          @"            /_/  |_|/_/   ",
          @"                          ",
        };

       // var embassyWin = new[]
       // {
      //  @"  __                   ___ ",
       // @" |""|  ___    _   __  |""" "",
       // @" |""| |"""|  |"| |""| |""" "",
       // @" |""| |"""|  |"| |""| |""" "",
       // @" |""| |"""|  |"| |""| |""" "",
      //  };

        switch (level)
        {
            case 1:
                level = 1;
                foreach (var item in sklWin)
                {
                    Terminal.WriteLine(item.ToString());
                }
                break;
            case 2:
                level = 2;
                Terminal.WriteLine(@"
                        _________________  _______
                        ___  ____/__  /_ \/ /__  /
                        __  /_   __  / __  /__  / 
                        _  __/   _  /___  /  /_/  
                        /_/      /_____/_/  (_)   
                                    ");
                Terminal.WriteLine(@"There are now illegal immigrants everywhere. Good job!");
                break;
            case 3:
                level = 3;
                Terminal.WriteLine(@"
                        /  _> | __>| . \|  \  \/ __>| || |
                        | <_/\| _> |   /|     |\__ \|_/|_/
                        `____/|___>|_\_\|_|_|_|<___/<_><_>
                        ");
                Terminal.WriteLine("There are now outbreaks of deadly diseases everywhere. Good job!");
                break;
            default:
                Terminal.WriteLine("WINNER!!");
                break;
        }

    }

    void Update()
    {
        
    }
}
