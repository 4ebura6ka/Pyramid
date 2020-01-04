using System;
using System.Collections.Generic;

namespace Pyramid
{
    public class PyramidComputations
    {
        public List<List<int>> Pyramid { get; private set; }

        public int Height { get; private set; }

        public string MaxSumPath { get; private set; }

        public int MaxSum { get; private set; }

        public PyramidComputations(List<List<int>> pyramid, int height)
        {
            MaxSumPath = string.Empty;
            MaxSum = 0;

            Height = height;
            Pyramid = pyramid;

            if (height < 1)
            {
                throw new ArgumentOutOfRangeException("Pyramid at least should be 1 level height");
            }
        }

        public void CalculateMaxSumAndPath()
        {
            // start from the very first row in pyramid
            List<int> sumsCurrentRow = new List<int>(Pyramid[Height - 1]);

            // record indexes of nodes we came
            List<List<int>> pathInPyramid = new List<List<int>>();

            for (var rowIndex = Height - 1; rowIndex > 0; rowIndex--)
            {
                List<int> sumsNextRow = new List<int>();
                List<int> pathRow = new List<int>();
                List<int> children = Pyramid[rowIndex];

                int rowSize = Pyramid[rowIndex - 1].Count;

                // calculate sums in parent row
                for (var i = 0; i < rowSize; i++)
                {
                    int parent = Pyramid[rowIndex - 1][i];
                    int leftChild = children[i];
                    int rightChild = children[i + 1];

                    // if node doesn't satisfied odd/even condition it will be not included by setting most minimal value
                    int leftChildSum = Int32.MinValue;
                    int rightChildSum = Int32.MinValue;

                    // checking the path creation condition
                    if (parent % 2 == 0 ^ leftChild % 2 == 0)
                    {
                        leftChildSum = sumsCurrentRow[i] + parent;
                    }

                    if (parent % 2 == 0 ^ rightChild % 2 == 0)
                    {
                        rightChildSum = sumsCurrentRow[i + 1] + parent;
                    }

                    //choose max from two childs
                    if (leftChildSum < rightChildSum)
                    {
                        sumsNextRow.Add(rightChildSum);
                        pathRow.Add(i + 1);
                    }
                    else
                    {
                        sumsNextRow.Add(leftChildSum);
                        pathRow.Add(i);
                    }
                }

                sumsCurrentRow = new List<int>(sumsNextRow);
                pathInPyramid.Add(pathRow);
            }

            RestorePath(sumsCurrentRow, pathInPyramid);
        }

        private void RestorePath(List<int> sumsCurrentRow, List<List<int>> pathInPyramid)
        {
            int level = 0;
            int pathPyramidHeight = pathInPyramid.Count;
            int pathIndex = pathInPyramid[pathPyramidHeight - 1][0];

            // check if path was found
            if (pathPyramidHeight == Height - 1)
            {
                MaxSumPath += Pyramid[0][0];
                for (var ndx = pathPyramidHeight - 1; ndx >= 0; ndx--)
                {
                    MaxSumPath += "->";
                    //extract next index in path pyramid
                    pathIndex = pathInPyramid[ndx][pathIndex];
                    level++;

                    MaxSumPath += Pyramid[level][pathIndex];
                }

                MaxSum = sumsCurrentRow[0];
            }
            else
            {
                throw new ArgumentNullException("Path not found");
            }
        }
    }
}
