using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CapstoneSH
{

    // #==========================================================#
    // 
    //  Title: Capstone Project - The Derelict Arcade Machine
    //  Description: An abandoned arcade machine loaded with 3 simple arcade games accessed via menu.
    //               beat the games and earn the keys in order to progress to ending screen. 
    //               Source code for some parts of the program used from links provided below, 
    //               refactored, added and shaved features.
    //  Application Type: Console
    //  Author: Hill, Shane
    //  Dated Created: 9/28/2020
    //  Last Modified: 11/8/2020
    //  

    //Code References/Source/Inspiration:
    //https://ascii.co.uk/art/key
    //https://gist.github.com/wynand1004/b5c521ea8392e9c6bfe101b025c39abe
    //https://www.youtube.com/watch?v=WJCNxT2bolg
    //https://codereview.stackexchange.com/questions/127515/first-c-program-snake-game
    //https://github.com/ZacharyPatten/dotnet-console-games
    // #==========================================================#


    class Program
    {

        enum SnakeDirection
        {
            Up,
            Down,
            Right,
            Left
        }

        static void Main(string[] args)
        {

            SetTheme();

            DisplayFirstBootUp();
            //BootUpBar();
            DisplayWelcomeScreen();
            DisplayMenuScreen();
            //DisplayClosingScreen();

        }

        #region MainMenu

        /// <summary>
        /// setup the console theme
        /// </summary>
        /// 
        static void SetTheme()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.BackgroundColor = ConsoleColor.Black;

        }

        /// <summary>
        /// #====================================#
        /// #       Arcade Main Menu Screen      #
        /// #====================================#
        /// </summary>
        /// 
        static void DisplayMenuScreen()
        {
            Console.CursorVisible = true;

            bool quitApplication = false;
            string menuChoice;
            int score = 5;
            int scoreTwo = 0;
            int scoreThree = 0;
            string passKeyOne;
            string passKeyTwo;
            string passKeyThree;

            do
            {
                DisplayArcadeMenuHeader();
                SetTheme();

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Snake Game Challenge");
                Console.WriteLine("\tb) Wack A Mole Challenge");
                Console.WriteLine("\tc) Rock Paper Scissors Challenge");
                Console.WriteLine("\td) Check Earned Keys");
                //Console.WriteLine("\te) Power Down\n");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        score = ArcadeSnake();

                        break;

                    case "b":
                        scoreTwo = ArcadeWackAMole();

                        break;

                    case "c":
                        RockPaperScissors();

                        break;

                    case "d":
                            //
                            //Nested ifs to verify correct key and proceed to end screen.
                            //
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("\n\tType the valid key to proceed\n");
                        Console.WriteLine("\tKey One:");
                        passKeyOne = Console.ReadLine().ToUpper();
                        if (passKeyOne == "END")
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("\n\tType the next valid key to proceed\n");
                            Console.WriteLine("\tKey Two:");
                            passKeyTwo = Console.ReadLine().ToUpper();

                            if (passKeyTwo == "OF")
                                Console.Clear();
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine("\n\tType the valid key to proceed\n");
                                Console.WriteLine("\tKey Three:");
                                passKeyThree = Console.ReadLine().ToUpper();
                                if (passKeyThree == "LINE")
                                {
                                    Console.WriteLine("\tWell done. You may enter the program.");
                                    Console.ReadKey();

                                    EnterKeyProceed(score, scoreTwo, scoreThree);
                                    break;
                                }
                            }
                        }
                        Console.WriteLine("Score high enough in each game to reveal the keys. You may continue when you have entered the proper keys.");

                        DisplayContinuePrompt();

                        break;

                    case "f":

                        break;

                    case "q":

                        quitApplication = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitApplication);
        }


        /// <summary>
        /// Ending screen method displays keys and arcade machine, and thank you message.
        /// </summary>
        /// 
        static void EnterKeyProceed(int score, int scoreTwo, int scoreThree)
        {

            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Yellow;
            var HeaderVictory = new[]
       {
           @"     _____________     _____________     _____________            ",
           @"    /      _      \   /      _      \   /      _      \           ",
           @"    [] :: (_) :: []   [] :: (_) :: []   [] :: (_) :: []           ",
           @"    [] ::::::::: []   [] ::::::::: []   [] ::::::::: []           ",
           @"    [] :::END::: []   [] :::OF:::: []   [] ::LINE::: []           ",
           @"    [] ::::::::: []   [] ::::::::: []   [] ::::::::: []           ",
           @"    [] ::::::::: []   [] ::::::::: []   [] ::::::::: []           ",
           @"    [_____________]   [_____________]   [_____________]           ",
           @"          I I               I I               I I                 ",
           @"         I_ _I             I_ _I             I_ _I                ",
           @"         /   \             /   \             /   \                ",
           @"         \   /             \   /             \   /                ",
           @"         (   )             (   )             (   )                ",
           @"         /   \             /   \             /   \                ",
           @"         \___/             \___/             \___/                ",
   };
            foreach (string line in HeaderVictory) Console.WriteLine(line);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"\n\t Congratulations. You have earned all three keys. This is the end of the line.\n");
            DisplayContinuePrompt();
            Console.Clear();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            var ArcadeEnd = new[]
{

       @"             @@@@@@@@@@@@@@@@@@@@&             ",
       @"    @@@@@@@@% (*******************&            ",
       @"   @@@@@@@@@@@%#*******************@,          ",
       @"   @@@@@@@@@@@&@*******************@#          ",
       @"   @@@@@@@@@@@/ ..,,*/#@@@@@@@@@@@@@@@         ",
       @"   @@@@@@@@@@@.................%@%             ",
       @"   @@@@@@@@@&................@@@/              ",
       @"   @@@@@@@@@@&%%%%%%%%%%%%&@@(@&               ",
       @"   @@@@@@@@@@@%%%%%%%%%%%%%% &.@&          A beam of light eminates from the screen and envelopes you. ",
       @"   @@@@@@@@@@@@%%%%%%%%%%%%%%@(@@*              ",
       @"   @@@@@@@@@@@@%%%%%%%%%%%%%% &@(@              ",
       @"   @@@@@@@@@@@@&%%%%%%%%%%%%%@@.@@@             ",
       @"   @@@@@@@@@@@@.................@@@@            ",
       @"   @@@@@@@@@@@@@..(/ .........(@@(@@            ",
       @"   @@@@@@@@@@@@@@,..@&............,@            ",
       @"   @@@@@@@@@@@@@@@@%%%%%%%%%%%%%%%%%%           ",
       @"   @@@@@@@@@@@@@@@@%%%%%%%%%@&@@@@@*            ",
       @"   @@@@@@@@@@@@@@....*&%@@@&&...&&              ",
       @"   @@@@@@@@@@@@@@....(%@&@@&)...&&              ",
       @"   @@@@@@@@@@@@@@....(%@  &&)...&&              ",
       @"   @@@@@@@@@@@@@@....(%%%@@@)...&&              ",
       @"   @@@@@@@@@@@@@@...............&&              ",
       @"   @@@@@@@@@@@@@@***************&&              ",
       @"   @@@@@@@@@@@@@@***************&&              ",
       @"   @@@@@@@@@@@@@@***************%@              ",
       @"   @@@@@@@@@@@@@@***************%@              ",
       @"   %@@@@@ @@@@@@@@@@@@@@@@@@@@@@@@              ",

                 };
            Console.WindowWidth = 140;
            Console.WindowHeight = 35;
            Console.WriteLine("\n\n");
            foreach (string line in ArcadeEnd) Console.WriteLine(line);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n\tThank you for playing!");
            DisplayContinuePrompt();

        }

        #endregion

        #region RockPaperScissors

        /// <summary>
        /// #=======================================#
        /// #       Rock Paper Scissors Screen      #
        /// #=======================================#
        /// </summary>
        /// 
        static void RockPaperScissors()
        {
            string inputPlayer, inputCPU;
            int randomInt;


            bool playAgain = true;

            Console.Clear();
            Console.WindowWidth = 80;
            Console.WindowHeight = 30;
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            var rockPaperScissorsHeader = new[]
            {
             @"         ____            _      ____                          _    _    ",
             @"        |  _ \ ___   ___| | __ |  _ \ __ _ _ __   ___ _ __   (_)  / )   ",
             @"        | |_) / _ \ / __| |/ / | |_) / _` | '_ \ / _ \ '__|    | (_/    ",
             @"        |  _ < (_) | (__|   <  |  __/ (_| | |_) |  __/ |       _+/      ",
             @"        |_| \_\___/ \___|_|\_\ | |   \__,_| .__/ \___|_|       //|\     ",
             @"                               |_|                            // | )    ",
             @"                                                             (/  |/     ",
   };
            foreach (string line in rockPaperScissorsHeader) Console.WriteLine(line);

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n\tWelcome to Rock Paper Scissors.");
            Console.WriteLine("\tYou must beat the computer to generate the third key.\n");
            DisplayContinuePrompt();
            Console.Clear();

            while (playAgain)
            {

                int scoreThree = 0;
                int scoreCPU = 0;

                while (scoreThree < 3 && scoreCPU < 3)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("---------------------------------------------------------");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\n\tPress any key to start the round.");
                    Console.ReadKey();
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("\n\tChoose between ROCK, PAPER and SCISSORS:    \n");
                    inputPlayer = Console.ReadLine();
                    inputPlayer = inputPlayer.ToUpper();

                    Random rnd = new Random();

                    randomInt = rnd.Next(1, 4);

                    //
                    //switch and case blocks for rock, paper, and scissors - player win outcome and loose outcome. 
                    //
                    switch (randomInt)
                    {
                        case 1:
                            inputCPU = "ROCK";
                            Console.WriteLine("Computer chose ROCK\n");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Render(rockRender);
                            Console.ForegroundColor = ConsoleColor.Blue;
                            if (inputPlayer == "ROCK")
                            {
                                Console.WriteLine("DRAW!!\n\n");
                            }
                            else if (inputPlayer == "PAPER")
                            {
                                Console.WriteLine("PLAYER WINS!!\n\n");
                                scoreThree++;

                            }
                            else if (inputPlayer == "SCISSORS")
                            {
                                Console.WriteLine("CPU WINS!!\n\n");
                                scoreCPU++;
                            }
                            break;

                        case 2:
                            inputCPU = "PAPER";
                            Console.WriteLine("Computer chose PAPER\n");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Render(paperRender);
                            Console.ForegroundColor = ConsoleColor.Blue;
                            if (inputPlayer == "PAPER")
                            {
                                Console.WriteLine("DRAW!!\n\n");
                            }
                            else if (inputPlayer == "ROCK")
                            {
                                Console.WriteLine("CPU WINS!!\n\n");
                                scoreCPU++;
                            }
                            else if (inputPlayer == "SCISSORS")
                            {
                                Console.WriteLine("PLAYER WINS!!\n\n");
                                scoreThree++;

                            }
                            break;

                        case 3:
                            inputCPU = "SCISSORS";
                            Console.WriteLine("Computer chose SCISSORS\n");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Render(scissorsRender);
                            Console.ForegroundColor = ConsoleColor.Blue;
                            if (inputPlayer == "SCISSORS")
                            {
                                Console.WriteLine("DRAW!!\n\n");
                            }
                            else if (inputPlayer == "ROCK")
                            {
                                Console.WriteLine("PLAYER WINS!!\n\n");
                                scoreThree++;

                            }
                            else if (inputPlayer == "PAPER")
                            {
                                Console.WriteLine("CPU WINS!!\n\n");
                                scoreCPU++;
                            }
                            break;
                        default:
                            Console.WriteLine("Invalid entry!");
                            break;
                    }

                    Console.WriteLine("\n\nSCORES:\tPLAYER:\t{0}\tCPU:\t{1}", scoreThree, scoreCPU);
                }

                //
                //displays key if player beats CPU
                //
                if (scoreThree == 3)
                {
                    Console.Clear();
                    Console.WriteLine("\n\t\tPlayer WON!");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    var rockPaperScissorsHeaderTwo = new[]
                  {
                         @"     _____________          ",
                         @"    /      _      \         ",
                         @"    [] :: (_) :: []         ",
                         @"    [] ::::::::: []         ",
                         @"    [] ::LINE::::[]         ",
                         @"    [] ::::::::: []         ",
                         @"    [] ::::::::: []         ",
                         @"    [_____________]         ",
                         @"          I I               ",
                         @"         I_ _I              ",
                         @"         /   \              ",
                         @"         \   /              ",
                         @"         (   )              ",
                         @"         /   \              ",
                         @"         \___/              ",
   };
                    foreach (string line in rockPaperScissorsHeaderTwo) Console.WriteLine(line);
                    Console.WriteLine("\n\tKEY THREE IS LINE");



                }
                else if (scoreCPU == 3)
                {
                    Console.WriteLine("CPU WON!");


                }
                else
                {

                }

                Console.WriteLine("Do you want to play again?(y/n)");
                string loop = Console.ReadLine().ToLower();
                if (loop == "y")
                {
                    playAgain = true;
                    Console.Clear();
                }
                else if (loop == "n")
                {
                    playAgain = false;
                }
                else
                {

                }
            }

        }

        /// <summary>
        /// This render displays rock
        /// </summary>
        /// 
        public static string rockRender =
           @"              _______     " + '\n' +
           @"         -- -'   ____)    " + '\n' +
           @"                (_____)   " + '\n' +
           @"                (_____)   " + '\n' +
           @"                 (____)   " + '\n' +
           @"           ---.__(___)    ";

        /// <summary>
        /// This string represents paper.
        /// </summary>
        /// 
        public static string paperRender =
           @"        _______           " + '\n' +
           @" -- - '    ____)____      " + '\n' +
           @"              ______)     " + '\n' +
           @"            _______)      " + '\n' +
           @"           _______)       " + '\n' +
           @"   ---.__________)        ";

        /// <summary>
        /// This string represents scissors
        /// </summary>
        /// 
        public static string scissorsRender =
           @"           _______           " + '\n' +
           @"     -- - '   ____)____      "+ '\n' +
           @"                 ______)     " + '\n' +
           @"              __________)    " + '\n' +
           @"               (____)        " + '\n' +
           @"        ---.__(___)          ";





        #endregion

        #region WackaMole

        /// <summary>
        /// #=============================================#
        /// #       Arcade WackAMole Welcome Screen       #
        /// #=============================================#
        /// </summary>
        /// 
        static void ArcadeWackAMoleWelcomeScreen()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            var wackAMoleWelcomeHeader = new[]
            {
              @"      __    __   ____    __  __  _   ____  ___ ___   ___   _        ___   ",
              @"     |  T__T  T /    T  /  ]|  l/ ] /    T|   T   T /   \ | T      /  _]  ",
              @"     |  |  |  |Y  o  | /  / |  ' / Y  o  || _   _ |Y     Y| |     /  [_   ",
              @"     |  |  |  ||     |/  /  |    \ |     ||  \_/  ||  O  || l___ Y    _]  ",
              @"     l  `  '  !|  _  /   \_ |     Y|  _  ||   |   ||     ||     T|   [_   ",
              @"      \      / |  |  \     ||  .  ||  |  ||   |   |l     !|     ||     T  ",
              @"       \_/\_/  l__j__j\____jl__j\_jl__j__jl___j___j \___/ l_____jl_____j  ",
              @"                                                                        ",
              @"                        ██████████████                                  ",
              @"                     ████░░░░░░░░░░░░░░██                               ",
              @"                  ██░░░░░░░░░░░░░░░░░░░░████                            ",
              @"              ████░░░░░░░░░░░░░░░░░░░░░░░░░░████████████████████        ",
              @"        ██████░░░░░░░░░░░░████░░░░░░░░░░░░░░██░░░░░░░░░░░░░░░░░░██      ",
              @"    ██████░░░░░░░░░░░░░░██    ██░░░░░░░░░░░░░░██░░░░░░░░░░░░░░░░░░██    ",
              @"  ██▓▓▓▓▓▓██░░░░░░░░░░░░██    ██░░░░░░░░░░░░░░░░██░░░░░░░░░░░░░░░░░░██           ",
              @"  ██▓▓▓▓▓▓▓▓██░░░░░░░░░░░░████░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░██         ",
              @"    ██▓▓▓▓██░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░██       ",
              @"      ████░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░██       ",
              @"        ██░░░░░░░░░░░░░░████████████░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░██       ",
              @"          ████░░░░░░████░░░░░░░░░░░░██░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░██████   ",
              @"        ██░░░░██████░░░░░░░░░░░░░░░░░░██░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░██    ██   ",
              @"      ██░░░░██░░░░░░░░░░░░░░░░░░░░░░░░██░░░░░░░░████████████████░░░░░░░░████    ██ ",
              @"      ██████░░░░░░░░░░░░░░░░░░░░░░░░░░██░░░░░░██░░░░░░░░░░░░░░░░██░░░░░░██  ████   ",
              @"            ████  ██░░░░██░░░░░░░░░░░░██░░░░██░░░░░░░░░░░░░░░░░░░░██████           ",
              @"                ██░░░░██░░░░░░██░░░░██████████░░░░██░░░░░░██░░░░░░██               ",
              @"              ██░░░░██░░░░░░██░░░░██        ██░░██░░░░░░██░░░░░░██                 ",
              @"            ██░░░░██░░░░████░░░░██            ██░░░░████░░░░░░██                   ",
              @"              ██████████  ██████                ████  ████████                     ",

            };
            //
            //Instrunctions
            //
            Console.WindowWidth = 140;
            Console.WindowHeight = 40;
            Console.WriteLine("\n");
            foreach (string line in wackAMoleWelcomeHeader) Console.WriteLine(line);
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\t\t\tWackAMole Instructions\n");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("\tWack as many moles as possible within ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write($"{(int)playTime.TotalSeconds}");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write(" seconds.\n");
            Console.Write("\tYou must score at least ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("15");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write(" points to reveal the second code word.\n");
            Console.Write("\tUse keys");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write(" #1-9 ");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("to wack the moles in their corresponding numbered circles.\n");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\tPress any key to start whacking moles!");
            Console.ReadKey();

            SetTheme();
        }


        /// <summary>
        /// This string represents the ground/board in which moles pop out. 
        /// </summary>
        /// 
        public static string Board =
        @"       <\/></X\></X\><\/>    <\/></X\></X\><\/>    <\/></X\></X\><\/>      " + '\n' +
        @"       </\>    #1    </\>    </\>    #2    </\>    </\>    #3    </\>      " + '\n' +
        @"     <\/>              <\/><\/>              <\/><\/>              <\/>    " + '\n' +
        @"    </\>                </\/\>                </\/\>                </\>   " + '\n' +
        @"   <\/>                  <\/>                  <\/>                  <\/>  " + '\n' +
        @"   </\>                  </\>                  </\>                  </\>  " + '\n' +
        @"    <\/>                <\/\/>                <\/\/>                 <\/>  " + '\n' +
        @"    </\>               </\></\>              </\></\>              </\>    " + '\n' +
        @"       <\/>          <\/>    <\/>          <\/>    <\/>          <\/>      " + '\n' +
        @"       </\><\X/><\X/></\>    </\><\X/><\X/></\>    </\><\X/><\X/></\>      " + '\n' +
        @"       <\/></X\></X\><\/>    <\/></X\></X\><\/>    <\/></X\></X\><\/>      " + '\n' +
        @"       </\>    #4    </\>    </\>    #5    </\>    </\>    #6    </\>      " + '\n' +
        @"    <\/>               <\/><\/>              <\/><\/>              <\/>    " + '\n' +
        @"    </\>                </\/\>                </\/\>                </\>   " + '\n' +
        @"   <\/>                  <\/>                  <\/>                  <\/>  " + '\n' +
        @"   </\>                  </\>                  </\>                  </\>  " + '\n' +
        @"    <\/>                <\/\/>                <\/\/>                 <\/>  " + '\n' +
        @"    </\>               </\></\>              </\></\>              </\>    " + '\n' +
        @"       <\/>          <\/>    <\/>          <\/>    <\/>          <\/>      " + '\n' +
        @"       </\><\X/><\X/></\>    </\><\X/><\X/></\>    </\><\X/><\X/></\>      " + '\n' +
        @"       <\/></X\></X\><\/>    <\/></X\></X\><\/>    <\/></X\></X\><\/>      " + '\n' +
        @"       </\>    #7    </\>    </\>    #8    </\>    </\>    #9    </\>      " + '\n' +
        @"    <\/>               <\/><\/>              <\/><\/>              <\/>    " + '\n' +
        @"    </\>                </\/\>                </\/\>                </\>   " + '\n' +
        @"   <\/>                  <\/>                  <\/>                  <\/>  " + '\n' +
        @"   </\>                  </\>                  </\>                  </\>  " + '\n' +
        @"    <\/>                <\/\/>                <\/\/>                 <\/>  " + '\n' +
        @"    </\>               </\></\>              </\></\>              </\>    " + '\n' +
        @"       <\/>          <\/>    <\/>          <\/>    <\/>          <\/>      " + '\n' +
        @"       </\><\X/><\X/></\>    </\><\X/><\X/></\>    </\><\X/><\X/></\>";

        /// <summary>
        /// Mole image code, visually represents the mole on the screen. 
        /// </summary>
        /// 
        public static string Mole =
        @"    _____  " + '\n' +
        @"   \'_ _'/ " + '\n' +
        @"  |(>)-(<)|" + '\n' +
        @"./  ' O '  \." + '\n' +
        @"((:-.,_,.-:))";

        /// <summary>
        /// Dead mole image code, replaces the mole above once whacked with a dead mole. 
        /// </summary>
        /// 
        public static string DeadMole =
        @"    _____  " + '\n' +
        @"   \'_ _'/ " + '\n' +
        @"  |(X)-(X)|" + '\n' +
        @"./  ' O '  \." + '\n' +
        @"((:-.,_,.-:))";

        /// <summary>
        /// Once the mole dead mole is displayed, this code replaces that render with blank text to 'erase' the mole. 
        /// </summary>
        /// 
        public static readonly string Empty =
        @"           " + '\n' +
        @"           " + '\n' +
        @"           " + '\n' +
        @"             " + '\n' +
        @"             ";

        /// <summary>
        /// Sets the wack a mole play time/time limit. 
        /// </summary>
        /// 
        static readonly TimeSpan playTime = TimeSpan.FromSeconds(20);


        /// <summary>
        /// #==========================================================#
        /// #       Main Wack A Mole method and rendering screen       #
        /// #==========================================================#
        /// </summary>
        /// 
        static int ArcadeWackAMole()
        {
            Random random = new Random();
            int moleLocation = random.Next(1, 10);
            int scoreTwo = 0;

            Console.Clear();
            ArcadeWackAMoleWelcomeScreen();
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            var wackAMoleHeader = new[]
                {
            @"        ________              __     _______ _______         __        ",
            @"       |  |  |  |.---.-.----.|  |--.|   _   |   |   |.-----.|  |.-----.",
            @"       |  |  |  ||  _  |  __||    < |       |       ||  _  ||  ||  -__|",
            @"       |________||___._|____||__|__||___|___|__|_|__||_____||__||_____|",
        };
            foreach (string line in wackAMoleHeader) Console.WriteLine(line);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine();
            Console.WriteLine(Board);

            //
            //starts time limit
            //
            DateTime start = DateTime.Now;
            //int scoreTwo = 0;
            //Random random = new Random();
            //int moleLocation = random.Next(1,10);
            Console.CursorVisible = false;

            //
            //After time start, loop renders mole on board. Thereafter, switch and case block determines numpad and console number key presses
            //and triggers a position for each in a later case block. 
            //
            while (DateTime.Now - start < playTime)
            {
                var (left, top) = Map(moleLocation);
                Console.SetCursorPosition(left, top);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Render(Mole);
                Console.ForegroundColor = ConsoleColor.Blue;
                int selection;
            GetInput:
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D1: case ConsoleKey.NumPad1: selection = 1; break;
                    case ConsoleKey.D2: case ConsoleKey.NumPad2: selection = 2; break;
                    case ConsoleKey.D3: case ConsoleKey.NumPad3: selection = 3; break;
                    case ConsoleKey.D4: case ConsoleKey.NumPad4: selection = 4; break;
                    case ConsoleKey.D5: case ConsoleKey.NumPad5: selection = 5; break;
                    case ConsoleKey.D6: case ConsoleKey.NumPad6: selection = 6; break;
                    case ConsoleKey.D7: case ConsoleKey.NumPad7: selection = 7; break;
                    case ConsoleKey.D8: case ConsoleKey.NumPad8: selection = 8; break;
                    case ConsoleKey.D9: case ConsoleKey.NumPad9: selection = 9; break;

                    default: goto GetInput;
                }

                //
                //Once the correct key is entered, this section adds to the score, and renders the dead mole, followed by 
                //the empty mole to clear the space. 
                //
                if (moleLocation == selection)
                {
                    scoreTwo++;
                    Console.SetCursorPosition(left, top);
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Render(DeadMole);
                    System.Threading.Thread.Sleep(200);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.SetCursorPosition(left, top);
                    Render(Empty);
                    moleLocation = random.Next(1, 10);
                }
            }

            Console.CursorVisible = true;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            var wackAMoleHeaderTwo = new[]
                {
            @"        ________              __     _______ _______         __        ",
            @"       |  |  |  |.---.-.----.|  |--.|   _   |   |   |.-----.|  |.-----.",
            @"       |  |  |  ||  _  |  __||    < |       |       ||  _  ||  ||  -__|",
            @"       |________||___._|____||__|__||___|___|__|_|__||_____||__||_____|",
        };
            foreach (string line in wackAMoleHeaderTwo) Console.WriteLine(line);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine();
            Console.WriteLine(Board);
            Console.WriteLine();
            Console.WriteLine("Game Over. Score: " + scoreTwo);

            //
            //Displays player won screen and the key needed to proceed in the main menu.
            //
            if (scoreTwo >= 15)
            {
                Console.Clear();
                Console.WriteLine("\n\t\tPlayer WON!");
                Console.ForegroundColor = ConsoleColor.Yellow;
                var rockPaperScissorsHeaderTwo = new[]
              {
                         @"     _____________          ",
                         @"    /      _      \         ",
                         @"    [] :: (_) :: []         ",
                         @"    [] ::::::::: []         ",
                         @"    [] ::::OF::::[]         ",
                         @"    [] ::::::::: []         ",
                         @"    [] ::::::::: []         ",
                         @"    [_____________]         ",
                         @"          I I               ",
                         @"         I_ _I              ",
                         @"         /   \              ",
                         @"         \   /              ",
                         @"         (   )              ",
                         @"         /   \              ",
                         @"         \___/              ",
   };
                foreach (string line in rockPaperScissorsHeaderTwo) Console.WriteLine(line);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\n\tKEY TWO IS: OF");
            }
            DisplayContinuePrompt();

            return scoreTwo;
        }


        /// <summary>
        /// Sets a position on the mole board for each key that was called earlier. 
        /// </summary>
        /// 
        static (int Left, int Top) Map(int hole)
        {
            switch (hole)
            {
                case 1:
                    return (9, 7);
                case 2:
                    return (32, 7);
                case 3:
                    return (54, 7);
                case 4:
                    return (09, 17);
                case 5:
                    return (32, 17);
                case 6:
                    return (54, 17);
                case 7:
                    return (09, 27);
                case 8:
                    return (32, 27);
                case 9:
                    return (54, 27);

                default:
                    return (30, 0);
            }

        }

        /// <summary>
        /// sets position of cursor x and y cords
        /// </summary>
        /// 
        static void Render(string @string)
        {
            int x = Console.CursorLeft;
            int y = Console.CursorTop;
            foreach (char c in @string)
            {
                if (c is '\n')
                {
                    Console.SetCursorPosition(x, ++y);
                }
                else
                {
                    Console.Write(c);
                }
            }
        }

        #endregion

        #region Snake Game
        /// <summary>
        /// #===========================================#
        /// #        Arcade Snake Welcome Screen        #
        /// #===========================================#
        /// </summary>
        /// 
        static void ArcadeSnakeWelcomeScreen()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            var headerText = new[]
{
               @"                                                             ",
               @"                           _________   ____ __  _   ___      ",
               @"                          / ___/    \ /    |  |/ ] /  _]     ",
               @"                         (   \_|  _  |  o  |  ' / /  [_      ",
               @"           /^\/^\         \__  |  |  |     |    \|    _]     ",
               @"         _|__|  O|        /  \ |  |  |  _  |     \   [_      ",
               @" \/     /~     \_/ \      \    |  |  |  |  |  .  |     |     ",
               @"  \____|__________/  \     \___|__|__|__|__|__|\_|_____|     ",
               @"        \_______      \                                ",
               @"                `\     \                 \             ",
               @"                  |     |                  \           ",
               @"                /      /                    \          ",
               @"               /     /                       \\        ",
               @"            /      /                         \ \       ",
               @"           /     /                            \  \     ",
               @"         /     /             _----_            \   \   ",
               @"        /     /           _-~      ~-_         |   |   ",
               @"       (      (        _-~    _--_    ~-_     _/   |   ",
               @"        \      ~-____-~    _-~    ~-_    ~-_-~    /    ",
               @"         ~-_           _-~          ~-_       _-~      ",
               @"              ~--______-~                ~-___-~       ",


            };
            Console.WindowWidth = 140;
            Console.WindowHeight = 30;
            Console.WriteLine("\n");
            foreach (string line in headerText) Console.WriteLine(line);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\t\tSnake Game Instructions\n");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("\t The ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("UP");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(" | ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Down");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(" | ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Left");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(" | ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Right");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(" Keys will control the snake. Your goal is to eat the bait!\n");

            DisplayContinuePrompt();


            SetTheme();
        }
        /// <summary>
        /// #==================================#
        /// #        Arcade Snake Game         #
        /// #==================================#
        /// </summary>
        /// 
        static int ArcadeSnake()
        {

            ArcadeSnakeWelcomeScreen();

            //
            //Sets Snake game border parameters via console window size
            //
            Console.Clear();
            Console.WindowHeight = 16;
            Console.WindowWidth = 32;
            int snakeBorderWidth = Console.WindowWidth;
            int snakeBorderHeight = Console.WindowHeight;

            //
            //random variable generates snake head positioning
            //
            Random snakeHeadRandom = new Random();

            int score = 5;
            var gameover = false;

            //
            //Defines starting position of snakehead and bait. Determines color of both and adds random modifier to affect bait spawn.
            //
            var snakeHead = new SnakeHead(Console.WindowWidth / 2, Console.WindowHeight / 2, ConsoleColor.Red);
            var snakeBait = new SnakeHead(snakeHeadRandom.Next(1, Console.WindowWidth - 2), snakeHeadRandom.Next(1, Console.WindowHeight - 2), ConsoleColor.DarkYellow);
            var snakeBody = new List<SnakeHead>();
            var currentMovement = SnakeDirection.Right;

            DrawBorder(snakeBorderWidth, snakeBorderHeight);
            //
            //loop drives snake on board while tracking x and ypos - scores border hits and bait hits. 
            //border hits earn a gameover
            //
            while (true)
            {
                ClearConsole(snakeBorderWidth, snakeBorderHeight);

                gameover |= (snakeHead.XPos == Console.WindowWidth - 1 || snakeHead.XPos == 0 || snakeHead.YPos == Console.WindowHeight - 1 || snakeHead.YPos == 0);

                if (snakeBait.XPos == snakeHead.XPos && snakeBait.YPos == snakeHead.YPos)
                {
                    score++;
                    snakeBait = new SnakeHead(snakeHeadRandom.Next(1, Console.WindowWidth - 2), snakeHeadRandom.Next(1, Console.WindowHeight - 2), ConsoleColor.Cyan);
                }

                for (int i = 0; i < snakeBody.Count; i++)
                {
                    DrawPixel(snakeBody[i]);
                    gameover |= (snakeBody[i].XPos == snakeHead.XPos && snakeBody[i].YPos == snakeHead.YPos);
                }

                if (gameover)
                {
                    break;
                }
                Console.CursorVisible = false;

                DrawPixel(snakeHead);
                DrawPixel(snakeBait);

                var sw = Stopwatch.StartNew();
                while (sw.ElapsedMilliseconds <= 200)
                {
                    currentMovement = ReadMovement(currentMovement);
                }

                snakeBody.Add(new SnakeHead(snakeHead.XPos, snakeHead.YPos, ConsoleColor.Green));

                switch (currentMovement)
                {
                    case SnakeDirection.Up:
                        snakeHead.YPos--;
                        break;
                    case SnakeDirection.Down:
                        snakeHead.YPos++;
                        break;
                    case SnakeDirection.Left:
                        snakeHead.XPos--;
                        break;
                    case SnakeDirection.Right:
                        snakeHead.XPos++;
                        break;
                }

                if (snakeBody.Count > score)
                {
                    snakeBody.RemoveAt(0);
                }


            }
            Console.SetCursorPosition(snakeBorderWidth / 5, snakeBorderHeight / 2);
            Console.WriteLine($"Game over, Score: {score - 5}");
            if (score - 5 >= 10)
            {
                Console.Clear();
                Console.WindowWidth = 70;
                Console.WindowHeight = 35;
                Console.ForegroundColor = ConsoleColor.Yellow;
                var rockPaperScissorsHeaderTwo = new[]
              {
                         @"     _____________          ",
                         @"    /      _      \         ",
                         @"    [] :: (_) :: []         ",
                         @"    [] ::::::::: []         ",
                         @"    [] :::END::::[]         ",
                         @"    [] ::::::::: []         ",
                         @"    [] ::::::::: []         ",
                         @"    [_____________]         ",
                         @"          I I               ",
                         @"         I_ _I              ",
                         @"         /   \              ",
                         @"         \   /              ",
                         @"         (   )              ",
                         @"         /   \              ",
                         @"         \___/              ",
   };
                foreach (string line in rockPaperScissorsHeaderTwo) Console.WriteLine(line);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\n\tWell done. KEY ONE IS: END");
                DisplayContinuePrompt();
            }
            Console.SetCursorPosition(snakeBorderWidth / 5, snakeBorderHeight / 2 + 1);
            Console.ReadKey();
            return score;


        }

        /// <summary>
        /// This method determines snake movement controls and pulls down | up | right | left from enum.
        /// </summary>
        static SnakeDirection ReadMovement(SnakeDirection movement)
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.UpArrow && movement != SnakeDirection.Down)
                {
                    movement = SnakeDirection.Up;
                }
                else if (key == ConsoleKey.DownArrow && movement != SnakeDirection.Up)
                {
                    movement = SnakeDirection.Down;
                }
                else if (key == ConsoleKey.LeftArrow && movement != SnakeDirection.Right)
                {
                    movement = SnakeDirection.Left;
                }
                else if (key == ConsoleKey.RightArrow && movement != SnakeDirection.Left)
                {
                    movement = SnakeDirection.Right;
                }
            }

            return movement;
        }

        /// <summary>
        /// Sets Game screen size and borders. 
        /// </summary>
        private static void DrawBorder(int snakeBorderWidth, int snakeBorderHeight)
        {
            var horizontalBar = string.Join("", new byte[snakeBorderWidth].Select(b => "■").ToArray());

            Console.SetCursorPosition(0, 0);
            Console.Write(horizontalBar);
            Console.SetCursorPosition(0, snakeBorderHeight - 1);
            Console.Write(horizontalBar);

            for (int i = 0; i < snakeBorderHeight; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("■");
                Console.SetCursorPosition(snakeBorderWidth - 1, i);
                Console.Write("■");
            }
        }

        /// <summary>
        ///Method that loops and turns foreground black to reduce flickering that calling Console.Clear() would induce upon every loop. 
        /// </summary>
        private static void ClearConsole(int snakeBorderWidth, int snakeBorderHeight)
        {
            var blackLine = string.Join("", new byte[snakeBorderWidth - 2].Select(b => " ").ToArray());
            Console.ForegroundColor = ConsoleColor.Black;
            for (int i = 1; i < snakeBorderHeight - 1; i++)
            {
                Console.SetCursorPosition(1, i);
                Console.Write(blackLine);
            }
        }

        /// <summary>
        ///Method that loops and keeps the background black to reduce flickering that calling Console.Clear() would induce upon every loop of snake movement with direction key. 
        /// </summary>
        static void DrawPixel(SnakeHead snake)
        {
            Console.SetCursorPosition(snake.XPos, snake.YPos);
            Console.ForegroundColor = snake.ScreenColor;
            Console.Write("■");
            Console.SetCursorPosition(0, 0);
        }


        /// <summary>
        /// Sets Game screen size and borders. 
        /// </summary>
        class SnakeHead
        {
            public SnakeHead(int xPos, int yPos, ConsoleColor color)
            {
                XPos = xPos;
                YPos = yPos;
                ScreenColor = color;
            }
            public int XPos { get; set; }
            public int YPos { get; set; }
            public ConsoleColor ScreenColor { get; set; }
        }
        #endregion

        #region Arcade Interface 

        /// <summary>
        /// #=====================================#
        /// #          Welcome Screen             #
        /// #=====================================#
        /// </summary>
        /// 
        static void DisplayFirstBootUp()
        {
            Console.CursorVisible = false;

            Console.WriteLine();
            Console.Clear();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            var headerText = new[]
{

       @"             @@@@@@@@@@@@@@@@@@@@&             ",
       @"    @@@@@@@@% (*******************&            ",
       @"   @@@@@@@@@@@%#*******************@,          ",
       @"   @@@@@@@@@@@&@*******************@#          ",
       @"   @@@@@@@@@@@/ ..,,*/#@@@@@@@@@@@@@@@         ",
       @"   @@@@@@@@@@@.................%@%             ",
       @"   @@@@@@@@@&................@@@/              ",
       @"   @@@@@@@@@@&%%%%%%%%%%%%&@@(@&               ",
       @"   @@@@@@@@@@@%%%%%%%%%%%%%% &.@&          An arcade machine partly covered with an old cloth work tarp and  ",
       @"   @@@@@@@@@@@@%%%%%%%%%%%%%%@(@@*         a layer of dust stands before you.   ",
       @"   @@@@@@@@@@@@%%%%%%%%%%%%%% &@(@              ",
       @"   @@@@@@@@@@@@&%%%%%%%%%%%%%@@.@@@             ",
       @"   @@@@@@@@@@@@.................@@@@       You see a faint light glowing behind the cound slot and decide to insert a quarter. ",
       @"   @@@@@@@@@@@@@..(/ .........(@@(@@            ",
       @"   @@@@@@@@@@@@@@,..@&............,@            ",
       @"   @@@@@@@@@@@@@@@@%%%%%%%%%%%%%%%%%%           ",
       @"   @@@@@@@@@@@@@@@@%%%%%%%%%@&@@@@@*            ",
       @"   @@@@@@@@@@@@@@....*&%@@@&&...&&              ",
       @"   @@@@@@@@@@@@@@....(%@&@@&)...&&              ",
       @"   @@@@@@@@@@@@@@....(%@  &&)...&&              ",
       @"   @@@@@@@@@@@@@@....(%%%@@@)...&&              ",
       @"   @@@@@@@@@@@@@@...............&&              ",
       @"   @@@@@@@@@@@@@@***************&&              ",
       @"   @@@@@@@@@@@@@@***************&&              ",
       @"   @@@@@@@@@@@@@@***************%@              ",
       @"   @@@@@@@@@@@@@@***************%@              ",
       @"   %@@@@@ @@@@@@@@@@@@@@@@@@@@@@@@              ",

                 };
            Console.WindowWidth = 140;
            Console.WindowHeight = 35;
            Console.WriteLine("\n\n");
            foreach (string line in headerText) Console.WriteLine(line);

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.Green;
        }

        static void DisplayWelcomeScreen()
        {
            Console.CursorVisible = false;

            Console.Clear();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\t\tWelcome to the arcade user interface.");
            Console.WriteLine();

            DisplayContinuePrompt();
        }



        /// <summary>
        /// Display continue prompt
        /// </summary>
        static void DisplayContinuePrompt()
        {
            Console.WriteLine();
            Console.WriteLine("\tPress any key to continue.");
            Console.ReadKey();
        }

        /// <summary>
        /// display progress bar animation upon running program
        /// </summary>
        /// 
        private static void BootUpBar()
        {
            //Parallel.Invoke(BootUpBarMole, BootUpBar);
            Console.Clear();
            Console.CursorVisible = false;
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\t\tBoot Up Sequence Initiating...");
            Console.SetCursorPosition(3, 3);
            Console.ForegroundColor = ConsoleColor.DarkYellow;

            for (int i = 0; i <= 60; i++)
            {
                for (int y = 0; y < i; y++)
                {
                    Console.Write("█");

                }
                Console.WriteLine(i + "/60");
                Console.SetCursorPosition(3, 3);
                System.Threading.Thread.Sleep(100);
            }
            System.Threading.Thread.Sleep(300);
        }

        /// <summary>
        /// display progress bar animation upon running program
        /// </summary>
        /// 
        private static void BootUpBarMole()
        {
            Console.Clear();
            Console.CursorVisible = false;
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(6, 5);
            Console.WriteLine("TIMER");
            Console.SetCursorPosition(6, 6);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            for (int i = 0; i <= 30; i++)
            {
                for (int y = 0; y < i; y++)
                {
                    Console.Write("");

                }
                Console.WriteLine(i + "/30");
                Console.SetCursorPosition(6, 6);
                System.Threading.Thread.Sleep(1000);
            }
            System.Threading.Thread.Sleep(300);
        }

        /// <summary>
        /// display ASCII Art Arcade Bar Header 
        /// foreach loop that writes the headertext string array
        /// </summary>
        static void DisplayArcadeMenuHeader()
        {
            Console.Clear();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            var headerText = new[]
{
                    @"      ███████╗██╗  ██╗   ██╗███╗   ██╗███╗   ██╗███████╗     █████╗ ██████╗  ██████╗ █████╗ ██████╗ ███████╗    ",
                    @"      ██╔════╝██║  ╚██╗ ██╔╝████╗  ██║████╗  ██║██╔════╝    ██╔══██╗██╔══██╗██╔════╝██╔══██╗██╔══██╗██╔════╝    ",
                    @"      █████╗  ██║   ╚████╔╝ ██╔██╗ ██║██╔██╗ ██║███████╗    ███████║██████╔╝██║     ███████║██║  ██║█████╗      ",
                    @"      ██╔══╝  ██║    ╚██╔╝  ██║╚██╗██║██║╚██╗██║╚════██║    ██╔══██║██╔══██╗██║     ██╔══██║██║  ██║██╔══╝      ",
                    @"      ██║     ███████╗██║   ██║ ╚████║██║ ╚████║███████║    ██║  ██║██║  ██║╚██████╗██║  ██║██████╔╝███████╗    ",
                    @"      ╚═╝     ╚══════╝╚═╝   ╚═╝  ╚═══╝╚═╝  ╚═══╝╚══════╝    ╚═╝  ╚═╝╚═╝  ╚═╝ ╚═════╝╚═╝  ╚═╝╚═════╝ ╚══════╝    ",


            };
            Console.WindowWidth = 140;
            Console.WindowHeight = 30;
            Console.WriteLine("\n\n");
            foreach (string line in headerText) Console.WriteLine(line);

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
        }


        #endregion
    }
}
