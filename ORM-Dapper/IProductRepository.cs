using System;
namespace ORM_Dapper
{
	public interface IProductRepository
	{
		public IEnumerable<Product> GetAllProducts();

		public void CreateProduct(string name, double Price, int CategoryID);
    }

}

