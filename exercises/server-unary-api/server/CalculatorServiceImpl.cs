using System;
using Calculator;
using static Calculator.CalculatorService;
using Grpc.Core;

namespace server
{
    public class CalculatorServiceImpl : CalculatorServiceBase
    {
        public override Task<SumResponse> Sum(SumRequest request, ServerCallContext context)
        {
            int result = request.A + request.B;
            return Task.FromResult(new SumResponse() { Result = result });
        }

        public override Task<SubstractResponse> Substract(SubstractRequest request, ServerCallContext context)
        {
            int result = request.A - request.B;
            return Task.FromResult(new SubstractResponse() { Result = result });
        }
    }
}