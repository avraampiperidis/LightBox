using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Firedump.sqlitetables;
using MySql.Data.MySqlClient;
using Oracle.ManagedDataAccess.Client;
using Firedump.core.db;

namespace FiredumpTest
{
    /// <summary>
    /// Summary description for Test_DbUtils
    /// </summary>
    [TestClass]
    public class Test_DbUtils
    {

        [TestMethod]
        public void Test_Convert()
        {
            Assert.AreEqual(DbTypeEnum.MYSQL, _DbUtils._convert(0));
            Assert.AreEqual(DbTypeEnum.MARIADB, _DbUtils._convert(1));
            Assert.AreEqual(DbTypeEnum.ORACLE, _DbUtils._convert(2));
            Assert.AreEqual(DbTypeEnum.POSTGRES, _DbUtils._convert(3));
            Assert.AreEqual(DbTypeEnum.SQLSERVER, _DbUtils._convert(4));
        }

        [TestMethod]
        public void TestGetDbTypeEnum()
        {
            Assert.AreEqual(DbTypeEnum.MYSQL, _DbUtils.GetDbTypeEnum(new MySqlConnection()));
            Assert.AreEqual(DbTypeEnum.ORACLE, _DbUtils.GetDbTypeEnum(new OracleConnection()));
        }
    }
}
