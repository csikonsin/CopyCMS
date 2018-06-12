using CopyCMS.Code.ModuleParameters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace CopyCMS
{
    public interface IBaseModule
    {
        void SetParameter(BaseParameter parameter);
    }

    public static class ParameterBuilder
    {
        public static BaseParameter Deserialize(string settings, Type type)
        {
            BaseParameter result = null;

            try
            {
                using(var reader = new StringReader(settings))
                {
                    var deserializer = new XmlSerializer(type);
                    result = (BaseParameter)deserializer.Deserialize(reader);
                }
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }

        public static string Serialize<T>(T obj) where T: BaseParameter
        {
            string result = string.Empty;
            try
            {
                var serializer = new XmlSerializer(obj.GetType());
                using(var writer = new StringWriter())
                {
                    serializer.Serialize(writer, obj);
                    result = writer.ToString();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
    }
}