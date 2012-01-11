using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class CustomerService
{
	private List<Customer> Customers
	{
		get
		{
			List<Customer> customers;
			if (HttpContext.Current.Session["Customers"] != null)
			{
				customers = (List<Customer>)HttpContext.Current.Session["Customers"];
			}
			else
			{
				//Create customer data store and save in session
				customers = new List<Customer>();

				InitCustomerData(customers);

				HttpContext.Current.Session["Customers"] = customers;
			}

			return customers;
		}
	}


	public Customer GetByID(int customerID)
	{
		return this.Customers.AsQueryable().First(customer => customer.ID == customerID);
	}


	public IList<Customer> GetAll()
	{
		return this.Customers;
	}


	public IQueryable<Customer> GetQueryable()
	{
		return this.Customers.AsQueryable();
	}


	public void Add(Customer customer)
	{
		customer.ID = this.Customers.Count + 1;
		this.Customers.Add(customer);
	}


	public void Update(Customer customer)
	{
        
	}


	public void Delete(int customerID)
	{
		this.Customers.RemoveAll(customer => customer.ID == customerID);
	}


	private void InitCustomerData(List<Customer> customers)
	{
		customers.Add(new Customer
		{
			ID = 1,
			FirstName = "John",
			LastName = "Doe",
			Phone = "1111111111",
			Email = "johndoe@gmail.com",
			DateOfBirth = DateTime.Parse("5/3/1971")
		});

		customers.Add(new Customer
		{
			ID = 2,
			FirstName = "Jane",
			LastName = "Doe",
			Phone = "2222222222",
			Email = "janedoe@gmail.com",
			DateOfBirth = DateTime.Parse("4/5/1982")
		});
	}
}

