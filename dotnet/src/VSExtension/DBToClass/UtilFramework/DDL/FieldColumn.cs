using Org.FGQ.CodeGenerate.Util.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Org.FGQ.CodeGenerate.Model.DDL
{


	public class FieldColumn
	{

		public string Desc { get; set; } = string.Empty;

		/// <summary>
		/// for example:
		/// varchar,字符,是否,日期,时间,整数,布尔,bool,boolean 
		/// </summary>
		public string DataTypeDesc { get; set; } = string.Empty;

		public string Name { get; set; } = string.Empty;

		public string Remark { get; set; } = string.Empty;

		public string PrimaryKeySign { get; set; } = string.Empty;


		public string UniqueKeySign { get; set; } = string.Empty;

		/// <summary>
		/// 唯一键，但是否在数据表中建立唯一键约束？
		/// </summary>
		public bool UniqueForDB { get; set; } = true;


		public string SqlType { get; internal set; }


		public bool IsPrimaryKeyColumn()
		{

			return PrimaryKeySign.ToLower().Trim() == "是"
				|| PrimaryKeySign.ToLower().Trim() == "y"
				|| PrimaryKeySign.ToLower().Trim() == "true";

		}

		public bool IsUniqueKeyColumn()
		{

			return UniqueKeySign.ToLower().Trim() == "是"
				|| UniqueKeySign.ToLower().Trim() == "y"
				|| UniqueKeySign.ToLower().Trim() == "true";

		}


		public bool IsKeyColumn()
		{

			return IsPrimaryKeyColumn() || IsUniqueKeyColumn();

		}

		public string NullStr()
		{
			return IsKeyColumn() ? " not null" : "null";
		}

		public string KeyStr()
		{
			if (false == IsKeyColumn())
			{
				return String.Empty;
			}
			if (IsPrimaryKeyColumn() && this.Table.DDLConfig.MyDBType == WareDDL.DBType.MySql)
			{
				return "primary key";
			}
			if (IsUniqueKeyColumn() && this.Table.DDLConfig.MyDBType == WareDDL.DBType.MySql)
			{
				if (this.UniqueForDB)
				{
					return "unique key";
				}
				else
				{
					return String.Empty;
				}


			}
			throw new Exception("非支持的操作");

		}



		/// <summary>
		/// 是否父对象的外键
		/// </summary>
		public bool IsParentKey { get; set; } = false;

		private string nameSql;

		/// <summary>
		/// the column name that in database in sql script;
		/// </summary>
		public string NameSql
		{
			get { return nameSql ?? Name; }
			set { nameSql = value; }
		}

		private string jsonFieldName;

		public string JsonFieldName
		{
			get { return jsonFieldName ?? Name; }
			set { jsonFieldName = value; }
		}

		public EntityTable Table { get; internal set; }
		public int? Length { get; internal set; }

		public string CommentStr()
		{

			return this.Desc + "   " + this.Remark + (string.IsNullOrEmpty(jsonFieldName) ? " " : " json字段:" + jsonFieldName);
		}

		public bool Validate()
		{
			return false == (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(DataTypeDesc));
		}

		public FieldColumn(string desc, string name, string type, string primarykeySign, string remark, bool isparentkey)
		{
			Desc = desc?.Trim() ?? throw new ArgumentNullException(nameof(desc));
			Name = name?.Trim() ?? throw new ArgumentNullException(nameof(name));
			DataTypeDesc = type?.Trim() ?? throw new ArgumentNullException(nameof(type));
			PrimaryKeySign = primarykeySign?.Trim() ?? throw new ArgumentNullException(nameof(primarykeySign));
			Remark = remark?.Trim() ?? throw new ArgumentNullException(nameof(remark));
			IsParentKey = isparentkey;

		}

		public FieldColumn(string desc, string name, string type, string primarykeySign, string remark) : this(desc, name, type, primarykeySign, remark, false)
		{

		}
		public FieldColumn(string desc, string name, string type) : this(desc, name, type, "N", "")
		{

		}

		public FieldColumn(string desc, string name, string type, int length) : this(desc, name, type, "N", "")
		{
			Length = length;
		}

		public FieldColumn(DBColumn column)
		{
			Desc = column?.Comment ?? throw new ArgumentNullException(nameof(column));
			Name = column?.ColName ?? throw new ArgumentNullException(nameof(column));
			DataTypeDesc = column?.ColumnType ?? throw new ArgumentNullException(nameof(column));
			PrimaryKeySign = column.IsPriKey ? "Y" : "N";
			Remark = column.Comment;
		}
	}
}
