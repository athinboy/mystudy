﻿using Org.FGQ.CodeGenerate.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Org.FGQ.CodeGenerate.Util.Code
{
    public class ClassBase
    {

        public string NamespaceName { get; set; }



        public string Desc { get; set; }

        public ClassBase(string namespaceName, DDLTable dDLTable)
        {
            NamespaceName = namespaceName ?? throw new ArgumentNullException(nameof(namespaceName));
            DDLTable = dDLTable ?? throw new ArgumentNullException(nameof(dDLTable));
        }

        public ClassBase(string namespaceName, string className)
        {
            NamespaceName = namespaceName ?? throw new ArgumentNullException(nameof(namespaceName));
            ClassName = className ?? throw new ArgumentNullException(nameof(className));
        }



        public List<FieldBase> Fields { get; set; } = new List<FieldBase>();

        public DDLTable DDLTable { get; set; }


        public string ClassName { get; protected set; }

        public bool HasKeyField
        {

            get
            {
                return Fields.Any(f => f.IsKeyField);
            }
        }

        public List<FieldBase> KeyFileds
        {
            get
            {
                return Fields.FindAll(x => x.IsKeyField);
            }
        }




    }
}
