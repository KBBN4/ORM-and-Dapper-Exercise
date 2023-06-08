using System;
using System.Data;
using Dapper;

namespace ORM_Dapper
{
	public class DapperProductRepository : IProductRepository
	{

        private readonly IDbConnection _connection;
		public DapperProductRepository(IDbConnection connection)
		{
            _connection = connection;
		}

        public void CreateProduct(string name, double Price, int CategoryID)
        {
            _connection.Execute("INSERT INTO Products (Name , Price, CategoryID) " +
                " VALUES ( @name, @price, @categoryID) ; ", new { name = name, price = Price, CategoryID = CategoryID });
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _connection.Query<Product>("SELECT * FROM products ;");
        }
    }
}

