#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     Ten kod został wygenerowany przez narzędzie.
//     Wersja wykonawcza:4.0.30319.42000
//
//     Zmiany w tym pliku mogą spowodować nieprawidłowe zachowanie i zostaną utracone, jeśli
//     kod zostanie ponownie wygenerowany.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OrderApp
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="FastFood_Sys")]
	public partial class UsersDataDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertUsers(Users instance);
    partial void UpdateUsers(Users instance);
    partial void DeleteUsers(Users instance);
    partial void InsertRoles(Roles instance);
    partial void UpdateRoles(Roles instance);
    partial void DeleteRoles(Roles instance);
    #endregion
		
		public UsersDataDataContext() : 
				base(global::OrderApp.Properties.Settings.Default.FastFood_SysConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public UsersDataDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public UsersDataDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public UsersDataDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public UsersDataDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Users> Users
		{
			get
			{
				return this.GetTable<Users>();
			}
		}
		
		public System.Data.Linq.Table<Roles> Roles
		{
			get
			{
				return this.GetTable<Roles>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Users")]
	public partial class Users : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _Id;
		
		private string _Pin;
		
		private string _Name;
		
		private string _Second_name;
		
		private byte _Role_id;
		
		private string _Pesel;
		
		private string _Phone_number;
		
		private EntitySet<Roles> _Roles;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(long value);
    partial void OnIdChanged();
    partial void OnPinChanging(string value);
    partial void OnPinChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnSecond_nameChanging(string value);
    partial void OnSecond_nameChanged();
    partial void OnRole_idChanging(byte value);
    partial void OnRole_idChanged();
    partial void OnPeselChanging(string value);
    partial void OnPeselChanged();
    partial void OnPhone_numberChanging(string value);
    partial void OnPhone_numberChanged();
    #endregion
		
		public Users()
		{
			this._Roles = new EntitySet<Roles>(new Action<Roles>(this.attach_Roles), new Action<Roles>(this.detach_Roles));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="BigInt NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public long Id
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Pin", DbType="NChar(4) NOT NULL", CanBeNull=false)]
		public string Pin
		{
			get
			{
				return this._Pin;
			}
			set
			{
				if ((this._Pin != value))
				{
					this.OnPinChanging(value);
					this.SendPropertyChanging();
					this._Pin = value;
					this.SendPropertyChanged("Pin");
					this.OnPinChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(25) NOT NULL", CanBeNull=false)]
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
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Second_name", DbType="NVarChar(25) NOT NULL", CanBeNull=false)]
		public string Second_name
		{
			get
			{
				return this._Second_name;
			}
			set
			{
				if ((this._Second_name != value))
				{
					this.OnSecond_nameChanging(value);
					this.SendPropertyChanging();
					this._Second_name = value;
					this.SendPropertyChanged("Second_name");
					this.OnSecond_nameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Role_id", DbType="TinyInt NOT NULL")]
		public byte Role_id
		{
			get
			{
				return this._Role_id;
			}
			set
			{
				if ((this._Role_id != value))
				{
					this.OnRole_idChanging(value);
					this.SendPropertyChanging();
					this._Role_id = value;
					this.SendPropertyChanged("Role_id");
					this.OnRole_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Pesel", DbType="NChar(11) NOT NULL", CanBeNull=false)]
		public string Pesel
		{
			get
			{
				return this._Pesel;
			}
			set
			{
				if ((this._Pesel != value))
				{
					this.OnPeselChanging(value);
					this.SendPropertyChanging();
					this._Pesel = value;
					this.SendPropertyChanged("Pesel");
					this.OnPeselChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Phone_number", DbType="NChar(9) NOT NULL", CanBeNull=false)]
		public string Phone_number
		{
			get
			{
				return this._Phone_number;
			}
			set
			{
				if ((this._Phone_number != value))
				{
					this.OnPhone_numberChanging(value);
					this.SendPropertyChanging();
					this._Phone_number = value;
					this.SendPropertyChanged("Phone_number");
					this.OnPhone_numberChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Users_Roles", Storage="_Roles", ThisKey="Role_id", OtherKey="Id")]
		public EntitySet<Roles> Roles
		{
			get
			{
				return this._Roles;
			}
			set
			{
				this._Roles.Assign(value);
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
		
		private void attach_Roles(Roles entity)
		{
			this.SendPropertyChanging();
			entity.Users = this;
		}
		
		private void detach_Roles(Roles entity)
		{
			this.SendPropertyChanging();
			entity.Users = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Roles")]
	public partial class Roles : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private byte _Id;
		
		private string _Name;
		
		private EntityRef<Users> _Users;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(byte value);
    partial void OnIdChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    #endregion
		
		public Roles()
		{
			this._Users = default(EntityRef<Users>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="TinyInt NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public byte Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					if (this._Users.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(25) NOT NULL", CanBeNull=false)]
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
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Users_Roles", Storage="_Users", ThisKey="Id", OtherKey="Role_id", IsForeignKey=true)]
		public Users Users
		{
			get
			{
				return this._Users.Entity;
			}
			set
			{
				Users previousValue = this._Users.Entity;
				if (((previousValue != value) 
							|| (this._Users.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Users.Entity = null;
						previousValue.Roles.Remove(this);
					}
					this._Users.Entity = value;
					if ((value != null))
					{
						value.Roles.Add(this);
						this._Id = value.Role_id;
					}
					else
					{
						this._Id = default(byte);
					}
					this.SendPropertyChanged("Users");
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
