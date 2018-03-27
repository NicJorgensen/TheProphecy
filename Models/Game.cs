using System;
using System.Collections.Generic;

namespace theprophecy.Models
{
    public class Game : IGame
    {
        public Room CurrentRoom { get; set; }
        public List<Room> Rooms { get; set; }


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

            //CREATE ITEMS
            Item wand = new Item("Wand", "");
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
            Room boysRoom = new Room("Gryffindor Boy's Dormitory", "A decent sized, circular room with 5 four poster beds surrounding the middle of the room. There's a trunk, sitting open, at the base of your bed. To the east are the exit stairs to the Common Room.");
            Room commonRoom = new Room("Gryffindor Common Room", "");
            //MINISTRY OF MAGIC
            Room entryRoom = new Room("The Department of Mysteries", "");
            Room hallwayRoom = new Room("Hallway", "");
            Room circleRoom = new Room("Circle Room", "");
            Room brainRoom = new Room("The Brain Room", "");
            Room loveRoom = new Room("The Love Chamber", "");
            Room deathRoom = new Room("The Death Chamber", "");
            Room planetRoom = new Room("The Planet Room", "");
            Room timeRoom = new Room("The Time Room", "");
            Room prophecyRoom = new Room("The Hall of Prophecy", "");
            Room musicRoom = new Room("The Music Room", "");


            //ADD DIRECTIONS TO ROOMS
            boysRoom.Directions.Add("east", commonRoom);
            commonRoom.Directions.Add("west", boysRoom);
            

            //ADD ITEMS TO ROOMS
            boysRoom.Items.Add(wand);

            //ADD EVERYTHING TO THE GAME
            game.Rooms.Add(boysRoom);
            game.Rooms.Add(commonRoom);
            game.Rooms.Add(entryRoom);
            game.Rooms.Add(hallwayRoom);
            game.Rooms.Add(circleRoom);
            game.Rooms.Add(brainRoom);
            game.Rooms.Add(loveRoom);
            game.Rooms.Add(deathRoom);
            game.Rooms.Add(planetRoom);
            game.Rooms.Add(timeRoom);
            game.Rooms.Add(prophecyRoom);
            game.Rooms.Add(musicRoom);

            game.PlayGame();
        }

        public void PlayGame()
        {
            Console.Clear();
            this.CurrentRoom = this.Rooms[0];
            System.Console.WriteLine(@"
                    --------------------------------------------------------------------------------------------------- 
                                                THE PROPHECY: ESCAPE THE DEPARTMENT OF MYSTERIES           
                    ---------------------------------------------------------------------------------------------------");
            System.Console.WriteLine(@"
                                                                    COMMANDS:

                                    Go <Direction>   Use <ItemName>   Take <ItemName>   Look   Inventory   Quit   
                    --------------------------------------------------------------------------------------------------- 
            ");
            System.Console.WriteLine($@"
{this.CurrentRoom.Name}

            There’s a flash of green light. You hear a woman’s scream. Everything goes dark. Everything goes silent. . .

                    “Harry. . . Harry, wake up. Come on, Harry. It’s time!”

            You begin to open your eyes, the light cast from Ron’s wand blinding you.

                    “It’s time to go. Luna, Neville, Ginny and Hermione are all ready. Grab your stuff.”

            You sit up and everything begins to solidify. Yes! It's time to do this. Ron hurries out of the Boy's Dormitory. You get out of bed.
            ");
        }

        public void UseItem(string itemName)
        {

        }
    }
}