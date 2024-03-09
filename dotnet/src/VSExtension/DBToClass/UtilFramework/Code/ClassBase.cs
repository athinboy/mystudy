using Org.FGQ.CodeGenerate.Config;
using Org.FGQ.CodeGenerate.Model;using Org.FGQ.CodeGenerate.Model.DDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Org.FGQ.CodeGenerate.Util.Code
{
    public class ClassBase:BaseModel
    {

        public string NamespaceName { get; set; }



        public string Desc { get; set; }

        public ClassBase(string namespaceName, EntityTable Table)
        {
            NamespaceName = namespaceName ?? throw new ArgumentNullException(nameof(namespaceName));
            Table = Table ?? throw new ArgumentNullException(nameof(Table));
        }

        public ClassBase(string namespaceName, string className)
        {
            NamespaceName = namespaceName ?? throw new ArgumentNullException(nameof(namespaceName));
            ClassName = className ?? throw new ArgumentNullException(nameof(className));
        }



        public List<FieldBase> Fields { get; set; } = new List<FieldBase>();

        public EntityTable Table { get; set; }


        public string ClassName { get; protected set; }


        public bool HasNoKeyLongIDField
        {
            get
            {
                return Fields.Any(x => x.IsKeyField == false && x.Name.ToLower() == "id" && x.FieldType == FieldTypes.Long);
            }
        }

        public FieldBase LongIntIDField
        {
            get
            {
                return Fields.Find(x => x.Name.ToLower() == "id" && x.FieldType == FieldTypes.Long);
            }
        }

        public bool HasKeyField
        {

            get
            {
                return Fields.Any(f => f.IsKeyField);
            }
        }
        public bool HasPrimaryKeyField
        {

            get
            {
                return Fields.Any(f => f.IsPrimaryKeyColumn);
            }
        }
        public bool HasUniqueKeyField
        {

            get
            {
                return Fields.Any(f => f.IsUniqueKeyColumn);
            }
        }

        public List<FieldBase> KeyFields
        {
            get
            {
                return Fields.FindAll(x => x.IsKeyField);
            }
        }

        public List<FieldBase> PrimaryKeyFields
        {
            get
            {
                return Fields.FindAll(x => x.IsPrimaryKeyColumn);
            }
        }

        public List<FieldBase> UniqueKeyFields
        {
            get
            {
                return Fields.FindAll(x => x.IsUniqueKeyColumn);
            }
        }

        public List<FieldBase> ParentKeyFields
        {
            get
            {
                return Fields.FindAll(x => x.IsParentKey);
            }
        }

        protected static string GetFildTypeStr(FieldBase filedBase)
        {
            throw new NotImplementedException();
        }


    }
}
