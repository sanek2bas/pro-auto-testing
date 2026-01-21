using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace LogAn;

public interface IExtensionManager
{
    bool IsValid(string fileName);
}

public class FileExtensionManager : IExtensionManager
{
    public bool IsValid(string fileName)
    {
        throw new NotImplementedException();
    }
}
