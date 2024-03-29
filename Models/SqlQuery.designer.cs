﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcUmbraco.Models
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="UmbracoDB")]
	public partial class SqlQueryDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public SqlQueryDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["UmbracoDBConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public SqlQueryDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public SqlQueryDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public SqlQueryDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public SqlQueryDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<country> countries
		{
			get
			{
				return this.GetTable<country>();
			}
		}
		
		public System.Data.Linq.Table<countrylanguage> countrylanguages
		{
			get
			{
				return this.GetTable<countrylanguage>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.country")]
	public partial class country
	{
		
		private string _Code;
		
		private string _Name;
		
		private string _Continent;
		
		private string _Region;
		
		private decimal _SurfaceArea;
		
		private System.Nullable<short> _IndepYear;
		
		private int _Population;
		
		private System.Nullable<decimal> _LifeExpectancy;
		
		private System.Nullable<decimal> _GNP;
		
		private System.Nullable<decimal> _GNPOld;
		
		private string _LocalName;
		
		private string _GovernmentForm;
		
		private string _HeadOfState;
		
		private System.Nullable<int> _Capital;
		
		private string _Code2;
		
		public country()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Code", DbType="Char(3) NOT NULL", CanBeNull=false)]
		public string Code
		{
			get
			{
				return this._Code;
			}
			set
			{
				if ((this._Code != value))
				{
					this._Code = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="Char(52) NOT NULL", CanBeNull=false)]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Continent", DbType="VarChar(13) NOT NULL", CanBeNull=false)]
		public string Continent
		{
			get
			{
				return this._Continent;
			}
			set
			{
				if ((this._Continent != value))
				{
					this._Continent = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Region", DbType="Char(26) NOT NULL", CanBeNull=false)]
		public string Region
		{
			get
			{
				return this._Region;
			}
			set
			{
				if ((this._Region != value))
				{
					this._Region = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SurfaceArea", DbType="Decimal(10,2) NOT NULL")]
		public decimal SurfaceArea
		{
			get
			{
				return this._SurfaceArea;
			}
			set
			{
				if ((this._SurfaceArea != value))
				{
					this._SurfaceArea = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IndepYear", DbType="SmallInt")]
		public System.Nullable<short> IndepYear
		{
			get
			{
				return this._IndepYear;
			}
			set
			{
				if ((this._IndepYear != value))
				{
					this._IndepYear = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Population", DbType="Int NOT NULL")]
		public int Population
		{
			get
			{
				return this._Population;
			}
			set
			{
				if ((this._Population != value))
				{
					this._Population = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LifeExpectancy", DbType="Decimal(3,1)")]
		public System.Nullable<decimal> LifeExpectancy
		{
			get
			{
				return this._LifeExpectancy;
			}
			set
			{
				if ((this._LifeExpectancy != value))
				{
					this._LifeExpectancy = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_GNP", DbType="Decimal(10,2)")]
		public System.Nullable<decimal> GNP
		{
			get
			{
				return this._GNP;
			}
			set
			{
				if ((this._GNP != value))
				{
					this._GNP = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_GNPOld", DbType="Decimal(10,2)")]
		public System.Nullable<decimal> GNPOld
		{
			get
			{
				return this._GNPOld;
			}
			set
			{
				if ((this._GNPOld != value))
				{
					this._GNPOld = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LocalName", DbType="Char(45) NOT NULL", CanBeNull=false)]
		public string LocalName
		{
			get
			{
				return this._LocalName;
			}
			set
			{
				if ((this._LocalName != value))
				{
					this._LocalName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_GovernmentForm", DbType="Char(45) NOT NULL", CanBeNull=false)]
		public string GovernmentForm
		{
			get
			{
				return this._GovernmentForm;
			}
			set
			{
				if ((this._GovernmentForm != value))
				{
					this._GovernmentForm = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_HeadOfState", DbType="Char(60)")]
		public string HeadOfState
		{
			get
			{
				return this._HeadOfState;
			}
			set
			{
				if ((this._HeadOfState != value))
				{
					this._HeadOfState = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Capital", DbType="Int")]
		public System.Nullable<int> Capital
		{
			get
			{
				return this._Capital;
			}
			set
			{
				if ((this._Capital != value))
				{
					this._Capital = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Code2", DbType="Char(2) NOT NULL", CanBeNull=false)]
		public string Code2
		{
			get
			{
				return this._Code2;
			}
			set
			{
				if ((this._Code2 != value))
				{
					this._Code2 = value;
				}
			}
		}

        public int Count { get; set; }

        public string Language { get; set; }

        public string IsOfficial { get; set; }
    }
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.countrylanguage")]
	public partial class countrylanguage
	{
		
		private string _CountryCode;
		
		private string _Language;
		
		private string _IsOfficial;
		
		private decimal _Percentage;
		
		public countrylanguage()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CountryCode", DbType="Char(3) NOT NULL", CanBeNull=false)]
		public string CountryCode
		{
			get
			{
				return this._CountryCode;
			}
			set
			{
				if ((this._CountryCode != value))
				{
					this._CountryCode = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Language", DbType="Char(30) NOT NULL", CanBeNull=false)]
		public string Language
		{
			get
			{
				return this._Language;
			}
			set
			{
				if ((this._Language != value))
				{
					this._Language = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsOfficial", DbType="VarChar(1) NOT NULL", CanBeNull=false)]
		public string IsOfficial
		{
			get
			{
				return this._IsOfficial;
			}
			set
			{
				if ((this._IsOfficial != value))
				{
					this._IsOfficial = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Percentage", DbType="Decimal(4,1) NOT NULL")]
		public decimal Percentage
		{
			get
			{
				return this._Percentage;
			}
			set
			{
				if ((this._Percentage != value))
				{
					this._Percentage = value;
				}
			}
		}

        public string Name { get; set; }
    }
}
#pragma warning restore 1591
