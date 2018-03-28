using System;
using System.Collections.Generic;
using System.Linq;

namespace theprophecy.Models
{
    public class Game : IGame
    {
        public Room CurrentRoom { get; set; }
        public List<Room> Rooms { get; set; }
        public Player Player { get; set; }

        public Dictionary<string, Item> Items { get; set; }

        public Game()
        {
            Rooms = new List<Room>();
            Items = new Dictionary<string, Item>();
        }


        public void Reset()
        {

        }

        public void Setup()
        {
            //CREATE GAME
            Game game = new Game();

            //CREATE PLAYER
            Player player = new Player();
            game.Player = player;

            //CREATE ITEMS
            Item wand = new Item("Wand", "Your wand. 11 inches, made of holly, with a phoenix feather core.");
            Item cloak = new Item("Invisibility Cloak", "Given to you in your first year at Hogwarts. Useful for sneaking around.");
            Item beans = new Item("Bertie Bott's Every Flavour Beans", "Many flavors such as Cherry, Watermelon and Earwax!");
            Item parchment = new Item("Parchment", "A crumpled up piece of parchment with just one word printed on it, “legilimens”.");
            // Item wand = new Item("", "");
            // Item wand = new Item("", "");
            // Item wand = new Item("", "");
            // Item wand = new Item("", "");
            // Item wand = new Item("", "");
            // Item wand = new Item("", "");
            // Item wand = new Item("", "");
            // Item wand = new Item("", "");

            //ADD ITEMS TO GAME
            game.Items.Add("wand", wand);
            game.Items.Add("cloak", cloak);
            game.Items.Add("parchment", parchment);

            //CREATE ROOMS
            //HOGWARTS
            Room boysRoom = new Room("Gryffindor Boy's Dormitory", @"A decent sized, circular room with 5 four-poster beds surrounding the middle of the room. 

                    There's a trunk sitting at the base of your bed. To the east are the exit stairs to the Common Room.");
            Room commonRoom = new Room("Gryffindor Common Room", @"The living quarters of the Gryffindor students in Gryffindor Tower. 

                    The fire is roaring in the large fireplace which provides light for the room. Stars can be seen outside of the large windows. 

                    To the west is the boys dormitory, to the east is the girl's dormitory, and to the south is the exit.");
            //MINISTRY OF MAGIC
            Room entryRoom = new Room("The Department of Mysteries", @"Smooth black marble slates the walls and floor. The ceilings are high. It's not very bright. 

                    The only light comes from the blue-flame torches along the walls. The elevator door to the south is closed. 

                    The only way to go is north.");
            Room hallwayRoom = new Room("Hallway", @"The blue-flame torches along the walls shine an eerie light on you and your friends.

                    The main entrance of the Department of Mysteries is to the south.
                    
                    A large black door with a smooth silver handle is to the north.");
            Room circleRoom = new Room("Circle Room", @"This room is a large circle with a total of 8 doors equally spread around the wall. 

                    Each door looks the same. You entered from the south. 

                    The other 7 doors are at the remaining cardinal direction and each intermediate direction.");
            Room brainRoom = new Room("The Brain Room", @"A Long rectangular room. There are low hanging lamps that float over countless tanks full of a green solution.

                    Floating in the solution in each tank are what appear to be human brains. There's a bright blue light at the end of the room. 

                    The only exit is to the east.");
            Room deathRoom = new Room("The Death Chamber", @"A square stone chamber that resembles a court room. 

                    In the middle of the room stands a tall stone archway covered in a black veil. 

                    You seem to hear whispers coming from behind the curtain. 

                    You can exit to the south east.");
            Room planetRoom = new Room("The Planet Room", @"Everything is dark. The only light comes from what appear to be planets hanging in mid-air. 

                    It's cold. It feels like you're in space, in fact, you seem to be floating just slightly. 

                    You can float and exit to the north west.");
            Room timeRoom = new Room("The Time Room", @"This rectangular room is filled with sparkling, dancing lights. 

                    Clocks, watches, hourglasses and time-turners are floating just out of reach overhead. 

                    There's a large crystal bell jar in the middle of the room. 

                    There's a grandfather clock standing at the end of the room. 

                    The only door is to the west.");
            Room prophecyRoom = new Room("The Hall of Prophecy", @"This room seems to go on forever. Tall shelves willed with glass orbs; prophecies. 

                    Each prophecy glows with a dim light, clouds swirling inside each orb. This is the place from your dreams. 

                    The exit to the south appears to be the only way out.");

            //ADD DIRECTIONS TO ROOMS
            boysRoom.Directions.Add("go east", commonRoom);
            commonRoom.Directions.Add("go west", boysRoom);
            commonRoom.Directions.Add("go south", entryRoom);
            entryRoom.Directions.Add("go north", hallwayRoom);
            hallwayRoom.Directions.Add("go south", entryRoom);
            hallwayRoom.Directions.Add("go north", circleRoom);
            circleRoom.Directions.Add("go north", prophecyRoom);
            circleRoom.Directions.Add("go east", timeRoom);
            circleRoom.Directions.Add("go south east", planetRoom);
            circleRoom.Directions.Add("go south", hallwayRoom);
            circleRoom.Directions.Add("go west", brainRoom);
            circleRoom.Directions.Add("go north west", deathRoom);
            deathRoom.Directions.Add("go south east", circleRoom);
            brainRoom.Directions.Add("go east", circleRoom);
            planetRoom.Directions.Add("go north west", circleRoom);
            timeRoom.Directions.Add("go west", circleRoom);
            prophecyRoom.Directions.Add("go south", circleRoom);


            //ADD ITEMS TO ROOMS
            boysRoom.Items.Add("wand", wand);
            boysRoom.Items.Add("invisibility cloak", cloak);
            commonRoom.Items.Add("beans", beans);
            entryRoom.Items.Add("parchment", parchment);

            //ADD EVERYTHING TO THE GAME
            game.Rooms.Add(boysRoom);//0
            game.Rooms.Add(commonRoom);//1
            game.Rooms.Add(entryRoom);//2
            game.Rooms.Add(hallwayRoom);//3
            game.Rooms.Add(circleRoom);//4
            game.Rooms.Add(brainRoom);//5
            game.Rooms.Add(deathRoom);//6
            game.Rooms.Add(planetRoom);//7
            game.Rooms.Add(timeRoom);//8
            game.Rooms.Add(prophecyRoom);//9

            game.PlayGame();
        }

        public void PlayGame()
        {
            Console.Clear();
            this.CurrentRoom = this.Rooms[0];
            bool playGame = true;
            System.Console.WriteLine(@"
                    --------------------------------------------------------------------------------------------------- 
                                                THE PROPHECY: ESCAPE THE DEPARTMENT OF MYSTERIES           
                    ---------------------------------------------------------------------------------------------------");
            System.Console.WriteLine(@"
                                                                    COMMANDS:

                      Go <Direction>   Take <ItemName>   Use <ItemName>   Search <ItemName>   Look   Inventory   Quit   
                    --------------------------------------------------------------------------------------------------- 
            ");
            System.Console.WriteLine($@"
{this.CurrentRoom.Name}

                    There’s a flash of green light. You see a room lined with endless shelves of swirling blue orbs. 
                    A man, somewhere, is screaming. Everything goes dark. Everything goes silent. . .

                            “Harry. . . Harry, wake up. Come on, Harry. It’s time!”

                    You begin to open your eyes, the light cast from Ron’s wand is blinding you.

                            “It’s time to go. Luna, Neville, Ginny and Hermione are all ready. Grab your stuff.”

                    You sit up and put on your glasses. You begin to remember. 

                    Yes, it's time to do this! Ron hurries out of the Boy's Dormitory. You get out of bed.
            ");
            //BOYSDORM
            while (playGame)
            {
                #region ROOMONE
                if (this.CurrentRoom == this.Rooms[0])
                {
                    if (this.Player.Moves > 0)
                    {
                        Console.Clear();
                        System.Console.WriteLine(@"
                    --------------------------------------------------------------------------------------------------- 
                                                THE PROPHECY: ESCAPE THE DEPARTMENT OF MYSTERIES           
                    ---------------------------------------------------------------------------------------------------");
                        System.Console.WriteLine(@"
                                                                    COMMANDS:

                      Go <Direction>   Take <ItemName>   Use <ItemName>   Search <ItemName>   Look   Inventory   Quit   
                    --------------------------------------------------------------------------------------------------- 
            ");
                        System.Console.WriteLine($@"
{this.CurrentRoom.Name}
                    ");
                    }
                    bool roomOne = true;
                    while (roomOne)
                    {

                        System.Console.Write(">");
                        string command = Console.ReadLine();
                        this.Player.Moves++;

                        //GO
                        if (command.ToLower().StartsWith("go"))
                        {
                            if (this.CurrentRoom.Directions.ContainsKey(command))
                            {
                                this.CurrentRoom = this.CurrentRoom.Directions[command];
                                roomOne = false;
                            }
                            else if (command == "go")
                            {
                                System.Console.WriteLine(@"
                    You can't wander these halls aimlessly. Specify a direction.
                    
                    ");
                            }
                            else System.Console.WriteLine(@"
                    You can't go that way.
                    
                    ");
                        }
                        //USE
                        if (command.ToLower().StartsWith("use"))
                        {
                            if (this.Player.Inventory.Count == 0)
                            {
                                System.Console.WriteLine(@"
                    You don't have anything to use.
                    
                    ");
                            }
                            else
                            {
                                System.Console.WriteLine(@"
                    There's nothing to use in here.

                                ");
                            }
                        }
                        //TAKE
                        if (command.ToLower().StartsWith("take"))
                        {
                            string command2 = command.TrimStart('t');
                            string command3 = command2.TrimStart('a');
                            string command4 = command3.TrimStart('k');
                            string command5 = command4.TrimStart('e');
                            string item = command5.TrimStart(' ').ToLower();
                            if (this.CurrentRoom.Items.ContainsKey(item))
                            {
                                this.Player.Inventory.Add(this.CurrentRoom.Items[item]);
                                System.Console.WriteLine($@"
                    {this.CurrentRoom.Items[item].Name} added to your inventory.
                    
                    ");
                                this.CurrentRoom.Items.Remove(item);
                            }
                            else
                            {
                                System.Console.WriteLine(@"
                    You can't do that.

                                ");
                            }
                            if (item == "wand")
                            {
                                this.Player.Score += 20;
                            }
                            if (item == "invisibility cloak")
                            {
                                this.Player.Score += 10;
                            }
                        }
                        //SEARCH
                        if (command.ToLower().StartsWith("search"))
                        {
                            if (command.ToLower() == "search trunk")
                            {
                                System.Console.WriteLine(@"
                    You open the trunk to see a copy of 'Quidditch Through the Ages'. Your Invisibility Cloak. 

                    Your potions cauldron. Some school robes. And sitting right on top of the robes is your wand. 

                                ");
                            }
                            else
                            {
                                System.Console.WriteLine(@"
                    Nothing to see here.

                                ");
                            }
                        }
                        //LOOK
                        if (command.ToLower() == "look")
                        {
                            System.Console.WriteLine($@"
                    {this.CurrentRoom.Description}
                    
                    ");
                        }
                        //INVENTORY
                        if (command.ToLower() == "inventory")
                        {
                            System.Console.WriteLine($@"
                    Score: {this.Player.Score}  Moves: {this.Player.Moves}
                    ------------------------------------------
                                    INVENTORY:
                            ");
                            this.Player.Inventory.ForEach(Item =>
                            {
                                System.Console.WriteLine($@"
                    {Item.Name}: {Item.Description}
                            ");
                            });
                            System.Console.WriteLine(@"
                    ------------------------------------------      

                            ");
                        }
                        //QUIT
                        if (command.ToLower() == "quit")
                        {
                            System.Console.WriteLine(@"
                    Are you sure you'd like to quit? (Y/N)

                            ");
                            System.Console.Write(">");
                            string quit = Console.ReadLine();
                            if (quit.ToLower() == "y")
                            {
                                playGame = false;
                                roomOne = false;
                            }
                        }
                    }
                }
                #endregion

                #region ROOMTWO
                else if (this.CurrentRoom == this.Rooms[1])
                {
                    Console.Clear();
                    System.Console.WriteLine(@"
                    --------------------------------------------------------------------------------------------------- 
                                                THE PROPHECY: ESCAPE THE DEPARTMENT OF MYSTERIES           
                    ---------------------------------------------------------------------------------------------------");
                    System.Console.WriteLine(@"
                                                                    COMMANDS:

                      Go <Direction>   Take <ItemName>   Use <ItemName>   Search <ItemName>   Look   Inventory   Quit   
                    --------------------------------------------------------------------------------------------------- 
            ");
                    System.Console.WriteLine($@"
{this.CurrentRoom.Name}            

                    Ron, Hermione, Neville, Luna and Ginny are all standing by the fireplace.

                            Hermione speaks, “Are you ready? We don’t have much time. We must get to the Ministry.”

                    Everyone seems tense. This mission won’t be easy, but your friends stand by your side.

                    Ginny gives you a shy smile. 

                    You must get to the Department of Mysteries and collect your Prophecy, before Voldemort can.
           
");
                    bool roomTwo = true;
                    while (roomTwo)
                    {
                        System.Console.Write(">");
                        string command = Console.ReadLine();
                        this.Player.Moves++;

                        //GO
                        if (command.ToLower().StartsWith("go"))
                        {
                            if (this.CurrentRoom.Directions.ContainsKey(command))
                            {
                                if (command.ToLower() == "go south")
                                {
                                    System.Console.WriteLine(@"
                            “Alright everybody, let’s do this.”, says Ron.

                    Everyone begins towards to exit of the Common Room.

                            “Are you ready Harry? You've got your wand, right?” (Y/N)

                                    ");
                                    System.Console.Write(">");
                                    string answer = Console.ReadLine();
                                    if (answer.ToLower() == "y")
                                    {
                                        System.Console.WriteLine(@"
                    You and your friends quietly leave the Common Room through the portrait of the Fat Lady, who appears to be sleeping.

                    As you sneak out of the school, you have to avoid Filch and his cat, Mrs. Norris. 

                    After exiting from a side door, close to the Herbology classroom, your group heads out to the Forbidden Forest.

	                        “I don’t like this place.” mumbles Ron.
	
	                        “Oh come one, Ron. It isn’t that bad.” teases Ginny.

                    Neville seems to be shaking in fear. You’re quite surprised he’s got up the courage to come along to the Ministry of Magic.

	                        “Alright everyone,” you announce, “time to get on the Thestrals.”

                    Only you and Luna can see them. So it’s awkward seeing everyone try to balance on the zombie-like horses.

                    As the Thestrals spread their wings and begin towards the sky, you feel a pit in your stomach.

                    Not from flying, you’re used to that. This is a gutsy mission. But we have to do it. We must get that Prophecy.

                                    --------------------------------------------------------------------------------------------------- 

                    You’ve flown to the Ministry and snuck in through the Guest Entrance. You and your friends have made the way down to the 9th floor.

                    Everyone steps out of the elevator. It *dings* closed behind you. And here you are, in the Department of Mysteries. 

                            (Press Enter to Continue)

                                        ");
                                        Console.Write(">");
                                        Console.ReadLine();
                                        this.CurrentRoom = this.CurrentRoom.Directions[command];
                                        roomTwo = false;
                                    }
                                    else
                                    {
                                        System.Console.WriteLine(@"
                    You take a step back.

                            “I’m not quite ready.”

                            “Okay Harry,” says Luna “take your time. After all, we’re doing this for you.”

                            “Thanks, Luna.”
                                        
                                        ");
                                    }
                                }
                                else
                                {
                                    this.CurrentRoom = this.CurrentRoom.Directions[command];
                                    roomTwo = false;
                                }
                            }
                            else if (command.ToLower() == "go")
                            {
                                System.Console.WriteLine(@"
                    You can't wander these halls aimlessly. Specify a direction.
                    
                    ");
                            }
                            else if (command.ToLower() == "go east")
                            {
                                System.Console.WriteLine(@"
                    You begin up the stairs to the Girl's Dormitory. Everyone is giving you a befuddled look. 

                    As you reach the fifth step, the stairs suddenly turn into a slide and you end up on your backside.

                    You slide down and land at Ginny's feet.
                            
                            “Come now, Harry. You know you can’t go up there.”

                                ");
                            }
                            else System.Console.WriteLine(@"
                    You can't go that way.
                    
                    ");
                        }
                        //TAKE
                        if (command.ToLower().StartsWith("take"))
                        {
                            string command2 = command.TrimStart('t');
                            string command3 = command2.TrimStart('a');
                            string command4 = command3.TrimStart('k');
                            string command5 = command4.TrimStart('e');
                            string item = command5.TrimStart(' ').ToLower();
                            if (this.CurrentRoom.Items.ContainsKey(item))
                            {
                                this.Player.Inventory.Add(this.CurrentRoom.Items[item]);
                                System.Console.WriteLine($@"
                    {this.CurrentRoom.Items[item].Name} added to your inventory.
                    
                    ");
                                this.CurrentRoom.Items.Remove(item);
                            }
                            else
                            {
                                System.Console.WriteLine(@"
                    You can't do that.

                                ");
                            }
                            if (item == "beans")
                            {
                                this.Player.Score += 5;
                            }
                        }
                        //USE
                        if (command.ToLower().StartsWith("use"))
                        {
                            if (this.Player.Inventory.Count == 0)
                            {
                                System.Console.WriteLine(@"
                    You don't have anything to use.
                    
                    ");
                            }
                            else
                            {
                                System.Console.WriteLine(@"
                    There's nothing to use in here.

                                ");
                            }
                        }
                        //SEARCH
                        if (command.ToLower().StartsWith("search"))
                        {
                            if (command.ToLower() == "search fireplace")
                            {
                                System.Console.WriteLine(@"
                    Not much here. The fire is roaring. Some poor first year has left their damp shoes by the fire.

                    The mantle is grand, but mostly empty; other than a box of beans. Bertie Bott's Every Flavour Beans, to be exact.

                    You love the Cinnamon ones!

                                ");
                            }
                            else
                            {
                                System.Console.WriteLine(@"
                    Nothing to see here.

                                ");
                            }
                        }
                        //LOOK
                        if (command.ToLower() == "look")
                        {
                            System.Console.WriteLine($@"
                    {this.CurrentRoom.Description}

                            ");
                        }
                        //INVENTORY
                        if (command.ToLower() == "inventory")
                        {
                            System.Console.WriteLine($@"
                    Score: {this.Player.Score}  Moves: {this.Player.Moves}
                    ------------------------------------------
                                    INVENTORY:
                            ");
                            this.Player.Inventory.ForEach(Item =>
                            {
                                System.Console.WriteLine($@"
                    {Item.Name}: {Item.Description}
                            ");
                            });
                            System.Console.WriteLine(@"
                    ------------------------------------------   

                            ");
                        }
                        //QUIT
                        if (command.ToLower() == "quit")
                        {
                            System.Console.WriteLine(@"
                    Are you sure you'd like to quit? (Y/N)

                            ");
                            System.Console.Write(">");
                            string quit = Console.ReadLine();
                            if (quit.ToLower() == "y")
                            {
                                playGame = false;
                                roomTwo = false;
                            }
                        }

                    }
                }
                #endregion

                #region ROOMTHREE
                else if (this.CurrentRoom == this.Rooms[2])
                {
                    Console.Clear();
                    System.Console.WriteLine(@"
                    --------------------------------------------------------------------------------------------------- 
                                                THE PROPHECY: ESCAPE THE DEPARTMENT OF MYSTERIES           
                    ---------------------------------------------------------------------------------------------------");
                    System.Console.WriteLine(@"
                                                                    COMMANDS:

                      Go <Direction>   Take <ItemName>   Use <ItemName>   Search <ItemName>   Look   Inventory   Quit   
                    --------------------------------------------------------------------------------------------------- 
            ");
                    System.Console.WriteLine($@"
{this.CurrentRoom.Name}            

");
                    bool roomThree = true;
                    while (roomThree)
                    {
                        System.Console.Write(">");
                        string command = Console.ReadLine();
                        this.Player.Moves++;

                        //GO
                        if (command.ToLower().StartsWith("go"))
                        {
                            if (this.CurrentRoom.Directions.ContainsKey(command))
                            {
                                this.CurrentRoom = this.CurrentRoom.Directions[command];
                                roomThree = false;
                            }
                            else if (command.ToLower() == "go")
                            {
                                System.Console.WriteLine(@"
                    You can't wander these halls aimlessly. Specify a direction.
                    
                    ");
                            }
                            else System.Console.WriteLine(@"
                    You can't go that way.
                    
                    ");
                        }
                        //TAKE
                        if (command.ToLower().StartsWith("take"))
                        {
                            string command2 = command.TrimStart('t');
                            string command3 = command2.TrimStart('a');
                            string command4 = command3.TrimStart('k');
                            string command5 = command4.TrimStart('e');
                            string item = command5.TrimStart(' ').ToLower();
                            if (this.CurrentRoom.Items.ContainsKey(item))
                            {
                                this.Player.Inventory.Add(this.CurrentRoom.Items[item]);
                                System.Console.WriteLine($@"
                    {this.CurrentRoom.Items[item].Name} added to your inventory.
                    
                    ");
                                this.CurrentRoom.Items.Remove(item);
                            }
                            else
                            {
                                System.Console.WriteLine(@"
                    You can't do that.

                                ");
                            }
                            if (item == "parchment")
                            {
                                this.Player.Score += 10;
                            }
                        }
                        //USE
                        if (command.ToLower().StartsWith("use"))
                        {
                            if (this.Player.Inventory.Count == 0)
                            {
                                System.Console.WriteLine(@"
                    You don't have anything to use.
                    
                    ");
                            }
                            else if (this.Player.Inventory.Contains(this.Items["wand"]) && command.ToLower() == "use wand")
                            {
                                if (this.Player.Inventory.Contains(this.Items["parchment"]))
                                {
                                    System.Console.WriteLine(@"
                            “Lumos!”

                    You and your friends cast some extra light. You see a long hall to the north.
        
                                ");
                                }
                                else
                                {
                                    System.Console.WriteLine(@"
                            “Lumos!”

                    You and your friends cast some extra light. You see a long hall to the north.

                    You can also clearly see a crumpled piece of parchment in the corner.
        
                                ");
                                }
                            }
                            else if (this.Player.Inventory.Contains(this.Items["parchment"]) && command.ToLower() == "use parchment")
                            {
                                System.Console.WriteLine(@"
                    You can't really use the parchment, but you open it up and read it.

                            “Legilimens.” Hermione reads over your shoulder. “Hmm, I wonder what that could be for.”

                            “What's a leglilimens?” asks Neville.

                            “A sort of mind-reader. It's very rare, but some witches or wizards are said to be born with the talent.”

                    You give the piece of parchment a second look then put it back into your pocket.
                                
                                ");
                            }
                            else
                            {
                                System.Console.WriteLine(@"
                    You can't do that.
                                
                                ");
                            }
                        }
                        //SEARCH
                        if (command.ToLower().StartsWith("search"))
                        {
                            if (command.ToLower().StartsWith("search"))
                            {
                                if (this.Player.Inventory.Contains(this.Items["parchment"]))
                                {
                                    System.Console.WriteLine(@"
                    You look down on the ground. The floor is very smooth.

                    There doesn't seem to be anything of interest.

                                ");
                                }
                                else
                                {

                                    System.Console.WriteLine(@"
                    You look down on the ground. The floor is very smooth.

                    But what's that? There appears to be something small in one of the dark corners.

                    Perhaps a small piece of parchment?

                                ");
                                }
                            }
                            else
                            {
                                System.Console.WriteLine(@"
                    Nothing to see here.

                                ");
                            }
                        }
                        //LOOK
                        if (command.ToLower() == "look")
                        {
                            System.Console.WriteLine($@"
                    {this.CurrentRoom.Description}

                            ");
                        }
                        //INVENTORY
                        if (command.ToLower() == "inventory")
                        {
                            System.Console.WriteLine($@"
                    Score: {this.Player.Score}  Moves: {this.Player.Moves}
                    ------------------------------------------
                                    INVENTORY:
                            ");
                            this.Player.Inventory.ForEach(Item =>
                            {
                                System.Console.WriteLine($@"
                    {Item.Name}: {Item.Description}
                            ");
                            });
                            System.Console.WriteLine(@"
                    ------------------------------------------   

                            ");
                        }
                        //QUIT
                        if (command.ToLower() == "quit")
                        {
                            System.Console.WriteLine(@"
                    Are you sure you'd like to quit? (Y/N)

                            ");
                            System.Console.Write(">");
                            string quit = Console.ReadLine();
                            if (quit.ToLower() == "y")
                            {
                                playGame = false;
                                roomThree = false;
                            }
                        }
                    }
                }
                #endregion

                #region ROOMFOUR
                else if (this.CurrentRoom == this.Rooms[3])
                {
                    Console.Clear();
                    System.Console.WriteLine(@"
                    --------------------------------------------------------------------------------------------------- 
                                                THE PROPHECY: ESCAPE THE DEPARTMENT OF MYSTERIES           
                    ---------------------------------------------------------------------------------------------------");
                    System.Console.WriteLine(@"
                                                                    COMMANDS:

                      Go <Direction>   Take <ItemName>   Use <ItemName>   Search <ItemName>   Look   Inventory   Quit   
                    --------------------------------------------------------------------------------------------------- 
            ");
                    System.Console.WriteLine($@"
{this.CurrentRoom.Name}            

");
                    bool roomFour = true;
                    while (roomFour)
                    {
                        System.Console.Write(">");
                        string command = Console.ReadLine();
                        this.Player.Moves++;

                        //GO
                        if (command.ToLower().StartsWith("go"))
                        {
                            if (this.CurrentRoom.Directions.ContainsKey(command))
                            {
                                if (command.ToLower() == "go north")
                                {
                                    System.Console.WriteLine(@"
                    You try the handle of the ominous door, but it doesn't seem to budge.

                            “How can we get through!?” blurts Ron.

                            “Hush Ron, there has to be a way.” says Hermione as she slaps his arm.

                            “Ow! Bloody Hell...” 
                                    
                            “Well Harry, what do you say?”

                                    ");
                                    System.Console.Write(">");
                                    string password = Console.ReadLine();
                                    this.Player.Moves++;

                                    if (password.ToLower() == "legilimens")
                                    {
                                        System.Console.WriteLine(@"
                            “Legilimens!” you say aloud.

                    The door suddenly gives a slight twinkling sound.

                    It glows blue and you try the handle again.

                    It turns with ease.

                            “Well,” spoke Ginny “That's some foolish Ministry worker for leaving the password just lying around.”

                    (Press Enter to Continue)
                                        
                                        ");
                                        System.Console.Write(">");
                                        Console.ReadLine();
                                        this.CurrentRoom = this.CurrentRoom.Directions[command];
                                        roomFour = false;
                                    }
                                    else
                                    {
                                        System.Console.WriteLine(@"
                    Nothing happens.
                                        
                                        ");
                                    }
                                }

                            }
                            else if (command.ToLower() == "go")
                            {
                                System.Console.WriteLine(@"
                    You can't wander these halls aimlessly. Specify a direction.
                    
                    ");
                            }
                            else System.Console.WriteLine(@"
                    You can't go that way.
                    
                    ");
                        }
                        //TAKE
                        if (command.ToLower().StartsWith("take"))
                        {
                            System.Console.WriteLine(@"
                    You can't do that.

                                ");
                        }
                        //USE
                        if (command.ToLower().StartsWith("use"))
                        {
                            if (this.Player.Inventory.Count == 0)
                            {
                                System.Console.WriteLine(@"
                    You don't have anything to use.
                    
                    ");
                            }
                            else if (this.Player.Inventory.Contains(this.Items["parchment"]) && command.ToLower() == "use parchment")
                            {
                                System.Console.WriteLine(@"
                    You remember the parchment, and pull it from your pocket.

                            “legilimens.” is all it reads.
                                
                                ");
                            }
                            else
                            {
                                System.Console.WriteLine(@"
                    You can't do that.
                                
                                ");
                            }
                        }
                        //SEARCH
                        if (command.ToLower().StartsWith("search"))
                        {
                            if (command.ToLower() == "search door")
                            {
                                System.Console.WriteLine(@"
                    You walk up and try the handle of the door, but it wont budge.

                    The door seems to be giving off a slight hum, as if a charm were placed upon it.

                            “Alohamora!” tries Hermione, but it doesn't seem to do anything.

                            “I wonder if it has a password,” says Luna “Like the Common Room.” 
                                            
                                            ");
                            }
                            else
                            {
                                System.Console.WriteLine(@"
                    Nothing to see here.

                                ");
                            }
                        }
                        //LOOK
                        if (command.ToLower() == "look")
                        {
                            System.Console.WriteLine($@"
                    {this.CurrentRoom.Description}

                            ");
                        }
                        //INVENTORY
                        if (command.ToLower() == "inventory")
                        {
                            System.Console.WriteLine($@"
                    Score: {this.Player.Score}  Moves: {this.Player.Moves}
                    ------------------------------------------
                                    INVENTORY:
                            ");
                            this.Player.Inventory.ForEach(Item =>
                            {
                                System.Console.WriteLine($@"
                    {Item.Name}: {Item.Description}
                            ");
                            });
                            System.Console.WriteLine(@"
                    ------------------------------------------   

                            ");
                        }
                        //QUIT
                        if (command.ToLower() == "quit")
                        {
                            System.Console.WriteLine(@"
                    Are you sure you'd like to quit? (Y/N)

                            ");
                            System.Console.Write(">");
                            string quit = Console.ReadLine();
                            if (quit.ToLower() == "y")
                            {
                                playGame = false;
                                roomFour = false;
                            }
                        }
                    }
                }
                #endregion

            }

            System.Console.WriteLine(@"
                    THE END
            ");
        }

        public void UseItem(string itemName)
        {

        }
    }
}