using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF_Client.ServiceReference1;

namespace WCF_Client
{
    public partial class CalculatorServiceClient : System.ServiceModel.ClientBase<CalculatorService>, CalculatorService
    {
        public int Add(int a, int b)
        {
            return base.Channel.Add(a, b);
        }

        public Task<int> AddAsync(int a, int b)
        {
            throw new NotImplementedException();
        }

        public int Subtract(int a, int b)
        {
            return base.Channel.Subtract(a, b);
        }

        public Task<int> SubtractAsync(int a, int b)
        {
            throw new NotImplementedException();
        }

        public int Multiply(int a, int b)
        {
            return base.Channel.Multiply(a, b);
        }

        public Task<int> MultiplyAsync(int a, int b)
        {
            throw new NotImplementedException();
        }

        public int Divide(int a, int b)
        {
            return base.Channel.Divide(a, b);
        }

        public Task<int> DivideAsync(int a, int b)
        {
            throw new NotImplementedException();
        }
    }
}
