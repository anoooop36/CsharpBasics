using System;

using Newtonsoft.Json;

namespace SerializationDeserialization
{
    class Program
    {
        //serialize a rocket array to JSON string
        public static string DoSerialization()
        {
            Rocket[] rockets =
            {
                new Rocket{ID=0,Builder="ISRO",Target="Moon",Speed=2.5},
                new Rocket{ID=1,Builder="ISRO",Target="Saturn",Speed=1.5},
                new Rocket{ID=2,Builder="NASA",Target="Mars",Speed=3.0},
                new Rocket{ID=3,Builder="NASA",Target="Neptune",Speed=4.0 }
            };
            var json = JsonConvert.SerializeObject(rockets);
            return json;
        }

        //Deserialize a JSON string back to a Rocket array
        public static void DoDeserialization(string json)
        {
            var rockets = JsonConvert.DeserializeObject<Rocket[]>(json);
            foreach (var r in rockets)
            {
                Console.WriteLine($"ID:{r.ID} Builder:{r.Builder} Target:{r.Target} Speed:{r.Speed}");
            }
        }

        //Deserialize a JSON string to UFO object array contains similar properties as Rocket
        public static void DoDeserializeToUfoArray(string json)
        {
            var UfoArray = JsonConvert.DeserializeObject<UFO[]>(json);
            foreach (var u in UfoArray)
            {
                Console.WriteLine($"Target:{u.Target}, Speed:{u.Speed}");
            }
        }

        static void Main(string[] args)
        {
            var json = DoSerialization();
            Console.WriteLine(json);
            Console.WriteLine("------After Deserialization to Rocket Array---");
            DoDeserialization(json);
            Console.WriteLine("---Deserialization to Ufo array");
            DoDeserializeToUfoArray(json);
            Console.ReadKey();
        }
    }
}
