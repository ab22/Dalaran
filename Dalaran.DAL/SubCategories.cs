//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Dalaran.DAL
{
    using System;
    using Dalaran.DAL.Interfaces;
    public partial class SubCategories : IEntity
    {
        public int SubCategoryId { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public string Name { get; set; }
    
        public virtual Categories Categories { get; set; }
    }
}
