namespace LogAn.UnitTests
{
    public class AlwaysValidFakeExtensionManager : IExtensionManager
    {
        public bool IsValid(string fileName) 
            => true;
    }
}
