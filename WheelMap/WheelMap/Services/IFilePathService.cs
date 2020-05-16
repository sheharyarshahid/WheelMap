using System;
using System.Collections.Generic;
using System.Text;

namespace WheelMap.Services
{
    public interface IFilePathService
    {
        string GetLocalFilePath(string fileName);
    }
}
