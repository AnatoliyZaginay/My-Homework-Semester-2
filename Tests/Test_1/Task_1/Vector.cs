using System;
using System.Collections.Generic;


namespace Task_1
{
    public class Vector
    {
        public Dictionary<int , int> Coordinates { get; set; }

        public int Dimension { get; set; }

        public Vector(int dimension, Dictionary<int, int> coordinates)
        {
            this.Dimension = dimension;
            this.Coordinates = coordinates;

            foreach (var key in coordinates.Keys)
            {
                if (key > dimension - 1)
                {
                    throw new ArgumentException("The position of the coordinate is larger than the dimension");
                }
            }
        }

        /// <summary>
        /// Returns true if vector is null.
        /// </summary>
        public static bool IsNull(Vector vector)
            => vector.Coordinates.Count == 0;

        /// <summary>
        /// Returns the sum vector.
        /// </summary>
        public static Vector Sum(Vector firstVector, Vector secondVector)
        {
            if (firstVector.Dimension != secondVector.Dimension)
            {
                throw new ArgumentException("The dimensions of the vectors do not match");
            }

            Dictionary<int, int> newCoordinates = new Dictionary<int, int>();

            foreach (var key in firstVector.Coordinates.Keys)
            {
                if (secondVector.Coordinates.ContainsKey(key))
                {
                    int sum = firstVector.Coordinates[key] + secondVector.Coordinates[key];
                    if (sum != 0)
                    {
                        newCoordinates[key] = sum;
                    }
                    continue;
                }

                newCoordinates[key] = firstVector.Coordinates[key];
            }

            foreach (var key in secondVector.Coordinates.Keys)
            {
                if (firstVector.Coordinates.ContainsKey(key))
                {
                    int sum = firstVector.Coordinates[key] + secondVector.Coordinates[key];
                    if (sum != 0)
                    {
                        newCoordinates[key] = sum;
                    }
                    continue;
                }

                newCoordinates[key] = secondVector.Coordinates[key];
            }

            return new Vector(firstVector.Dimension, newCoordinates);
        }

        /// <summary>
        /// Returns the difference vector.
        /// </summary>
        public static Vector Difference(Vector firstVector, Vector secondVector)
        {
            if (firstVector.Dimension != secondVector.Dimension)
            {
                throw new ArgumentException("The dimensions of the vectors do not match");
            }

            Dictionary<int, int> newCoordinates = new Dictionary<int, int>();

            foreach (var key in firstVector.Coordinates.Keys)
            {
                if (secondVector.Coordinates.ContainsKey(key))
                {
                    int difference = firstVector.Coordinates[key] - secondVector.Coordinates[key];
                    if (difference != 0)
                    {
                        newCoordinates[key] = difference;
                    }
                    continue;
                }

                newCoordinates[key] = firstVector.Coordinates[key];
            }

            foreach (var key in secondVector.Coordinates.Keys)
            {
                if (firstVector.Coordinates.ContainsKey(key))
                {
                    int difference = firstVector.Coordinates[key] - secondVector.Coordinates[key];
                    if (difference != 0)
                    {
                        newCoordinates[key] = difference;
                    }
                    continue;
                }

                newCoordinates[key] = -secondVector.Coordinates[key];
            }

            return new Vector(firstVector.Dimension, newCoordinates);
        }

        /// <summary>
        /// Returns the result of scalar multiplication.
        /// </summary>
        public static int Multiplication(Vector firstVector, Vector secondVector)
        {
            if (firstVector.Dimension != secondVector.Dimension)
            {
                throw new ArgumentException("The dimensions of the vectors do not match");
            }

            int result = 0;

            foreach (var key in firstVector.Coordinates.Keys)
            {
                if (secondVector.Coordinates.ContainsKey(key))
                {
                    result += firstVector.Coordinates[key] * secondVector.Coordinates[key];
                }
            }

            return result;
        }
    }
}
