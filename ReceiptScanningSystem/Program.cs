using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

class Program
{
    public static void Main(string[] args)
    {
        // Go to bin/debug/net6.0 directory for command shell execute
        string basePath = AppDomain.CurrentDomain.BaseDirectory;
        string jsonPath = Path.Combine(basePath, "response.json");
        string outputPath = Path.Combine(basePath, "output.json");

        if (!File.Exists(jsonPath))
        {
            Console.WriteLine("Error: response.json file not found.");
            return;
        }

        string json = File.ReadAllText(jsonPath);

        List<Item> items = JsonConvert.DeserializeObject<List<Item>>(json);

        // Sort by Y values ​​to split into the lines
        items = items.OrderBy(item => item.boundingPoly.vertices[0].Y).ToList();

        List<List<Item>> lines = new();

        List<Item> currentLine = new();
        int previousY = 0;
        int threshold = 10;

        // Skip first item contains all information
        foreach (Item item in items.Skip(1))
        {
            int currentY = item.boundingPoly.vertices[0].Y;

            //  If vertical distances are close they are on the same line
            if (Math.Abs(currentY - previousY) > threshold)
            {
                lines.Add(currentLine);
                currentLine = new List<Item>();
            }

            currentLine.Add(item);
            previousY = currentY;
        }

        // Add last item to list
        lines.Add(currentLine);

        // Sort by x values, inline sort
        lines.ForEach(line => line.Sort((a, b) => a.boundingPoly.vertices[0].X.CompareTo(b.boundingPoly.vertices[0].X)));


        int lineNumber = 1;
        
        using (StreamWriter writer = new StreamWriter(outputPath))
        {
            foreach (List<Item> line in lines)
            {
                List<string> descriptions = new List<string>();
                foreach (Item item in line)
                {
                    descriptions.Add(item.description);
                }
                if (descriptions.Count > 0) // If the item contains descriptions, write to output
                {
                    string output = lineNumber.ToString() + " " + string.Join(" ", descriptions);
                    writer.WriteLine(output);
                    Console.WriteLine(output);
                    lineNumber++;
                }
            }
            writer.Close();
            Console.WriteLine("Done");
        }
    }
}