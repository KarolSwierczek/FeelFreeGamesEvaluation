using UnityEngine;

namespace FeelFreeGames.Evaluation.Utils
{
    public static class MathUtils
    {
        public static int Mod(int k, int n)
        {
            return ((k %= n) < 0) ? k+n : k;
        }

        public static Vector2Int IndexToCoords(int index, int width)
        {
            return new Vector2Int(index % width, index / width);
        }

        public static int CoordsToIndex(Vector2Int coords, int width)
        {
            return coords.x + coords.y * width;
        }
        
        public static Vector2Int ClampCoords(Vector2Int coords, Vector2Int dimensions)
        {
            var clampedCoords = coords;
            
            if (coords.x >= dimensions.x)
            {
                clampedCoords.x = dimensions.x - 1;
            }
            else if (coords.x < 0)
            {
                clampedCoords.x = 0;
            }
            
            if (coords.y >= dimensions.y)
            {
                clampedCoords.y = dimensions.y - 1;
            }
            else if (coords.y < 0)
            {
                clampedCoords.y = 0;
            }
            
            return clampedCoords;
        }
    }
}