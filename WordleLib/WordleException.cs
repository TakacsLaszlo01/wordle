using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordleLib;

[Serializable]
public sealed class NonexistentWordException : Exception
{
    public NonexistentWordException() { }
    public NonexistentWordException(string message) : base(message) { }
    public NonexistentWordException(string message,  Exception innerException)
        : base(message, innerException) { }
}
[Serializable]
public sealed class OutOfGuessesException : Exception
{
    public OutOfGuessesException() { }
    public OutOfGuessesException(string message) : base(message) { }
    public OutOfGuessesException(string message, Exception innerException)
        : base(message, innerException) { }
}
