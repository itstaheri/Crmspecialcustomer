using System;
using System.Text;
using System.Threading.Tasks;

namespace Frameworkes
{
    public class CodeGenerator
    {
        public static async Task<string> Generate(string symbol)
        {
            return $"{symbol}{(await RandomString())}{RandomNumber()}";
        }

        private static async Task<string> RandomString()
        {
            StringBuilder strBuild = new StringBuilder();

            await Task.Run(() =>
            {
                const int length = 2;

              
                var random = new Random();

                for (var i = 0; i <= length; i++)
                {
                    var flt = random.NextDouble();
                    var shift = Convert.ToInt32(Math.Floor(25 * flt));
                    var letter = Convert.ToChar(shift + 65);
                    strBuild.Append(letter);
                }

            });
            return strBuild.ToString();


        }

        private static string RandomNumber()
        {
            var random = new Random().Next(100, 999).ToString();
            return random;
        }
    }
}