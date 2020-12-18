using System;

namespace Mod5._6_HW1
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }

    public class Document
    {
        public virtual string AddText { get; set; }
        public string Name { get; set; }

    }

    public class SignedDocument : Document
    {
        public string signature { get; set; }
        public sealed override string AddText
        { get => base.AddText; 
            
            set if(signature) => base.AddText = value; } 
    }
    

