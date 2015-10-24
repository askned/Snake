using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
	class Walls
	{
		List<Figure> wallList;
        Random random = new Random();

        public Walls( int mapWidth, int mapHeight )
		{
			wallList = new List<Figure>();

			// Отрисовка рамочки
			HorizontalLine upLine = new HorizontalLine( 0, mapWidth - 2, 0, '+' );
			HorizontalLine downLine = new HorizontalLine( 0, mapWidth - 2, mapHeight - 1, '+' );
			VerticalLine leftLine = new VerticalLine( 0, mapHeight - 1, 0, '+' );
			VerticalLine rightLine = new VerticalLine( 0, mapHeight - 1, mapWidth - 2, '+' );

			wallList.Add( upLine );
			wallList.Add( downLine );
			wallList.Add( leftLine );
			wallList.Add( rightLine );
		}

		internal bool IsHit( Figure figure )
		{
			foreach(var wall in wallList)
			{
				if(wall.IsHit(figure))
				{
					return true;
				}
			}
			return false;
		}

		public void Draw()
		{
			foreach ( var wall in wallList )
			{
				wall.Draw();
			}
		}
        public void AddWall(int mapWidth, int mapHeight)
        {
            int x = random.Next(2, mapWidth - 4);
            int y = random.Next(2, mapHeight - 4);
            HorizontalLine wallNew = new HorizontalLine(x, x+1, y, '#');
            wallNew.Draw();
            wallList.Add(wallNew);

        }
	}
}
