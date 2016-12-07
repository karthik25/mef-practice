using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.IO;
using System.Reflection;
using MefContracts;

namespace MefPractice
{
    class Program
    {
        [Import]
        public IGreeting Greeting;

        [Import] 
        public IGreeting Greeting2;

        [ImportMany(typeof(IPlugin))] 
        public IEnumerable<IPlugin> Plugins;

        [Import]
        public Lazy<INamedGreeting, INamedGreetingMetaData> NamedGreeting;

        [Import]
        public Lazy<INamedGreeting, IDictionary<string, object>> NamedGreeting2;
        
        [Import]
        public IComplexOp ComplexOp;

        static void Main(string[] args)
        {            
            var program = new Program();
            program.Compose();
            program.Run();
        }

        // http://blog.thekfactor.info/wp-content/uploads/2015/05/mef.png
        void Compose()
        {
            try
            {
                var catalog =
                    new DirectoryCatalog(AppDomain.CurrentDomain.BaseDirectory);

                var agcatalogue =
                    new AggregateCatalog(new ComposablePartCatalog[] {catalog,
                   new AssemblyCatalog(Assembly.GetExecutingAssembly())});

                var container = new CompositionContainer(agcatalogue);

                var batch = new CompositionBatch();

                batch.AddPart(this);

                container.Compose(batch);
            }
            catch (FileNotFoundException fnfex)
            {
                Console.WriteLine(fnfex.Message);
            }
            catch (CompositionException cex)
            {
                Console.WriteLine(cex.Message);
            }
        }

        void Run()
        {
            if (Greeting != null)
            {
                Console.WriteLine("Greeting 1 - " + Greeting.SayHello());
            }
            if (Greeting2 != null)
            {
                Console.WriteLine("Greeting 2 - " + Greeting2.SayHello());
            }

            if (Plugins != null)
            {
                foreach (var plugin in Plugins)
                {
                    plugin.OnActionInit();
                }
            }

            if (NamedGreeting != null)
            {
                var metadata = NamedGreeting.Metadata;
                NamedGreeting.Value.SayGreeting("Karthik");
                Console.WriteLine("Name = " + metadata.Name);
            }

            if (NamedGreeting2 != null)
            {
                var metadata2 = NamedGreeting2.Metadata;
                NamedGreeting2.Value.SayGreeting("Vaishnavi");
                Console.WriteLine("Name = " + metadata2["Name"]);
            }

            if (ComplexOp != null)
            {
                ComplexOp.DoSomething();
            }
        }
    }
}
