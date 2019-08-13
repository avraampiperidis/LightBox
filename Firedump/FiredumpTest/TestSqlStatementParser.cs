using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Firedump.utils.parsers;

namespace FiredumpTest
{
    /// <summary>
    /// Summary description for TestSqlStatementParser
    /// </summary>
    [TestClass]
    public class TestSqlStatementParser
    {
        [TestMethod]
        public void TestParser()
        {
            string sql = "select * from table c;;;;";
            Assert.AreEqual(1, new SqlStatementParserWrapper(sql).Parse().Count);
            sql = "select * from mytable; create table2(`id` not null /* ;ignored semicolon;*/ );;    ;     ;; ;; ;    ;   " +
                "; \n select * from table1 where t.prop like 'commnet;' and id = 3 #trailing; comment;;;;;";
            Assert.AreEqual(3, new SqlStatementParserWrapper(sql).Parse().Count);
            sql = "select * from something      update asd set asd = 3";
            Assert.AreEqual(1, new SqlStatementParserWrapper(sql).Parse().Count);
        }

        [TestMethod]
        public void TestConvert()
        {
            string sql = "select * from mytable; create table2(`id` not null /* ;ignored semicolon;*/ );;    ;     ;; ;; ;    ;   " +
               "; \n select * from table1 where t.prop like 'commnet;' and id = 3 #trailing; comment;;;;;";
            SqlStatementParserWrapper parser = new SqlStatementParserWrapper(sql);
            Assert.AreEqual(3, parser.convert(parser.Parse()).Count);
        }
    }
}
