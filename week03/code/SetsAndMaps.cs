using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;


public static class SetsAndMaps
{
    // Problem 1
    public static string[] FindPairs(string[] words)
    {
        HashSet<string> wordSet = new HashSet<string>(words);
        List<string> result = new List<string>();

        foreach (string word in words)
        {
            if (word.Length != 2) continue;

            char[] reversedChars = word.ToCharArray();
            Array.Reverse(reversedChars);
            string reversedWord = new string(reversedChars);

             if (wordSet.Contains(reversedWord) && word != reversedWord && string.Compare(word,reversedWord) < 0) // Avoid duplicates and self-pairs, and make sure the first word in the pair has lower value
            {
              
                result.Add($"{word} & {reversedWord}");
            }
        }

        return result.ToArray();
    }

    // Problem 2
    public static Dictionary<string, int> SummarizeDegrees(string filePath)
    {
        Dictionary<string, int> degreeCounts = new Dictionary<string, int>();

        using (StreamReader reader = new StreamReader(filePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(',');
                if (parts.Length > 4) // Ensure there is a degree column
                {
                    string degree = parts[3].Trim(); // Column 4 is at index 3

                    if (degreeCounts.ContainsKey(degree))
                    {
                        degreeCounts[degree]++;
                    }
                    else
                    {
                        degreeCounts[degree] = 1;
                    }
                }
            }
        }
        return degreeCounts;
    }


    // Problem 3
    public static bool IsAnagram(string word1, string word2)
    {
        // Remove spaces and convert to lowercase
        string cleanWord1 = word1.Replace(" ", "").ToLower();
        string cleanWord2 = word2.Replace(" ", "").ToLower();

        if (cleanWord1.Length != cleanWord2.Length)
            return false;

        Dictionary<char, int> charCounts1 = new Dictionary<char, int>();
        Dictionary<char, int> charCounts2 = new Dictionary<char, int>();

        foreach(char c in cleanWord1)
        {
          if(charCounts1.ContainsKey(c)){
            charCounts1[c]++;
          } else {
            charCounts1[c] = 1;
          }
        }

        foreach(char c in cleanWord2)
        {
           if(charCounts2.ContainsKey(c)){
            charCounts2[c]++;
          } else {
            charCounts2[c] = 1;
          }
        }

        if (charCounts1.Count != charCounts2.Count)
           return false;
           
        foreach (var pair in charCounts1)
        {
            if (!charCounts2.ContainsKey(pair.Key) || charCounts2[pair.Key] != pair.Value)
               return false;
        }


        return true;
    }

    // Problem 5
    public static string[] EarthquakeDailySummary()
    {
        using HttpClient client = new HttpClient();
        var response = client.GetAsync("https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson").Result;
        response.EnsureSuccessStatusCode();
        var content = response.Content.ReadAsStringAsync().Result;

        FeatureCollection featureCollection = JsonSerializer.Deserialize<FeatureCollection>(content);
         if (featureCollection == null || featureCollection.Features == null)
        {
          return [];
        }
        return featureCollection.Features.Select(f => $"{f.Properties.Place} - Mag {f.Properties.Mag}").ToArray();
    }
}