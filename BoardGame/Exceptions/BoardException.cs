using System;

namespace BoardGame.Exceptions
{
    internal class BoardException : ApplicationException
    {
        public BoardException(string message) : base(message) { }
    }
}
