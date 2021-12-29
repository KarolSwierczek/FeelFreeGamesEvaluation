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

        /// <summary>
        /// Clamps coordinates to fit inside given matrix dimensions
        /// </summary>
        /// <returns>
        /// true if at least one component of the coordinates already fit inside the dimensions,
        /// false otherwise
        /// </returns>
        public static bool ClampCoords(ref Vector2Int coords, Vector2Int dimensions)
        {
            var fitsHorizontally = true;
            var fitsVertically = true;
            
            if (coords.x >= dimensions.x)
            {
                fitsHorizontally = false;
                coords.x = dimensions.x - 1;
            }
            else if (coords.x < 0)
            {
                fitsHorizontally = false;
                coords.x = 0;
            }
            
            if (coords.y >= dimensions.y)
            {
                fitsVertically = false;
                coords.y = dimensions.y - 1;
            }
            else if (coords.y < 0)
            {
                fitsVertically = false;
                coords.y = 0;
            }

            return fitsHorizontally || fitsVertically;
        }
    }
}