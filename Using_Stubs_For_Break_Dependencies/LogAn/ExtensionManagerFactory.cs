namespace LogAn
{
    public sealed class ExtensionManagerFactory
    {
        private IExtensionManager customManager = null;
        private static ExtensionManagerFactory instance;

        public static ExtensionManagerFactory Instance
        {
            get
            {
                instance ??= new ExtensionManagerFactory();
                return instance;
            }
        }

        private ExtensionManagerFactory() 
        { }
        
        public IExtensionManager Create()
        {
            if (customManager != null)
                return customManager;
            return new FileExtensionManager();
        }

        public void SetManager(IExtensionManager mgr)
        {
            customManager = mgr;
        }
    }
}
