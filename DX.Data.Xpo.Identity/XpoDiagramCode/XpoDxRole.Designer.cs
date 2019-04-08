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
namespace DX.Data.Xpo.Identity.Persistent
{

    [Persistent(@"DXRoles")]
    public partial class XpoDxRole : XpoDxBase
    {
        string _Name;
        [Indexed(Name = @"IdxRoleName", Unique = true)]
        [Size(50)]
        public string Name
        {
            get { return _Name; }
            set { SetPropertyValue<string>("Name", ref _Name, value); }
        }
        [Indexed(Name = @"IdxRoleNameUpper", Unique = true)]
        [Size(50)]
        [Persistent(@"NameUpper")]
        string _NameUpper;
        [PersistentAlias("_NameUpper")]
        public string NameUpper
        {
            get { return _NameUpper; }
        }
        string _NormalizedName;
        [Indexed(Name = @"IdxNormalizedRoleName")]
        public string NormalizedName
        {
            get { return _NormalizedName; }
            set { SetPropertyValue<string>("NormalizedName", ref _NormalizedName, value); }
        }
        [Association(@"XpoDxUsersRoles")]
        public XPCollection<XpoDxUser> Users { get { return GetCollection<XpoDxUser>("Users"); } }
        [Association(@"XpoDxRoleClaimReferencesXpoDxRole"), Aggregated]
        public XPCollection<XpoDxRoleClaim> Claims { get { return GetCollection<XpoDxRoleClaim>("Claims"); } }
    }

}