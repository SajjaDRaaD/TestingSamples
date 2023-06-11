using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CodeSamples
{
    public static class StringBuilderExtensions
    {
        public static void AppendLines(this StringBuilder target, IEnumerable<string> lines)
        {
            foreach (var line in lines)
            {
                target.Append(line);
            }
        }

        public static void BeginXmlTag(this StringBuilder target, string key) => target.Append($"<{key}>");

        public static void EndXmlTag(this StringBuilder target, string key) => target.Append($"</{key}>");
    }
}
