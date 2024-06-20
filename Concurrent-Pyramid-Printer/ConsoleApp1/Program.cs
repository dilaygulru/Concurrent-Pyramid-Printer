using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        // Input file path
        string inputFilePath = @"C:\Users\gulru\Documents\Dilay\okul\PRINCIPLES OF PROGRAMMING LANGUAGES\ödev2\deneme\input.txt";
        // Output and log file paths
        string outputFilePath = @"C:\Users\gulru\Documents\Dilay\okul\PRINCIPLES OF PROGRAMMING LANGUAGES\ödev2\deneme\output.txt";
        string logFilePath = @"C:\Users\gulru\Documents\Dilay\okul\PRINCIPLES OF PROGRAMMING LANGUAGES\ödev2\deneme\log.txt";

        // Read and process the print requests
        ProcessPrintRequests(inputFilePath, outputFilePath, logFilePath);
    }

    static void ProcessPrintRequests(string inputFile, string outputFile, string logFile)
    {
        var requests = File.ReadAllLines(inputFile);
        List<string> output = new List<string>();
        List<string> logs = new List<string>();

        string currentPatternType = null;
        int lastEndTime = 0;

        foreach (var request in requests)
        {
            string[] parts = request.Split('\t');
            int requestTime = int.Parse(parts[0]);
            string patternType = parts[1];
            int outputSize = int.Parse(parts[2]);

            // Check if the printer is free or if the current request matches the ongoing pattern type
            if (currentPatternType == null || currentPatternType == patternType || lastEndTime <= requestTime)
            {
                // Calculate start time and duration
                int startTime = Math.Max(lastEndTime, requestTime);
                int duration = outputSize * outputSize;
                int endTime = startTime + duration;

                // Log the task
                logs.Add($"Task start: {startTime} ms, Task end: {endTime} ms, Pattern: {patternType}, Size: {outputSize}");

                // Generate the pattern
                if (patternType == "Star")
                {
                    output.AddRange(GenerateStarPattern(outputSize));
                }
                else if (patternType == "Alphabet")
                {
                    output.AddRange(GenerateAlphabetPattern(outputSize));
                }

                lastEndTime = endTime;
                currentPatternType = patternType;
            }
            else
            {
                // If a different pattern type is requested, wait for the current pattern type to finish
                if (lastEndTime > requestTime)
                {
                    int waitTime = lastEndTime - requestTime;
                    Thread.Sleep(waitTime);
                }

                // After waiting, start the new task
                int startTime = lastEndTime;
                int duration = outputSize * outputSize;
                int endTime = startTime + duration;

                // Log the task
                logs.Add($"Task start: {startTime} ms, Task end: {endTime} ms, Pattern: {patternType}, Size: {outputSize}");

                // Generate the pattern
                if (patternType == "Star")
                {
                    output.AddRange(GenerateStarPattern(outputSize));
                }
                else if (patternType == "Alphabet")
                {
                    output.AddRange(GenerateAlphabetPattern(outputSize));
                }

                lastEndTime = endTime;
                currentPatternType = patternType;
            }
        }

        File.WriteAllLines(outputFile, output);
        File.WriteAllLines(logFile, logs);
    }


    static List<string> GenerateStarPattern(int size)
    {
        List<string> result = new List<string>();
        for (int i = 1; i <= size; i++)
        {
            result.Add(new string(' ', size - i) + new string('*', 2 * i - 1));
        }
        result.Add(new string('-', 30)); // Ayırıcı çizgi ekle
        return result;
    }

    static List<string> GenerateAlphabetPattern(int size)
    {
        List<string> result = new List<string>();
        int maxLineWidth = 2 * (size * 2 - 1) - 1; // En geniş satırın genişliğini hesapla

        for (int i = 0; i < size; i++)
        {
            string line = "";
            // Önce artan harfleri ekle
            for (int j = i; j < i + i + 1; j++)
            {
                line += (char)('A' + j % 26);
                if (j < i + i) // Son harf hariç boşluk ekle
                    line += " ";
            }
            // Sonra azalan harfleri ekle
            for (int k = i + i - 1; k >= i; k--)
            {
                line += " " + (char)('A' + k % 26);
            }

            // Her satırı merkeze hizala
            int padding = (maxLineWidth - line.Length) / 2;
            result.Add(new string(' ', padding) + line);
        }
        result.Add(new string('-', 30)); // Ayırıcı çizgi ekle
        return result;
    }
}
