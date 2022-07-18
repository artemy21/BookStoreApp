using System;

namespace Service.Services
{
    public abstract class ValidatorService
    {
        public static void StringNotNullOrEmpty(string argument, string parameterName)
        {
            if (string.IsNullOrEmpty(argument)) throw new ArgumentNullException(parameterName);
        }

        public static void ArgumentNotNull(object argument, string parameterName)
        {
            if (parameterName is null) throw new ArgumentNullException("parameterName");
            if (argument is null) throw new ArgumentNullException(parameterName);
        }
    }
}
