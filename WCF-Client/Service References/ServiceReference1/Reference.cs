﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace WCF_Client.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://www.artech.com/", ConfigurationName="ServiceReference1.CalculatorService")]
    public interface CalculatorService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.artech.com/CalculatorService/Add", ReplyAction="http://www.artech.com/CalculatorService/AddResponse")]
        int Add(int a, int b);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.artech.com/CalculatorService/Add", ReplyAction="http://www.artech.com/CalculatorService/AddResponse")]
        System.Threading.Tasks.Task<int> AddAsync(int a, int b);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.artech.com/CalculatorService/Subtract", ReplyAction="http://www.artech.com/CalculatorService/SubtractResponse")]
        int Subtract(int a, int b);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.artech.com/CalculatorService/Subtract", ReplyAction="http://www.artech.com/CalculatorService/SubtractResponse")]
        System.Threading.Tasks.Task<int> SubtractAsync(int a, int b);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.artech.com/CalculatorService/Multiply", ReplyAction="http://www.artech.com/CalculatorService/MultiplyResponse")]
        int Multiply(int a, int b);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.artech.com/CalculatorService/Multiply", ReplyAction="http://www.artech.com/CalculatorService/MultiplyResponse")]
        System.Threading.Tasks.Task<int> MultiplyAsync(int a, int b);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.artech.com/CalculatorService/Divide", ReplyAction="http://www.artech.com/CalculatorService/DivideResponse")]
        int Divide(int a, int b);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.artech.com/CalculatorService/Divide", ReplyAction="http://www.artech.com/CalculatorService/DivideResponse")]
        System.Threading.Tasks.Task<int> DivideAsync(int a, int b);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface CalculatorServiceChannel : WCF_Client.ServiceReference1.CalculatorService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CalculatorServiceClient : System.ServiceModel.ClientBase<WCF_Client.ServiceReference1.CalculatorService>, WCF_Client.ServiceReference1.CalculatorService {
        
        public CalculatorServiceClient() {
        }
        
        public CalculatorServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CalculatorServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CalculatorServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CalculatorServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int Add(int a, int b) {
            return base.Channel.Add(a, b);
        }
        
        public System.Threading.Tasks.Task<int> AddAsync(int a, int b) {
            return base.Channel.AddAsync(a, b);
        }
        
        public int Subtract(int a, int b) {
            return base.Channel.Subtract(a, b);
        }
        
        public System.Threading.Tasks.Task<int> SubtractAsync(int a, int b) {
            return base.Channel.SubtractAsync(a, b);
        }
        
        public int Multiply(int a, int b) {
            return base.Channel.Multiply(a, b);
        }
        
        public System.Threading.Tasks.Task<int> MultiplyAsync(int a, int b) {
            return base.Channel.MultiplyAsync(a, b);
        }
        
        public int Divide(int a, int b) {
            return base.Channel.Divide(a, b);
        }
        
        public System.Threading.Tasks.Task<int> DivideAsync(int a, int b) {
            return base.Channel.DivideAsync(a, b);
        }
    }
}
