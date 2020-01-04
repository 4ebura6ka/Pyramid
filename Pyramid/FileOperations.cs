using System;
using System.IO;
using System.Collections.Generic;

namespace Pyramid
{
    public class FileOperations
    {
        public FileOperations()
        {
        }

        public int FileLinesCount { get; private set; }

        public List<List<int>> ReadFile(string path)
        {
            List<List<int>> pyramid = new List<List<int>>();

            using (StreamReader fileStream = File.OpenText(path))
            {
                int intNode = 0;

                while (!fileStream.EndOfStream)
                {
                    FileLinesCount++;

                    string data = fileStream.ReadLine();
                    string[] separatedData = data.Split(' ');

                    List<int> nodes = new List<int>();
                    foreach (var node in separatedData)
                    {
                        if (!int.TryParse(node, out intNode))
                        {
                            throw new InvalidDataException("Issue with converting to integer");
                        }

                        nodes.Add(intNode);
                    }

                    pyramid.Add(nodes);
                }
            }

            return pyramid;
        }
    }
}
