using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DapperQueryBuilder
{
    [TestClass]
    public class DapperTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            Product product = new Product();
            product.Id = 3;
            product.Name = "Macbook pro 13'";

            var insertQuery = QueryBuilder.GetInsertQuery(product);
        }
    }
}
