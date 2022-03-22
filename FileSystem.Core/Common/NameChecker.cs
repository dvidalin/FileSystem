using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem.Core.Common;
public class NameChecker 
{
    private const string SUFFIX_BASE = "- Copy";

    public static string GetAvailableName(string desiredName, List<string> usedNames, int i = 0)
    {
        string nameToCheck = i == 0 ? desiredName : $"{desiredName} {SUFFIX_BASE} ({i})";

        if (!usedNames.Contains(nameToCheck))
            return nameToCheck;        

        return GetAvailableName(desiredName, usedNames, ++i);                
    }
}
