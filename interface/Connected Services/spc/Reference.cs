﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _interface.spc {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="spc.WebService1Soap")]
    public interface WebService1Soap {
        
        // CODEGEN: Generating message contract since element name suppliername from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/InsertsupplierWeb", ReplyAction="*")]
        _interface.spc.InsertsupplierWebResponse InsertsupplierWeb(_interface.spc.InsertsupplierWebRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/InsertsupplierWeb", ReplyAction="*")]
        System.Threading.Tasks.Task<_interface.spc.InsertsupplierWebResponse> InsertsupplierWebAsync(_interface.spc.InsertsupplierWebRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/InsertstockrWeb", ReplyAction="*")]
        int InsertstockrWeb(int drug_id, int warehouse_id, int quantity_in_stock, int purchase_price, int selling_price);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/InsertstockrWeb", ReplyAction="*")]
        System.Threading.Tasks.Task<int> InsertstockrWebAsync(int drug_id, int warehouse_id, int quantity_in_stock, int purchase_price, int selling_price);
        
        // CODEGEN: Generating message contract since element name pharmacy_name from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/InsertpharmacyWeb", ReplyAction="*")]
        _interface.spc.InsertpharmacyWebResponse InsertpharmacyWeb(_interface.spc.InsertpharmacyWebRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/InsertpharmacyWeb", ReplyAction="*")]
        System.Threading.Tasks.Task<_interface.spc.InsertpharmacyWebResponse> InsertpharmacyWebAsync(_interface.spc.InsertpharmacyWebRequest request);
        
        // CODEGEN: Generating message contract since element name order_date from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/InsertorderWeb", ReplyAction="*")]
        _interface.spc.InsertorderWebResponse InsertorderWeb(_interface.spc.InsertorderWebRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/InsertorderWeb", ReplyAction="*")]
        System.Threading.Tasks.Task<_interface.spc.InsertorderWebResponse> InsertorderWebAsync(_interface.spc.InsertorderWebRequest request);
        
        // CODEGEN: Generating message contract since element name staff_name from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/InsertstaffWeb", ReplyAction="*")]
        _interface.spc.InsertstaffWebResponse InsertstaffWeb(_interface.spc.InsertstaffWebRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/InsertstaffWeb", ReplyAction="*")]
        System.Threading.Tasks.Task<_interface.spc.InsertstaffWebResponse> InsertstaffWebAsync(_interface.spc.InsertstaffWebRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class InsertsupplierWebRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="InsertsupplierWeb", Namespace="http://tempuri.org/", Order=0)]
        public _interface.spc.InsertsupplierWebRequestBody Body;
        
        public InsertsupplierWebRequest() {
        }
        
        public InsertsupplierWebRequest(_interface.spc.InsertsupplierWebRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class InsertsupplierWebRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string suppliername;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string Supplieraddress;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string Supplieremail;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=3)]
        public int Suppliercontact_number;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=4)]
        public int Supplierregistration_date;
        
        public InsertsupplierWebRequestBody() {
        }
        
        public InsertsupplierWebRequestBody(string suppliername, string Supplieraddress, string Supplieremail, int Suppliercontact_number, int Supplierregistration_date) {
            this.suppliername = suppliername;
            this.Supplieraddress = Supplieraddress;
            this.Supplieremail = Supplieremail;
            this.Suppliercontact_number = Suppliercontact_number;
            this.Supplierregistration_date = Supplierregistration_date;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class InsertsupplierWebResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="InsertsupplierWebResponse", Namespace="http://tempuri.org/", Order=0)]
        public _interface.spc.InsertsupplierWebResponseBody Body;
        
        public InsertsupplierWebResponse() {
        }
        
        public InsertsupplierWebResponse(_interface.spc.InsertsupplierWebResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class InsertsupplierWebResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public int InsertsupplierWebResult;
        
        public InsertsupplierWebResponseBody() {
        }
        
        public InsertsupplierWebResponseBody(int InsertsupplierWebResult) {
            this.InsertsupplierWebResult = InsertsupplierWebResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class InsertpharmacyWebRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="InsertpharmacyWeb", Namespace="http://tempuri.org/", Order=0)]
        public _interface.spc.InsertpharmacyWebRequestBody Body;
        
        public InsertpharmacyWebRequest() {
        }
        
        public InsertpharmacyWebRequest(_interface.spc.InsertpharmacyWebRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class InsertpharmacyWebRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string pharmacy_name;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string location;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public int contact_number;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string email;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=4)]
        public string registration_date;
        
        public InsertpharmacyWebRequestBody() {
        }
        
        public InsertpharmacyWebRequestBody(string pharmacy_name, string location, int contact_number, string email, string registration_date) {
            this.pharmacy_name = pharmacy_name;
            this.location = location;
            this.contact_number = contact_number;
            this.email = email;
            this.registration_date = registration_date;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class InsertpharmacyWebResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="InsertpharmacyWebResponse", Namespace="http://tempuri.org/", Order=0)]
        public _interface.spc.InsertpharmacyWebResponseBody Body;
        
        public InsertpharmacyWebResponse() {
        }
        
        public InsertpharmacyWebResponse(_interface.spc.InsertpharmacyWebResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class InsertpharmacyWebResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public int InsertpharmacyWebResult;
        
        public InsertpharmacyWebResponseBody() {
        }
        
        public InsertpharmacyWebResponseBody(int InsertpharmacyWebResult) {
            this.InsertpharmacyWebResult = InsertpharmacyWebResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class InsertorderWebRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="InsertorderWeb", Namespace="http://tempuri.org/", Order=0)]
        public _interface.spc.InsertorderWebRequestBody Body;
        
        public InsertorderWebRequest() {
        }
        
        public InsertorderWebRequest(_interface.spc.InsertorderWebRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class InsertorderWebRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public int drug_id;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public int Pharmacy_id;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string order_date;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=3)]
        public int quantity_ordered;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=4)]
        public string status;
        
        public InsertorderWebRequestBody() {
        }
        
        public InsertorderWebRequestBody(int drug_id, int Pharmacy_id, string order_date, int quantity_ordered, string status) {
            this.drug_id = drug_id;
            this.Pharmacy_id = Pharmacy_id;
            this.order_date = order_date;
            this.quantity_ordered = quantity_ordered;
            this.status = status;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class InsertorderWebResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="InsertorderWebResponse", Namespace="http://tempuri.org/", Order=0)]
        public _interface.spc.InsertorderWebResponseBody Body;
        
        public InsertorderWebResponse() {
        }
        
        public InsertorderWebResponse(_interface.spc.InsertorderWebResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class InsertorderWebResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public int InsertorderWebResult;
        
        public InsertorderWebResponseBody() {
        }
        
        public InsertorderWebResponseBody(int InsertorderWebResult) {
            this.InsertorderWebResult = InsertorderWebResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class InsertstaffWebRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="InsertstaffWeb", Namespace="http://tempuri.org/", Order=0)]
        public _interface.spc.InsertstaffWebRequestBody Body;
        
        public InsertstaffWebRequest() {
        }
        
        public InsertstaffWebRequest(_interface.spc.InsertstaffWebRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class InsertstaffWebRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string staff_name;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string staff_address;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string staff_email;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=3)]
        public int staff_contact_number;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=4)]
        public string staff_registration_date;
        
        public InsertstaffWebRequestBody() {
        }
        
        public InsertstaffWebRequestBody(string staff_name, string staff_address, string staff_email, int staff_contact_number, string staff_registration_date) {
            this.staff_name = staff_name;
            this.staff_address = staff_address;
            this.staff_email = staff_email;
            this.staff_contact_number = staff_contact_number;
            this.staff_registration_date = staff_registration_date;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class InsertstaffWebResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="InsertstaffWebResponse", Namespace="http://tempuri.org/", Order=0)]
        public _interface.spc.InsertstaffWebResponseBody Body;
        
        public InsertstaffWebResponse() {
        }
        
        public InsertstaffWebResponse(_interface.spc.InsertstaffWebResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class InsertstaffWebResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public int InsertstaffWebResult;
        
        public InsertstaffWebResponseBody() {
        }
        
        public InsertstaffWebResponseBody(int InsertstaffWebResult) {
            this.InsertstaffWebResult = InsertstaffWebResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface WebService1SoapChannel : _interface.spc.WebService1Soap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WebService1SoapClient : System.ServiceModel.ClientBase<_interface.spc.WebService1Soap>, _interface.spc.WebService1Soap {
        
        public WebService1SoapClient() {
        }
        
        public WebService1SoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WebService1SoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WebService1SoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WebService1SoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        _interface.spc.InsertsupplierWebResponse _interface.spc.WebService1Soap.InsertsupplierWeb(_interface.spc.InsertsupplierWebRequest request) {
            return base.Channel.InsertsupplierWeb(request);
        }
        
        public int InsertsupplierWeb(string suppliername, string Supplieraddress, string Supplieremail, int Suppliercontact_number, int Supplierregistration_date) {
            _interface.spc.InsertsupplierWebRequest inValue = new _interface.spc.InsertsupplierWebRequest();
            inValue.Body = new _interface.spc.InsertsupplierWebRequestBody();
            inValue.Body.suppliername = suppliername;
            inValue.Body.Supplieraddress = Supplieraddress;
            inValue.Body.Supplieremail = Supplieremail;
            inValue.Body.Suppliercontact_number = Suppliercontact_number;
            inValue.Body.Supplierregistration_date = Supplierregistration_date;
            _interface.spc.InsertsupplierWebResponse retVal = ((_interface.spc.WebService1Soap)(this)).InsertsupplierWeb(inValue);
            return retVal.Body.InsertsupplierWebResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<_interface.spc.InsertsupplierWebResponse> _interface.spc.WebService1Soap.InsertsupplierWebAsync(_interface.spc.InsertsupplierWebRequest request) {
            return base.Channel.InsertsupplierWebAsync(request);
        }
        
        public System.Threading.Tasks.Task<_interface.spc.InsertsupplierWebResponse> InsertsupplierWebAsync(string suppliername, string Supplieraddress, string Supplieremail, int Suppliercontact_number, int Supplierregistration_date) {
            _interface.spc.InsertsupplierWebRequest inValue = new _interface.spc.InsertsupplierWebRequest();
            inValue.Body = new _interface.spc.InsertsupplierWebRequestBody();
            inValue.Body.suppliername = suppliername;
            inValue.Body.Supplieraddress = Supplieraddress;
            inValue.Body.Supplieremail = Supplieremail;
            inValue.Body.Suppliercontact_number = Suppliercontact_number;
            inValue.Body.Supplierregistration_date = Supplierregistration_date;
            return ((_interface.spc.WebService1Soap)(this)).InsertsupplierWebAsync(inValue);
        }
        
        public int InsertstockrWeb(int drug_id, int warehouse_id, int quantity_in_stock, int purchase_price, int selling_price) {
            return base.Channel.InsertstockrWeb(drug_id, warehouse_id, quantity_in_stock, purchase_price, selling_price);
        }
        
        public System.Threading.Tasks.Task<int> InsertstockrWebAsync(int drug_id, int warehouse_id, int quantity_in_stock, int purchase_price, int selling_price) {
            return base.Channel.InsertstockrWebAsync(drug_id, warehouse_id, quantity_in_stock, purchase_price, selling_price);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        _interface.spc.InsertpharmacyWebResponse _interface.spc.WebService1Soap.InsertpharmacyWeb(_interface.spc.InsertpharmacyWebRequest request) {
            return base.Channel.InsertpharmacyWeb(request);
        }
        
        public int InsertpharmacyWeb(string pharmacy_name, string location, int contact_number, string email, string registration_date) {
            _interface.spc.InsertpharmacyWebRequest inValue = new _interface.spc.InsertpharmacyWebRequest();
            inValue.Body = new _interface.spc.InsertpharmacyWebRequestBody();
            inValue.Body.pharmacy_name = pharmacy_name;
            inValue.Body.location = location;
            inValue.Body.contact_number = contact_number;
            inValue.Body.email = email;
            inValue.Body.registration_date = registration_date;
            _interface.spc.InsertpharmacyWebResponse retVal = ((_interface.spc.WebService1Soap)(this)).InsertpharmacyWeb(inValue);
            return retVal.Body.InsertpharmacyWebResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<_interface.spc.InsertpharmacyWebResponse> _interface.spc.WebService1Soap.InsertpharmacyWebAsync(_interface.spc.InsertpharmacyWebRequest request) {
            return base.Channel.InsertpharmacyWebAsync(request);
        }
        
        public System.Threading.Tasks.Task<_interface.spc.InsertpharmacyWebResponse> InsertpharmacyWebAsync(string pharmacy_name, string location, int contact_number, string email, string registration_date) {
            _interface.spc.InsertpharmacyWebRequest inValue = new _interface.spc.InsertpharmacyWebRequest();
            inValue.Body = new _interface.spc.InsertpharmacyWebRequestBody();
            inValue.Body.pharmacy_name = pharmacy_name;
            inValue.Body.location = location;
            inValue.Body.contact_number = contact_number;
            inValue.Body.email = email;
            inValue.Body.registration_date = registration_date;
            return ((_interface.spc.WebService1Soap)(this)).InsertpharmacyWebAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        _interface.spc.InsertorderWebResponse _interface.spc.WebService1Soap.InsertorderWeb(_interface.spc.InsertorderWebRequest request) {
            return base.Channel.InsertorderWeb(request);
        }
        
        public int InsertorderWeb(int drug_id, int Pharmacy_id, string order_date, int quantity_ordered, string status) {
            _interface.spc.InsertorderWebRequest inValue = new _interface.spc.InsertorderWebRequest();
            inValue.Body = new _interface.spc.InsertorderWebRequestBody();
            inValue.Body.drug_id = drug_id;
            inValue.Body.Pharmacy_id = Pharmacy_id;
            inValue.Body.order_date = order_date;
            inValue.Body.quantity_ordered = quantity_ordered;
            inValue.Body.status = status;
            _interface.spc.InsertorderWebResponse retVal = ((_interface.spc.WebService1Soap)(this)).InsertorderWeb(inValue);
            return retVal.Body.InsertorderWebResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<_interface.spc.InsertorderWebResponse> _interface.spc.WebService1Soap.InsertorderWebAsync(_interface.spc.InsertorderWebRequest request) {
            return base.Channel.InsertorderWebAsync(request);
        }
        
        public System.Threading.Tasks.Task<_interface.spc.InsertorderWebResponse> InsertorderWebAsync(int drug_id, int Pharmacy_id, string order_date, int quantity_ordered, string status) {
            _interface.spc.InsertorderWebRequest inValue = new _interface.spc.InsertorderWebRequest();
            inValue.Body = new _interface.spc.InsertorderWebRequestBody();
            inValue.Body.drug_id = drug_id;
            inValue.Body.Pharmacy_id = Pharmacy_id;
            inValue.Body.order_date = order_date;
            inValue.Body.quantity_ordered = quantity_ordered;
            inValue.Body.status = status;
            return ((_interface.spc.WebService1Soap)(this)).InsertorderWebAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        _interface.spc.InsertstaffWebResponse _interface.spc.WebService1Soap.InsertstaffWeb(_interface.spc.InsertstaffWebRequest request) {
            return base.Channel.InsertstaffWeb(request);
        }
        
        public int InsertstaffWeb(string staff_name, string staff_address, string staff_email, int staff_contact_number, string staff_registration_date) {
            _interface.spc.InsertstaffWebRequest inValue = new _interface.spc.InsertstaffWebRequest();
            inValue.Body = new _interface.spc.InsertstaffWebRequestBody();
            inValue.Body.staff_name = staff_name;
            inValue.Body.staff_address = staff_address;
            inValue.Body.staff_email = staff_email;
            inValue.Body.staff_contact_number = staff_contact_number;
            inValue.Body.staff_registration_date = staff_registration_date;
            _interface.spc.InsertstaffWebResponse retVal = ((_interface.spc.WebService1Soap)(this)).InsertstaffWeb(inValue);
            return retVal.Body.InsertstaffWebResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<_interface.spc.InsertstaffWebResponse> _interface.spc.WebService1Soap.InsertstaffWebAsync(_interface.spc.InsertstaffWebRequest request) {
            return base.Channel.InsertstaffWebAsync(request);
        }
        
        public System.Threading.Tasks.Task<_interface.spc.InsertstaffWebResponse> InsertstaffWebAsync(string staff_name, string staff_address, string staff_email, int staff_contact_number, string staff_registration_date) {
            _interface.spc.InsertstaffWebRequest inValue = new _interface.spc.InsertstaffWebRequest();
            inValue.Body = new _interface.spc.InsertstaffWebRequestBody();
            inValue.Body.staff_name = staff_name;
            inValue.Body.staff_address = staff_address;
            inValue.Body.staff_email = staff_email;
            inValue.Body.staff_contact_number = staff_contact_number;
            inValue.Body.staff_registration_date = staff_registration_date;
            return ((_interface.spc.WebService1Soap)(this)).InsertstaffWebAsync(inValue);
        }
    }
}
