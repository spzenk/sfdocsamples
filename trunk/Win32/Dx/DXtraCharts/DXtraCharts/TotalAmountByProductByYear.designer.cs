﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3074
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DXtraCharts
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
	public partial class TotalAmountByProductByYearDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public TotalAmountByProductByYearDataContext() : 
				base(global::DXtraCharts.Properties.Settings.Default.AdventureWorksConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public TotalAmountByProductByYearDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public TotalAmountByProductByYearDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public TotalAmountByProductByYearDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public TotalAmountByProductByYearDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<TotalAmountByProductByYear> TotalAmountByProductByYears
		{
			get
			{
				return this.GetTable<TotalAmountByProductByYear>();
			}
		}
	}
	
	[Table(Name="dbo.TotalAmountByProductByYear")]
	public partial class TotalAmountByProductByYear
	{
		
		private string _Name;
		
		private int _ProductID;
		
		private System.Nullable<int> _Year;
		
		private System.Nullable<decimal> _TotalAmount;
		
		public TotalAmountByProductByYear()
		{
		}
		
		[Column(Storage="_Name", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this._Name = value;
				}
			}
		}
		
		[Column(Storage="_ProductID", DbType="Int NOT NULL")]
		public int ProductID
		{
			get
			{
				return this._ProductID;
			}
			set
			{
				if ((this._ProductID != value))
				{
					this._ProductID = value;
				}
			}
		}
		
		[Column(Storage="_Year", DbType="Int")]
		public System.Nullable<int> Year
		{
			get
			{
				return this._Year;
			}
			set
			{
				if ((this._Year != value))
				{
					this._Year = value;
				}
			}
		}
		
		[Column(Storage="_TotalAmount", DbType="Money")]
		public System.Nullable<decimal> TotalAmount
		{
			get
			{
				return this._TotalAmount;
			}
			set
			{
				if ((this._TotalAmount != value))
				{
					this._TotalAmount = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
