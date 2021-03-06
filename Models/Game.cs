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
            Item uranus = new Item("Uranus", "A mysterious blue planet with silvery rings. Found in the Planet Room.");
            Item gear = new Item("Gear", "A small, bronze, circular gear. It looks like it's part of some kind of mechanism.");
            Item key = new Item("Key", "A golden key that fell from the Grandfather Clock you fixed.");
            Item memory = new Item("Memory", @"Recieved from a floating orb in the Brain Room:
                    'You see a man standing in front of a door.
                    He takes out his wand and casts a spell.
                    'Revalio Completum' he speaks.
                    The door's handle changes and he enters.'");
            Item prophecy = new Item("The Prophecy", @"Your prophecy, which says:
                    'One with the power to vanquish Voldemort.
                    Born to those who have thrice defied him,
                    born as the seventh month dies.
                    And the Dark Lord will mark him as his equal,
                    but he will have power the Dark Lord knows not.
                    And either must die at the hand of the other,
                    for neither can live while the other survives.'");
            // Item wand = new Item("", "");
            // Item wand = new Item("", "");
            // Item wand = new Item("", "");

            //ADD ITEMS TO GAME
            game.Items.Add("wand", wand);
            game.Items.Add("invisibility cloak", cloak);
            game.Items.Add("parchment", parchment);
            game.Items.Add("uranus", uranus);
            game.Items.Add("gear", gear);
            game.Items.Add("key", key);
            game.Items.Add("memory", memory);
            game.Items.Add("prophecy", prophecy);

            //CREATE ROOMS
            //HOGWARTS
            Room boysRoom = new Room("Gryffindor Boy's Dormitory", @"A decent sized, circular room with 5 four-poster beds surrounding the middle of the room. 

                    There's a trunk sitting at the base of your bed. To the east are the exit stairs to the Common Room.");
            Room commonRoom = new Room("Gryffindor Common Room", @"The living quarters of the Gryffindor students in Gryffindor Tower. 

                    There's a large fireplace with a beautiful mantle and a fire burning in it. Stars can be seen outside of the large windows. 

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

                    The other 7 doors are at the remaining cardinal directions and each intermediate direction.");
            Room brainRoom = new Room("The Brain Room", @"A Long rectangular room. There are low hanging lamps that float over countless tanks full of a green solution.

                    Floating in the solution in each tank are what appear to be human brains. There's a bright blue light at the end of the room. 

                    The only exit is to the east.");
            Room deathRoom = new Room("The Death Chamber", @"A square stone chamber that resembles a court room. 

                    In the middle of the room stands a tall stone archway covered in a black veil. 

                    You seem to hear whispers coming from behind the curtain. 

                    You can exit to the south east.");
            Room planetRoom = new Room("The Planet Room", @"Everything is dark. The only light comes from what appear to be planets hanging in mid-air. 

                    It's cold. It feels like you're in space; in fact, you seem to be floating just slightly.

                    The room seems to go one forever, as if there were no walls.

                    Is that a black hole in the distance? 

                    You can float and exit to the north west.");
            Room timeRoom = new Room("The Time Room", @"This rectangular room is filled with sparkling, dancing lights. 

                    Clocks, watches, hourglasses and time-turners are floating just out of reach overhead. 

                    There's a large crystal bell jar in the middle of the room. 

                    There's a grandfather clock standing at the end of the room. 

                    The only door is to the west.");
            Room prophecyRoom = new Room("The Hall of Prophecy", @"This room seems to go on forever. Tall shelves filled with glass orbs; prophecies. 

                    Each prophecy glows with a dim light, clouds swirling inside each orb. This is the place from your dreams. 

                    There appears to be no way out. You can only go north.");

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
            circleRoom.Directions.Add("go west", brainRoom);
            deathRoom.Directions.Add("go south east", circleRoom);
            brainRoom.Directions.Add("go east", circleRoom);
            planetRoom.Directions.Add("go north west", circleRoom);
            timeRoom.Directions.Add("go west", circleRoom);

            //ADD ITEMS TO ROOMS
            boysRoom.Items.Add("wand", wand);
            boysRoom.Items.Add("invisibility cloak", cloak);
            commonRoom.Items.Add("beans", beans);
            entryRoom.Items.Add("parchment", parchment);
            planetRoom.Items.Add("uranus", uranus);
            deathRoom.Items.Add("gear", gear);
            timeRoom.Items.Add("key", key);
            brainRoom.Items.Add("memory", memory);
            prophecyRoom.Items.Add("prophecy", prophecy);

            //ADD ROOMS TO THE GAME
            game.Rooms.Add(boysRoom);//0
            game.Rooms.Add(commonRoom);//1
            game.Rooms.Add(entryRoom);//2
            game.Rooms.Add(hallwayRoom);//3
            game.Rooms.Add(circleRoom);//4
            game.Rooms.Add(planetRoom);//5
            game.Rooms.Add(deathRoom);//6
            game.Rooms.Add(timeRoom);//7
            game.Rooms.Add(brainRoom);//8
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

                          Go <Direction>   Take <Item>   Use <Item>   Search <Item/Room>   Look   Inventory   Quit   
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
            while (playGame)
            {
                #region ROOM ONE
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

                          Go <Direction>   Take <Item>   Use <Item>   Search <Item/Room>   Look   Inventory   Quit   
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
                            if (this.CurrentRoom.Directions.ContainsKey(command.ToLower()))
                            {
                                this.CurrentRoom = this.CurrentRoom.Directions[command.ToLower()];
                                roomOne = false;
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
                            string command2 = command.ToLower().TrimStart('t');
                            string command3 = command2.ToLower().TrimStart('a');
                            string command4 = command3.ToLower().TrimStart('k');
                            string command5 = command4.ToLower().TrimStart('e');
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

                #region ROOM TWO
                else if (this.CurrentRoom == this.Rooms[1])
                {
                    Console.Clear();
                    System.Console.WriteLine(@"
                    --------------------------------------------------------------------------------------------------- 
                                                THE PROPHECY: ESCAPE THE DEPARTMENT OF MYSTERIES           
                    ---------------------------------------------------------------------------------------------------");
                    System.Console.WriteLine(@"
                                                                    COMMANDS:

                          Go <Direction>   Take <Item>   Use <Item>   Search <Item/Room>   Look   Inventory   Quit   
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
                            if (this.CurrentRoom.Directions.ContainsKey(command.ToLower()))
                            {
                                if (this.Player.Inventory.Contains(this.Items["wand"]) && command.ToLower() == "go south")
                                {

                                    if (command.ToLower() == "go south")
                                    {
                                        #region 
                                        System.Console.WriteLine(@"
                            “Alright everybody, let’s do this.”, says Ron.

                    Everyone begins towards to exit of the Common Room.

                            “Are you ready Harry? You've got your wand, right?” (Y/N)

                                    ");
                                        System.Console.Write(">");
                                        string answer = Console.ReadLine();
                                        if (answer.ToLower() == "y")
                                        {
                                            Console.Clear();
                                            System.Console.WriteLine(@"
                    --------------------------------------------------------------------------------------------------- 
                                                THE PROPHECY: ESCAPE THE DEPARTMENT OF MYSTERIES           
                    ---------------------------------------------------------------------------------------------------");

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
                                            Console.Write(">PRESS ENTER<");
                                            Console.ReadLine();
                                            this.CurrentRoom = this.CurrentRoom.Directions[command.ToLower()];
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
                                        #endregion
                                    }
                                    else
                                    {
                                        this.CurrentRoom = this.CurrentRoom.Directions[command.ToLower()];
                                        roomTwo = false;
                                    }
                                }
                                else
                                {
                                    if (command.ToLower() == "go south")
                                    {

                                        System.Console.WriteLine(@"
                            “Harry! You've got to get your wand!” says Hermione.

                            “Oh of course.” you reply.

                            “Come on, mate. You're almost as forgetful as Neville.” jokes Ron.

                    You give Neville an awkward glance and he just shrugs.
                                    
                                    ");
                                    }
                                    else
                                    {
                                        this.CurrentRoom = this.CurrentRoom.Directions[command.ToLower()];
                                        roomTwo = false;
                                    }
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
                            string command2 = command.ToLower().TrimStart('t');
                            string command3 = command2.ToLower().TrimStart('a');
                            string command4 = command3.ToLower().TrimStart('k');
                            string command5 = command4.ToLower().TrimStart('e');
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

                #region ROOM THREE
                else if (this.CurrentRoom == this.Rooms[2])
                {
                    Console.Clear();
                    System.Console.WriteLine(@"
                    --------------------------------------------------------------------------------------------------- 
                                                THE PROPHECY: ESCAPE THE DEPARTMENT OF MYSTERIES           
                    ---------------------------------------------------------------------------------------------------");
                    System.Console.WriteLine(@"
                                                                    COMMANDS:

                          Go <Direction>   Take <Item>   Use <Item>   Search <Item/Room>   Look   Inventory   Quit   
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
                            if (this.CurrentRoom.Directions.ContainsKey(command.ToLower()))
                            {
                                this.CurrentRoom = this.CurrentRoom.Directions[command.ToLower()];
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
                            string command2 = command.ToLower().TrimStart('t');
                            string command3 = command2.ToLower().TrimStart('a');
                            string command4 = command3.ToLower().TrimStart('k');
                            string command5 = command4.ToLower().TrimStart('e');
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
                                this.Player.Score += 12;
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

                #region ROOM FOUR
                else if (this.CurrentRoom == this.Rooms[3])
                {
                    Console.Clear();
                    System.Console.WriteLine(@"
                    --------------------------------------------------------------------------------------------------- 
                                                THE PROPHECY: ESCAPE THE DEPARTMENT OF MYSTERIES           
                    ---------------------------------------------------------------------------------------------------");
                    System.Console.WriteLine(@"
                                                                    COMMANDS:

                          Go <Direction>   Take <Item>   Use <Item>   Search <Item/Room>   Look   Inventory   Quit   
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
                            if (this.CurrentRoom.Directions.ContainsKey(command.ToLower()))
                            {
                                if (command.ToLower() == "go north")
                                {
                                    System.Console.WriteLine(@"
                    You try the handle of the ominous door, but it doesn't seem to budge.

                            “How can we get through!?” blurts Ron.

                            “Hush Ron, there has to be a way.” says Hermione as she slaps his arm.

                            “Ow! Bloody Hell...” 
                                    
                            “Well Harry, what do you say?”");
                                    System.Console.Write(@"
                            >");
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
                                        this.Player.Score += 15;
                                        System.Console.Write(">PRESS ENTER<");
                                        Console.ReadLine();
                                        this.CurrentRoom = this.CurrentRoom.Directions[command.ToLower()];
                                        roomFour = false;
                                    }
                                    else
                                    {
                                        System.Console.WriteLine(@"
                    Nothing happens.
                                        
                                        ");
                                    }
                                }
                                else
                                {
                                    this.CurrentRoom = this.CurrentRoom.Directions[command.ToLower()];
                                    roomFour = false;
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

                            “Alohomora!” tries Hermione, but it doesn't seem to do anything.

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

                #region ROOM FIVE
                else if (this.CurrentRoom == this.Rooms[4])
                {
                    Console.Clear();
                    System.Console.WriteLine(@"
                    --------------------------------------------------------------------------------------------------- 
                                                THE PROPHECY: ESCAPE THE DEPARTMENT OF MYSTERIES           
                    ---------------------------------------------------------------------------------------------------");
                    System.Console.WriteLine(@"
                                                                    COMMANDS:

                          Go <Direction>   Take <Item>   Use <Item>   Search <Item/Room>   Look   Inventory   Quit   
                    --------------------------------------------------------------------------------------------------- 
            ");
                    System.Console.WriteLine($@"
{this.CurrentRoom.Name}            

");
                    bool roomFive = true;
                    while (roomFive)
                    {
                        System.Console.Write(">");
                        string command = Console.ReadLine();
                        this.Player.Moves++;

                        //GO
                        if (command.ToLower().StartsWith("go"))
                        {
                            if (command.ToLower() == "go west")
                            {
                                if (this.Player.Inventory.Contains(this.Items["key"]))
                                {
                                    System.Console.WriteLine(@"
                    You take the golden key from your pocket and enter it into the keyhole.

                    It turns, and clicks open.

                    You keep the key, just in case.

                            (Press Enter to Continue)
                                    
                                    ");
                                    Console.Write(">PRESS ENTER<");
                                    Console.ReadLine();
                                    this.CurrentRoom = this.Rooms[8];
                                    roomFive = false;
                                }
                                else
                                {
                                    System.Console.WriteLine(@"
                    It's locked. No spells work on the door.

                    There's a golden key hole in the handle.
                                            
                                            ");
                                }
                            }
                            else if (command.ToLower() == "go north")
                            {
                                System.Console.Write(@"
                    You approach the door, it's locked.

                    It's giving off a slight hum.

                            “Maybe it's another password,” says Ron.

                            “I don't think so,” replies Hermione “this door looks different.”

                    You look closely and notice the handle is slightly different than the others. This one seems to be newer.

                            “Do you know a spell that could help, Harry?” asks Ginny, smiling at you.
                                
                    >");
                                string spell = Console.ReadLine();
                                if (spell.ToLower() == "revalio completum")
                                {
                                    System.Console.WriteLine(@"
                    The door glows and you see the handle of the door change.

                    Now it looks just like the others.

                    You turn the handle and enter the room. . .The Hall of Prophecies.
                                    
                            (Press Enter to Continue)
                                    ");
                                    System.Console.Write(@">PRESS ENTER<");
                                    Console.ReadLine();
                                    this.Player.Score += 20;
                                    this.CurrentRoom = this.Rooms[9];
                                    roomFive = false;
                                }
                                else
                                {
                                    System.Console.WriteLine(@"
                    Nothing happens.
                                    
                                    ");
                                }
                            }
                            else if (this.CurrentRoom.Directions.ContainsKey(command.ToLower()))
                            {
                                this.CurrentRoom = this.CurrentRoom.Directions[command.ToLower()];
                                roomFive = false;
                            }
                            else if (command.ToLower() == "go south west")
                            {
                                System.Console.WriteLine(@"
                    You try the door, but it's locked.

                    From below the door you can see a pink glow.

                    The group walks up behind you.

                            “It smells like new parchment and freshly mown grass...” says Hermione as she takes a whiff.

                            “I smell fresh chocolate chip cookies!” says Ron in excitement.

                            “Smells like bumbleberry jam.” sighs Luna.

                    You can smell Ginny's perfume, but that's probably just because she's standing next to you.

                            “We should avoid that room.” says Hermione “It must be full of Amortentia, the love potion.”

                    You begin to blush, avoid the gaze of your friends and head back to the middle of the room.
                                
                                ");
                            }
                            else if (command.ToLower() == "go north east")
                            {
                                System.Console.WriteLine(@"
                    You can hear the other side of the door before you even try the handle.

                    It sounds as though an entire band has gone into a full fledged war.

                    Trumpets were shouting, cymballs clanging, drums beating to no particular rhythm.

                    Luna gets an excited look on her face and jumps ahead of you to open the door.

                    As she does so, a particularly aggressive trombone turns to her and begins to fly straight at her, playing Beethoven’s 5th.

                            “Look out!” cries Neville as he reaches for the handle and pulls the door closed.

                            “Oh thank you Neville. I was so caught up in that music.”

                            “Didn't sound like music to me” grumbled Ron. Hermione gave the back of his head a tweak.

                    Everyone moves back to the middle of the room.

                                ");
                            }
                            else if (command.ToLower() == "go north west")
                            {
                                System.Console.WriteLine(@"
                    You walk up to the door. To no surprise, it's locked.

                            “Alohomora!”. . . nothing happens.

                    The door is still locked.

                    You can hear whispering on the other side of the door.

                    You go back to the middle of the room.
                                
                                ");
                            }
                            else if (command.ToLower() == "go south")
                            {
                                System.Console.WriteLine(@"
                    It appears the door locked behind you when you entered this room.

                    No point going out this way.
                                
                                ");
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
                            string command2 = command.ToLower().TrimStart('t');
                            string command3 = command2.ToLower().TrimStart('a');
                            string command4 = command3.ToLower().TrimStart('k');
                            string command5 = command4.ToLower().TrimStart('e');
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
                                System.Console.WriteLine(@"
                    You remember a spell Hermione taught you for the third task in the Triwizard Tournament.

                            “Point Me!” you shout, holding your wand out.

                    A blue streak of light appears from your wand and makes its way to the door to the south east.

                            “Maybe we should go that way.” says Ginny. “Where'd you learn that one Harry?”

                            “Hermione taught it to me.”

                    Hermione blushes and gives the ground a bit of a scuff with her foot.
                                
                                ");
                            }
                            else if (this.Player.Inventory.Contains(this.Items["key"]) && command.ToLower() == "use key")
                            {
                                System.Console.WriteLine(@"
                    Hmm, which door might this go to?

                    The key is golden.
                                
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
                            if (command.ToLower() == "search room")
                            {
                                System.Console.WriteLine(@"
                    The room is completely empty. Other than you and your friends.
                    
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
                                roomFive = false;
                            }
                        }
                    }
                }
                #endregion

                #region ROOM SIX
                else if (this.CurrentRoom == this.Rooms[5])
                {
                    Console.Clear();
                    System.Console.WriteLine(@"
                    --------------------------------------------------------------------------------------------------- 
                                                THE PROPHECY: ESCAPE THE DEPARTMENT OF MYSTERIES           
                    ---------------------------------------------------------------------------------------------------");
                    System.Console.WriteLine(@"
                                                                    COMMANDS:

                          Go <Direction>   Take <Item>   Use <Item>   Search <Item/Room>   Look   Inventory   Quit   
                    --------------------------------------------------------------------------------------------------- 
            ");
                    System.Console.WriteLine($@"
{this.CurrentRoom.Name}            

");
                    bool roomSix = true;
                    while (roomSix)
                    {
                        System.Console.Write(">");
                        string command = Console.ReadLine();
                        this.Player.Moves++;

                        //GO
                        if (command.ToLower().StartsWith("go"))
                        {
                            if (this.CurrentRoom.Directions.ContainsKey(command.ToLower()))
                            {
                                this.CurrentRoom = this.CurrentRoom.Directions[command.ToLower()];
                                roomSix = false;
                            }
                            else if (command.ToLower() == "go")
                            {
                                System.Console.WriteLine(@"
                    You can't wander space aimlessly. Specify a direction.
                    
                    ");
                            }
                            else System.Console.WriteLine(@"
                    You can't go that way.
                    
                    ");
                        }
                        //TAKE
                        if (command.ToLower().StartsWith("take"))
                        {
                            string command2 = command.ToLower().TrimStart('t');
                            string command3 = command2.ToLower().TrimStart('a');
                            string command4 = command3.ToLower().TrimStart('k');
                            string command5 = command4.ToLower().TrimStart('e');
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
                            if (item == "uranus")
                            {
                                this.Player.Score += 8;
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
                                if (this.Player.Inventory.Contains(this.Items["uranus"]))
                                {
                                    System.Console.WriteLine(@"
                    No other use for your wand in here.
                                    
                                    ");
                                }
                                else
                                {

                                    System.Console.WriteLine(@"
                    You reach out your hand towards a blue planet with rings around it.

                            “Reducio!”

                    The humongous planet suddenly shrinks down to the size of a golf ball.

                            “Harry, I doubt this is the best time to be playing with Uranus.” giggles Luna.

                    Uranus floats passed you and you catch Ron holding in a laugh while Hermione rolls her eyes.
                                
                                ");
                                }
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
                            if (command.ToLower() == "search room")
                            {
                                System.Console.WriteLine(@"
                    Mostly it's just planets and stars.

                    You see Jupiter, Saturn, Mars. . .even Pluto way off in the distance.
                    
                    The black hole nearby looks quite ominous.
                                
                                ");
                            }
                            else if (command.ToLower() == "search black hole")
                            {
                                System.Console.WriteLine(@"
                    You begin floating towards the black hole. Light and sound seem to fade.

                            “Harry, you're getting awful close to that black hole.” warns Neville.

                    The others start to float towards you, as if to pull you away from the swirling vortex. 

                    Meteors zoom past as you continue to float forward. Your friends' warnings fading in the background.

                    Do you continue? (Y/N)");
                                System.Console.Write(@"
                    >");
                                string answer = Console.ReadLine();
                                if (answer.ToLower() == "y")
                                {
                                    System.Console.WriteLine(@"
                    You ignore their warnings.

                    The black hole has begun to pull you in.

                    Your friends have grabbed onto you, trying to keep you away from it.

                            “Harry stop!” cries Hermione

                    Just as Ginny is about to speak, the black hole engulfs everyone and everything goes dark.

                    (Press Enter to Continue)
                                    
                                    ");
                                    System.Console.Write(@">PRESS ENTER<");
                                    Console.ReadLine();
                                    this.Player.Score += 20;
                                    this.CurrentRoom = this.Rooms[6];
                                    roomSix = false;
                                }
                                else
                                {
                                    System.Console.WriteLine(@"
                    You heed their warnings and change directions.

                            “Wow Harry, that one was close.” smirked Ron.

                    Everyone seems a bit flustered.
                                    
                                    ");
                                }

                            }
                            else
                            {
                                System.Console.WriteLine(@"
                    Nothing to see here. Just space.

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
                                roomSix = false;
                            }
                        }
                    }
                }
                #endregion

                #region ROOM SEVEN
                else if (this.CurrentRoom == this.Rooms[6])
                {
                    Console.Clear();
                    System.Console.WriteLine(@"
                    --------------------------------------------------------------------------------------------------- 
                                                THE PROPHECY: ESCAPE THE DEPARTMENT OF MYSTERIES           
                    ---------------------------------------------------------------------------------------------------");
                    System.Console.WriteLine(@"
                                                                    COMMANDS:

                          Go <Direction>   Take <Item>   Use <Item>   Search <Item/Room>   Look   Inventory   Quit   
                    --------------------------------------------------------------------------------------------------- 
            ");
                    System.Console.WriteLine($@"
{this.CurrentRoom.Name}       

                    Suddenly you're surrounded by light.

                    You're falling.

                    The ground is getting closer...and fast!

                    What do you do!?");
                    System.Console.Write(@"
                    >");
                    string wand = Console.ReadLine();
                    this.Player.Moves++;

                    if (wand.ToLower() == "use wand")
                    {
                        System.Console.WriteLine(@"
                    Quickly you pull out your wand and shout . . .

                            “Arresto Momentum!”

                    Just as you and your friends are about to hit the floor, everyone comes to a sudden stop.

                    Everyone is floating just a foot above the ground for a split second.

                    Then suddenly everyone falls to the ground.

                            “Quick thinking Harry,” says Ginny, brushing off her jeans.

                    Everyone stands up and looks around the stone chamber.
                        
                        ");
                        this.Player.Score += 5;
                    }
                    else
                    {
                        System.Console.WriteLine(@"
                    Before you can do anything, you and your friends hit the stone floor.

                    Everyone is a bit shaken up. 

                            “Is everyone okay?” asks Hermione.

                            “Just a bit shaken,” answers Luna.

                    The rest of the group answers in soft moans.

                    Everything is okay, you must continue.

                        ");
                        this.Player.Score -= 10;
                    }
                    bool roomSeven = true;
                    while (roomSeven)
                    {
                        System.Console.Write(">");
                        string command = Console.ReadLine();
                        this.Player.Moves++;

                        //GO
                        if (command.ToLower().StartsWith("go"))
                        {
                            if (this.CurrentRoom.Directions.ContainsKey(command.ToLower()))
                            {
                                this.CurrentRoom = this.CurrentRoom.Directions[command.ToLower()];
                                roomSeven = false;
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
                            string command2 = command.ToLower().TrimStart('t');
                            string command3 = command2.ToLower().TrimStart('a');
                            string command4 = command3.ToLower().TrimStart('k');
                            string command5 = command4.ToLower().TrimStart('e');
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
                            if (command.ToLower() == "take gear")
                            {
                                this.Player.Score += 15;
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
                            if (command.ToLower() == "search veil" || command.ToLower() == "search archway" || command.ToLower() == "search stone archway")
                            {
                                System.Console.WriteLine(@"
                    You step closer to the stone archway. Luna follows behind you.

                            “What do you think they're saying?” you ask, hearing the whispers grow louder.

                            “What who's saying?” responds Ron.

                            “Harry, nobody's saying anything. . .” cautions Hermione.

                            “I hear them, Harry,” says Luna, staring into the stone archway.

                    You're standing right next to the archway now. If you only reach out and push aside the veil. . .

                    Do you reach out and move the veil? (Y/N)");
                                System.Console.Write(@"
                    >");
                                string veil = Console.ReadLine();
                                this.Player.Moves++;
                                if (veil.ToLower() == "y")
                                {
                                    System.Console.WriteLine(@"
                    You reach out and push the veil back.

                    Suddenly, behind you, you hear something whoosh by. Hermione, Ginny and Luna all shriek.

                    A black cloaked figure flies overhead.

                    A Dementor. What is a Dementor doing in here!?

                    Other black figures begin to come down on you and your friends.

                    The Demenotrs have circled around you and your friends. 

                    What do you do!?");
                                    System.Console.Write(@"
                    >");
                                    string dementor = Console.ReadLine();
                                    this.Player.Moves++;

                                    if (dementor.ToLower() == "use wand")
                                    {
                                        System.Console.WriteLine(@"
                    With all the power you have, you close your eyes, collect your thoughts, pull out your wand, then open your eyes and cast . . .

                            “Expecto Patronum!”

                    You hold the wand with both hands, pointing it directly up.

                    A bright white-blue light illuminates from the end. 

                    It grows stronger and stronger as the Dementors try to fight it.

                    Hermione, Neville, Ron, Ginny and Luna all join. Each one casting their own patronus charm.

                    Suddenly, a huge white figure emerges from the tip of your wand. A stag. It stands tall and mighty.

                    It faces a Dementor head on and charges, knocking the Dementor out of sight.

                    All around you can see your friends' patronuses. A rabbit, a jack russel, an otter, a horse and a great mass of light that looks like a cloud.

                    Each one attacks the Dementors, driving them away.

                    You and your friends are safe now.
                                        
                                        ");
                                        this.Player.Score += 10;
                                    }
                                    else
                                    {
                                        System.Console.WriteLine(@"
                    You can feel the cold of the Dementors taking over.

                    Your friends break out of the circle and begin to run for the door to the south east.

                    You follow them, the Dementors chasing after you.

                    Ron opens the door, and you see the circular room ahead. Everybody makes it through the door and you slam it shut.

                    You can hear it lock behind you.

                    You and your friends are safe...for now.

                    (Press Enter to Continue)                    
                                        
                                        ");
                                        System.Console.Write(">PRESS ENTER<");
                                        Console.ReadLine();
                                        this.Player.Moves++;
                                        this.CurrentRoom = this.Rooms[4];
                                        roomSeven = false;
                                    }

                                }
                                else
                                {
                                    System.Console.WriteLine(@"
                            “Harry,” Luna states “I think we'd better leave them alone.”

                    You retract your hand and take a step back.

                            “You're right. Let's move on.”

                                    ");
                                }
                            }
                            else if (command.ToLower() == "search room")
                            {
                                System.Console.WriteLine(@"
                    Around the stone chamber you see lines of benches.

                    Besides the stone archway, there also appears to be a podium. 

                    Perhaps this was were a judge would stand?

                    Up the benches to the south east is an exit door.

                                ");
                            }
                            else if (command.ToLower() == "search podium")
                            {
                                System.Console.WriteLine(@"
                    You walk up to the podium. There isn't anything on top of it.

                    The podium is made of a dark brown stone. It's rough. You can see marking on the top, where a gavel might hit it.

                    Sitting on the ground near the base of the podium, sits a small metal gear.

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
                                roomSeven = false;
                            }
                        }
                    }
                }
                #endregion

                #region ROOM EIGHT
                else if (this.CurrentRoom == this.Rooms[7])
                {
                    Console.Clear();
                    System.Console.WriteLine(@"
                    --------------------------------------------------------------------------------------------------- 
                                                THE PROPHECY: ESCAPE THE DEPARTMENT OF MYSTERIES           
                    ---------------------------------------------------------------------------------------------------");
                    System.Console.WriteLine(@"
                                                                    COMMANDS:

                          Go <Direction>   Take <Item>   Use <Item>   Search <Item/Room>   Look   Inventory   Quit   
                    --------------------------------------------------------------------------------------------------- 
            ");
                    System.Console.WriteLine($@"
{this.CurrentRoom.Name}            

");
                    bool roomEight = true;
                    while (roomEight)
                    {
                        System.Console.Write(">");
                        string command = Console.ReadLine();
                        this.Player.Moves++;

                        //GO
                        if (command.ToLower().StartsWith("go"))
                        {
                            if (this.CurrentRoom.Directions.ContainsKey(command.ToLower()))
                            {
                                this.CurrentRoom = this.CurrentRoom.Directions[command.ToLower()];
                                roomEight = false;
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
                            else if (this.Player.Inventory.Contains(this.Items["gear"]) && command.ToLower() == "use gear")
                            {
                                System.Console.WriteLine(@"
                    You walk up to the Grandfather Clock.

                    It's body is made almost entirely from moving parts and gears.

                    But some parts don't seem to be moving. It's hard to tell where the gear would go.

                    What do you do?");
                                Console.Write(@"
                    >");
                                string fix = Console.ReadLine();
                                this.Player.Moves++;
                                if (fix.ToLower() == "use wand")
                                {
                                    System.Console.WriteLine(@"
                    You hold out the gear with one hand, and take out your wand in the other.

                            “Reparo!”

                    The gear floats out of your hand and towards the side of the Grandfather Clock.

                    There's a bit of a grinding, a small spark, and then suddenly you can see the pendulum swinging and hear the clock ticking.
                                    
                    The hands on the face swirl around and around and suddenly, you hear a clink on the ground in front of you.

                    A small golden key appears to have fallen out of the clock. You better take it, just in case.
                                    ");
                                    this.Player.Inventory.Remove(this.Items["gear"]);
                                    this.Player.Inventory.Add(this.CurrentRoom.Items["key"]);
                                    System.Console.WriteLine($@"
                    {this.CurrentRoom.Items["key"].Name} added to your inventory.
                    
                    ");
                                    this.CurrentRoom.Items.Remove("key");
                                    this.Player.Score += 10;
                                }
                                else
                                {
                                    System.Console.WriteLine(@"
                    Hmm, nothing seemed to happen.
                                    
                                    ");
                                }
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
                            if (command.ToLower() == "search bell jar")
                            {
                                System.Console.WriteLine(@"
                    The bell jar stands about two meters tall.

                    Inside, you see a hummingbird, floating just below eyelevel.

                    It's surrounded by a golden dust. It looks just like the dust inside of a time-turner.

                            “I think that's time.” says Hermione, covering her mouth in awe.

                            “Yeah, it looks like the inside of your old time-turner,” you reply.

                    As the hummingbird flies higher, it suddenly deteriorates and becomes pure bone.

                    It then slowly makes it's way downward. Turning back into a young hummingbird and a baby bird.
                    
                    And then, as it reaches just centimeters above the ground. . .

                            “Oh my, it's turned back into an egg,” says Luna.

                    And indeed it had. What a strange bell jar. A jar of time.
                                
                                ");
                            }
                            else if (command.ToLower() == "search clock" || command.ToLower() == "search grandfather clock")
                            {
                                System.Console.WriteLine(@"
                    You approach the Grandfather Clock.

                    The entire room is ticking. . .but this clock doesn't seem to be.

                            “Hmm, this one appears to be broken,” states Hermione.

                    You can see that only some of the gears seems to be moving.

                    It's quite easy to notice, seeing as the entire clock's body is made of gears and dials.
                                
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
                                roomEight = false;
                            }
                        }
                    }
                }
                #endregion

                #region ROOM NINE
                else if (this.CurrentRoom == this.Rooms[8])
                {
                    Console.Clear();
                    System.Console.WriteLine(@"
                    --------------------------------------------------------------------------------------------------- 
                                                THE PROPHECY: ESCAPE THE DEPARTMENT OF MYSTERIES           
                    ---------------------------------------------------------------------------------------------------");
                    System.Console.WriteLine(@"
                                                                    COMMANDS:

                          Go <Direction>   Take <Item>   Use <Item>   Search <Item/Room>   Look   Inventory   Quit   
                    --------------------------------------------------------------------------------------------------- 
            ");
                    System.Console.WriteLine($@"
{this.CurrentRoom.Name}            

");
                    bool roomNine = true;
                    while (roomNine)
                    {
                        System.Console.Write(">");
                        string command = Console.ReadLine();
                        this.Player.Moves++;

                        //GO
                        if (command.ToLower().StartsWith("go"))
                        {
                            if (this.CurrentRoom.Directions.ContainsKey(command.ToLower()))
                            {
                                this.CurrentRoom = this.CurrentRoom.Directions[command.ToLower()];
                                roomNine = false;
                            }
                            else if (command.ToLower() == "go west")
                            {
                                System.Console.WriteLine(@"
                    You decide to make a run for it.

                    Quickly, you head towards the blue orb.

                    The brains suddenly spring from the tanks, green goo flinging everywhere.

                    You keep running, but the brains are flying around you, leaving trails of memories behind them.

                    You've made it to the orb. . .the brains have stopped. . .but you're covered in goo.
                                
                                ");
                                this.Player.Score -= 15;
                                if (this.Player.Inventory.Contains(this.Items["memory"]))
                                {
                                    System.Console.WriteLine("");
                                }
                                else
                                {

                                    System.Console.Write(@"
                    Will you touch the glowing blue orb? (Y/N)
                                
                    >");
                                    string orb = Console.ReadLine();
                                    if (orb.ToLower() == "y")
                                    {
                                        System.Console.WriteLine(@"
                    You touch it. Immediately a memory flashes through your mind. . . but this isn't your memory.

                    Your head spins, and suddenly you're back on the other side of the room with your friends.

                            “Oh my. . . ” Hermione says as she shakes her head. “Scourgify!”

                    You feel a rush of cool air and the green goo disappears.

                            “Thanks Hermione.”

                                        ");
                                        this.Player.Inventory.Add(this.Items["memory"]);
                                        System.Console.WriteLine($@"
                    {this.Items["memory"].Name} added to your inventory.
                    
                    ");
                                        this.CurrentRoom.Items.Remove("memory");
                                    }
                                    else
                                    {
                                        System.Console.WriteLine(@"
                    You decide it would be better to leave the orb alone.

                    You run back to the east side of the room, completely covered in goo.

                            “Oh my. . . ” Hermione says as she shakes her head. “Scourgify!”

                    You feel a rush of cool air and the green goo disappears.

                            “Thanks Hermione.”
                                        
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
                            else if (this.Player.Inventory.Contains(this.Items["invisibility cloak"]) && command.ToLower() == "use invisibility cloak")
                            {
                                System.Console.WriteLine(@"
                    You throw the invisibility cloak over yourself.

                    Slowly you make your way to the other side of the room.

                    It seems as though the brains don't even notice you!

                            “Nice thinking, Harry!” shouts Ginny.

                    You continue to the blue glow.

                    Once your reach it, you find that it's a floating orb. It looks a lot like the prophecies you saw in your dreams.

                    You can't help but reach out and touch it. Immediately a memory flashes through your mind. . . but this isn't your memory.

                    Your head spins, and suddenly you're back on the other side of the room with your friends.
                                
                                ");
                                this.Player.Inventory.Add(this.Items["memory"]);
                                System.Console.WriteLine($@"
                    {this.Items["memory"].Name} added to your inventory.
                    
                    ");
                                this.CurrentRoom.Items.Remove("memory");
                                this.Player.Score += 25;
                            }
                            else if (command.ToLower() == "use wand")
                            {
                                System.Console.WriteLine(@"
                            “Accio orb!” you cast.

                    You're not too surprised, but it didn't do anything.

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
                            if (command.ToLower() == "search tank" || command.ToLower() == "search tanks")
                            {
                                System.Console.WriteLine(@"
                    The closer you get to the tanks, the more the brains floating in the green goo begin to move.

                    It's almost as if the brains can see you!

                            “Ew!” cries Neville “Those brains are moving!!”

                    You take a step back. . .the brains begin to settle down.

                            “How are we going to get by them without being seen?” questions Ginny.

                                ");
                            }
                            else if (command.ToLower() == "search room")
                            {
                                System.Console.WriteLine(@"
                    There's a bright blue light across the room to the west.

                            “That looks important,” says Ron.

                            “What makes you think that, genius?” claps Ginny.

                    They stare each other down.

                    You gaze at the blue light. . .you've got to go to it. 
                                
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
                                roomNine = false;
                            }
                        }
                    }
                }
                #endregion

                #region ROOM TEN
                else if (this.CurrentRoom == this.Rooms[9])
                {
                    Console.Clear();
                    System.Console.WriteLine(@"
                    --------------------------------------------------------------------------------------------------- 
                                                THE PROPHECY: ESCAPE THE DEPARTMENT OF MYSTERIES           
                    ---------------------------------------------------------------------------------------------------");
                    System.Console.WriteLine(@"
                                                                    COMMANDS:

                          Go <Direction>   Take <Item>   Use <Item>   Search <Item/Room>   Look   Inventory   Quit   
                    --------------------------------------------------------------------------------------------------- 
            ");
                    System.Console.WriteLine($@"
{this.CurrentRoom.Name}

                    As the door closes behind you, it dissolves into a golden dust.

                    The only way to go is north.

");
                    bool ready = false;
                    int north = 0;
                    bool roomTen = true;
                    while (roomTen)
                    {
                        System.Console.Write(">");
                        string command = Console.ReadLine();
                        this.Player.Moves++;

                        //GO
                        if (command.ToLower().StartsWith("go"))
                        {
                            if (command.ToLower() == "go north" && north == 0)
                            {
                                System.Console.WriteLine(@"
                    You and your friends rush down the hall.

                            “We're close, I can feel it!” you shout.

                    Frantically, you search the shelves as you pass them. . .

                    But suddenly you're brought to a halt by a hooded figure.

                    A Death Eater. One of Voldemort's followers.

                    Immediately, you cast a disarming spell at him, but he blocks it.

                            “Stay back!” you shout to your friends, but they're having trouble too.

                            “Petrificus Totalus!”

                            “Protego!”

                            “Expelliarmus!”

                    Your friends are casting spells at a number of Death Eaters that have now surrounded your group.

                    Prophecies are crashing to the ground, exploding into blue dust as they hit.

                    You give Ginny a determined look and, determined, she points her wand at two of the Death Eaters. . .

                            “Reducto!”

                    They go flying back into the darkness. The remaining Death Eaters turn into a cloud of darkness and fly off.

                    They've retreated. The only way to go is north.    

                                ");
                                north++;
                                this.Player.Score += 10;
                            }
                            else if (command.ToLower() == "go north" && north == 1)
                            {
                                System.Console.WriteLine(@"
                    You and your friends continue forward.

                            “Is everyone okay?” ask Ron.

                    Hermione and Luna nod. Ginny gives a muddled “Yes.”

                    Neville doesn't respond. He looks quite shaken.

                    You stop.

                            “It's going to be alright, Neville,” you say.

                            “Thanks Harry, I've never felt so brave.”

                    The only way to go is north.
                                
                                ");
                                north++;
                                this.Player.Score += 15;
                            }
                            else if (command.ToLower() == "go north" && north == 2)
                            {
                                System.Console.WriteLine(@"
                    You continue a bit farth down the endless shelves.

                            “Wait. . .this is it.”

                    You approach a blue orb, you can hear it.

                    As you get closer you reach out and grab it.

                    You can hear what it says. . .

                            “One with the power to vanquish Voldemort.

                            Born to those who have thrice defied him,

                            born as the seventh month dies.

                            And the Dark Lord will mark him as his equal,

                            but he will have power the Dark Lord knows not.

                            And either must die at the hand of the other,

                            for neither can live while the other survives.”
                                
                                ");
                                north++;
                                this.Player.Score += 20;
                                ready = true;
                            }
                            else if (command.ToLower() == "go")
                            {
                                System.Console.WriteLine(@"
                    You can't wander these halls aimlessly. Specify a direction.
                    
                    ");
                            }
                            else
                            {
                                System.Console.WriteLine(@"
                    You can't go that way.
                    
                    ");
                            }
                        }
                        //TAKE
                        if (command.ToLower().StartsWith("take"))
                        {
                            string command2 = command.ToLower().TrimStart('t');
                            string command3 = command2.ToLower().TrimStart('a');
                            string command4 = command3.ToLower().TrimStart('k');
                            string command5 = command4.ToLower().TrimStart('e');
                            string item = command5.TrimStart(' ').ToLower();
                            if (this.CurrentRoom.Items.ContainsKey(item) && ready == true)
                            {
                                this.Player.Inventory.Add(this.CurrentRoom.Items[item]);
                                System.Console.WriteLine($@"
                    {this.CurrentRoom.Items[item].Name} added to your inventory.
                    
                    ");
                                this.CurrentRoom.Items.Remove(item);
                                this.Player.Score += 35;

                                System.Console.WriteLine(@"
                    You now hold the prophecy. Voldemort will never know these words.

                            “Now how do we escape?” asks Ron.

                            “I've got an idea,” replies Hermione.

                    She closes her eyes and holds the tip of her wand to her lips. She whispers.

                    As she finishes, blue mist emerges from her wand and forms an otter.

                    The otter swims up and out of the Hall of Prophecies.

                            “What did you do?” asks Luna.

                            “I sent a message to Dumbledore. I'm sure he'll send help now.” 

                    And sure enough, a mass of light appeared to the south. A huge cloud of light.

                    And there stood Sirius, Tonks, Lupin and other members of the Order of the Phoenix.

                            “Come now, Harry.” speaks Siruis “Let's get out of here.”

                    You run up and give Sirius a hug.

                            “You'll need to use your wand Harry.”

                                ");
                            }
                            else
                            {
                                System.Console.WriteLine(@"
                    You can't do that.

                                ");
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
                            else if (this.Player.Inventory.Contains(this.Items["prophecy"]) && command.ToLower() == "use wand")
                            {
                                //END STORY

                                System.Console.WriteLine(@"
                    You raise your wand and join the members of the Order.

                    A white cloud surrounds everyone and you lift off the ground.

                    As you and the rest of the Order begin to leave the Department of Mysteries, you can hear a laugh.

                    Black smoke surrounds you and suddenly you're back in the Death Room.

                    You've been stopped by Bellatrix and her Death Eater friends.

                    A battle breaks out, filling the entire room with curses and charms.

                    As you battle with Sirius next to the archway, you hear a voice behind you scream.

                            “Avada Kadavra!”

                    There's a flash of green light and Sirius stops moving. You catch him before he falls to the ground. All life as left him.
                    
                    The whispers of the stone archway become louder and the veil opens up, taking Sirius' body from your arms.

                            Bellatrix runs away screaming and taunting, “I killed Sirius Black! I killed Sirius Black.”

                    You have no choice but to chase her down. As you run, the prophecy falls from your hand and smashes to the ground.

                            “Crucio!” you scream at her, shooting a bolt of red light from your wand.

                    She falls to the ground, squirming. Before you can do anything else, Lupin grabs your shoulder and the white cloud of light surrounds you again.

                    You've escaped. The prophecy is gone. Sirius is dead. . .but your friends and you are safe.

                    This is only the beginning of a new Wizarding War.
                                
                                ");
                                Console.Write(@"
                    >PRESS ENTER<
                                
                                ");
                                Console.ReadLine();

                                System.Console.WriteLine(@"
                            __   __                    _____                                           _   _ 
                            \ \ / /   ___    _   _    | ____|  ___    ___    __ _   _ __     ___    __| | | |
                             \ V /   / _ \  | | | |   |  _|   / __|  / __|  / _` | | '_ \   / _ \  / _` | | |
                              | |   | (_) | | |_| |   | |___  \__ \ | (__  | (_| | | |_) | |  __/ | (_| | |_|
                              |_|    \___/   \__,_|   |_____| |___/  \___|  \__,_| | .__/   \___|  \__,_| (_)
                                                                                   |_|        
                    ---------------------------------------------------------------------------------------------------
                                                                       _ __
                                      ___                             | '  \
                                 ___  \ /  ___         ,'\_           | .-. \        /|
                                 \ /  | |,'__ \  ,'\_  |   \          | | | |      ,' |_   /|
                               _ | |  | |\/  \ \ |   \ | |\_|    _    | |_| |   _ '-. .-',' |_   _
                              // | |  | |____| | | |\_|| |__    //    |     | ,'_`. | | '-. .-',' `. ,'\_
                              \\_| |_,' .-, _  | | |   | |\ \  //    .| |\_/ | / \ || |   | | / |\  \|   \
                               `-. .-'| |/ / | | | |   | | \ \//     |  |    | | | || |   | | | |_\ || |\_|
                                 | |  | || \_| | | |   /_\  \ /      | |`    | | | || |   | | | .---'| |
                                 | |  | |\___,_\ /_\ _      //       | |     | \_/ || |   | | | |  /\| |
                                 /_\  | |           //_____//       .||`      `._,' | |   | | \ `-' /| |
                                      /_\           `------'        \ |              `.\  | |  `._,' /_\
                                                                     \|                    `.\
                                ");
                                roomTen = false;
                                playGame = false;
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
                            if (command.ToLower() == "search room" || command.ToLower() == "search shelves")
                            {
                                System.Console.WriteLine(@"
                    You look along the shelves nearby. . .

                    Where could your prophecy be?
                               
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
                                roomTen = false;
                            }
                        }
                    }
                }
                #endregion
            }
            System.Console.WriteLine(@"
                    --------------------------------------------------------------------------------------------------- 
                                                THE PROPHECY: ESCAPE THE DEPARTMENT OF MYSTERIES           
                    ---------------------------------------------------------------------------------------------------");
            System.Console.WriteLine($@"
                                                                THE END

                                                Final Score: {this.Player.Score}        Total Moves: {this.Player.Moves}
            ");
        }
    }
}
