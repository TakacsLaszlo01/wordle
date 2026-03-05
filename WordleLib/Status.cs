using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordleLib;
public enum Status { Wrong, Contains, Matches }
public static class StaticExtends
{
    public static bool CheckAll(this Status[] array, Status status)
    {
        int n = array.Length;
        for (int i = 0; i < n; i++)
            if (array[i] != status)
                return false;
        return true;
    }
}