using NUnit.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

[Serializable]
public class MethodNameFilter : TestFilter
{
    private ArrayList names = new ArrayList();

    public MethodNameFilter()
    {
    }

    public MethodNameFilter(string name)
    {
        this.names.Add(name);
    }

    public MethodNameFilter(string[] namesToAdd)
    {
        this.names.AddRange(namesToAdd);
    }

    public void Add(string name)
    {
        this.names.Add(name);
    }

    public void Add(string[] namesToAdd)
    {
        string[] strArrays = namesToAdd;
        for (int i = 0; i < (int)strArrays.Length; i++)
        {
            string str = strArrays[i];
            this.names.Add(str);
        }
    }

    public override bool Match(ITest test)
    {
        bool flag;
        foreach (string name in this.names)
        {

            if (!(Regex.Replace(test.TestName.FullName, @" ?\(.*?\)", string.Empty) == name))
            {
                continue;
            }
            flag = true;
            return flag;
        }
        flag = false;
        return flag;
    }
}
