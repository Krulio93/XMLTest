using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace XMLTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load("Test1.xml");
                XmlNamespaceManager xmlnsm = new XmlNamespaceManager(xmldoc.NameTable);
                xmlnsm.AddNamespace("cs", "http://schemas.datacontract.org/2004/07/Intergraph.IPS.ChangeSubscription.Objects");

                string root = xmldoc.DocumentElement.Name;

                XmlNode node = xmldoc.DocumentElement.SelectSingleNode("//cs:AgencyEventId", xmlnsm);

                string inner = node.InnerText.Trim();


                XmlNode nodeName = xmldoc.DocumentElement.SelectSingleNode("//cs:CurrLev", xmlnsm);

                if (nodeName.Attributes.Count == 0)
                {
                    throw new Exception();
                }

                XmlAttributeCollection coll = nodeName.Attributes;



                if (nodeName.Attributes[0].Name.ToString() == "cs:changed")
                {

                }


                bool value =Convert.ToBoolean(nodeName.Attributes.Item(0).Value);

                //cs:changed="true" cs:oldValue="2"


                foreach (XmlAttribute item in coll)
                {
                    Console.WriteLine(item.Value);

                }

                Console.ReadKey();
            }
            catch (XmlException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                Console.ReadKey();
            }
        }
    }
}
