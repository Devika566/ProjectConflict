using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace DemoSerialization
{
   [Serializable] //Compiler will fail to indicate which data has to be serialized we didn't used 'Serializable' class.
    //Compiler will noe indicate that this Customer class data has to be serialized.
    //[Serializable] this attribute is only used in the case og binaryFormatter serialization and deserialization but no need for XMLserialization and XMLdeserialization.

    public class BinaryFormatter
    {
        
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public long ContactNumber { get; set; }

        public void SerializeCustomerData()
        {
            FileStream fileStream = null; //FileStream is in-build class present in 'System.IO' namespace
            try
            {
                fileStream = new FileStream("C:\\Serialization\\Customer.txt", FileMode.Create,
                    FileAccess.ReadWrite);
                BinaryFormatter customer = new BinaryFormatter() { CustomerId = 101, CustomerName = "Rocks",ContactNumber=123444 };
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                formatter.Serialize(fileStream, customer);


            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally
            {
                fileStream.Close();
            }
        }
        public void DeSerializeCustomerData()
        {
            FileStream stream= null;
            try
            {
                stream = new FileStream("C:\\Serialization\\Customer.txt", FileMode.Open, FileAccess.Read);
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                BinaryFormatter customer=(BinaryFormatter)formatter.Deserialize(stream);
                Console.WriteLine("{0}\t {1}\t {2}",customer.CustomerId,customer.CustomerName,
                    customer.ContactNumber);
            }
            catch (Exception ex)
            {

                Console.WriteLine (ex.Message);
            }
        }


    }
}
