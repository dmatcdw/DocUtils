Imports System.Security.Principal

Public Class DocUtils
    Public strDocPaths(10) As String
    Public strDocDescs(10) As String
    Public strSettingsPath As String = "wslog\DocUtils_Diagnostics.txt"
    Public DiagnosticsOn As Boolean = False
    Public strLogPath As String = Nothing
    Public strDrive As String = Nothing
    Public QuoteRef As String = Nothing

    Dim strServerPool As String = Nothing
    Dim strArguments As String = Nothing
    Dim strResult As String = Nothing
    Dim strProgName As String = Nothing
    Dim strMethod As String = Nothing
    Dim strPath As String = Nothing


    Dim XmlDets As XmlTools.Xml = New XmlTools.Xml
    Dim LiveDocSvc As uk.co.coversure.www.CsureDocs = New uk.co.coversure.www.CsureDocs
    Dim LocalDocSvc As LocalCsureDocs.CsureDocs = New LocalCsureDocs.CsureDocs
    Dim TestDocSvc As TestCsureDocs.CsureDocs = New TestCsureDocs.CsureDocs
    Public Function DocsAvailable(ByVal ServerPool As String, ByVal strUserId As String, ByVal strQuoteType As String, ByVal strDocRef As String) As String
        If strQuoteType = "cv" Then
            strPath = "&path=MDS,PF-FLEET,"
        Else
            strPath = "&path=MDS,POLICYFAST,"
        End If
        strServerPool = ServerPool
        strArguments = strPath & "&userid=" & strUserId & "&quotetype=" & strQuoteType & "&formatreqd=xml&reference=" & strDocRef
        strProgName = "getdocuments"
        strMethod = "POST"
        ConnectToD3()
        Return strResult
    End Function
    Public Function GetMTADocs(ByVal ServerPool As String, ByVal strUserId As String, ByVal strQuoteType As String, ByVal strDocRef As String, ByVal strLastDate As String, ByVal strLastTime As String) As String
        If strQuoteType = "cv" Then
            strPath = "&path=MDS,PF-FLEET,"
        Else
            strPath = "&path=MDS,POLICYFAST,"
        End If
        strServerPool = ServerPool
        strArguments = strPath & "&itemid=" & strDocRef & "&lastdate=" & strLastDate & "&lasttime=" & strLastTime
        strProgName = "get.mta.docs"
        strMethod = "POST"
        ConnectToD3()
        Return strResult
    End Function
    Public Function GetFormattedDocument(ByVal strFormatRequired As String, ByVal strPDF As String) As String
        Dim LogDetails As String = Nothing
        Dim strDiagsOn As String = Nothing
        '
        ' -----------------------------
        ' Set up logging
        ' -----------------------------
        '
        If Environment.MachineName = "CHRISWARD-PC" Then
            strDrive = "d:\"
        Else
            strDrive = "e:\"
        End If

        Try
            LogDetails = My.Computer.FileSystem.ReadAllText(strDrive & strSettingsPath)
            strDiagsOn = LogDetails.Split(",")(0)
        Catch ex As Exception
            strDiagsOn = "OFF"
        End Try

        If strDiagsOn = "ON" Then
            Dim DatePart As String = Year(Today) & Format(Month(Today), "00") & Format(Day(Today), "00")
            Dim TimePart As String = Format(Hour(Now), "00") & Format(Minute(Now), "00") & Format(Second(Now), "00")
            Dim rootpath As String = LogDetails.Split(",")(1)
            strLogPath = strDrive & rootpath & "_GetFormattedDocument_" & DatePart & TimePart & ".txt"
            DiagnosticsOn = True
        End If
        LogMessage("Opening Log to " & strLogPath)
        '
        '************************************************
        ' Function to wrap document in MIME or XML tags
        '************************************************
        '
        Dim strFormattedDocument As String = Nothing
        Select Case strFormatRequired
            Case "string"
                strFormattedDocument &= "--MIME_boundary"
                strFormattedDocument &= strPDF
            Case "xml"
                '
                '*******************************************************
                ' Extract the PDF from MIME Document and re-wrap in XML
                '*******************************************************
                '
                Dim strElementArray() As String
                Dim strElementDataDescriptor As String
                Dim strElementDataValue As String
                Dim strDocID As String = Nothing
                Dim strDocFilename As String = Nothing
                Dim docarray() As String = strPDF.Split(vbLf)
                Dim intNoofElements As Integer = docarray.Length - 1
                Dim strDocBase64 As String = Nothing
                For x = 0 To intNoofElements
                    Dim strPdfElement As String = docarray(x)
                    LogMessage("Element " & x.ToString & "=" & strPdfElement)
                    If strPdfElement <> Nothing Then
                        If docarray(x).Length > 200 Then
                            strDocBase64 = docarray(x)
                        Else
                            strElementArray = strPdfElement.Split(":")
                            strElementDataDescriptor = strElementArray(0)
                            If strElementArray.Length > 1 Then
                                strElementDataValue = strElementArray(1)
                                strElementDataValue = strElementDataValue.Replace(vbCrLf, Nothing)
                                strElementDataValue = strElementDataValue.Replace(vbCr, Nothing)
                                strElementDataValue = strElementDataValue.Replace(Chr(10), Nothing)
                            Else
                                strElementDataValue = Nothing
                            End If

                            If Mid(strElementDataDescriptor, 1, 10) = "Content-ID" Then strElementDataDescriptor = "Content-ID"
                            Select Case strElementDataDescriptor
                                Case "Content-ID"
                                    Dim strDocIDa As String = Mid(strElementDataValue, 2)
                                    strDocID = Right(strDocIDa, strDocIDa.Length - 2)
                                    strDocID = strDocID.Replace(">", Nothing)
                                    strDocID = strDocID.Replace("<", Nothing)
                                Case "Content-Disposition"
                                    Dim strEqPos As Integer = strElementDataValue.IndexOf("=") + 2
                                    strDocFilename = Mid(strElementDataValue, strEqPos)
                            End Select
                        End If
                    End If
                Next
                strFormattedDocument &= "<document>"
                strFormattedDocument &= "<id>" & strDocID & "</id>"
                strFormattedDocument &= "<filename>" & strDocFilename & "</filename>"
                strFormattedDocument &= "<base64>" & strDocBase64 & "</base64>"
                strFormattedDocument &= "</document>"
        End Select

        Return strFormattedDocument
    End Function
    Public Function GetQuoteDocUrls(ByVal ServerPool As String, ByVal strPayload As String, ByVal strLob As String) As String
        If strLob = "cv" Then
            strPath = "&path=MDS,PF-FLEET,"
        Else
            strPath = "&path=MDS,POLICYFAST,"
        End If
        strServerPool = ServerPool
        strArguments = strPath & "&payload=" & strPayload & "&lob=" & strLob
        strProgName = "GetQuoteDocs"
        strMethod = "POST"
        ConnectToD3()
        Return strResult
    End Function
    Public Function QuoteDocsAvailable(ByVal ServerPool As String, ByVal strUserId As String, ByVal strQuoteType As String, ByVal strDocRef As String, ByVal strPremium As String, ByVal strInsurer As String) As String
        If strQuoteType = "cv" Then
            strPath = "&path=MDS,PF-FLEET,"
        Else
            strPath = "&path=MDS,POLICYFAST,"
        End If
        strServerPool = ServerPool
        strArguments = strPath & "&userid=" & strUserId & "&quotetype=" & strQuoteType
        strArguments &= "&formatreqd=xml&reference=" & strDocRef
        strArguments &= "&mode=quote&cocode=" & strInsurer & "&premium=" & strPremium
        strProgName = "prepareprint"
        strMethod = "POST"
        ConnectToD3()
        Return strResult
    End Function
    Private Sub ConnectToD3()
        Dim strArg As String = Nothing
        Dim Http As New MSXML.XMLHTTPRequest
        Dim RandomNumber As Random = New Random
        Dim strDomain As String = Nothing
        Select Case strServerPool
            Case "doris"
                strDomain = "http://www.datamatters.info"
            Case "wendy"
                strDomain = "http://www.coversure.co.uk"
        End Select
        Dim strRandomString As String = "&random=" & RandomNumber.Next.ToString
        Dim ConnectionString As String = strDomain & "/cgi-bin/fccgi.exe?w3exec=" + strProgName

        If strServerPool <> Nothing Then
            strArg = "&w3serverpool=" & strServerPool & strArguments & strRandomString
        Else
            strArg = strArguments & strRandomString
        End If

        If strMethod = Nothing Then
            strMethod = "GET"
        End If

        Try
            Http.open(strMethod, ConnectionString, False)
            Http.setRequestHeader("Content-Type", "application/x-www-form-urlencoded")
            Http.setRequestHeader("Timeout", "600000")
            Http.send(strArg)
            strResult = Http.responseText
        Catch ex As Exception
            strResult = strProgName & " - " & ex.Message
        End Try
    End Sub
    Public Sub CheckDocsDone(ByVal strDocListing As String, ByRef blnDocsReady As Boolean)
        '
        '**************************************************
        ' Check all available documents have been generated
        '**************************************************
        '
        Dim intIPos As Integer = Nothing
        Dim strStartString As String = "<Document>"
        Dim strEndString As String = "</Document>"
        Dim intEndPos As Integer = 0
        Dim strInsSegment As String = Nothing
        Dim intStartPos As Integer = 0
        Dim strDocUrl As String = Nothing
        Dim strDocDesc As String = Nothing
        Dim intDocCount As Integer = 0
        blnDocsReady = True
        Dim blnCert As Boolean = False
        Dim blnSof As Boolean = False
        Dim intArrayCounter As Int32 = 0
        '
        '*********************************************************************************
        ' Check output from document listing request to make sure all documents have a URL
        '*********************************************************************************
        '
        Do
            '
            '***************************************
            ' Get insurer segment -1 means not found
            '***************************************
            '
            intIPos = strDocListing.IndexOf(strStartString, intStartPos)
            If intIPos <> -1 Then
                If intIPos = 0 Then intIPos = 1
                intEndPos = strDocListing.IndexOf(strEndString, intIPos)
                strInsSegment = Mid(strDocListing, intIPos, ((intEndPos - intIPos) + strEndString.Length + 1))
                strDocUrl = XmlDets.ExtractFromXml("Document_Url", strInsSegment, "Val")
                strDocDesc = XmlDets.ExtractFromXml("Document_Desc", strInsSegment, "Val")
                If strDocUrl = Nothing Or strDocDesc = "Documents are still being produced" Then
                    blnDocsReady = False
                Else
                    blnCert = False
                    blnSof = False
                    If strDocDesc.IndexOf("Statement of Facts", 1) > -1 Then blnSof = True
                    If strDocDesc.IndexOf("Certificate and Schedule", 1) > -1 Then blnCert = True
                    '
                    ' -----------------------------------------------------
                    ' Only interested in Statement of Facts or Certificates
                    ' -----------------------------------------------------
                    '
                    If blnSof = True Or blnCert = True Then
                        strDocPaths(intArrayCounter) = strDocUrl
                        strDocDescs(intArrayCounter) = strDocDesc
                        intArrayCounter += 1
                    End If
                    intDocCount += 1
                End If
                intStartPos = intIPos + 1
            End If
        Loop Until (intIPos = -1)
        If intDocCount = 0 Then
            blnDocsReady = False
        End If
    End Sub
    Public Function FormatDocResponse(ByVal strQuoteResults As String, ByVal strPolRef As String, ByVal strDocFormat As String, ByVal strEnv As String, ByVal strUserName As String, ByVal strUserPwd As String, ByVal strPathResults As String) As String
        Dim strDocResponse As String = Nothing
        Dim intLoopCount As Integer = 0
        Dim blnDocsGenerated As Boolean = False
        Dim strDocUrl As String = Nothing
        Dim strDocDesc As String = Nothing
        Dim strPDF As String = Nothing
        Dim xmlDocRequest As System.Xml.XmlDocument
        Dim strFault As String = Nothing
        Dim LogDetails As String = Nothing
        Dim strDiagsOn As String = Nothing
        System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12

        '
        ' -----------------------------
        ' Set up logging
        ' -----------------------------
        '
        If Environment.MachineName = "CHRISWARD-PC" Then
            strDrive = "d:\"
        Else
            strDrive = "e:\"
        End If

        Try
            LogDetails = My.Computer.FileSystem.ReadAllText(strDrive & strSettingsPath)
            strDiagsOn = LogDetails.Split(",")(0)
        Catch ex As Exception
            strDiagsOn = "OFF"
        End Try
        Dim D3PolicyRec As String = Nothing
        Dim q1(200) As String
        If strDiagsOn = "ON" Then
            Dim DatePart As String = Year(Today) & Format(Month(Today), "00") & Format(Day(Today), "00")
            Dim TimePart As String = Format(Hour(Now), "00") & Format(Minute(Now), "00") & Format(Second(Now), "00")
            Dim rootpath As String = LogDetails.Split(",")(1)
            '     strLogPath = strDrive & rootpath & "_FormatDocResponse_" & DatePart & TimePart & ".txt"
            strArguments = strPath & "&user=" & strUserName
            strArguments &= "&file=POLICIES&itemid=" & strPolRef
            strArguments &= "&path=MDS,PF-FLEET,"
            strProgName = "readitem"
            strMethod = "POST"
            ConnectToD3()
            D3PolicyRec = strResult.Replace("*am*", "~")
            q1 = D3PolicyRec.Split("~")
            QuoteRef = q1(3)
            strLogPath = strDrive & "wslog\Truck\WriteBusinessProcess_" & QuoteRef & ".txt"
            DiagnosticsOn = True
        End If
        LogMessage("DocUtils_FormatDocResponse Opening Log to " & strLogPath)
        LogMessage("DocUtils_FormatDocResponse Starting document formatting for quote " & QuoteRef)
        If strDocFormat = "string" Then
            strDocResponse = "MIME-Version: 1.0 Content-Type: multipart/mixed; boundary=MIME_boundary"
            '
            '*******************************************************
            ' Before PDF files done, add XML Write business response
            '*******************************************************
            '
            strDocResponse &= vbCrLf & "--MIME_boundary"
            strDocResponse &= vbCrLf & "Content-Type: text/xml"
            strDocResponse &= vbCrLf & "Content-Transfer-Encoding : 8bit "
            strDocResponse &= vbCrLf & "Content-ID : <" & strPolRef & ".xml>"
            strDocResponse &= vbCrLf
            strDocResponse &= vbCrLf & strQuoteResults & vbCrLf
        Else
            '
            '*************************
            ' xml response for Acturis
            '*************************
            '
            Dim intXmlstart As Integer = strQuoteResults.IndexOf(">", 1) + 1
            strDocResponse = Left(strQuoteResults, intXmlstart) & "<WriteBusinessResult>" & Mid(strQuoteResults, intXmlstart + 1) & "<documents>"
        End If
        LogMessage("DocUtils_FormatDocResponse Completed document formatting; strpathresults = " & strPathResults)
        If strPathResults <> Nothing Then
            FormDocArrays(strPathResults)
        End If
        Do
            strDocUrl = strDocPaths(intLoopCount)
            strDocDesc = strDocDescs(intLoopCount)

            LogMessage("DocUtils_FormatDocResponse count = " & intLoopCount.ToString & " url=" & strDocUrl & " Desc=" & strDocDesc & " results= " & strPathResults)
            LogMessage("DocUtils_FormatDocResponse strenv=" & strEnv)
            LogMessage("DocUtils_FormatDocResponse strdocurl=" & strDocUrl)
            If strDocUrl = Nothing Then
                blnDocsGenerated = True
            Else
                xmlDocRequest = Nothing
                strPDF = Nothing
                '
                '*******************************************
                ' Get Individual Documents, add to MIME file
                '*******************************************
                '
                xmlDocRequest = FormDocRequest(strPolRef, strDocUrl, strEnv, strUserName, strUserPwd)

                '  strPDF = svcDoc.GetDocuments(xmlDocRequest)
                If Environment.MachineName = "CHRISWARD-PC" Then
                    Try
                        strPDF = LocalDocSvc.GetDocuments(xmlDocRequest)
                    Catch ex As Exception
                        strFault = ex.Message
                    End Try
                Else
                    If strEnv = "T" Then
                        TestDocSvc.Timeout = 600000
                        strPDF = TestDocSvc.GetDocuments(xmlDocRequest)
                    Else
                        LiveDocSvc.Timeout = 600000
                        strPDF = LiveDocSvc.GetDocuments(xmlDocRequest)
                    End If
                End If
                Dim strElementArray() As String
                Dim strElementDataDescriptor As String
                Dim strElementDataValue As String
                Dim strDocID As String = Nothing
                Dim strDocFilename As String = Nothing
                Dim strDocBase64 As String = Nothing
                LogMessage("DocUtils_FormatDocResponse adding to response")
                If strDocFormat = "string" Then
                    strDocResponse = strDocResponse & "--MIME_boundary"
                    strDocResponse &= strPDF
                Else
                    'xml
                    Try
                        Dim docarray() As String = strPDF.Split(vbLf)
                        Dim intNoofElements As Integer = docarray.Length - 1
                        For x = 0 To intNoofElements
                            Dim strPdfElement As String = docarray(x)
                            If strPdfElement <> Nothing Then
                                If x = 6 Then
                                    strDocBase64 = docarray(6)
                                Else
                                    Try
                                        strElementArray = strPdfElement.Split(":")
                                        strElementDataDescriptor = strElementArray(0)
                                        strElementDataValue = strElementArray(1)
                                        If Mid(strElementDataDescriptor, 1, 10) = "Content-ID" Then strElementDataDescriptor = "Content-ID"
                                        Try
                                            Select Case strElementDataDescriptor
                                                Case "Content-ID"
                                                    Dim strDocIDa As String = Mid(strElementDataValue, 2)
                                                    strDocID = Right(strDocIDa, strDocIDa.Length - 1)
                                                Case "Content-Disposition"
                                                    Dim strEqPos As Integer = strElementDataValue.IndexOf("=") + 2
                                                    strDocFilename = Mid(strElementDataValue, strEqPos)
                                            End Select
                                        Catch ex As Exception
                                            strFault = ex.ToString
                                        End Try
                                    Catch ex As Exception
                                        strFault = ex.ToString
                                    End Try
                                End If
                            End If
                        Next
                    Catch ex As Exception
                        strFault = ex.ToString
                    End Try

                    strDocResponse &= "<document>"
                    strDocResponse &= "<id>" & strDocID & "</id>"
                    strDocResponse &= "<filename>" & strDocFilename & "</filename>"
                    strDocResponse &= "<base64>" & strDocBase64 & "</base64>"
                    strDocResponse &= "</document>"
                End If

                intLoopCount += 1
            End If
        Loop Until blnDocsGenerated = True
        If strDocFormat = "xml" Then
            strDocResponse &= "</documents>"
            strDocResponse &= "</WriteBusinessResult>"
        End If

        Return strDocResponse
    End Function
    Public Function FormatDocErrorResponse(ByVal strQuoteResults As String, ByVal strPolRef As String, ByVal strDocFormat As String) As String
        Dim strDocResponse As String = Nothing
        Dim strTempstring As String
        Dim strTempPos As Integer = strQuoteResults.IndexOf("</QuoteResults>", 0)
        strTempstring = Left(strQuoteResults, strTempPos)
        strQuoteResults = strTempstring & "<Error><Error_General Val = ""Document Timeout"" /></Error></QuoteResults></root>"
        If strDocFormat = "string" Then
            strDocResponse = "MIME-Version: 1.0 Content-Type: multipart/mixed; boundary=MIME_boundary"
            strDocResponse &= vbCrLf & "--MIME_boundary"
            strDocResponse &= vbCrLf & "Content-Type: text/xml"
            strDocResponse &= vbCrLf & "Content-Transfer-Encoding : 8bit "
            strDocResponse &= vbCrLf & "Content-ID : <" & strPolRef & ".xml>"
            strDocResponse &= vbCrLf
            strDocResponse &= vbCrLf & strQuoteResults & vbCrLf
        End If
        Return strDocResponse
    End Function
    Private Function FormDocRequest(ByVal strPolRef As String, ByVal strUrl As String, ByVal strEnv As String, ByVal strUserName As String, ByVal strUserPwd As String) As System.Xml.XmlDocument
        '
        '*************************************************************
        ' Utility to form Document request for all available Documents
        '*************************************************************
        '
        Dim strDocRequest As String = "<?xml version=""1.0"" encoding=""utf-8""?>"
        Dim strTransDate As String = Date.Today.ToString
        Dim strTransTime As String = TimeOfDay
        strDocRequest &= "<Service>"
        strDocRequest &= "<Header>"
        strDocRequest &= "<Header_Environment Val=""" & strEnv & """/>"
        strDocRequest &= "<Header_Status val=""ok""/>"
        strDocRequest &= "<Header_Transref Val=""81""/>"
        strDocRequest &= "<Header_TransDate Val=""" & strTransDate & """/>"
        strDocRequest &= "<Header_TransTime Val=""" & strTransTime & """/>"
        strDocRequest &= "<Header_UserName Val=""" & strUserName & """/>"
        strDocRequest &= "<Header_Password Val=""" & strUserPwd & """/>"
        strDocRequest &= "</Header>"
        strDocRequest &= "<Service_Function val=""Request""/>"
        strDocRequest &= "<Service_BusinessRef val=""" & strPolRef & """/>"
        strDocRequest &= "<Service_BusinessType val=""Truck""/>"
        strDocRequest &= "<Document><Document_Url val=""" & strUrl & """/>"
        strDocRequest &= "</Document>"
        strDocRequest &= "</Service>"
        Dim xmldoc As New System.Xml.XmlDocument
        xmldoc.LoadXml(strDocRequest)
        Return xmldoc
    End Function
    Private Function ExtractFromXml(ByVal strElement As String, ByVal strXmlRequest As String) As String
        '
        '***************************************
        ' Utility to extract field from XML file
        '***************************************
        '
        Dim strXmlField As String = Nothing
        Dim IntTagStart As Integer = 0
        Dim strTemp As String = Nothing
        Dim strTempArray As String()
        Dim intExtractLen As Integer = 0
        IntTagStart = strXmlRequest.IndexOf(strElement)
        If IntTagStart < 0 Then
            strXmlField = "Error:Tag not found"
        Else
            intExtractLen = strXmlRequest.Length - IntTagStart
            If IntTagStart > 0 Then
                strTemp = Mid(strXmlRequest, IntTagStart, intExtractLen)
            Else
                strTemp = Left(strXmlRequest, intExtractLen)
            End If

            strTempArray = strTemp.Split(Chr(34))
            strXmlField = strTempArray(1)
        End If
        Return strXmlField
    End Function
    Private Sub FormDocArrays(ByVal strDocListing As String)

        Dim intIPos As Integer = 0
        Dim intEndPos As Integer = 0
        Dim intDocCount As Integer = 0
        Dim intStartPos As Integer = 0
        Dim strInsSegment As String = Nothing
        Dim strDocUrl As String = Nothing
        Dim strDocDesc As String = Nothing
        Dim strStartString As String = "<Document>"
        Dim strEndString As String = "</Document>"
        Dim blnDocsReady As Boolean = False
        Dim strErrorMsg As String = Nothing
        Dim intArrayCounter As Integer = 0
        Do
            '
            '***************************************
            ' Get insurer segment -1 means not found
            '***************************************
            '
            Dim blnCert As Boolean = False
            Dim blnSof As Boolean = False

            Try
                intIPos = strDocListing.IndexOf(strStartString, intStartPos)
                If intIPos <> -1 Then
                    blnCert = False
                    blnSof = False
                    If intIPos = 0 Then intIPos = 1
                    intEndPos = strDocListing.IndexOf(strEndString, intIPos)
                    strInsSegment = Mid(strDocListing, intIPos, ((intEndPos - intIPos) + strEndString.Length + 1))
                    strDocUrl = XmlDets.ExtractFromXml("Document_Url", strInsSegment, "Val")
                    strDocDesc = XmlDets.ExtractFromXml("Document_Desc", strInsSegment, "Val")
                    If strDocDesc.IndexOf("Statement of Facts", 1) > -1 Then blnSof = True
                    If strDocDesc.IndexOf("Certificate and Schedule", 1) > -1 Then blnCert = True
                    '
                    ' -----------------------------------------------------
                    ' Only interested in Statement of Facts or Certificates
                    ' -----------------------------------------------------
                    '
                    LogMessage("DocUtils_FormDocArrays strdocdesc=" & strDocDesc & "strinsegment= " & strInsSegment & "blnSof=" & blnSof.ToString & "blncert=" & blnCert.ToString)
                    If blnSof = True Or blnCert = True Then
                        strDocPaths(intArrayCounter) = strDocUrl
                        strDocDescs(intArrayCounter) = strDocDesc
                        LogMessage("DocUtils_FormDocArrays Adding to array... counter= " & intArrayCounter.ToString & " strdocurl = " & strDocUrl & "strdocdescs= " & strDocDesc)
                        intArrayCounter += 1
                    End If
                    intDocCount += 1
                    intStartPos = intIPos + 1
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try

        Loop Until (intIPos = -1)
    End Sub
    Private Sub LogMessage(ByVal ErrorMsg As String)
        If DiagnosticsOn = True Then
            Dim LogDate As Date = Today
            Dim LogTime As Date = Now
            FileOpen(1, strLogPath, OpenMode.Append)
            Print(1, LogTime.ToString & " " & ErrorMsg & vbCrLf)
            FileClose(1)
        End If
    End Sub
End Class
