using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Snake
{
	class Program
	{
        private static int scrWaight = 80;
        private static int scrHeight = 25;


        static void Main( string[] args )
		{
            int score = 0;
            int sleepTime = 100;
            Console.SetBufferSize(scrWaight, scrHeight);

			Walls walls = new Walls(scrWaight, scrHeight);
			walls.Draw();

			// Отрисовка точек			
			Point p = new Point( 4, 5, '*' );
			Snake snake = new Snake( p, 4, Direction.RIGHT );
			snake.Draw();

			FoodCreator foodCreator = new FoodCreator(scrWaight, scrHeight, '$' );
			Point food = foodCreator.CreateFood();
			food.Draw();

			while (true)
			{
				if ( walls.IsHit(snake) || snake.IsHitTail() )
				{
					break;
				}
				if(snake.Eat( food ) )
				{
                    food.ClearFood();
                    food = foodCreator.CreateFood();
                  	food.Draw();
                    sleepTime = sleepTime - 5;
                    score = score + 10;
                   walls.AddWall(scrWaight, scrHeight);
                }
				else
				{
					snake.Move();
				}

				Thread.Sleep(sleepTime);
				if ( Console.KeyAvailable )
				{
					ConsoleKeyInfo key = Console.ReadKey();
					snake.HandleKey( key.Key );
				}
			}
			WriteGameOver(score);
			Console.ReadLine();
      }


		static void WriteGameOver(int score)
		{
			int xOffset = scrWaight / 3;
			int yOffset = scrHeight/ 3;
			Console.ForegroundColor = ConsoleColor.Red;
			Console.SetCursorPosition( xOffset, yOffset++ );
			WriteText( "============================", xOffset, yOffset++ );
			WriteText( "И Г Р А    О К О Н Ч Е Н А", xOffset + 1, yOffset++ );
			yOffset++;
			WriteText( "Автор: Денис", xOffset + 1, yOffset++ );
		
            WriteText("Ваш рекорд = " +score, xOffset + 5, yOffset++);
            WriteText( "============================", xOffset, yOffset++ );
		}

		static void WriteText( String text, int xOffset, int yOffset )
		{
			Console.SetCursorPosition( xOffset, yOffset );
			Console.WriteLine( text );
		}

	}
}
