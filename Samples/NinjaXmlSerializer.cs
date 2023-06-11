using System.Reflection;
using System.Text;

namespace CodeSamples
{
    public class NinjaXmlSerializer
    {
        public static string Serialize(object sourceObj)
        {
            if (sourceObj == null) throw new ArgumentNullException("source");

            var objType = sourceObj.GetType();
            var typeName = objType.Name;
            var properties = objType.GetProperties();

            var xml = new StringBuilder();

            xml.BeginXmlTag(typeName);
            xml.AppendLines(SerializeProperties(sourceObj, objType));
            xml.EndXmlTag(typeName);

            return xml.ToString();
        }
        private static string AppendTags(string key, string value)
        {
            return($"<{key}>{value}</{key}>");
        }

        private static IEnumerable<string> SerializeProperties(object sourceObj, Type type)
        {
            foreach (var property in type.GetProperties())
            {
                var propertyValue = property.GetValue(sourceObj);
                if (IsClass(property))
                {
                    yield return (Serialize(propertyValue));
                } else
                {
                    var propertyName = property.Name;
                    yield return (AppendTags(propertyName, propertyValue.ToString()));
                }
            }

        }

        private static bool IsClass(PropertyInfo property)
        {
            var objType = property.PropertyType;
            return objType != typeof(int) && objType != typeof(string);
        }
    }
}