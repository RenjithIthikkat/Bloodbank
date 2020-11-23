﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BloodBank
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="BloodBankDB")]
	public partial class BloodBankDBDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertDonor(Donor instance);
    partial void UpdateDonor(Donor instance);
    partial void DeleteDonor(Donor instance);
    #endregion
		
		public BloodBankDBDataContext() : 
				base(global::BloodBank.Properties.Settings.Default.BloodBankDBConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public BloodBankDBDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public BloodBankDBDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public BloodBankDBDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public BloodBankDBDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Donor> Donors
		{
			get
			{
				return this.GetTable<Donor>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Donor")]
	public partial class Donor : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _firstName;
		
		private string _lastName;
		
		private string _phone;
		
		private int _bloodGroup;
		
		private System.Nullable<int> _age;
		
		private System.Nullable<int> _gender;
		
		private System.Nullable<int> _province;
		
		private string _city;
		
		private System.Nullable<System.DateTime> _date;
		
		private int _bloodAvailable;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnfirstNameChanging(string value);
    partial void OnfirstNameChanged();
    partial void OnlastNameChanging(string value);
    partial void OnlastNameChanged();
    partial void OnphoneChanging(string value);
    partial void OnphoneChanged();
    partial void OnbloodGroupChanging(int value);
    partial void OnbloodGroupChanged();
    partial void OnageChanging(System.Nullable<int> value);
    partial void OnageChanged();
    partial void OngenderChanging(System.Nullable<int> value);
    partial void OngenderChanged();
    partial void OnprovinceChanging(System.Nullable<int> value);
    partial void OnprovinceChanged();
    partial void OncityChanging(string value);
    partial void OncityChanged();
    partial void OndateChanging(System.Nullable<System.DateTime> value);
    partial void OndateChanged();
    partial void OnbloodAvailableChanging(int value);
    partial void OnbloodAvailableChanged();
    #endregion
		
		public Donor()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_firstName", DbType="VarChar(50)")]
		public string firstName
		{
			get
			{
				return this._firstName;
			}
			set
			{
				if ((this._firstName != value))
				{
					this.OnfirstNameChanging(value);
					this.SendPropertyChanging();
					this._firstName = value;
					this.SendPropertyChanged("firstName");
					this.OnfirstNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_lastName", DbType="VarChar(50)")]
		public string lastName
		{
			get
			{
				return this._lastName;
			}
			set
			{
				if ((this._lastName != value))
				{
					this.OnlastNameChanging(value);
					this.SendPropertyChanging();
					this._lastName = value;
					this.SendPropertyChanged("lastName");
					this.OnlastNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_phone", DbType="VarChar(50)")]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_bloodGroup", DbType="Int NOT NULL")]
		public int bloodGroup
		{
			get
			{
				return this._bloodGroup;
			}
			set
			{
				if ((this._bloodGroup != value))
				{
					this.OnbloodGroupChanging(value);
					this.SendPropertyChanging();
					this._bloodGroup = value;
					this.SendPropertyChanged("bloodGroup");
					this.OnbloodGroupChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_age", DbType="Int")]
		public System.Nullable<int> age
		{
			get
			{
				return this._age;
			}
			set
			{
				if ((this._age != value))
				{
					this.OnageChanging(value);
					this.SendPropertyChanging();
					this._age = value;
					this.SendPropertyChanged("age");
					this.OnageChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_gender", DbType="Int")]
		public System.Nullable<int> gender
		{
			get
			{
				return this._gender;
			}
			set
			{
				if ((this._gender != value))
				{
					this.OngenderChanging(value);
					this.SendPropertyChanging();
					this._gender = value;
					this.SendPropertyChanged("gender");
					this.OngenderChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_province", DbType="Int")]
		public System.Nullable<int> province
		{
			get
			{
				return this._province;
			}
			set
			{
				if ((this._province != value))
				{
					this.OnprovinceChanging(value);
					this.SendPropertyChanging();
					this._province = value;
					this.SendPropertyChanged("province");
					this.OnprovinceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_city", DbType="VarChar(50)")]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_date", DbType="DateTime")]
		public System.Nullable<System.DateTime> date
		{
			get
			{
				return this._date;
			}
			set
			{
				if ((this._date != value))
				{
					this.OndateChanging(value);
					this.SendPropertyChanging();
					this._date = value;
					this.SendPropertyChanged("date");
					this.OndateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_bloodAvailable", DbType="Int NOT NULL")]
		public int bloodAvailable
		{
			get
			{
				return this._bloodAvailable;
			}
			set
			{
				if ((this._bloodAvailable != value))
				{
					this.OnbloodAvailableChanging(value);
					this.SendPropertyChanging();
					this._bloodAvailable = value;
					this.SendPropertyChanged("bloodAvailable");
					this.OnbloodAvailableChanged();
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
