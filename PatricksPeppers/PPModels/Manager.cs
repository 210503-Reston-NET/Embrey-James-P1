using System.Globalization;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace PPModels
{
    public class Manager
    {
            public Manager (string mname)
            {
                this.mName = mname;
            }

            public string mName { get; set; }

            public override string ToString()
            {
                return $"mName: {this.mName}";
            }
    }
}