﻿using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Reflection;
using Newtonsoft.Json;

namespace WhereAreYou
{
    
    public class Utils
    {
        
        public const string DEFAULT_FILE = "WhereAreYou.Data.ScheduleJSON.json";
        
        public static List<Schedule> ReadListOfData(string filename)
        {
            string jsonText;
            
            try
            {
                using (var reader = new StreamReader($"./Data/{filename}"))
                {
                    jsonText = reader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                var assembly = IntrospectionExtensions.GetTypeInfo(typeof(MainPage)).Assembly;
                Stream stream = assembly.GetManifestResourceStream(DEFAULT_FILE);
                using (var reader = new StreamReader(stream)) jsonText = reader.ReadToEnd(); // This is crashing the app for me (DM)
            }

            return JsonConvert.DeserializeObject<List<Schedule>>(jsonText);
            
        }
        
        public static void SaveListOfData(string filename, List<Schedule> list)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string fname = Path.Combine(path, filename);
            using(var writer = new StreamWriter(fname, false))
            {
                string jsonText = JsonConvert.SerializeObject(list);
                writer.WriteLine(jsonText);
            }
        }
    }
}
