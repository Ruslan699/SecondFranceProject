using System.Diagnostics.Contracts;
using System.Linq;

namespace PapaStreet.Common.Responses
{
    public class ActionResponse
    {
        public bool IsSucceed { get; private set; }

        public string[] FailureResult { get; private set; }


        public static ActionResponse Failure(params string[] failureResult)
        {
            var actionResult = new ActionResponse();
            Failure(actionResult, failureResult);
            return actionResult;
        }

        public static ActionResponse Succeed()
        {
            var result = new ActionResponse();
            Succeed(result);
            return result;
        }

        protected static void Succeed(ActionResponse result)
        {
            result.IsSucceed = true;
            result.FailureResult = new string[0];
        }

        protected static void Failure(ActionResponse result, params string[] failureResult)
        {
            Contract.Requires(failureResult != null);
            Contract.Requires(failureResult.Any());
            result.IsSucceed = false;
            result.FailureResult = failureResult;
        }
    }

    public class ActionResponse<T> : ActionResponse
    {
        public T Data { get; set; }

        public new static ActionResponse<T> Failure(params string[] failureResult)
        {
            var result = new ActionResponse<T>();
            Failure(result, failureResult);
            return result;
        }

        public static ActionResponse<T> Succeed(T data)
        {
            var result = new ActionResponse<T>() { Data = data };
            Succeed(result);
            return result;
        }

    }
}
