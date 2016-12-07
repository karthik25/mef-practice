using System;
using System.ComponentModel.Composition;
using MefContracts;

namespace MefLib
{
    [Export(typeof(INamedGreeting))]
    [ExportMetadata("Name", "Default")]
    public class NamedGreeting : INamedGreeting
    {
        public void SayGreeting(string name)
        {
            Console.WriteLine("Hello {0}", name);
        }
    }
}