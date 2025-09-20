using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DocTapTinXML2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            using (XmlWriter writer = XmlWriter.Create("books.xml")) 
            {
                String pi = "type=\"text/xsl\" href=\"book.xsl\"";
                writer.WriteProcessingInstruction("xml-stylesheet", pi);
                writer.WriteDocType("catalog", null, null, "<!ENTITY h \"hardcover\">");
                writer.WriteComment("This is a book sample XML");
                writer.WriteStartElement("book");
                writer.WriteAttributeString("ISBN", "9831123212");
                writer.WriteAttributeString("yearpublushed", "2002");
                writer.WriteAttributeString("author", "Mahesh Chand");
                writer.WriteAttributeString("tittle", "Visual C# Programming");
                writer.WriteAttributeString("price", "44.95");
                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Flush();
            }    
        }
    }
}
