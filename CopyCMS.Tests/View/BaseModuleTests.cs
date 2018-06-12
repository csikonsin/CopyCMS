using CopyCMS.Code.ModuleParameters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyCMS.Tests.View
{
    [TestClass]
    public class BaseModuleTests
    {
        [TestMethod]
        public void SerializeDeserialize_EmptyObject()
        {
            var obj = new FakeParameter();
            var result = ParameterBuilder.Serialize(obj);

            var deserializedObj = ParameterBuilder.Deserialize<FakeParameter>(result);
            Assert.AreEqual(obj.Text, deserializedObj.Text);
        }

        
        [TestMethod]
        public void Deserialize_EmptyString()
        {
            var result = ParameterBuilder.Deserialize<FakeParameter>("");
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        public void SerializeDeserialize_Object()
        {
            var obj = new FakeParameter()
            {
                Text = "Hallo World!"
            };

            var result = ParameterBuilder.Serialize(obj);
            var des = ParameterBuilder.Deserialize<FakeParameter>(result);
            Assert.AreEqual(obj.Text, des.Text);
        }
    }


    public class FakeParameter : BaseParameter
    {
        public string Text { get; set; }
    }
}
