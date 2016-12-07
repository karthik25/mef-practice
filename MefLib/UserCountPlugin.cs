using System;
using System.ComponentModel.Composition;
using MefContracts;

namespace MefLib
{
    [Export(typeof(IPlugin))]
    public class UserCountPlugin : IPlugin
    {
        public void PrePageRequest()
        {
            
        }

        public void OnPageRequest()
        {
            
        }

        public void PreViewRender()
        {
            
        }

        public void OnActionInit()
        {
            Console.WriteLine("[Action] Init - User Count");
        }
    }
}
