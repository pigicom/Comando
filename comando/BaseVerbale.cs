namespace Comando
{
    using System;
    using System.Collections.Generic;

    public class BaseVerbale
    {
        public string directory = string.Empty;
        public Dictionary<string, string> Fields = new Dictionary<string, string>();

        public virtual void LoadMyFiled()
        {
        }
    }
}

