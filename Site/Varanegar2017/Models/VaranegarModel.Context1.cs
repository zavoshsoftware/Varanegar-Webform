﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Varanegar2017.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class VaranegarEntities : DbContext
    {
        public VaranegarEntities()
            : base("name=VaranegarEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AgentPreviousJobs> AgentPreviousJobs { get; set; }
        public virtual DbSet<AgentQuestionaries> AgentQuestionaries { get; set; }
        public virtual DbSet<BlogComments> BlogComments { get; set; }
        public virtual DbSet<BlogGroups> BlogGroups { get; set; }
        public virtual DbSet<Blogs> Blogs { get; set; }
        public virtual DbSet<CareerForm> CareerForm { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<ContactUsForm> ContactUsForm { get; set; }
        public virtual DbSet<ContactUsFormRecievers> ContactUsFormRecievers { get; set; }
        public virtual DbSet<CustomerGroups> CustomerGroups { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<DemoRequests> DemoRequests { get; set; }
        public virtual DbSet<EmailRecieverRoles> EmailRecieverRoles { get; set; }
        public virtual DbSet<Emails> Emails { get; set; }
        public virtual DbSet<FamiliarMethods> FamiliarMethods { get; set; }
        public virtual DbSet<GalleryGroups> GalleryGroups { get; set; }
        public virtual DbSet<GalleryImages> GalleryImages { get; set; }
        public virtual DbSet<ImageGroups> ImageGroups { get; set; }
        public virtual DbSet<Images> Images { get; set; }
        public virtual DbSet<Log_Errors> Log_Errors { get; set; }
        public virtual DbSet<Log_SearchQueries> Log_SearchQueries { get; set; }
        public virtual DbSet<Managers> Managers { get; set; }
        public virtual DbSet<NewsLetters> NewsLetters { get; set; }
        public virtual DbSet<ProductGroups> ProductGroups { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Province> Province { get; set; }
        public virtual DbSet<Rel_Customer_Province> Rel_Customer_Province { get; set; }
        public virtual DbSet<Rel_Solutions_Customers> Rel_Solutions_Customers { get; set; }
        public virtual DbSet<Resumes> Resumes { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Services> Services { get; set; }
        public virtual DbSet<ServiceStepItems> ServiceStepItems { get; set; }
        public virtual DbSet<ServiceSteps> ServiceSteps { get; set; }
        public virtual DbSet<Sliders> Sliders { get; set; }
        public virtual DbSet<SolutionGroups> SolutionGroups { get; set; }
        public virtual DbSet<Solutions> Solutions { get; set; }
        public virtual DbSet<Texts> Texts { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<SeminarRequests> SeminarRequests { get; set; }
    }
}
