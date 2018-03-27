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


        public Game()
        {
            Rooms = new List<Room>();
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
            // Item wand = new Item("", "");
            // Item wand = new Item("", "");
            // Item wand = new Item("", "");
            // Item wand = new Item("", "");
            // Item wand = new Item("", "");
            // Item wand = new Item("", "");
            // Item wand = new Item("", "");
            // Item wand = new Item("", "");
            // Item wand = new Item("", "");
            // Item wand = new Item("", "");
            // Item wand = new Item("", "");

            //CREATE ROOMS
            //HOGWARTS
            Room boysRoom = new Room("Gryffindor Boy's Dormitory", @"A decent sized, circular room with 5 four poster beds surrounding the middle of the room. 
            There's a trunk sitting at the base of your bed. To the east are the exit stairs to the Common Room.");
            Room commonRoom = new Room("Gryffindor Common Room", @"The living quarters of the Gryffindor students in Gryffindor Tower. 
            The fire is roaring in the large fireplace which provides light for the room. Stars can be seen outside of the large windows. 
            To the west is the boys dormitory, to the east is the girl's dormitory, and to the south is the exit.");
            //MINISTRY OF MAGIC
            Room entryRoom = new Room("The Department of Mysteries", @"Smooth black marble slates the walls and floor. The ceilings are high. It's not very bright. 
            The only light comes from the blue-flame torches along the walls. The elevator door to the south is closed. 
            The only way to go is down the hall to the north.");
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
                if (this.CurrentRoom == this.Rooms[0])
                {
                    bool roomOne = true;
                    while (roomOne)
                    {

                        System.Console.Write(">");
                        string command = Console.ReadLine();

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
            You can't wander these halls aimlessly. Specify a direction.");
                            }
                            else System.Console.WriteLine(@"
            You can't go that way.");
                        }
                        //USE
                        if (command.ToLower().StartsWith("use"))
                        {
                            if (this.Player.Inventory.Count == 0)
                            {
                                System.Console.WriteLine(@"
            You don't have anything to use.");
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
                            if (this.CurrentRoom.Items[item] != null)
                            {
                                this.Player.Inventory.Add(this.CurrentRoom.Items[item]);
                                System.Console.WriteLine($@"
            {this.CurrentRoom.Items[item].Name} added to your inventory.");
                                this.CurrentRoom.Items.Remove(item);
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
                            if (command.ToLower() == "search trunk")
                            {
                                System.Console.WriteLine(@"
            You open the trunk to see a copy of 'Quidditch Through the Ages'. 
            Your potions cauldron. Some school robes. And sitting right on top of the robes is your wand. 
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
                            System.Console.WriteLine(@"
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
                            if(quit.ToLower() == "y")
                            {
                                playGame = false;
                                roomOne = false;
                            }
                        }
                    }
                }
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
            ");
                    bool roomtwo = true;
                    while (roomtwo)
                    {
                        System.Console.Write(">");
                        string command = Console.ReadLine();
                    }
                }
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