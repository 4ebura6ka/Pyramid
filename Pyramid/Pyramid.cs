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

            for (var childrenRowIndex = Height - 1; childrenRowIndex > 0; childrenRowIndex--)
            {
                List<int> sumsNextRow = new List<int>();
                List<int> pathRow = new List<int>();
                List<int> children = Pyramid[childrenRowIndex];

                int rowSize = Pyramid[childrenRowIndex - 1].Count;
                int parentRowIndex = childrenRowIndex - 1;

                // calculate sums in parent row
                for (var leftChildIndex = 0; leftChildIndex < rowSize; leftChildIndex++)
                {
                    int parent = Pyramid[parentRowIndex][leftChildIndex];
                    int leftChild = children[leftChildIndex];
                    int rightChildIndex = leftChildIndex + 1;
                    int rightChild = children[rightChildIndex];

                    // if node doesn't satisfied odd/even condition it will be not included by setting most minimal value
                    int leftChildSum = Int32.MinValue;
                    int rightChildSum = Int32.MinValue;

                    // checking the path creation condition
                    if ((parent + leftChild) % 2 == 1)
                    {
                        leftChildSum = sumsCurrentRow[leftChildIndex] + parent;
                    }

                    if ((parent + rightChild) % 2 == 1)
                    {
                        rightChildSum = sumsCurrentRow[rightChildIndex] + parent;
                    }

                    //choose max from two childs
                    if (leftChildSum < rightChildSum)
                    {
                        sumsNextRow.Add(rightChildSum);
                        pathRow.Add(rightChildIndex);
                    }
                    else
                    {
                        sumsNextRow.Add(leftChildSum);
                        pathRow.Add(leftChildIndex);
                    }
                }

                sumsCurrentRow = new List<int>(sumsNextRow);
                pathInPyramid.Add(pathRow);
            }

            RestorePath(sumsCurrentRow, pathInPyramid);
        }

        private void RestorePath(List<int> sumsCurrentRow, List<List<int>> pathInPyramid)
        {
            int pyramidLevel = 0;
            int pathPyramidHeight = pathInPyramid.Count;
            int pathIndex = pathInPyramid[pathPyramidHeight - 1][0];

            // check if path was found
            if (pathPyramidHeight == Height - 1)
            {
                MaxSumPath += Pyramid[0][0];
                for (var level = pathPyramidHeight - 1; level >= 0; level--)
                {
                    MaxSumPath += "->";
                    //extract next index in path pyramid
                    pathIndex = pathInPyramid[level][pathIndex];
                    pyramidLevel++;

                    MaxSumPath += Pyramid[pyramidLevel][pathIndex];
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
