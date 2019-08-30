using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCF_Contracts
{
    /// <summary>
    /// 定义服务契约
    /// </summary>
    [ServiceContract(Name = "CalculatorService", Namespace = "http://www.artech.com/")]
    public interface IWCF_Contracts
    {
        [OperationContract]
        int Add(int a, int b);
        [OperationContract]
        int Subtract(int a, int b);
        [OperationContract]
        int Multiply(int a, int b);
        [OperationContract]
        int Divide(int a, int b);
    }
}
