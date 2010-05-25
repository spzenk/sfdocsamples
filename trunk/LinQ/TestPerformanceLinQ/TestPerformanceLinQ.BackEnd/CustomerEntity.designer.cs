﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3053
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestPerformanceLinQ.BackEnd
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[System.Data.Linq.Mapping.DatabaseAttribute(Name="AdventureWorks")]
	public partial class CustomerEntityDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertCustomer(Customer instance);
    partial void UpdateCustomer(Customer instance);
    partial void DeleteCustomer(Customer instance);
    partial void InsertCustomerAddress(CustomerAddress instance);
    partial void UpdateCustomerAddress(CustomerAddress instance);
    partial void DeleteCustomerAddress(CustomerAddress instance);
    #endregion
		
		public CustomerEntityDataContext() : 
				base(global::TestPerformanceLinQ.BackEnd.Properties.Settings.Default.AdventureWorksConnectionString1, mappingSource)
		{
			OnCreated();
		}
		
		public CustomerEntityDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public CustomerEntityDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public CustomerEntityDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public CustomerEntityDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Customer> Customers
		{
			get
			{
				return this.GetTable<Customer>();
			}
		}
		
		public System.Data.Linq.Table<CustomerAddress> CustomerAddresses
		{
			get
			{
				return this.GetTable<CustomerAddress>();
			}
		}
	}
	
	[Table(Name="Sales.Customer")]
	public partial class Customer : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _CustomerID;
		
		private System.Nullable<int> _TerritoryID;
		
		private string _AccountNumber;
		
		private char _CustomerType;
		
		private System.Guid _rowguid;
		
		private System.DateTime _ModifiedDate;
		
		private EntitySet<CustomerAddress> _CustomerAddresses;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnCustomerIDChanging(int value);
    partial void OnCustomerIDChanged();
    partial void OnTerritoryIDChanging(System.Nullable<int> value);
    partial void OnTerritoryIDChanged();
    partial void OnAccountNumberChanging(string value);
    partial void OnAccountNumberChanged();
    partial void OnCustomerTypeChanging(char value);
    partial void OnCustomerTypeChanged();
    partial void OnrowguidChanging(System.Guid value);
    partial void OnrowguidChanged();
    partial void OnModifiedDateChanging(System.DateTime value);
    partial void OnModifiedDateChanged();
    #endregion
		
		public Customer()
		{
			this._CustomerAddresses = new EntitySet<CustomerAddress>(new Action<CustomerAddress>(this.attach_CustomerAddresses), new Action<CustomerAddress>(this.detach_CustomerAddresses));
			OnCreated();
		}
		
		[Column(Storage="_CustomerID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int CustomerID
		{
			get
			{
				return this._CustomerID;
			}
			set
			{
				if ((this._CustomerID != value))
				{
					this.OnCustomerIDChanging(value);
					this.SendPropertyChanging();
					this._CustomerID = value;
					this.SendPropertyChanged("CustomerID");
					this.OnCustomerIDChanged();
				}
			}
		}
		
		[Column(Storage="_TerritoryID", DbType="Int")]
		public System.Nullable<int> TerritoryID
		{
			get
			{
				return this._TerritoryID;
			}
			set
			{
				if ((this._TerritoryID != value))
				{
					this.OnTerritoryIDChanging(value);
					this.SendPropertyChanging();
					this._TerritoryID = value;
					this.SendPropertyChanged("TerritoryID");
					this.OnTerritoryIDChanged();
				}
			}
		}
		
		[Column(Storage="_AccountNumber", AutoSync=AutoSync.Always, DbType="VarChar(10) NOT NULL", CanBeNull=false, IsDbGenerated=true, UpdateCheck=UpdateCheck.Never)]
		public string AccountNumber
		{
			get
			{
				return this._AccountNumber;
			}
			set
			{
				if ((this._AccountNumber != value))
				{
					this.OnAccountNumberChanging(value);
					this.SendPropertyChanging();
					this._AccountNumber = value;
					this.SendPropertyChanged("AccountNumber");
					this.OnAccountNumberChanged();
				}
			}
		}
		
		[Column(Storage="_CustomerType", DbType="NChar(1) NOT NULL")]
		public char CustomerType
		{
			get
			{
				return this._CustomerType;
			}
			set
			{
				if ((this._CustomerType != value))
				{
					this.OnCustomerTypeChanging(value);
					this.SendPropertyChanging();
					this._CustomerType = value;
					this.SendPropertyChanged("CustomerType");
					this.OnCustomerTypeChanged();
				}
			}
		}
		
		[Column(Storage="_rowguid", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid rowguid
		{
			get
			{
				return this._rowguid;
			}
			set
			{
				if ((this._rowguid != value))
				{
					this.OnrowguidChanging(value);
					this.SendPropertyChanging();
					this._rowguid = value;
					this.SendPropertyChanged("rowguid");
					this.OnrowguidChanged();
				}
			}
		}
		
		[Column(Storage="_ModifiedDate", DbType="DateTime NOT NULL")]
		public System.DateTime ModifiedDate
		{
			get
			{
				return this._ModifiedDate;
			}
			set
			{
				if ((this._ModifiedDate != value))
				{
					this.OnModifiedDateChanging(value);
					this.SendPropertyChanging();
					this._ModifiedDate = value;
					this.SendPropertyChanged("ModifiedDate");
					this.OnModifiedDateChanged();
				}
			}
		}
		
		[Association(Name="Customer_CustomerAddress", Storage="_CustomerAddresses", ThisKey="CustomerID", OtherKey="CustomerID")]
		public EntitySet<CustomerAddress> CustomerAddresses
		{
			get
			{
				return this._CustomerAddresses;
			}
			set
			{
				this._CustomerAddresses.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_CustomerAddresses(CustomerAddress entity)
		{
			this.SendPropertyChanging();
			entity.Customer = this;
		}
		
		private void detach_CustomerAddresses(CustomerAddress entity)
		{
			this.SendPropertyChanging();
			entity.Customer = null;
		}
	}
	
	[Table(Name="Sales.CustomerAddress")]
	public partial class CustomerAddress : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _CustomerID;
		
		private int _AddressID;
		
		private int _AddressTypeID;
		
		private System.Guid _rowguid;
		
		private System.DateTime _ModifiedDate;
		
		private EntityRef<Customer> _Customer;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnCustomerIDChanging(int value);
    partial void OnCustomerIDChanged();
    partial void OnAddressIDChanging(int value);
    partial void OnAddressIDChanged();
    partial void OnAddressTypeIDChanging(int value);
    partial void OnAddressTypeIDChanged();
    partial void OnrowguidChanging(System.Guid value);
    partial void OnrowguidChanged();
    partial void OnModifiedDateChanging(System.DateTime value);
    partial void OnModifiedDateChanged();
    #endregion
		
		public CustomerAddress()
		{
			this._Customer = default(EntityRef<Customer>);
			OnCreated();
		}
		
		[Column(Storage="_CustomerID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int CustomerID
		{
			get
			{
				return this._CustomerID;
			}
			set
			{
				if ((this._CustomerID != value))
				{
					if (this._Customer.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnCustomerIDChanging(value);
					this.SendPropertyChanging();
					this._CustomerID = value;
					this.SendPropertyChanged("CustomerID");
					this.OnCustomerIDChanged();
				}
			}
		}
		
		[Column(Storage="_AddressID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int AddressID
		{
			get
			{
				return this._AddressID;
			}
			set
			{
				if ((this._AddressID != value))
				{
					this.OnAddressIDChanging(value);
					this.SendPropertyChanging();
					this._AddressID = value;
					this.SendPropertyChanged("AddressID");
					this.OnAddressIDChanged();
				}
			}
		}
		
		[Column(Storage="_AddressTypeID", DbType="Int NOT NULL")]
		public int AddressTypeID
		{
			get
			{
				return this._AddressTypeID;
			}
			set
			{
				if ((this._AddressTypeID != value))
				{
					this.OnAddressTypeIDChanging(value);
					this.SendPropertyChanging();
					this._AddressTypeID = value;
					this.SendPropertyChanged("AddressTypeID");
					this.OnAddressTypeIDChanged();
				}
			}
		}
		
		[Column(Storage="_rowguid", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid rowguid
		{
			get
			{
				return this._rowguid;
			}
			set
			{
				if ((this._rowguid != value))
				{
					this.OnrowguidChanging(value);
					this.SendPropertyChanging();
					this._rowguid = value;
					this.SendPropertyChanged("rowguid");
					this.OnrowguidChanged();
				}
			}
		}
		
		[Column(Storage="_ModifiedDate", DbType="DateTime NOT NULL")]
		public System.DateTime ModifiedDate
		{
			get
			{
				return this._ModifiedDate;
			}
			set
			{
				if ((this._ModifiedDate != value))
				{
					this.OnModifiedDateChanging(value);
					this.SendPropertyChanging();
					this._ModifiedDate = value;
					this.SendPropertyChanged("ModifiedDate");
					this.OnModifiedDateChanged();
				}
			}
		}
		
		[Association(Name="Customer_CustomerAddress", Storage="_Customer", ThisKey="CustomerID", OtherKey="CustomerID", IsForeignKey=true)]
		public Customer Customer
		{
			get
			{
				return this._Customer.Entity;
			}
			set
			{
				Customer previousValue = this._Customer.Entity;
				if (((previousValue != value) 
							|| (this._Customer.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Customer.Entity = null;
						previousValue.CustomerAddresses.Remove(this);
					}
					this._Customer.Entity = value;
					if ((value != null))
					{
						value.CustomerAddresses.Add(this);
						this._CustomerID = value.CustomerID;
					}
					else
					{
						this._CustomerID = default(int);
					}
					this.SendPropertyChanged("Customer");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
