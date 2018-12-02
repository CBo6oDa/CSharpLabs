using System;

namespace CSharpLab1.ReflectionTask
{
    class InvalidCoupleArguments : Exception
    {
        public InvalidCoupleArguments(string message) : base(message)
        {
        }
    }
}
