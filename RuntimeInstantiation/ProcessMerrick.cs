using System;

namespace RuntimeInstantiation
{
    class ProcessMerrick : IManageInstantiationMethods
    {
        public string GetRegularInstantiationMessage()
        {
            throw new NotImplementedException();
        }
        public string GetDynamicInstantiationMessage()
        {
            return "I am a Merrick processing method.";
        }
    }
}
