using System;


public class Customer
{
	public int ID { get; set; }

	public string FirstName { get; set; }

	public string LastName { get; set; }
	
    public string Phone { get; set; }

	public string Email { get; set; }

	public DateTime? DateOfBirth { get; set; }
    
	public string GetFullName()
	{
		return this.FirstName + " " + this.LastName;
	}
}

