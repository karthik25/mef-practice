namespace MefContracts
{
    public class PluginHost
    {
        private static readonly object InstanceLock = new object();

        private static volatile PluginHost _pluginHost;

        private PluginHost()
        {
            
        }

        public static PluginHost Instance
        {
            get
            {
                if (_pluginHost == null)
                {
                    lock (InstanceLock)
                    {                        
                        if (_pluginHost == null)
                            _pluginHost = new PluginHost();
                    }
                }
                return _pluginHost;
            }
        }
    }
}
