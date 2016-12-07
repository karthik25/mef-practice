using System.ComponentModel.Composition;
using MefContracts;

namespace MefLib
{
    [Export(typeof(IGreeting))]
    public class Greeting : IGreeting
    {
        public string SayHello()
        {
            return "Hello, World";
        }
    }
}
