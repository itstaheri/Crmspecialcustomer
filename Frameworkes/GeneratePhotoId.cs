using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frameworkes
{
    public class GeneratePhotoId
    {
        public static string Generate(string value)
        {
            //make name by value + randomNumber
            Random random = new Random();
            return value + (random.Next(3001, 124000).ToString());

        }
    }
}
