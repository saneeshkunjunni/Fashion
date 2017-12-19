using FashionModeling.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionModeling.DAL
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.CreateIfNotExists();
            var admins = ConfigurationManager.AppSettings["admins"].Split(',');
            var user = (from c in context.Users.OrderBy(x => x.CreateDateUTC)
                        join p in admins on c.Email equals p
                        select c).FirstOrDefault();
            if (user != null)
            {
                if (!context.Tags.Any())
                {
                    var lists = new Tags[] {
                        new Tags(){
                            CreatedBy=user.Id,
                            IsActive=true,
                            ModifiedBy=user.Id,
                            TagType=1,
                            TagName="Actor",
                        },
                        new Tags(){
                            CreatedBy=user.Id,
                            IsActive=true,
                            ModifiedBy=user.Id,
                            TagType=1,
                            TagName="Cast",
                        },
                        new Tags(){
                            CreatedBy=user.Id,
                            IsActive=true,
                            ModifiedBy=user.Id,
                            TagType=1,
                            TagName="Emcee/TV Presenter",
                        },
                        new Tags(){
                            CreatedBy=user.Id,
                            IsActive=true,
                            ModifiedBy=user.Id,
                            TagType=1,
                            TagName="Entertainers",
                        },
                        new Tags(){
                            CreatedBy=user.Id,
                            IsActive=true,
                            ModifiedBy=user.Id,
                            TagType=1,
                            TagName="Event Staff",
                        },
                        new Tags(){
                            CreatedBy=user.Id,
                            IsActive=true,
                            ModifiedBy=user.Id,
                            TagType=1,
                            TagName="Hair Stylish",
                        },
                        new Tags(){
                            CreatedBy=user.Id,
                            IsActive=true,
                            ModifiedBy=user.Id,
                            TagType=1,
                            TagName="Hostess",
                        },
                        new Tags(){
                            CreatedBy=user.Id,
                            IsActive=true,
                            ModifiedBy=user.Id,
                            TagType=1,
                            TagName="Make-Up Artist",
                        },
                        new Tags(){
                            CreatedBy=user.Id,
                            IsActive=true,
                            ModifiedBy=user.Id,
                            TagType=1,
                            TagName="Models",
                        },
                        new Tags(){
                            CreatedBy=user.Id,
                            IsActive=true,
                            ModifiedBy=user.Id,
                            TagType=1,
                            TagName="Photographers",
                        },
                        new Tags(){
                            CreatedBy=user.Id,
                            IsActive=true,
                            ModifiedBy=user.Id,
                            TagType=1,
                            TagName="Promoters",
                        },
                        new Tags(){
                            CreatedBy=user.Id,
                            IsActive=true,
                            ModifiedBy=user.Id,
                            TagType=1,
                            TagName="Videographers",
                        },
                        new Tags(){
                            CreatedBy=user.Id,
                            IsActive=true,
                            ModifiedBy=user.Id,
                            TagType=1,
                            TagName="Wardrobe Assistant",
                        },
                    };
                    context.Tags.AddRange(lists);
                    context.SaveChanges();
                }
                if (!context.Common.Any())
                {
                    var lists = new Common[]{
                        new Common{
                            Code = "CATEGORY" ,
                            Description ="Category content",
                            IsActive= true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Infant Toddler Boy (0-5 Years Old)"
                        },
                         new Common{
                            Code = "CATEGORY" ,
                            Description ="Category content",
                            IsActive= true, ModifiedBy =user.Id,CreatedBy =user.Id,Title="Infant Toddler Girl (0-5 Years Old)"
                        },
                          new Common{
                            Code = "CATEGORY" ,
                            Description ="Category content",
                            IsActive= true, ModifiedBy =user.Id,CreatedBy =user.Id,Title="Boy (6-19 Years Old)"
                        },
                           new Common{
                            Code = "CATEGORY" ,
                            Description ="Category content",
                            IsActive= true, ModifiedBy =user.Id,CreatedBy =user.Id,Title="Girl (6-19 Years Old)"
                        },
                            new Common{
                            Code = "CATEGORY" ,
                            Description ="Category content",
                            IsActive= true, ModifiedBy =user.Id,CreatedBy =user.Id,Title="Men (20 Years and above)"
                        },
                        new Common{
                            Code = "CATEGORY" ,
                            Description ="Category content",
                            IsActive= true, ModifiedBy =user.Id,CreatedBy =user.Id,Title="Women (20 Years and above)"
                        },
                        // TSHIRT SIZE
                        new Common{
                            Code = "FITSIZE" ,
                            Description ="Tshirt and Jacket size",
                            IsActive= true, ModifiedBy =user.Id,CreatedBy =user.Id,Title="XXS"
                        },
                        new Common{
                            Code = "FITSIZE" ,
                            Description ="Tshirt and Jacket size",
                            IsActive= true, ModifiedBy =user.Id,CreatedBy =user.Id,Title="XS"
                        },
                        new Common{
                            Code = "FITSIZE" ,
                            Description ="Tshirt and Jacket size",
                            IsActive= true, ModifiedBy =user.Id,CreatedBy =user.Id,Title="S"
                        },
                        new Common{
                            Code = "FITSIZE" ,
                            Description ="Tshirt and Jacket size",
                            IsActive= true, ModifiedBy =user.Id,CreatedBy =user.Id,Title="M"
                        },
                        new Common{
                            Code = "FITSIZE" ,
                            Description ="Tshirt and Jacket size",
                            IsActive= true, ModifiedBy =user.Id,CreatedBy =user.Id,Title="L"
                        },
                        new Common{
                            Code = "FITSIZE" ,
                            Description ="Tshirt and Jacket size",
                            IsActive= true, ModifiedBy =user.Id,CreatedBy =user.Id,Title="XL"
                        },
                        new Common{
                            Code = "FITSIZE" ,
                            Description ="Tshirt and Jacket size",
                            IsActive= true, ModifiedBy =user.Id,CreatedBy =user.Id,Title="XXL"
                        },
                        new Common{
                            Code = "FITSIZE" ,
                            Description ="Tshirt and Jacket size",
                            IsActive= true, ModifiedBy =user.Id,CreatedBy =user.Id,Title="XXXL"
                        },

                        // EXPERIENCE
                        new Common{
                            Code = "EXPERIENCE" ,
                            Description ="Level of experience",
                            IsActive= true, ModifiedBy =user.Id,CreatedBy =user.Id,Title="New"
                        },
                        new Common{
                            Code = "EXPERIENCE" ,
                            Description ="Level of experience",
                            IsActive= true, ModifiedBy =user.Id,CreatedBy =user.Id,Title="Beginner"
                        },
                        new Common{
                            Code = "EXPERIENCE" ,
                            Description ="Level of experience",
                            IsActive= true, ModifiedBy =user.Id,CreatedBy =user.Id,Title="Intermediate"
                        },
                        new Common{
                            Code = "EXPERIENCE" ,
                            Description ="Level of experience",
                            IsActive= true,
                            ModifiedBy =user.Id,CreatedBy =user.Id,Title ="Experienced",
                        },
                        // Special Features
                        new Common{
                            Code = "SPECIALFEATURES" ,
                            Description ="Special features of profile",
                            IsActive= true, ModifiedBy =user.Id,CreatedBy =user.Id,Title="Triplets"
                        },
                        new Common{
                            Code = "SPECIALFEATURES" ,
                            Description ="Special features of profile",
                            IsActive= true,
                            ModifiedBy =user.Id,CreatedBy =user.Id,Title ="Practicing",
                        },
                        new Common{
                            Code = "SPECIALFEATURES" ,
                            Description ="Special features of profile",
                            IsActive= true,
                            ModifiedBy =user.Id,CreatedBy =user.Id,Title ="Sports",
                        },
                        new Common{
                            Code = "SPECIALFEATURES" ,
                            Description ="Special features of profile",
                            IsActive= true,
                            ModifiedBy =user.Id,CreatedBy =user.Id,Title ="Twins",
                        },
                        new Common{
                            Code = "SPECIALFEATURES" ,
                            Description ="Special features of profile",
                            IsActive= true,
                            ModifiedBy =user.Id,CreatedBy =user.Id,Title ="Tattoos",
                        },
                        new Common{
                            Code = "SPECIALFEATURES" ,
                            Description ="Special features of profile",
                            IsActive= true,
                            ModifiedBy =user.Id,CreatedBy =user.Id,Title ="Plus Size",
                        },
                        new Common{
                            Code = "SPECIALFEATURES" ,
                            Description ="Special features of profile",
                            IsActive= true,
                            ModifiedBy =user.Id,CreatedBy =user.Id,Title ="Piercing",
                        },
                        new Common{
                            Code = "SPECIALFEATURES" ,
                            Description ="Special features of profile",
                            IsActive= true,
                            ModifiedBy =user.Id,CreatedBy =user.Id,Title ="Hand model",
                        },
                        new Common{
                            Code = "SPECIALFEATURES" ,
                            Description ="Special features of profile",
                            IsActive= true,
                            ModifiedBy =user.Id,CreatedBy =user.Id,Title ="Foot Model",
                        },
                        new Common{
                            Code = "SPECIALFEATURES" ,
                            Description ="Special features of profile",
                            IsActive= true,
                            ModifiedBy =user.Id,CreatedBy =user.Id,Title ="Dread locks",
                        },
                        new Common{
                            Code = "SPECIALFEATURES" ,
                            Description ="Special features of profile",
                            IsActive= true,
                            ModifiedBy =user.Id,CreatedBy =user.Id,Title ="Dread locks",
                        },
                        // ETHNICITY
                        new Common{
                            Code = "ETHNICITY" ,
                            Description ="Ethinicity of location",
                            IsActive= true,
                            ModifiedBy =user.Id,CreatedBy =user.Id,Title ="Pacific Islander",
                        },
                        new Common{
                            Code = "ETHNICITY" ,
                            Description ="Ethinicity of location",
                            IsActive= true,
                            ModifiedBy =user.Id,CreatedBy =user.Id,Title ="Oriental",
                        },
                        new Common{
                            Code = "ETHNICITY" ,
                            Description ="Ethinicity of location",
                            IsActive= true,
                            ModifiedBy =user.Id,CreatedBy =user.Id,Title ="Medoterranean",
                        },
                        new Common{
                            Code = "ETHNICITY" ,
                            Description ="Ethinicity of location",
                            IsActive= true,
                            ModifiedBy =user.Id,CreatedBy =user.Id,Title ="Latino",
                        },
                        new Common{
                            Code = "ETHNICITY" ,
                            Description ="Ethinicity of location",
                            IsActive= true,
                            ModifiedBy =user.Id,CreatedBy =user.Id,Title ="Indian",
                        },
                        new Common{
                            Code = "ETHNICITY" ,
                            Description ="Ethinicity of location",
                            IsActive= true,
                            ModifiedBy =user.Id,CreatedBy =user.Id,Title ="European / Caucasian",
                        },
                        new Common{
                            Code = "ETHNICITY" ,
                            Description ="Ethinicity of location",
                            IsActive= true,
                            ModifiedBy =user.Id,CreatedBy =user.Id,Title ="Asian",
                        },
                        new Common{
                            Code = "ETHNICITY" ,
                            Description ="Ethinicity of location",
                            IsActive= true,
                            ModifiedBy =user.Id,CreatedBy =user.Id,Title ="Arab",
                        },
                        new Common{
                            Code = "ETHNICITY" ,
                            Description ="Ethinicity of location",
                            IsActive= true,
                            ModifiedBy =user.Id,CreatedBy =user.Id,Title ="African",
                        },
                    };
                    context.Common.AddRange(lists);
                    context.SaveChanges();
                }
            }
        }

    }
}
