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

        public List<int> ReadFile(string path)
        {
            List<int> nodes = new List<int>();

            using (StreamReader fileStream = File.OpenText(path))
            {
                int intNode = 0;

                while (!fileStream.EndOfStream)
                {
                    string data = fileStream.ReadLine();
                    string[] separatedData = data.Split(' ');

                    foreach (var node in separatedData)
                    {
                        if (!int.TryParse(node, out intNode))
                        {
                            throw new InvalidDataException("Issue with converting to integer");
                        }

                        nodes.Add(intNode);
                    }
                }
            }

            return nodes;
        }
    }
}
