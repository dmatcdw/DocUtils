﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.42000
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Xml.Serialization

'
'This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.42000.
'
Namespace uk.co.coversure.www
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3056.0"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Web.Services.WebServiceBindingAttribute(Name:="CsureDocsSoap", [Namespace]:="http://dmatters.co.uk/webservices")>  _
    Partial Public Class CsureDocs
        Inherits System.Web.Services.Protocols.SoapHttpClientProtocol
        
        Private GetDocuments_StringOperationCompleted As System.Threading.SendOrPostCallback
        
        Private GetDocumentsOperationCompleted As System.Threading.SendOrPostCallback
        
        Private GetMIMEDocumentsOperationCompleted As System.Threading.SendOrPostCallback
        
        Private DocListingRequestOperationCompleted As System.Threading.SendOrPostCallback
        
        Private QuoteDocRequestOperationCompleted As System.Threading.SendOrPostCallback
        
        Private QuoteDocRequestXmlOperationCompleted As System.Threading.SendOrPostCallback
        
        Private useDefaultCredentialsSetExplicitly As Boolean
        
        '''<remarks/>
        Public Sub New()
            MyBase.New
            Me.Url = Global.DocUtils.My.MySettings.Default.DocUtils_uk_co_coversure_www_CsureDocs
            If (Me.IsLocalFileSystemWebService(Me.Url) = true) Then
                Me.UseDefaultCredentials = true
                Me.useDefaultCredentialsSetExplicitly = false
            Else
                Me.useDefaultCredentialsSetExplicitly = true
            End If
        End Sub
        
        Public Shadows Property Url() As String
            Get
                Return MyBase.Url
            End Get
            Set
                If (((Me.IsLocalFileSystemWebService(MyBase.Url) = true)  _
                            AndAlso (Me.useDefaultCredentialsSetExplicitly = false))  _
                            AndAlso (Me.IsLocalFileSystemWebService(value) = false)) Then
                    MyBase.UseDefaultCredentials = false
                End If
                MyBase.Url = value
            End Set
        End Property
        
        Public Shadows Property UseDefaultCredentials() As Boolean
            Get
                Return MyBase.UseDefaultCredentials
            End Get
            Set
                MyBase.UseDefaultCredentials = value
                Me.useDefaultCredentialsSetExplicitly = true
            End Set
        End Property
        
        '''<remarks/>
        Public Event GetDocuments_StringCompleted As GetDocuments_StringCompletedEventHandler
        
        '''<remarks/>
        Public Event GetDocumentsCompleted As GetDocumentsCompletedEventHandler
        
        '''<remarks/>
        Public Event GetMIMEDocumentsCompleted As GetMIMEDocumentsCompletedEventHandler
        
        '''<remarks/>
        Public Event DocListingRequestCompleted As DocListingRequestCompletedEventHandler
        
        '''<remarks/>
        Public Event QuoteDocRequestCompleted As QuoteDocRequestCompletedEventHandler
        
        '''<remarks/>
        Public Event QuoteDocRequestXmlCompleted As QuoteDocRequestXmlCompletedEventHandler
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://dmatters.co.uk/webservices/GetDocuments_String", RequestNamespace:="http://dmatters.co.uk/webservices", ResponseNamespace:="http://dmatters.co.uk/webservices", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function GetDocuments_String(ByVal strXmlRequest As String) As String
            Dim results() As Object = Me.Invoke("GetDocuments_String", New Object() {strXmlRequest})
            Return CType(results(0),String)
        End Function
        
        '''<remarks/>
        Public Overloads Sub GetDocuments_StringAsync(ByVal strXmlRequest As String)
            Me.GetDocuments_StringAsync(strXmlRequest, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub GetDocuments_StringAsync(ByVal strXmlRequest As String, ByVal userState As Object)
            If (Me.GetDocuments_StringOperationCompleted Is Nothing) Then
                Me.GetDocuments_StringOperationCompleted = AddressOf Me.OnGetDocuments_StringOperationCompleted
            End If
            Me.InvokeAsync("GetDocuments_String", New Object() {strXmlRequest}, Me.GetDocuments_StringOperationCompleted, userState)
        End Sub
        
        Private Sub OnGetDocuments_StringOperationCompleted(ByVal arg As Object)
            If (Not (Me.GetDocuments_StringCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent GetDocuments_StringCompleted(Me, New GetDocuments_StringCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://dmatters.co.uk/webservices/GetDocuments", RequestNamespace:="http://dmatters.co.uk/webservices", ResponseNamespace:="http://dmatters.co.uk/webservices", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function GetDocuments(ByVal strXmlRequest As System.Xml.XmlNode) As String
            Dim results() As Object = Me.Invoke("GetDocuments", New Object() {strXmlRequest})
            Return CType(results(0),String)
        End Function
        
        '''<remarks/>
        Public Overloads Sub GetDocumentsAsync(ByVal strXmlRequest As System.Xml.XmlNode)
            Me.GetDocumentsAsync(strXmlRequest, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub GetDocumentsAsync(ByVal strXmlRequest As System.Xml.XmlNode, ByVal userState As Object)
            If (Me.GetDocumentsOperationCompleted Is Nothing) Then
                Me.GetDocumentsOperationCompleted = AddressOf Me.OnGetDocumentsOperationCompleted
            End If
            Me.InvokeAsync("GetDocuments", New Object() {strXmlRequest}, Me.GetDocumentsOperationCompleted, userState)
        End Sub
        
        Private Sub OnGetDocumentsOperationCompleted(ByVal arg As Object)
            If (Not (Me.GetDocumentsCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent GetDocumentsCompleted(Me, New GetDocumentsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://dmatters.co.uk/webservices/GetMIMEDocuments", RequestNamespace:="http://dmatters.co.uk/webservices", ResponseNamespace:="http://dmatters.co.uk/webservices", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function GetMIMEDocuments(ByVal strXmlRequest As System.Xml.XmlNode) As String
            Dim results() As Object = Me.Invoke("GetMIMEDocuments", New Object() {strXmlRequest})
            Return CType(results(0),String)
        End Function
        
        '''<remarks/>
        Public Overloads Sub GetMIMEDocumentsAsync(ByVal strXmlRequest As System.Xml.XmlNode)
            Me.GetMIMEDocumentsAsync(strXmlRequest, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub GetMIMEDocumentsAsync(ByVal strXmlRequest As System.Xml.XmlNode, ByVal userState As Object)
            If (Me.GetMIMEDocumentsOperationCompleted Is Nothing) Then
                Me.GetMIMEDocumentsOperationCompleted = AddressOf Me.OnGetMIMEDocumentsOperationCompleted
            End If
            Me.InvokeAsync("GetMIMEDocuments", New Object() {strXmlRequest}, Me.GetMIMEDocumentsOperationCompleted, userState)
        End Sub
        
        Private Sub OnGetMIMEDocumentsOperationCompleted(ByVal arg As Object)
            If (Not (Me.GetMIMEDocumentsCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent GetMIMEDocumentsCompleted(Me, New GetMIMEDocumentsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://dmatters.co.uk/webservices/DocListingRequest", RequestNamespace:="http://dmatters.co.uk/webservices", ResponseNamespace:="http://dmatters.co.uk/webservices", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function DocListingRequest(ByVal strXmlRequest As System.Xml.XmlNode) As String
            Dim results() As Object = Me.Invoke("DocListingRequest", New Object() {strXmlRequest})
            Return CType(results(0),String)
        End Function
        
        '''<remarks/>
        Public Overloads Sub DocListingRequestAsync(ByVal strXmlRequest As System.Xml.XmlNode)
            Me.DocListingRequestAsync(strXmlRequest, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub DocListingRequestAsync(ByVal strXmlRequest As System.Xml.XmlNode, ByVal userState As Object)
            If (Me.DocListingRequestOperationCompleted Is Nothing) Then
                Me.DocListingRequestOperationCompleted = AddressOf Me.OnDocListingRequestOperationCompleted
            End If
            Me.InvokeAsync("DocListingRequest", New Object() {strXmlRequest}, Me.DocListingRequestOperationCompleted, userState)
        End Sub
        
        Private Sub OnDocListingRequestOperationCompleted(ByVal arg As Object)
            If (Not (Me.DocListingRequestCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent DocListingRequestCompleted(Me, New DocListingRequestCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://dmatters.co.uk/webservices/QuoteDocRequest", RequestNamespace:="http://dmatters.co.uk/webservices", ResponseNamespace:="http://dmatters.co.uk/webservices", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function QuoteDocRequest(ByVal strXmlRequest As System.Xml.XmlNode) As String
            Dim results() As Object = Me.Invoke("QuoteDocRequest", New Object() {strXmlRequest})
            Return CType(results(0),String)
        End Function
        
        '''<remarks/>
        Public Overloads Sub QuoteDocRequestAsync(ByVal strXmlRequest As System.Xml.XmlNode)
            Me.QuoteDocRequestAsync(strXmlRequest, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub QuoteDocRequestAsync(ByVal strXmlRequest As System.Xml.XmlNode, ByVal userState As Object)
            If (Me.QuoteDocRequestOperationCompleted Is Nothing) Then
                Me.QuoteDocRequestOperationCompleted = AddressOf Me.OnQuoteDocRequestOperationCompleted
            End If
            Me.InvokeAsync("QuoteDocRequest", New Object() {strXmlRequest}, Me.QuoteDocRequestOperationCompleted, userState)
        End Sub
        
        Private Sub OnQuoteDocRequestOperationCompleted(ByVal arg As Object)
            If (Not (Me.QuoteDocRequestCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent QuoteDocRequestCompleted(Me, New QuoteDocRequestCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://dmatters.co.uk/webservices/QuoteDocRequestXml", RequestNamespace:="http://dmatters.co.uk/webservices", ResponseNamespace:="http://dmatters.co.uk/webservices", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function QuoteDocRequestXml(ByVal strXmlRequest As System.Xml.XmlNode) As System.Xml.XmlNode
            Dim results() As Object = Me.Invoke("QuoteDocRequestXml", New Object() {strXmlRequest})
            Return CType(results(0),System.Xml.XmlNode)
        End Function
        
        '''<remarks/>
        Public Overloads Sub QuoteDocRequestXmlAsync(ByVal strXmlRequest As System.Xml.XmlNode)
            Me.QuoteDocRequestXmlAsync(strXmlRequest, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub QuoteDocRequestXmlAsync(ByVal strXmlRequest As System.Xml.XmlNode, ByVal userState As Object)
            If (Me.QuoteDocRequestXmlOperationCompleted Is Nothing) Then
                Me.QuoteDocRequestXmlOperationCompleted = AddressOf Me.OnQuoteDocRequestXmlOperationCompleted
            End If
            Me.InvokeAsync("QuoteDocRequestXml", New Object() {strXmlRequest}, Me.QuoteDocRequestXmlOperationCompleted, userState)
        End Sub
        
        Private Sub OnQuoteDocRequestXmlOperationCompleted(ByVal arg As Object)
            If (Not (Me.QuoteDocRequestXmlCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent QuoteDocRequestXmlCompleted(Me, New QuoteDocRequestXmlCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        Public Shadows Sub CancelAsync(ByVal userState As Object)
            MyBase.CancelAsync(userState)
        End Sub
        
        Private Function IsLocalFileSystemWebService(ByVal url As String) As Boolean
            If ((url Is Nothing)  _
                        OrElse (url Is String.Empty)) Then
                Return false
            End If
            Dim wsUri As System.Uri = New System.Uri(url)
            If ((wsUri.Port >= 1024)  _
                        AndAlso (String.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) = 0)) Then
                Return true
            End If
            Return false
        End Function
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3056.0")>  _
    Public Delegate Sub GetDocuments_StringCompletedEventHandler(ByVal sender As Object, ByVal e As GetDocuments_StringCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3056.0"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class GetDocuments_StringCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As String
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),String)
            End Get
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3056.0")>  _
    Public Delegate Sub GetDocumentsCompletedEventHandler(ByVal sender As Object, ByVal e As GetDocumentsCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3056.0"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class GetDocumentsCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As String
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),String)
            End Get
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3056.0")>  _
    Public Delegate Sub GetMIMEDocumentsCompletedEventHandler(ByVal sender As Object, ByVal e As GetMIMEDocumentsCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3056.0"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class GetMIMEDocumentsCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As String
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),String)
            End Get
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3056.0")>  _
    Public Delegate Sub DocListingRequestCompletedEventHandler(ByVal sender As Object, ByVal e As DocListingRequestCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3056.0"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class DocListingRequestCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As String
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),String)
            End Get
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3056.0")>  _
    Public Delegate Sub QuoteDocRequestCompletedEventHandler(ByVal sender As Object, ByVal e As QuoteDocRequestCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3056.0"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class QuoteDocRequestCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As String
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),String)
            End Get
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3056.0")>  _
    Public Delegate Sub QuoteDocRequestXmlCompletedEventHandler(ByVal sender As Object, ByVal e As QuoteDocRequestXmlCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3056.0"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class QuoteDocRequestXmlCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As System.Xml.XmlNode
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),System.Xml.XmlNode)
            End Get
        End Property
    End Class
End Namespace
