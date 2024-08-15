/*TASK: SIMULATES DICE ROLLING

    BUILD SPECS:
1. PROMPT USER FOR NUMBER 1-6
    - EXCEPTION HANDLING
2. PROMPTS USER TO ROLL DICE
3. APP ROLLS 2 n-SIDED DICE -> DISPLAY RESULTS + TOTAL
4. 6-SIDED DICE:
- "SNAKE EYES" = 1 AND 1
    - "ACE DEUCE" = 1 AND 2
    - "BOX CARS" = 6 AND 6
    - "WIN": TOTAL OF 7 OR 11
TOTAL OF 7:
- 6 AND 1
    - 3 AND 4
    - 5 AND 2
TOTAL OF 11:
- 5 AND 6
    - "CRAPS" = TOTAL OF 2, 3, 12
    - TOTAL OF 2:
- 1 AND 1
    - TOTAL OF 3:
- 2 AND 1
    - TOTAL OF 12:
5. APP TAKES ALL USER INPUT CORRECTLY
6. APP LOOPS PROPERLY
7. COME UP WITH A SET OF WINNING COMBINATIONS FOR OTHER DICE SIZES BESIDES 6
*/

//----------------------------------------------------------------------------------------------------------------------

// method that generates random numbers 
static int DiceCombos(int dice)
{
    Random rndm = new Random();
    int roll = rndm.Next(1, dice);
    return roll;
}

// method for build spec 2 
static void DeAngeloTheHelper(int die1, int die2) 
// did i do more work than i needed to? yes. did i finally figure out how to do ternary operator and was too happy to let it go? yes, absolutely.
{
    int dieTotal = die1 + die2;
    if (dieTotal == 2)
    {
        string snakeEyes = die1 == 1 && die1 == die2 ? "You got snake eyes!" : "Shhhhhhh (delete this later )"; 
        Console.WriteLine(snakeEyes);
    }
    else if (dieTotal == 3)
    {
        string aceDeuce = (die1 == 1 && die2 == 2) || (die1 == 2 && die2 == 1) ? "You got ace deuce!" : "Shhhhhhh (delete this later )";
        Console.WriteLine(aceDeuce);
    }
    else if (dieTotal == 12)
    {
        string boxCars = (die1 == 6) && (die1 == die2) ? "You got box cars!" : "Shhhhhhh (delete this later )";
        Console.WriteLine(boxCars);
    }
}

// method for build spec 3
static string HighRoller(int die1, int die2)
{
    int dieTotal = die1 + die2;
    if (dieTotal == 7)
    {
        return "You got a win!";
    }
    if (dieTotal == 11)
    {
        return "You got a win!";
    }
    else if (dieTotal == 12)
    {
        return "You got craps!";
    }
    else if (dieTotal == 3)
    {
        return "You got craps!";
    }
    else if (dieTotal == 2)
    {
        return "You got craps!";
    }
    return "";
}

// method for asking user if they want to continue 
static bool KeepGoing()
{
    bool userChoice = true;
    while (true)
    {
        Console.WriteLine();
        Console.Write("Would you like to roll again? (y/n)    ");
        string answer = Console.ReadLine().ToLower();
        if (answer == "y")
        {
            userChoice = true;
            Console.WriteLine();
            break;
        }
        else if (answer == "n")
        {
            userChoice = !true;
            break;
        }
        else
        {
            Console.WriteLine("Invalid entry. Please choose again.");
        }
    }
    return userChoice;
}

bool runProgram = true;

while (runProgram)
{
    int tracker = 1;
    
    Console.Write("Let's gamble! How many sides do you want your dice to have?  ");
    int pickingSides = 0;
    while (!int.TryParse(Console.ReadLine(), out pickingSides) || (pickingSides <= 1 || pickingSides > int.MaxValue))
    {
        Console.WriteLine("Sorry, please choose another number.");
    }
    
    int dice1 = DiceCombos(pickingSides);  
    int dice2 = DiceCombos(pickingSides);
    int diceTotal = dice1 + dice2;
    
    Console.WriteLine();
    Console.WriteLine("~~~~~~Roll your dice~~~~~~");
    tracker++;
    Console.WriteLine();
    
    Console.WriteLine($"Roll {tracker}:");
    Console.WriteLine($"You rolled a {dice1} and a {dice2}. Giving you a grand total of {diceTotal}!");
    
    DeAngeloTheHelper(dice1, dice2);
    HighRoller(dice1, dice2);
    
    runProgram = KeepGoing();
   
}

