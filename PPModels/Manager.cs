using System.Globalization;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;

namespace PPModels
{
    public class Manager
    {

        public Manager(string mname, int mid)
        {
            this.mName = mname;
            this.mId = mid;
        }

        public Manager()
        {

        }

        public string mName { get; set; }

        [Key]

        public int mId { get; set; }

        public override string ToString()
        {
            return $"mName: {this.mName}";
        }
    }
}