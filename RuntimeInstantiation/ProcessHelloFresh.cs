using System;

namespace RuntimeInstantiation
{
    class ProcessHelloFresh : IManageInstantiationMethods
    {
        public string GetRegularInstantiationMessage()
        {
            throw new NotImplementedException();
        }
        public string GetDynamicInstantiationMessage()
        {
            return "I am a HelloFresh processing method.";
        }
    }
}
