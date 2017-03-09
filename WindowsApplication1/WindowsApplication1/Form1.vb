Imports System.IO
Imports System.Xml
Imports System.Text

Public Class Form1

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Creo el archivo donde almacenaré mi xml.
        Dim oFile As New FileStream("E:\\archivo.xml", FileMode.Create)

        ' Establezco el archivo y la codificación al objeto 
        Dim oXML As New XmlTextWriter(oFile, Encoding.UTF8)

        ' Le indico que se cree con sangría los nodos del xml..
        oXML.Formatting = Formatting.Indented
        oXML.WriteProcessingInstruction("xml", "version='1.0' encoding='utf-8'")
        oXML.WriteStartElement("Retention")

        oXML.WriteAttributeString("xmlns", "urn:sunat:names:specification:ubl:peru:schema:xsd:Retention-1")
        oXML.WriteAttributeString("xmlns", "cac", Nothing, "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")
        oXML.WriteAttributeString("xmlns", "cbc", Nothing, "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")
        oXML.WriteAttributeString("xmlns", "ccts", Nothing, "urn:un:unece:uncefact:documentation:2")
        oXML.WriteAttributeString("xmlns", "ds", Nothing, "http://www.w3.org/2000/09/xmldsig#")
        oXML.WriteAttributeString("xmlns", "ext", Nothing, "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2")
        oXML.WriteAttributeString("xmlns", "qdt", Nothing, "urn:oasis:names:specification:ubl:schema:xsd:QualifiedDatatypes-2")
        oXML.WriteAttributeString("xmlns", "sac", Nothing, "urn:sunat:names:specification:ubl:peru:schema:xsd:SunatAggregateComponents-1")
        oXML.WriteAttributeString("xmlns", "udt", Nothing, "urn:un:unece:uncefact:data:specification:UnqualifiedDataTypesSchemaModule:2")
        oXML.WriteAttributeString("xmlns", "xsi", Nothing, "http://www.w3.org/2001/XMLSchema-instance")


        'Version del UBL
        oXML.WriteElementString("cbc:UBLVersionID", "2.0")

        'Versión de la estructura del documento        oXML.WriteElementString("cbc:CustomizationID", "1.0")

        'Firma digital
        oXML.WriteStartElement("ext:UBLExtensions")
        oXML.WriteStartElement("ext:UBLExtension")
        oXML.WriteStartElement("ext:ExtensionContent")
        oXML.WriteStartElement("ds:Signature")
        oXML.WriteAttributeString("Id", "signatureKG")
        oXML.WriteStartElement("ds:SignedInfo")
        oXML.WriteStartElement("ds:CanonicalizationMethod")
        oXML.WriteAttributeString("Algorithm", "http://www.w3.org/TR/2001/REC-xml-c14n-20010315#WithComments")
        oXML.WriteEndElement()
        oXML.WriteStartElement("ds:SignatureMethod")
        oXML.WriteAttributeString("Algorithm", "http://www.w3.org/2000/09/xmldsig#dsa-sha1")
        oXML.WriteEndElement()
        oXML.WriteStartElement("ds:Reference")
        oXML.WriteAttributeString("URI", "")
        oXML.WriteStartElement("ds:Transforms")
        oXML.WriteStartElement("ds:Transform")
        oXML.WriteAttributeString("Algorithm", "http://www.w3.org/2000/09/xmldsig#envelopedsignature")
        oXML.WriteEndElement()
        oXML.WriteEndElement()
        oXML.WriteStartElement("ds:DigestMethod")
        oXML.WriteAttributeString("Algorithm", "http://www.w3.org/2000/09/xmldsig#sha1")
        oXML.WriteEndElement()
        oXML.WriteElementString("ds:DigestValue", "+pruib33lOapq6GSw58GgQLR8VGIGqANloj4EqB1cb4=")
        oXML.WriteEndElement()
        oXML.WriteEndElement()
        oXML.WriteElementString("ds:SignatureValue", "Oatv5xMfFInuGqiX9SoLDTy2yuLf0tTlMFkWtkdw1z/Ss6kiDz+vIgZhgKfIaxp+JbVy57GT52f1" &
                                         "8D6+WMYZ0xOxTK2mojNkJNewwTTXzqOqrrAlObs9YoS5JAQAMi/TwkR4brNniU9tVwyybirHxw0H" &
                                         "WVzN2bB43yQd9hOlXzRUYpC8/sXw78h7ME3E/zeu882aOFySOnHWB63imBQGcYBV+LIGR/JW8ER+" &
                                         "0VLMLatdwPVRbrWmz1/NIy5CWp1xWMaM6fC/9SXV0O1Lqopk0UeX2I2yuf05QhmVfjgUu6GnS3m6" &
                                         "o6zM9J36iDvMVZyj7vbJTwI8SfWjTSNqxXlqPQ==")

        oXML.WriteStartElement("ds:KeyInfo")
        oXML.WriteStartElement("ds:X509Data")
        oXML.WriteElementString("ds:X509Certificate", "Certificado Digital")
        oXML.WriteEndElement()
        oXML.WriteEndElement()
        oXML.WriteEndElement()
        oXML.WriteEndElement()
        oXML.WriteEndElement()
        oXML.WriteEndElement()
        oXML.WriteStartElement("cac:Signature")
        oXML.WriteElementString("cbc:ID", "IDSignKG")
        oXML.WriteStartElement("cac:SignatoryParty")
        oXML.WriteStartElement("cac:PartyIdentification")
        oXML.WriteElementString("cbc:ID", "20100307902")
        oXML.WriteEndElement()
        oXML.WriteStartElement("cac:PartyName")
        oXML.WriteElementString("cbc:Name", "<![CDATA[Resemin S.A]]>")
        oXML.WriteEndElement()
        oXML.WriteEndElement()
        oXML.WriteStartElement("cac:DigitalSignatureAttachment")
        oXML.WriteStartElement("cac:ExternalReference")
        oXML.WriteElementString("cbc:URI", "#signatureKG")
        oXML.WriteEndElement()
        oXML.WriteEndElement()
        oXML.WriteEndElement()

        'Numeración, conformada por serie y número correlativo
        oXML.WriteElementString("cbc:ID", "R001-123")

        'Fecha de emisión
        oXML.WriteElementString("cbc:IssueDate", "2015-06-24")

        'Datos del Emisor Electrónico
        oXML.WriteStartElement("cac:AgentParty")

        'Número de documento de identidad
        'Tipo de documento de identidad
        oXML.WriteStartElement("cac:PartyIdentification")
        oXML.WriteStartElement("cbc:ID")
        oXML.WriteAttributeString("schemeID", "6")
        oXML.WriteValue(20100307902)
        oXML.WriteEndElement()
        oXML.WriteEndElement()

        'Nombre Comercial
        oXML.WriteStartElement("cac:PartyName")
        oXML.WriteStartElement("cbc:Name")
        oXML.WriteValue("<![CDATA[Resemin S.A]]>")
        oXML.WriteEndElement()
        oXML.WriteEndElement()
        'Domicilio fiscal del Emisor Electrónico
        'Apellidos y nombres, denominación o razón social



        oXML.WriteEndElement()
        oXML.WriteEndElement()



        ' Vuelco el buffer.
        oXML.Flush()
        oFile.Close()

    End Sub
End Class
