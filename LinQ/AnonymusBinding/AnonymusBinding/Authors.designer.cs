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

namespace AnonymusBinding
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
	
	
	[System.Data.Linq.Mapping.DatabaseAttribute(Name="PUBS")]
	public partial class PubsDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void Insertauthor(author instance);
    partial void Updateauthor(author instance);
    partial void Deleteauthor(author instance);
    partial void Inserttitleauthor(titleauthor instance);
    partial void Updatetitleauthor(titleauthor instance);
    partial void Deletetitleauthor(titleauthor instance);
    #endregion
		
		public PubsDataContext() : 
				base(global::AnonymusBinding.Properties.Settings.Default.PUBSConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public PubsDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public PubsDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public PubsDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public PubsDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<author> authors
		{
			get
			{
				return this.GetTable<author>();
			}
		}
		
		public System.Data.Linq.Table<titleauthor> titleauthors
		{
			get
			{
				return this.GetTable<titleauthor>();
			}
		}
	}
	
	[Table(Name="dbo.authors")]
	public partial class author : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _au_id;
		
		private string _au_lname;
		
		private string _au_fname;
		
		private string _phone;
		
		private string _address;
		
		private string _city;
		
		private string _state;
		
		private string _zip;
		
		private bool _contract;
		
		private EntitySet<titleauthor> _titleauthors;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Onau_idChanging(string value);
    partial void Onau_idChanged();
    partial void Onau_lnameChanging(string value);
    partial void Onau_lnameChanged();
    partial void Onau_fnameChanging(string value);
    partial void Onau_fnameChanged();
    partial void OnphoneChanging(string value);
    partial void OnphoneChanged();
    partial void OnaddressChanging(string value);
    partial void OnaddressChanged();
    partial void OncityChanging(string value);
    partial void OncityChanged();
    partial void OnstateChanging(string value);
    partial void OnstateChanged();
    partial void OnzipChanging(string value);
    partial void OnzipChanged();
    partial void OncontractChanging(bool value);
    partial void OncontractChanged();
    #endregion
		
		public author()
		{
			this._titleauthors = new EntitySet<titleauthor>(new Action<titleauthor>(this.attach_titleauthors), new Action<titleauthor>(this.detach_titleauthors));
			OnCreated();
		}
		
		[Column(Storage="_au_id", DbType="VarChar(11) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string au_id
		{
			get
			{
				return this._au_id;
			}
			set
			{
				if ((this._au_id != value))
				{
					this.Onau_idChanging(value);
					this.SendPropertyChanging();
					this._au_id = value;
					this.SendPropertyChanged("au_id");
					this.Onau_idChanged();
				}
			}
		}
		
		[Column(Storage="_au_lname", DbType="VarChar(40) NOT NULL", CanBeNull=false)]
		public string au_lname
		{
			get
			{
				return this._au_lname;
			}
			set
			{
				if ((this._au_lname != value))
				{
					this.Onau_lnameChanging(value);
					this.SendPropertyChanging();
					this._au_lname = value;
					this.SendPropertyChanged("au_lname");
					this.Onau_lnameChanged();
				}
			}
		}
		
		[Column(Storage="_au_fname", DbType="VarChar(20) NOT NULL", CanBeNull=false)]
		public string au_fname
		{
			get
			{
				return this._au_fname;
			}
			set
			{
				if ((this._au_fname != value))
				{
					this.Onau_fnameChanging(value);
					this.SendPropertyChanging();
					this._au_fname = value;
					this.SendPropertyChanged("au_fname");
					this.Onau_fnameChanged();
				}
			}
		}
		
		[Column(Storage="_phone", DbType="Char(12) NOT NULL", CanBeNull=false)]
		public string phone
		{
			get
			{
				return this._phone;
			}
			set
			{
				if ((this._phone != value))
				{
					this.OnphoneChanging(value);
					this.SendPropertyChanging();
					this._phone = value;
					this.SendPropertyChanged("phone");
					this.OnphoneChanged();
				}
			}
		}
		
		[Column(Storage="_address", DbType="VarChar(40)")]
		public string address
		{
			get
			{
				return this._address;
			}
			set
			{
				if ((this._address != value))
				{
					this.OnaddressChanging(value);
					this.SendPropertyChanging();
					this._address = value;
					this.SendPropertyChanged("address");
					this.OnaddressChanged();
				}
			}
		}
		
		[Column(Storage="_city", DbType="VarChar(20)")]
		public string city
		{
			get
			{
				return this._city;
			}
			set
			{
				if ((this._city != value))
				{
					this.OncityChanging(value);
					this.SendPropertyChanging();
					this._city = value;
					this.SendPropertyChanged("city");
					this.OncityChanged();
				}
			}
		}
		
		[Column(Storage="_state", DbType="Char(2)")]
		public string state
		{
			get
			{
				return this._state;
			}
			set
			{
				if ((this._state != value))
				{
					this.OnstateChanging(value);
					this.SendPropertyChanging();
					this._state = value;
					this.SendPropertyChanged("state");
					this.OnstateChanged();
				}
			}
		}
		
		[Column(Storage="_zip", DbType="Char(5)")]
		public string zip
		{
			get
			{
				return this._zip;
			}
			set
			{
				if ((this._zip != value))
				{
					this.OnzipChanging(value);
					this.SendPropertyChanging();
					this._zip = value;
					this.SendPropertyChanged("zip");
					this.OnzipChanged();
				}
			}
		}
		
		[Column(Storage="_contract", DbType="Bit NOT NULL")]
		public bool contract
		{
			get
			{
				return this._contract;
			}
			set
			{
				if ((this._contract != value))
				{
					this.OncontractChanging(value);
					this.SendPropertyChanging();
					this._contract = value;
					this.SendPropertyChanged("contract");
					this.OncontractChanged();
				}
			}
		}
		
		[Association(Name="author_titleauthor", Storage="_titleauthors", ThisKey="au_id", OtherKey="au_id")]
		public EntitySet<titleauthor> titleauthors
		{
			get
			{
				return this._titleauthors;
			}
			set
			{
				this._titleauthors.Assign(value);
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
		
		private void attach_titleauthors(titleauthor entity)
		{
			this.SendPropertyChanging();
			entity.author = this;
		}
		
		private void detach_titleauthors(titleauthor entity)
		{
			this.SendPropertyChanging();
			entity.author = null;
		}
	}
	
	[Table(Name="dbo.titleauthor")]
	public partial class titleauthor : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _au_id;
		
		private string _title_id;
		
		private System.Nullable<byte> _au_ord;
		
		private System.Nullable<int> _royaltyper;
		
		private EntityRef<author> _author;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Onau_idChanging(string value);
    partial void Onau_idChanged();
    partial void Ontitle_idChanging(string value);
    partial void Ontitle_idChanged();
    partial void Onau_ordChanging(System.Nullable<byte> value);
    partial void Onau_ordChanged();
    partial void OnroyaltyperChanging(System.Nullable<int> value);
    partial void OnroyaltyperChanged();
    #endregion
		
		public titleauthor()
		{
			this._author = default(EntityRef<author>);
			OnCreated();
		}
		
		[Column(Storage="_au_id", DbType="VarChar(11) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string au_id
		{
			get
			{
				return this._au_id;
			}
			set
			{
				if ((this._au_id != value))
				{
					if (this._author.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.Onau_idChanging(value);
					this.SendPropertyChanging();
					this._au_id = value;
					this.SendPropertyChanged("au_id");
					this.Onau_idChanged();
				}
			}
		}
		
		[Column(Storage="_title_id", DbType="VarChar(6) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string title_id
		{
			get
			{
				return this._title_id;
			}
			set
			{
				if ((this._title_id != value))
				{
					this.Ontitle_idChanging(value);
					this.SendPropertyChanging();
					this._title_id = value;
					this.SendPropertyChanged("title_id");
					this.Ontitle_idChanged();
				}
			}
		}
		
		[Column(Storage="_au_ord", DbType="TinyInt")]
		public System.Nullable<byte> au_ord
		{
			get
			{
				return this._au_ord;
			}
			set
			{
				if ((this._au_ord != value))
				{
					this.Onau_ordChanging(value);
					this.SendPropertyChanging();
					this._au_ord = value;
					this.SendPropertyChanged("au_ord");
					this.Onau_ordChanged();
				}
			}
		}
		
		[Column(Storage="_royaltyper", DbType="Int")]
		public System.Nullable<int> royaltyper
		{
			get
			{
				return this._royaltyper;
			}
			set
			{
				if ((this._royaltyper != value))
				{
					this.OnroyaltyperChanging(value);
					this.SendPropertyChanging();
					this._royaltyper = value;
					this.SendPropertyChanged("royaltyper");
					this.OnroyaltyperChanged();
				}
			}
		}
		
		[Association(Name="author_titleauthor", Storage="_author", ThisKey="au_id", OtherKey="au_id", IsForeignKey=true)]
		public author author
		{
			get
			{
				return this._author.Entity;
			}
			set
			{
				author previousValue = this._author.Entity;
				if (((previousValue != value) 
							|| (this._author.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._author.Entity = null;
						previousValue.titleauthors.Remove(this);
					}
					this._author.Entity = value;
					if ((value != null))
					{
						value.titleauthors.Add(this);
						this._au_id = value.au_id;
					}
					else
					{
						this._au_id = default(string);
					}
					this.SendPropertyChanged("author");
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
