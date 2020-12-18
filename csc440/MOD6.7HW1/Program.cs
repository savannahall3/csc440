using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace MOD6._7HW1
{
    [Serializable]                                      
    //designates class as serializable
    
    class ServiceConfiguration : ISerializable         
        //inherits from Iserializable
    {
        //creating properties
        public string ConfigName { get; set; }
        public string DatabaseHostName { get; set; }
        public string ApplicationDataPath { get; set; }

        //create a method to display
        public void Display()
        {
            Console.WriteLine("ConfigName = {0}\nDatabaseHostName = {1}\nApplicationDataPath = {2}",
                this.ConfigName, this.DatabaseHostName, this.ApplicationDataPath);
        }
        //creating constructors in relation to properties
        public ServiceConfiguration(string a, string b, string c)
        {
            this.ConfigName = a;
            this.DatabaseHostName = b;
            this.ApplicationDataPath = c;
        }

        //deconstructor, gets data in json form and makes it into this class object
        public ServiceConfiguration(SerializationInfo info, StreamingContext ctxt)
        {
            this.ConfigName = info.GetValue("ConfigName", typeof(string)).ToString();
            this.DatabaseHostName = info.GetValue("DatabaseHostName", typeof(string)).ToString();
            this.ApplicationDataPath = info.GetValue("ApplicationDataPath", typeof(string)).ToString();
        }

        //gets and passes object data to be deserialized. necessary with serializable content.
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("ConfigName", this.ConfigName);
            info.AddValue("DatabaseHostName", this.DatabaseHostName);
            info.AddValue("ApplicationDataPath", this.ApplicationDataPath);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input config name, then database host name, then application data path fields");
            JsonSerialize(Console.ReadLine(), Console.ReadLine(), Console.ReadLine());
            JsonDeSerialize();
        }

        public static void JsonSerialize(string cName, string dbHN, string aDP)
        {
            //serialize
            ServiceConfiguration config = new ServiceConfiguration(cName, dbHN, aDP);                         //creates object to be serialized
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(config.GetType());   //creates json serializer
            FileStream buffer = File.Create("config.txt");                                                  //Stream to specifed location
            jsonSerializer.WriteObject(buffer, config);                                                     //actually writes to location
            buffer.Close();                                                                                 //closes out
        }
        public static void JsonDeSerialize()
        {
            //deserialize
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(ServiceConfiguration));   //creates deserializer
            FileStream buffer = File.OpenRead("config.txt");                                                            //specifies file location
            ServiceConfiguration config = jsonSerializer.ReadObject(buffer) as ServiceConfiguration;                    //creates object in runetime to hold data
            buffer.Close();                                                                                             //closes out
            config.Display();
        }
    }
}