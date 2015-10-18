using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWEARNESS.Models.Utilities
{
    public class UniqueKeyGenerator
    {
        private static UniqueKeyGenerator m_Instance;
        private UniqueKeyGenerator()
        {

        }
        public static UniqueKeyGenerator Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    m_Instance = new UniqueKeyGenerator();
                }
                return m_Instance;
            }
        }
        public string GetPinCode(int i_Length)
        {
            Random rnd = new Random();
            string input = "abcdefghijklmnopqrstuvwxyz0123456789";
            var chars = Enumerable.Range(0, i_Length)
                                   .Select(x => input[rnd.Next(0, input.Length)]);
            return new string(chars.ToArray());
        }
        public string GetNumbericPinCode(int i_Length)
        {
            Random rnd = new Random();
            string outputString = "";
            for (int i = 0; i < i_Length; i++)
            {
                outputString += rnd.Next(0, 9);
            }
            return outputString;
        }
    }
     
}

