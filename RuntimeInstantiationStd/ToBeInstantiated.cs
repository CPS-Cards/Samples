namespace RuntimeInstantiation
{
    class ToBeInstantiated : IManageInstantiationMethods
    {
        public static string GetStaticMessage()
        {
            return "I have been called without my parent class being instantiated.";
        }

        public string GetConcreteInstantiationMessage()
        {
            return "I have been called outside of any contracts.";
        }

        public string GetRegularInstantiationMessage()
        {
            return "I am contractually obligated to provide you a message string. You won't be able to use my non-interface methods.";
        }

        public string GetDynamicInstantiationMessage()
        {
            return "The compiler doesn't initialize me but you do.";
        }

    }
}
