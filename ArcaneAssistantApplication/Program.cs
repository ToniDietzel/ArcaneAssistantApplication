// Arcane Assistant - Console Application
// Developed with .NET Framework 4.8 in Visual Studio 2022

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace ArcaneAssistant
{
    #region Data Models

    /// <summary>
    /// Represents a deity with name, epithet, and alignment.
    /// </summary>
    public class Deity
    {
        public string Name { get; set; }
        public string Epithet { get; set; }
        public string Alignment { get; set; }

        public Deity(string name, string epithet, string alignment)
        {
            Name = name;
            Epithet = epithet;
            Alignment = alignment;
        }
    }

    /// <summary>
    /// Represents an ancestry with name, rarity, and origin.
    /// </summary>
    public class Ancestry
    {
        public string Name { get; set; }
        public string Rarity { get; set; }
        public string Origin { get; set; }

        public Ancestry(string name, string rarity, string origin)
        {
            Name = name;
            Rarity = rarity;
            Origin = origin;
        }
    }

    /// <summary>
    /// Represents a profession with salary class, bonus, and lore bonus.
    /// </summary>
    public class Profession
    {
        public string Name { get; set; }
        public string SalaryClass { get; set; }
        public string Bonus { get; set; }
        public string LoreBonus { get; set; }

        public Profession(string name, string salaryClass, string bonus, string loreBonus)
        {
            Name = name;
            SalaryClass = salaryClass;
            Bonus = bonus;
            LoreBonus = loreBonus;
        }
    }

    /// <summary>
    /// Represents a full character for saving/loading
    /// </summary>
    public class Character
    {
        public string Name { get; set; }
        public string Ancestry { get; set; }
        public string AncestryOrigin { get; set; }
        public string AncestryRarity { get; set; }
        public string Class { get; set; }
        public string Deity { get; set; }
        public string DeityEpithet { get; set; }
        public string Alignment { get; set; }
        public string Motivation { get; set; }
        public string Talent { get; set; }
        public string Flaw { get; set; }
        public string Heritage { get; set; }
        public int Age { get; set; }
        public string Profession { get; set; }
        public string ProfessionSalaryClass { get; set; }
        public string ProfessionBonus { get; set; }
        public string ProfessionLoreBonus { get; set; }
        public int ProfessionExperience { get; set; }
    }

    #endregion

    #region Databases

    /// <summary>
    /// Database for deities
    /// </summary>
    public class DeityDatabase
    {
        public List<Deity> Deities { get; }

        public DeityDatabase()
        {
            Deities = new List<Deity>
            {
                new Deity("Abadar", "Master of the First Vault", "Lawful Neutral"),
                new Deity("Asmodeus", "Prince of Darkness", "Lawful Evil"),
                new Deity("Calistria", "Savored Sting", "Chaotic Neutral"),
                new Deity("Cayden Cailean", "Accidental God", "Chaotic Good"),
                new Deity("Desna", "Song of the Spheres", "Chaotic Good"),
                new Deity("Erastil", "Old Deadeye", "Lawful Good"),
                new Deity("Gorum", "Lord In Iron", "Chaotic Neutral"),
                new Deity("Gozreh", "Wind and the Waves", "Neutral"),
                new Deity("Iomedae", "Inheritor", "Lawful Good"),
                new Deity("Irori", "Master of Masters", "Lawful Neutral"),
                new Deity("Lamashtu", "Mother of Monsters", "Chaotic Evil"),
                new Deity("Nethys", "All-Seeing Eye", "Neutral"),
                new Deity("Norgorber", "Blackfingers", "Neutral Evil"),
                new Deity("Pharasma", "Lady of Graves", "Neutral"),
                new Deity("Rovagug", "Rough Beast", "Chaotic Evil"),
                new Deity("Sarenrae", "Dawnflower", "Neutral Good"),
                new Deity("Shelyn", "Eternal Rose", "Neutral Good"),
                new Deity("Torag", "Father of Creation", "Lawful Good"),
                new Deity("Urgathoa", "Pallid Princess", "Neutral Evil"),
                new Deity("Zon-Kuthon", "Midnight Lord", "Lawful Evil")
            };
        }
    }

    /// <summary>               //
    /// Database for ancestries //
    /// </summary>              //
    public class AncestryDatabase
    {
        public List<Ancestry> Ancestries { get; }

        public AncestryDatabase()
        {
            Ancestries = new List<Ancestry>
            {
                new Ancestry("Dwarf", "Common", "the Five Kings Mountains"),
                new Ancestry("Elf", "Common", "Kyonin"),
                new Ancestry("Gnome", "Common", "Sarkoris"),
                new Ancestry("Goblin", "Common", "Varisia"),
                new Ancestry("Halfling", "Common", "Andoran"),
                new Ancestry("Human", "Common", "Various"),
                new Ancestry("Leshy", "Common", "Mwangi Expanse"),
                new Ancestry("Orc", "Common", "Belkzen"),
                new Ancestry("Anadi", "Rare", "Mwangi Expanse"),
                new Ancestry("Android", "Rare", "Numeria"),
                new Ancestry("Automaton", "Rare", "Jistka Imperium"),
                new Ancestry("Azarketi", "Uncommon", "the Inner Sea"),
                new Ancestry("Catfolk", "Uncommon", "Southern Garund"),
                new Ancestry("Centaur", "Rare", "Iobaria"),
                new Ancestry("Conrasu", "Rare", "Mwangi Expanse"),
                new Ancestry("Fetchling", "Uncommon", "Shadow Plane"),
                new Ancestry("Fleshwarp", "Rare", "Numeria"),
                new Ancestry("Ghoran", "Rare", "Verduran Forest"),
                new Ancestry("Gnoll", "Uncommon", "Katapesh"),
                new Ancestry("Goloma", "Rare", "Mwangi Expanse"),
                new Ancestry("Grippli", "Uncommon", "Mwangi Expanse"),
                new Ancestry("Hobgoblin", "Uncommon", "Isger"),
                new Ancestry("Kashrishi", "Rare", "Tian Xia"),
                new Ancestry("Kitsune", "Uncommon", "Tian Xia"),
                new Ancestry("Kobold", "Common", "Mines of Druma"),
                new Ancestry("Lizardfolk", "Uncommon", "Mwangi Expanse"),
                new Ancestry("Merfolk", "Rare", "Arcadian Ocean"),
                new Ancestry("Minotaur", "Rare", "Iobaria"),
                new Ancestry("Nagaji", "Uncommon", "Nagajor"),
                new Ancestry("Poppet", "Rare", "an unknown place"),
                new Ancestry("Ratfolk", "Uncommon", "Numeria"),
                new Ancestry("Samsaran", "Rare", "Tian Xia"),
                new Ancestry("Shisk", "Rare", "Mwangi Expanse"),
                new Ancestry("Shoony", "Rare", "Isle of Kortos"),
                new Ancestry("Skeleton", "Rare", "Geb"),
                new Ancestry("Sprite", "Rare", "the Feywild"),
                new Ancestry("Strix", "Rare", "Ravounel"),
                new Ancestry("Tengu", "Uncommon", "Tian Xia"),
                new Ancestry("Vanara", "Uncommon", "Valashmai Jungle"),
                new Ancestry("Vishkanya", "Rare", "Vudra"),
                new Ancestry("Wayang", "Rare", "the Shadow Plane"),
                new Ancestry("Yaksha", "Rare", "Tian Xia"),
                new Ancestry("Yaoguai", "Rare", "Tian Xia")
            };
        }
    }

    /// <summary>
    /// Database for professions.
    /// </summary>
    public class ProfessionDatabase
    {
        public List<Profession> Professions { get; }

        public ProfessionDatabase()
        {
            Professions = new List<Profession>
            {
                new Profession("Street Performer", "lowPaying", "Performance +1", "Lore: Local"),
                new Profession("Chimney Sweep", "lowPaying", "Athletics +1", "Lore: Urban"),
                new Profession("Beggar", "lowPaying", "Deception +1", "Lore: Streets"),
                new Profession("Stable Hand", "lowPaying", "Nature +1", "Lore: Animals"),
                new Profession("Rat Catcher", "lowPaying", "Stealth +1", "Lore: Sewers"),
                new Profession("Dishwasher", "lowPaying", "Constitution +1", "Lore: Kitchens"),
                new Profession("Farm Laborer", "lowPaying", "Athletics +1", "Lore: Agriculture"),
                new Profession("Gravedigger", "lowPaying", "Religion +1", "Lore: Burial Rites"),
                new Profession("Lantern Bearer", "lowPaying", "Perception +1", "Lore: Underdark"),
                new Profession("Tanner", "lowPaying", "Crafting +1", "Lore: Leatherworking"),
                new Profession("Blacksmith", "averagePaying", "Crafting +1", "Lore: Blacksmithing"),
                new Profession("Merchant", "averagePaying", "Diplomacy +1", "Lore: Mercantile"),
                new Profession("Carpenter", "averagePaying", "Crafting +1", "Lore: Woodworking"),
                new Profession("Herbalist", "averagePaying", "Medicine +1", "Lore: Herbs"),
                new Profession("Guard", "averagePaying", "Intimidation +1", "Lore: Law"),
                new Profession("Cook", "averagePaying", "Crafting +1", "Lore: Culinary"),
                new Profession("Innkeeper", "averagePaying", "Society +1", "Lore: Hospitality"),
                new Profession("Fletcher", "averagePaying", "Crafting +1", "Lore: Archery"),
                new Profession("Miner", "averagePaying", "Survival +1", "Lore: Stonework"),
                new Profession("Sailor", "averagePaying", "Athletics +1", "Lore: Sailing"),
                new Profession("Alchemist", "highPaying", "Crafting +1", "Lore: Alchemy"),
                new Profession("Scholar", "highPaying", "Occultism +1", "Lore: Academia"),
                new Profession("Navigator", "highPaying", "Survival +1", "Lore: Geography"),
                new Profession("Engineer", "highPaying", "Crafting +1", "Lore: Engineering"),
                new Profession("Scribe", "highPaying", "Society +1", "Lore: Legal"),
                new Profession("Artificer", "highPaying", "Arcana +1", "Lore: Constructs"),
                new Profession("Magical Researcher", "highPaying", "Arcana +1", "Lore: Arcane"),
                new Profession("Diplomat", "highPaying", "Diplomacy +1", "Lore: Politics"),
                new Profession("Treasure Appraiser", "highPaying", "Thievery +1", "Lore: Appraisal"),
                new Profession("Court Bard", "highPaying", "Performance +1", "Lore: Nobility")
            };
        }
    }

    #endregion

    internal class Program
    {
        #region Win32 API for Fullscreen

        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        private const int SW_MAXIMIZE = 3;

        #endregion

        #region Static Fields

        private static readonly string[] DiceTypes = { "D4", "D6", "D8", "D10", "D12", "D20" };
        private static readonly List<string> Jokes = new List<string>();
        private static readonly string DataDirectory = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "ArcaneAssistant");
        private static readonly string UserDataFile = Path.Combine(DataDirectory, "user.txt");
        private static string userName = "Traveller";

        private static readonly DeityDatabase deityDatabase = new DeityDatabase();
        private static readonly AncestryDatabase ancestryDatabase = new AncestryDatabase();
        private static readonly ProfessionDatabase professionDatabase = new ProfessionDatabase();

        // Character save system
        private static readonly string CharacterSaveFile = Path.Combine(DataDirectory, "savedcharacters.txt");
        private static Character lastGeneratedCharacter = null;
        private const int MaxCharacterSlots = 9;

        #endregion

        #region Main Entry

        static void Main(string[] args)
        {
            Directory.CreateDirectory(DataDirectory);
            IntPtr handle = GetConsoleWindow();
            ShowWindow(handle, SW_MAXIMIZE);
            InitializeJokes();
            LoadOrCreateUserName();
            ShowMainMenu(true);
        }

        #endregion

        #region Utility Methods

        #endregion

        #region UI Methods

        private static void WizardPortrait()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("                                                                                                                ____                                     *                                           ");
            Console.WriteLine("         *                                  *                  ~         °        *                           .'* *.'                   *                                *        °          *       ");
            Console.WriteLine("              *                                                                                            __/_*_*(_                              ~                                                  ");
            Console.WriteLine("                                                                                                          / _______ \\                                                               ~        *      ");
            Console.WriteLine("                                              °         *        ~                        *              _\\_)/_ _\\(_/_       *                           *                °                        ");
            Console.WriteLine("                     *                                                                                  / _(( 0 0 ))_ \\                         °                                                   ");
            Console.WriteLine("                                                                                          ~             \\ \\()) - (()/ /                                                              *             ");
            Console.WriteLine("                                                                           *                             ' \\(((()))/ '                                   ~      *                                   ");
            Console.WriteLine("                                  *     ~                      *                                        / ' \\)).))/ ' \\                 *                                                          ");
            Console.WriteLine("                                                                                                      / _ \\ - | - /_  \\                                                      *                     ");
            Console.WriteLine("                                                 *                    ~        °                      (   ( .;''';. .'  )                                                                            ");
            Console.WriteLine("                                                                                       *             _\\'__  /     \\ __'/_                         *            °                    ~              ");
            Console.WriteLine("                      *                                     °                                           \\/  \\   ' /  \\/              ~                              *               °             ");
            Console.WriteLine("                                           °                                                             .'  '...' ' )                                                                               ");
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("                                                     ('-.    _  .-')            ('-.        .-') _  ('-.           ('-.     .-')    .-')            .-')   .-') _     ('-.        .-') _ .-')");
            Console.WriteLine("                                         ( OO ).-( \\( -O )          ( OO ).-.   ( OO ) _(  OO)         ( OO ).-.( OO ). ( OO ).         ( OO ).(  OO) )   ( OO ).-.   ( OO ) (  OO) )");
            Console.WriteLine("                                          / . --. /,------.  .-----. / . --. ,--./ ,--,(,------.        / . --. (_)---\\_(_)---\\_) ,-.-')(_)---\\_/     '._  / . --. ,--./ ,--,'/     '._  ");
            Console.WriteLine("                                          | \\-.  \\ |   /`. ''  .--./ | \\-.  \\|   \\ |  |\\|  .---'        | \\-.  \\/    _ |/    _ |  |  |OO/    _ ||'--...__) | \\-.  \\|   \\ |  |\\|'--...__) ");
            Console.WriteLine("                                        .-'-'  |  ||  /  | ||  |('-.-'-'  |  |    \\|  | |  |          .-'-'  |  \\  :` `.\\  :` `.  |  |  \\  :` `.'--.  .--.-'-'  |  |    \\|  | '--.  .--' ");
            Console.WriteLine("                                         \\| |_.'  ||  |_.' /_) |OO  \\| |_.'  |  .     |(|  '--.        \\| |_.'  |'..`''.)'..`''.) |  |(_/'..`''.)  |  |   \\| |_.'  |  .     |/   |  |    ");
            Console.WriteLine("                                          |  .-.  ||  .  '.||  |`-'| |  .-.  |  |\\    | |  .--'         |  .-.  .-._)   .-._)   \\,|  |_..-._)   \\  |  |    |  .-.  |  |\\    |    |  |    ");
            Console.WriteLine("                                          |  | |  ||  |\\  (_'  '--'\\ |  | |  |  | \\   | |  `---.        |  | |  \\       \\       (_|  |  \\       /  |  |    |  | |  |  | \\   |    |  |  ");
            Console.WriteLine("                                          `--' `--'`--' '--' `-----' `--' `--`--'  `--' `------'        `--' `--'`-----' `-----'  `--'   `-----'   `--'    `--' `--`--'  `--'    `--'  ");
            Console.WriteLine("\n\n\n");
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void DialogueFrameTop()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n                                                                 *~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"\n                                                                  [Arcane Assistant]:");
        }

        private static void DialogueFrameBottom()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n                                                                 *~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*");
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void InvalidInput()
        {
            Console.Clear();
            WizardPortrait();
            DialogueFrameTop();
            Console.WriteLine("\n                                                                   That path is unknown. Try again.");
            Console.WriteLine("\n\n\n");
            DialogueFrameBottom();
            Console.WriteLine("\n\n\n");
            Console.WriteLine("\n                                                                 (Press any key to continue...)");
            Console.ReadKey();
            ShowMainMenu(false);
        }

        #endregion

        #region User Management

        private static void LoadOrCreateUserName()
        {
            if (File.Exists(UserDataFile))
            {
                userName = File.ReadAllText(UserDataFile);
            }
            else
            {
                Console.Clear();
                WizardPortrait();
                DialogueFrameTop();
                Console.WriteLine("\n                                                                   Greetings, noble traveller and welcome to my realm of knowledge!");
                Console.WriteLine("\n                                                                   Before you stands the Arcane Assistant, the guardian of fate.");
                Console.WriteLine("\n                                                                   By which name shall thy call you?");
                Console.WriteLine("\n\n");
                DialogueFrameBottom();

                while (true)
                {
                    Console.Write("\n                                                                 Thy name is: ");
                    string input = Console.ReadLine();

                    if (IsValidUserName(input))
                    {
                        userName = input;
                        File.WriteAllText(UserDataFile, userName);

                        Console.Clear();
                        WizardPortrait();
                        DialogueFrameTop();
                        Console.WriteLine($"\n                                                                   Ah, {userName}, a name of power indeed!");
                        Console.WriteLine("\n\n\n");
                        DialogueFrameBottom();
                        Console.WriteLine("\n\n\n");
                        Console.WriteLine("\n                                                                 Press any key to continue...");
                        Console.ReadKey();
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        WizardPortrait();
                        DialogueFrameTop();
                        Console.WriteLine("\n                                                                   Hmm... Such a name confounds even my ancient wisdom.");
                        Console.WriteLine("\n                                                              (Only letters, up to 2 spaces allowed, and a maximum length of 20 characters.)");
                        DialogueFrameBottom();
                    }
                }
            }
        }

        private static bool IsValidUserName(string input)
        {
            if (string.IsNullOrWhiteSpace(input) || input.Length > 20)
                return false;

            int spaceCount = input.Count(c => c == ' ');
            if (spaceCount > 2)
                return false;

            return input.All(c => char.IsLetter(c) || c == ' ');
        }

        #endregion

        #region Menu Methods

        private static void ShowMainMenu(bool isFirstTime)
        {
            if (isFirstTime)
            {
                Console.Clear();
                WizardPortrait();
                DialogueFrameTop();
                Console.WriteLine($"\n                                                                   Greetings, {userName}. What shall we conjure today?");
                Console.WriteLine("\n\n\n");
                DialogueFrameBottom();
                Console.WriteLine("\n\n\n");
            }
            else
            {
                Console.Clear();
                WizardPortrait();
                DialogueFrameTop();
                Console.WriteLine($"\n                                                                   Back so soon, {userName}? Let us explore other paths.");
                Console.WriteLine("\n\n\n");
                DialogueFrameBottom();
                Console.WriteLine("\n\n\n");
            }
            Console.WriteLine("\n                                                                 [1] I would like to let fate decide and roll the dice of mysticism. (Roll Dice)");
            Console.WriteLine("                                                                 [2] I want you to open the Book of Summoning. (Open Character Menu)");
            Console.WriteLine("                                                                 [3] I would like to hear a joke. (Jokes)");
            Console.WriteLine("                                                                 [9] Tell me, who conjured this you? (Credits)");
            Console.WriteLine("                                                                 [0] I want to leave this realm. (Exit)");
            Console.WriteLine("\n\n\n");
            Console.Write("\n                                                                 Thy response: ");

            switch (Console.ReadLine())
            {
                case "1": ShowDiceMenu(); break;
                case "2": ShowCharacterMenu(); break;
                case "3": TellJoke(); break;
                case "9": ShowCredits(); break;
                case "0": CloseApp(); break;
                default:
                    InvalidInput();
                    break;
            }
        }

        private static void ShowDiceMenu()
        {
            Console.Clear();
            WizardPortrait();
            DialogueFrameTop();
            Console.WriteLine($"\n                                                                   Choose thy dice, {userName}:");
            Console.WriteLine("\n\n\n");
            DialogueFrameBottom();
            Console.WriteLine("\n\n\n");
            for (int i = 0; i < DiceTypes.Length; i++)
            {
                Console.WriteLine($"                                                                 [{i + 1}] {DiceTypes[i]}");
            }
            Console.WriteLine("                                                                 [0] Go Back");
            Console.Write("\n                                                                 Thy choice: ");

            if (int.TryParse(Console.ReadLine(), out int diceChoice) && diceChoice >= 0 && diceChoice <= DiceTypes.Length)
            {
                if (diceChoice == 0)
                {
                    ShowMainMenu(false);
                    return;
                }

                int diceSides = int.Parse(DiceTypes[diceChoice - 1].Substring(1));

                Console.Clear();
                WizardPortrait();
                DialogueFrameTop();
                Console.WriteLine($"\n                                                                   How many D{diceSides} dice dost thou wish to roll?");
                Console.WriteLine("\n\n\n");
                DialogueFrameBottom();
                Console.WriteLine("\n\n\n");
                Console.Write("\n                                                                 Thy choice: ");

                if (int.TryParse(Console.ReadLine(), out int count) && count > 0)
                {
                    RollDice(diceSides, count);
                }
                else
                {
                    Console.Clear();
                    WizardPortrait();
                    DialogueFrameTop();
                    Console.WriteLine($"\n                                                                   Numbers, dear {userName}, not riddles!");
                    Console.WriteLine("\n\n\n");
                    DialogueFrameBottom();
                    Console.WriteLine("\n\n\n");
                    Console.WriteLine("\n                                                                 (Press any key to continue...)");
                    Console.ReadKey();
                    ShowDiceMenu();
                }
            }
            else
            {
                InvalidInput();
            }
        }

        private static void RollDice(int sides, int count)
        {
            Random rnd = new Random();
            int total = 0;
            for (int i = 0; i < count; i++)
            {
                total += rnd.Next(1, sides + 1);
            }

            Console.Clear();
            WizardPortrait();
            DialogueFrameTop();
            Console.WriteLine($"\n                                                                   Thy total roll of {count} D{sides} dice is... {total}!");
            Console.WriteLine("\n\n\n");
            DialogueFrameBottom();
            Console.WriteLine("\n\n\n");
            Console.WriteLine("                                                                 [1] Reroll");
            Console.WriteLine("                                                                 [0] Go Back");
            Console.WriteLine("\n\n\n");
            Console.Write("\n                                                                 Thy desire: ");

            switch (Console.ReadLine())
            {
                case "1": RollDice(sides, count); break;
                case "0": ShowDiceMenu(); break;
                default:
                    InvalidInput();
                    break;
            }
        }

        private static void TellJoke()
        {
            Console.Clear();
            Random rnd = new Random();
            string joke = Jokes[rnd.Next(Jokes.Count)];

            Console.Clear();
            WizardPortrait();
            DialogueFrameTop();
            Console.WriteLine($"\n                                                                    Behold, a jest for thee, {userName}:");
            Console.WriteLine("\n");
            Console.WriteLine($"                                                                    {joke}");
            Console.WriteLine("\n\n\n");
            DialogueFrameBottom();
            Console.WriteLine("\n\n\n");
            Console.WriteLine("\n                                                                 [1] That was funny, tell another!");
            Console.WriteLine("                                                                 [2] Not amused.");
            Console.WriteLine("                                                                 [0] Return to Main Menu");
            Console.Write("\n                                                                 Thy choice: ");

            switch (Console.ReadLine())
            {
                case "1": TellJoke(); break;
                case "2":
                    Console.Clear();
                    WizardPortrait();
                    DialogueFrameTop();
                    Console.WriteLine("\n                                                                   Thou art a tough crowd... Yet I persist!");
                    Console.WriteLine("\n\n\n");
                    DialogueFrameBottom();
                    Console.WriteLine("\n\n\n");
                    Console.WriteLine("\n                                                                 (Press any key to continue...)");
                    Console.ReadKey();
                    TellJoke();
                    break;
                case "0": ShowMainMenu(false); break;
                default:
                    InvalidInput();
                    break;
            }
        }

        private static void InitializeJokes()
        {
            for (int i = 1; i <= 20; i++)
            {
                Jokes.Add("What do you call a dragon after it eats a group of adventurers? A party pooper!");
                Jokes.Add("Who gives the best hickeys? Neck Romancers!");
                Jokes.Add("What do you call a cleric without a god? Unemployed.");
                Jokes.Add("Why should you never ask a dwarf to pay for drinks? Because he’s always a little short.");
                Jokes.Add("How do you escape from a halfling? Step on a chair.");
                Jokes.Add("Did you hear the one about the banshee? It’s a scream.");
                Jokes.Add("How many gnomes does it take to paint a house? Depends on how hard you throw them.");
                Jokes.Add("Why do elves have ears like that? There had to be some point to elves.");
                Jokes.Add("Did you hear how dwarves invented copper wire? Two of them were fighting over a coin.");
                Jokes.Add("What has 4 legs and an arm? A happy hellhound.");
                Jokes.Add("Why don’t elves wear hats? Because their noses are so high in the air, they’d keep falling off.");
            }
        }

        private static void ShowCredits()
        {
            Console.Clear();
            WizardPortrait();
            DialogueFrameTop();
            Console.WriteLine("\n");
            Console.WriteLine("                                                                 Ah, seeker of origins, you wish to peer behind the veil, do you?");
            Console.WriteLine("                                                                 Very well, let the bones of truth be unearthed...");
            Console.WriteLine("\n");
            Console.WriteLine("                                                                 Crafted by the ever-mysterious Toni Dietzel, known in some circles as Gabi.");
            Console.WriteLine("                                                                 With the guiding hand and wisdom of Sebastian Müller, the mentor, also called Pinky.");
            Console.WriteLine("                                                                 Accompanied by the beautiful melodies of \"Down by the River\" by Boris Slavov, to stir the soul.");
            Console.WriteLine("\n");
            Console.WriteLine("                                                                 Now, I hope your curiosity is sated. (Press any key...)");
            DialogueFrameBottom();
            Console.ReadKey();
            ShowMainMenu(false);
        }

        private static void CloseApp()
        {
            Console.Clear();
            WizardPortrait();
            DialogueFrameTop();
            Console.WriteLine($"\n                                                                  Farewell, {userName}.");
            Console.WriteLine("\n\n\n\n\n");
            DialogueFrameBottom();
            Console.WriteLine("\n\n\n");
            Console.WriteLine("\n                                                                 Press any key to continue...");
            Console.ReadKey();
            Environment.Exit(0);
        }

        #endregion

        #region Character Management

        private static string SerializeCharacter(Character c)
        {
            if (c == null) return "";
            return string.Join("|", new string[]
            {
                c.Name, c.Ancestry, c.AncestryOrigin, c.AncestryRarity, c.Class, c.Deity, c.DeityEpithet, c.Alignment, c.Motivation,
                c.Talent, c.Flaw, c.Heritage, c.Age.ToString(), c.Profession, c.ProfessionSalaryClass, c.ProfessionBonus, c.ProfessionLoreBonus, c.ProfessionExperience.ToString()
            });
        }

        private static Character DeserializeCharacter(string line)
        {
            if (string.IsNullOrWhiteSpace(line)) return null;
            var parts = line.Split('|');
            if (parts.Length < 18) return null;
            return new Character
            {
                Name = parts[0],
                Ancestry = parts[1],
                AncestryOrigin = parts[2],
                AncestryRarity = parts[3],
                Class = parts[4],
                Deity = parts[5],
                DeityEpithet = parts[6],
                Alignment = parts[7],
                Motivation = parts[8],
                Talent = parts[9],
                Flaw = parts[10],
                Heritage = parts[11],
                Age = int.TryParse(parts[12], out int age) ? age : 0,
                Profession = parts[13],
                ProfessionSalaryClass = parts[14],
                ProfessionBonus = parts[15],
                ProfessionLoreBonus = parts[16],
                ProfessionExperience = int.TryParse(parts[17], out int exp) ? exp : 0
            };
        }

        private static Character[] LoadCharacterSlots()
        {
            if (!File.Exists(CharacterSaveFile))
                return new Character[MaxCharacterSlots];

            var lines = File.ReadAllLines(CharacterSaveFile);
            var slots = new Character[MaxCharacterSlots];
            for (int i = 0; i < MaxCharacterSlots && i < lines.Length; i++)
                slots[i] = DeserializeCharacter(lines[i]);
            return slots;
        }

        private static void SaveCharacterSlots(Character[] slots)
        {
            var lines = new List<string>();
            for (int i = 0; i < MaxCharacterSlots; i++)
                lines.Add(slots[i] != null ? SerializeCharacter(slots[i]) : "");
            File.WriteAllLines(CharacterSaveFile, lines);
        }

        private static void PrintCharacterSlotTable(Character[] slots)
        {
            Console.Clear();
            WizardPortrait();
            DialogueFrameTop();
            Console.WriteLine("\n                                                                 +---------------+----------------------+----------------------+----------------------+");
            Console.WriteLine("                                                                 | Character Slot | Name                 | Ancestry            | Class                |");
            Console.WriteLine("                                                                 +---------------+----------------------+----------------------+----------------------+");
            for (int i = 0; i < MaxCharacterSlots; i++)
            {
                if (slots[i] == null)
                {
                    Console.WriteLine($"                                                                 | {i + 1,-13} | {"EMPTY",-20} | {"",-20} | {"",-20} |");
                }
                else
                {
                    Console.WriteLine($"                                                                 | {i + 1,-13} | {slots[i].Name,-20} | {slots[i].Ancestry,-20} | {slots[i].Class,-20} |");
                }
            }
            Console.WriteLine("                                                                 +---------------+----------------------+----------------------+----------------------+");
            DialogueFrameBottom();
        }

        private static void PrintCharacterDetails(Character c)
        {
            Console.WriteLine("\n                                                                 *~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*");
            Console.WriteLine($"                                                                 Name: {c.Name}");
            Console.WriteLine($"                                                                 Ancestry: {c.Ancestry} (Origin: {c.AncestryOrigin}, Rarity: {c.AncestryRarity})");
            Console.WriteLine($"                                                                 Class: {c.Class}");
            Console.WriteLine($"                                                                 Age: {c.Age}");
            Console.WriteLine($"                                                                 Heritage: {c.Heritage}");
            Console.WriteLine($"                                                                 Deity: {c.Deity} ({c.DeityEpithet})");
            Console.WriteLine($"                                                                 Alignment: {c.Alignment}");
            Console.WriteLine($"                                                                 Motivation: {c.Motivation}");
            Console.WriteLine($"                                                                 Talent: {c.Talent}");
            Console.WriteLine($"                                                                 Flaw: {c.Flaw}");
            Console.WriteLine($"                                                                 Profession: {c.Profession} ({c.ProfessionSalaryClass}), {c.ProfessionExperience} years");
            Console.WriteLine($"                                                                 Profession Bonus: {c.ProfessionBonus}");
            Console.WriteLine($"                                                                 Profession Lore: {c.ProfessionLoreBonus}");
            Console.WriteLine("                                                                 *~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*");
        }

        private static void ShowCharacterMenu()
        {
            Console.Clear();
            WizardPortrait();
            DialogueFrameTop();
            Console.WriteLine("\n                                                               I shall open the Book of Summoning...");
            DialogueFrameBottom();
            Console.WriteLine("                                                                 [1] Create a new character");
            Console.WriteLine("                                                                 [2] Show saved characters");
            Console.WriteLine("                                                                 [0] Return to Main Menu");
            Console.Write("\n                                                                 Thy choice: ");

            switch (Console.ReadLine())
            {
                case "1": CreateCharacter(); break;
                case "2": ShowSavedCharacters(); break;
                case "0": ShowMainMenu(false); break;
                default:
                    InvalidInput();
                    break;
            }
        }

        // --- FIX: Talent and flaw cannot contradict each other ---
        private static void CreateCharacter()
        {
            Console.Clear();
            WizardPortrait();
            DialogueFrameTop();
            Console.WriteLine("\n                                                                   Let us draw a hero from the mists of the Age of Lost Omens...");
            Console.WriteLine("\n\n\n");
            DialogueFrameBottom();
            Console.WriteLine("\n\n\n");
            Console.WriteLine("\n                                                                 (Press any key to continue...)");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine();

            string[] classes = { "Alchemist", "Animist", "Druid", "Fighter", "Oracle", "Psychic", "Swashbuckler", "Thraumaturge", "Gunslinger", "Inventor", "Exemplar", "Barbarian", "Bard", "Investigator", "Kineticist", "Ranger", "Rogue", "Witch", "Wizard", "Champion", "Cleric", "Magus", "Monk", "Sorcerer", "Summoner" };
            string[] talents = { "Strong (+1 Strength)", "Agile (+1 Dexterity)", "Wise (+1 Wisdom)", "Charismatic (+1 Charisma)", "Smart (+1 Intelligence)", "Hardy (+1 Constitution)" };
            string[] flaws = { "Weak (-1 Strength)", "Clumsy (-1 Dexterity)", "Foolish (-1 Wisdom)", "Awkward (-1 Charisma)", "Dull (-1 Intelligence)", "Frail (-1 Constitution)" };
            string[] heritages = { "Noble", "Commoner", "Poor" };

            Random rnd = new Random();

            // Ancestry from database
            int ancestryindex = rnd.Next(ancestryDatabase.Ancestries.Count);
            Ancestry chosenAncestry = ancestryDatabase.Ancestries[ancestryindex];
            string ancestryName = chosenAncestry.Name;
            string ancestryRarity = chosenAncestry.Rarity;
            string ancestryOrigin = chosenAncestry.Origin;

            // Class from array
            string chosenClass = classes[rnd.Next(classes.Length)];

            // Deity from database
            int deityindex = rnd.Next(deityDatabase.Deities.Count);
            Deity chosenDeity = deityDatabase.Deities[deityindex];
            string deity = chosenDeity.Name;
            string epithet = chosenDeity.Epithet;
            string alignment = chosenDeity.Alignment;

            // Profession from database
            int professionIndex = rnd.Next(professionDatabase.Professions.Count);
            Profession chosenProfession = professionDatabase.Professions[professionIndex];
            string professionName = chosenProfession.Name;
            string professionSalaryClass = chosenProfession.SalaryClass;
            string professionBonus = chosenProfession.Bonus;
            string professionLoreBonus = chosenProfession.LoreBonus;

            string motivation;
            if (alignment == "Lawful Good")
                motivation = "act as a good person is expected or required to act";
            else if (alignment == "Neutral Good")
                motivation = "do good deeds out of personal conviction rather than adherence to laws or traditions";
            else if (alignment == "Chaotic Good")
                motivation = "is driven by a desire to bring about the greatest good for the greatest number, often by breaking societal norms or laws";
            else if (alignment == "Lawful Neutral")
                motivation = "act in accordance with laws, traditions, or personal codes, regardless of whether it is good or evil";
            else if (alignment == "True Neutral")
                motivation = "is motivated by balance, seeing extremes of law, chaos, good, and evil as equally undesirable";
            else if (alignment == "Chaotic Neutral")
                motivation = "is an individualist who follows their own whims, prioritizing personal freedom over all else, with no strong leanings towards good or evil";
            else if (alignment == "Lawful Evil")
                motivation = "act within the bounds of laws or codes to achieve selfish, evil ends, often with an emphasis on power and control";
            else if (alignment == "Neutral Evil")
                motivation = "is purely self-interested and does whatever it takes to get what they want, without any particular loyalty to law or chaos, or any desire to spread good or evil";
            else if (alignment == "Chaotic Evil")
                motivation = "is motivated by pure selfishness and destruction, showing no respect for rules, lives, or the well-being of others";
            else
                motivation = "have an unknown or undefined motivation";

            // Draw talent/flaw combination robustly: never contradicting
            var talentAttr = new Dictionary<string, string>
            {
                { "Strong (+1 Strength)", "Strength" },
                { "Agile (+1 Dexterity)", "Dexterity" },
                { "Wise (+1 Wisdom)", "Wisdom" },
                { "Charismatic (+1 Charisma)", "Charisma" },
                { "Smart (+1 Intelligence)", "Intelligence" },
                { "Hardy (+1 Constitution)", "Constitution" }
            };
            var flawAttr = new Dictionary<string, string>
            {
                { "Weak (-1 Strength)", "Strength" },
                { "Clumsy (-1 Dexterity)", "Dexterity" },
                { "Foolish (-1 Wisdom)", "Wisdom" },
                { "Awkward (-1 Charisma)", "Charisma" },
                { "Dull (-1 Intelligence)", "Intelligence" },
                { "Frail (-1 Constitution)", "Constitution" }
            };

            string talent = talents[rnd.Next(talents.Length)];
            string talentAttribute = talentAttr[talent];
            // Only allow flaws that do not contradict the talent
            var possibleFlaws = flaws.Where(f => flawAttr[f] != talentAttribute).ToArray();
            string flaw = possibleFlaws[rnd.Next(possibleFlaws.Length)];

            string heritage = heritages[rnd.Next(heritages.Length)];
            int age = rnd.Next(20, 51);
            int professionExperience = age - 15;

            // Store all generated values in lastGeneratedCharacter
            lastGeneratedCharacter = new Character
            {
                Name = "",
                Ancestry = ancestryName,
                AncestryOrigin = ancestryOrigin,
                AncestryRarity = ancestryRarity,
                Class = chosenClass,
                Deity = deity,
                DeityEpithet = epithet,
                Alignment = alignment,
                Motivation = motivation,
                Talent = talent,
                Flaw = flaw,
                Heritage = heritage,
                Age = age,
                Profession = professionName,
                ProfessionSalaryClass = professionSalaryClass,
                ProfessionBonus = professionBonus,
                ProfessionLoreBonus = professionLoreBonus,
                ProfessionExperience = professionExperience
            };

            // Always use the values from lastGeneratedCharacter for display and saving
            Console.Clear();
            WizardPortrait();
            DialogueFrameTop();
            Console.WriteLine("\n");
            Console.WriteLine($"                                                                 Thy hero is an {lastGeneratedCharacter.Age} year old {lastGeneratedCharacter.Ancestry} {lastGeneratedCharacter.Class}.");
            Console.WriteLine($"                                                                 Originally from {lastGeneratedCharacter.AncestryOrigin} thy hero seeks a new adventure.");
            Console.WriteLine($"                                                                 As a follower of {lastGeneratedCharacter.Deity}, the {lastGeneratedCharacter.DeityEpithet},");
            Console.WriteLine($"                                                                 they {lastGeneratedCharacter.Motivation}.");
            Console.WriteLine($"                                                                 On the one hand he is particularly {lastGeneratedCharacter.Talent}, but on the other hand he is rather {lastGeneratedCharacter.Flaw}.");
            Console.WriteLine($"                                                                 Before starting the path of an adventurer they worked as an {lastGeneratedCharacter.Profession} for {lastGeneratedCharacter.ProfessionExperience} years.");
            Console.WriteLine($"                                                                 After years of working in their job, they get {lastGeneratedCharacter.ProfessionBonus} and have an excellent knowledge in their field {lastGeneratedCharacter.ProfessionLoreBonus}.");
            DialogueFrameBottom();
            Console.WriteLine("\n\n\n");
            Console.WriteLine("\n                                                                 [1] Summon another hero.");
            Console.WriteLine("\n                                                                 [2] Write this hero into the Book of Summoning.");
            Console.WriteLine("                                                                 [0] Return to Main Menu");
            Console.Write("\n                                                                 Thy choice: ");

            switch (Console.ReadLine())
            {
                case "1":
                    CreateCharacter();
                    break;
                case "2":
                    // Ask for a character name
                    Console.Clear();
                    WizardPortrait();
                    DialogueFrameTop();
                    Console.WriteLine("\n");
                    Console.WriteLine($"                                                                 Thy hero is an {lastGeneratedCharacter.Age} year old {lastGeneratedCharacter.Ancestry} {lastGeneratedCharacter.Class}.");
                    Console.WriteLine($"                                                                 Originally from {lastGeneratedCharacter.AncestryOrigin} thy hero seeks a new adventure.");
                    Console.WriteLine($"                                                                 As a follower of {lastGeneratedCharacter.Deity}, the {lastGeneratedCharacter.DeityEpithet},");
                    Console.WriteLine($"                                                                 they {lastGeneratedCharacter.Motivation}.");
                    Console.WriteLine($"                                                                 On the one hand he is particularly {lastGeneratedCharacter.Talent}, but on the other hand he is rather {lastGeneratedCharacter.Flaw}.");
                    Console.WriteLine($"                                                                 Before starting the path of an adventurer they worked as an {lastGeneratedCharacter.Profession} for {lastGeneratedCharacter.ProfessionExperience} years.");
                    Console.WriteLine($"                                                                 After years of working in their job, they get {lastGeneratedCharacter.ProfessionBonus} and have an excellent knowledge in their field {lastGeneratedCharacter.ProfessionLoreBonus}.");
                    Console.WriteLine("\n");
                    Console.WriteLine("                                                                 By what name shall this hero be known?");
                    DialogueFrameBottom();
                    Console.WriteLine("\n\n\n");
                    Console.Write("\n                                                                  The hero shall be known by the name ");
                    string charName = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(charName))
                        charName = "Unnamed Hero";
                    lastGeneratedCharacter.Name = charName;
                    SaveCurrentCharacter();
                    break;
                case "0":
                    ShowMainMenu(false);
                    break;
                default:
                    InvalidInput();
                    break;
            }
        }

        private static void SaveCurrentCharacter()
        {
            if (lastGeneratedCharacter == null)
            {
                Console.Clear();
                WizardPortrait();
                DialogueFrameTop();
                Console.WriteLine("\n                                                                 No hero has been conjured yet to be immortalized.");
                DialogueFrameBottom();
                Console.WriteLine("\n                                                                 (Press any key to continue...)");
                Console.ReadKey();
                ShowMainMenu(false);
                return;
            }

            var slots = LoadCharacterSlots();

            while (true)
            {
                Console.Clear();
                WizardPortrait();
                DialogueFrameTop();
                Console.WriteLine("\n                                                                 Behold, the Book of Summoning. Choose a slot to save thy hero:");
                PrintCharacterSlotTable(slots);
                DialogueFrameBottom();
                Console.WriteLine("\n                                                                 Enter the number of the slot (1-9) to save/overwrite, or 0 to go back.");
                Console.Write("\n                                                                 Thy choice: ");
                string input = Console.ReadLine();

                if (input == "0")
                {
                    ShowMainMenu(false);
                    return;
                }
                if (int.TryParse(input, out int slot) && slot >= 1 && slot <= MaxCharacterSlots)
                {
                    slots[slot - 1] = lastGeneratedCharacter;
                    SaveCharacterSlots(slots);

                    Console.Clear();
                    WizardPortrait();
                    DialogueFrameTop();
                    Console.WriteLine($"\n                                                                 Thy hero has been written into slot {slot} of the Book of Summoning!");
                    DialogueFrameBottom();
                    Console.WriteLine("\n                                                                 (Press any key to continue...)");
                    Console.ReadKey();
                    ShowMainMenu(false);
                    return;
                }
                else
                {
                    InvalidInput();
                }
            }
        }

        private static void ShowSavedCharacters()
        {
            var slots = LoadCharacterSlots();

            while (true)
            {
                Console.Clear();
                WizardPortrait();
                DialogueFrameTop();
                Console.WriteLine("\n                                                                 These heroes have been immortalized in the Book of Summoning.");
                PrintCharacterSlotTable(slots);
                DialogueFrameBottom();
                Console.WriteLine("\n                                                                 Enter the number of the slot (1-9) to view, or 0 to return.");
                Console.Write("\n                                                                 Thy choice: ");
                string input = Console.ReadLine();

                if (input == "0")
                {
                    ShowMainMenu(false);
                    return;
                }
                if (int.TryParse(input, out int slot) && slot >= 1 && slot <= MaxCharacterSlots)
                {
                    var c = slots[slot - 1];
                    if (c == null)
                    {
                        Console.Clear();
                        WizardPortrait();
                        DialogueFrameTop();
                        Console.WriteLine($"\n                                                                 Character Slot {slot} is empty.");
                        DialogueFrameBottom();
                        Console.WriteLine("\n                                                                 (Press any key to continue...)");
                        Console.ReadKey();
                        continue;
                    }

                    // Show character details
                    while (true)
                    {
                        Console.Clear();
                        WizardPortrait();
                        DialogueFrameTop();
                        PrintCharacterDetails(c);
                        DialogueFrameBottom();
                        Console.WriteLine("\n                                                                 [1] Remove this hero from the Book of Summoning.");
                        Console.WriteLine("                                                                 [0] Return to character slots.");
                        Console.Write("\n                                                                 Thy choice: ");
                        string sub = Console.ReadLine();
                        if (sub == "0")
                            break;
                        if (sub == "1")
                        {
                            slots[slot - 1] = null;
                            SaveCharacterSlots(slots);
                            Console.Clear();
                            WizardPortrait();
                            DialogueFrameTop();
                            Console.WriteLine($"\n                                                                 The hero has been erased from slot {slot}.");
                            DialogueFrameBottom();
                            Console.WriteLine("\n                                                                                        (Press any key to continue...)");
                            Console.ReadKey();
                            break;
                        }
                        else
                        {
                            InvalidInput();
                        }
                    }
                }
                else
                {
                    InvalidInput();
                }
            }
        }

        #endregion
    }
}