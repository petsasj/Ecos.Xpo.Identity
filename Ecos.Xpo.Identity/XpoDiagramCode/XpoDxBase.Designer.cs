﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
namespace Ecos.Xpo.Identity.Persistent
{

    [NonPersistent]
    public partial class XpoDxBase : XPBaseObject
    {
        [Key]
        [Size(50)]
        [Persistent(@"Id")]
        string _Id;
        [PersistentAlias("_Id")]
        public string Id
        {
            get { return _Id; }
        }
        [Persistent(@"AddStampUTC")]
        DateTime _AddStampUTC;
        [PersistentAlias("_AddStampUTC")]
        public DateTime AddStampUTC
        {
            get { return _AddStampUTC; }
        }
        [Persistent(@"ModStampUTC")]
        DateTime _ModStampUTC;
        [PersistentAlias("_ModStampUTC")]
        public DateTime ModStampUTC
        {
            get { return _ModStampUTC; }
        }
    }

}