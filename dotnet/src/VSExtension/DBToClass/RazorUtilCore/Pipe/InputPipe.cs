﻿using Org.FGQ.CodeGenerate.Pipe.Delegate;
using Org.FGQ.CodeGenerate.Work;
using RazorEngineCore;
using System;
using System.Collections.Generic;

namespace Org.FGQ.CodeGenerate.Pipe
{

    public abstract class InputPipe : PipeBase
    {



        protected InputPipe() : base()
        {

        }

        public virtual void Finish()
        {
        }

        public virtual void Input()
        {
        }

        public virtual void PrepareInput()
        {
        }

        public Action3 PrepareVarAction { get; set; } = null;

        /// <summary>
        /// prepare the variable/environment.
        /// </summary>
        /// <param name="work"></param>
        /// <param name="pipe"></param>
        /// <remarks>the override method of this need call this method。</remarks>
        public virtual void PrepareVar(Work.Work work)
        {
            if (PrepareVarAction != null)
            {
                PrepareVarAction(work, this);
            }
        }
    }
}
