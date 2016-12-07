using System;
using System.ComponentModel.Composition;
using MefContracts;

namespace MefLib
{
    // The class implementing a contract and using ImportingConstructor
    // should also "export" itself in order to use ImportingConstructor
    // successfully

    [Export(typeof(IComplexOp))]
    public class ComplexOp : IComplexOp
    {
        private readonly IGreeting _greeting;

        [ImportingConstructor]
        public ComplexOp([Import(typeof(IGreeting))]IGreeting greeting)
        {
            _greeting = greeting;
        }

        public void DoSomething()
        {
            Console.WriteLine("Did something!");
            if (_greeting != null)
            {
                Console.WriteLine(_greeting.SayHello());
            }
        }
    }
}