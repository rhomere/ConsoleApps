using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApps.StringManipulation
{
    public class StringManipulationService
    {
        public string ToMoneyOrDefault(decimal d)
        {
            // If the decimals after the number are all zeros
            // return number with two trailing zeros
            // else return normal currency string format
            var split = d.ToString().Split(new char[] { '.' });

            var decimals = split.LastOrDefault();

            if (decimals == null) return null;

            bool allZeros = false;
            int zeroCount = 0;

            for (int i = 0; i < decimals.Length; i++)
            {
                var t = decimals[i];
                if (t == '0') zeroCount++;
            }

            if (zeroCount == decimals.Length) allZeros = true;

            if (allZeros)
            {
                return string.Format("${0}.00", split.First());
            }
            else
            {
                return d.ToString("{0:C}");
            }
        }
    }
}
