using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Firedump.utils.parsers;

namespace FiredumpTest
{
    /// <summary>
    /// Summary description for TestStatementTypeResolver
    /// </summary>
    [TestClass]
    public class TestStatementTypeResolver
    {
        
        [TestMethod]
        public void TestResolveSelect()
        {
            //Assert.AreEqual("select", "select".Trim().Split(' ')[0].ToLower());
            //Assert.AreEqual(StatementType.SELECT, StatementTypeResolver.Resolve("select"));
            //Assert.AreEqual(StatementType.SELECT, StatementTypeResolver.Resolve("select\n"));
            //Assert.AreEqual(StatementType.SELECT, StatementTypeResolver.Resolve("select\t"));
            //Assert.AreEqual(StatementType.SELECT, StatementTypeResolver.Resolve("SeLeCT"));
            //Assert.AreEqual(StatementType.SELECT, StatementTypeResolver.Resolve("select       "));
            //Assert.AreEqual(StatementType.SELECT, StatementTypeResolver.Resolve("select "));
            //Assert.AreEqual(StatementType.SELECT, StatementTypeResolver.Resolve("  SELECT"));
            //Assert.AreEqual(StatementType.SELECT, StatementTypeResolver.Resolve("  \t\t\tSELECT *\t\n\n  \n"));
            //Assert.AreEqual(StatementType.SELECT, StatementTypeResolver.Resolve("   select"));
            //Assert.AreEqual(StatementType.SELECT, StatementTypeResolver.Resolve(";select"));
        }

        [TestMethod]
        public void TestResolveOther()
        {
            //Assert.AreEqual(StatementType.OTHER, StatementTypeResolver.Resolve("sselect "));
            //Assert.AreEqual(StatementType.OTHER, StatementTypeResolver.Resolve("sselect\n"));
            //Assert.AreEqual(StatementType.OTHER, StatementTypeResolver.Resolve("\tsselect\n"));
            //Assert.AreEqual(StatementType.OTHER, StatementTypeResolver.Resolve("select\0"));//'\0' -> null is not valid
            //Assert.AreEqual(StatementType.OTHER, StatementTypeResolver.Resolve("   selectt"));
            //Assert.AreEqual(StatementType.OTHER, StatementTypeResolver.Resolve("   sele ctt"));
            //Assert.AreEqual(StatementType.OTHER, StatementTypeResolver.Resolve("update "));
            //Assert.AreEqual(StatementType.OTHER, StatementTypeResolver.Resolve("  INSERT"));
            //Assert.AreEqual(StatementType.OTHER, StatementTypeResolver.Resolve("'  INSERT"));
            //Assert.AreEqual(StatementType.OTHER, StatementTypeResolver.Resolve(" asdf as#@$%#$098234asd asd asfd "));
            //Assert.AreEqual(StatementType.OTHER, StatementTypeResolver.Resolve(null));
        }
    }
}
