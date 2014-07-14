using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class AcademyPopcornMain
    {
        const int WorldRows = 23;
        const int WorldCols = 40;
        const int RacketLength = 6;

        static void Initialize(Engine engine)
        {
            int startRow = 3;
            int startCol = 2;
            int endCol = WorldCols - 2;

            for (int i = startCol; i < endCol; i++)//Constucting blocks
            {
                Block currBlock = new Block(new MatrixCoords(startRow, i));

                if (i == 7)//Exercise 10
                {
                    currBlock = new ExplodingBlock(new MatrixCoords(startRow, i));
                }
                else if (i == endCol - 3)//Exersice 12
                {
                    currBlock = new GiftBlock(new MatrixCoords(startRow, i));
                }

                engine.AddObject(currBlock);
            }

            //Original ball
            Ball theBall = new Ball(new MatrixCoords(WorldRows / 2, 0), new MatrixCoords(-1, 1));//Constructing the ball\
            engine.AddObject(theBall);

            //Meteorite ball
            //Ball theMeteoriteBall = new MeteoriteBall(new MatrixCoords(WorldRows / 2, 0), new MatrixCoords(-1, 1));//Constructing the Meteorite ball
            //engine.AddObject(theMeteoriteBall);

            //Unstoppable ball
            //Ball theUnstoppableBall = new UnstoppableBall(new MatrixCoords(WorldRows / 2, 0), new MatrixCoords(-1, 1));//Constructing the Meteorite ball
            //engine.AddObject(theUnstoppableBall);

            //Adding the unpassable blocks
            for (int i = 2; i < WorldCols / 2 + 5; i += 4)
            {
                //engine.AddObject(new UnpassableBlock(new MatrixCoords(4, i)));//Exercise 9
            }

            Racket theRacket = new Racket(new MatrixCoords(WorldRows - 1, WorldCols / 2), RacketLength);//Constructing the racket

            engine.AddObject(theRacket);

            for (int i = 0; i < WorldRows; i++)
            {
                IndestructibleBlock leftWall = new IndestructibleBlock(new MatrixCoords(i, 0));//Constructing the left wall
                IndestructibleBlock rightWall = new IndestructibleBlock(new MatrixCoords(i, WorldCols - 1));//Constructing the right wall
                engine.AddObject(leftWall);
                engine.AddObject(rightWall);
            }
            for (int i = 0; i < WorldCols; i++)
            {
                IndestructibleBlock topHedge = new IndestructibleBlock(new MatrixCoords(0, i));//Constructing the top wall
                engine.AddObject(topHedge);
            }

            engine.AddObject(new TrailObject(new MatrixCoords(10, 15), new char[,] { { 'E', 'X', 'E', 'R', 'C', 'I', 'C', 'E', ' ', '5', } }, 100));//Exercise 5
        }

        static void Main(string[] args)
        {
            IRenderer renderer = new ConsoleRenderer(WorldRows, WorldCols);
            IUserInterface keyboard = new KeyboardInterface();

            Engine gameEngine = new Engine(renderer, keyboard, 100);

            keyboard.OnLeftPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketLeft();
            };

            keyboard.OnRightPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketRight();
            };

            Initialize(gameEngine);

            gameEngine.Run();
        }
    }
}
