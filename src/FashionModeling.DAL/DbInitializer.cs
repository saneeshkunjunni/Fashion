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
                        // gender
                         new Common{
                            Code = "GENDER" ,
                            Description ="Gender content",
                            IsActive= true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Men"
                        },
                          new Common{
                            Code = "GENDER" ,
                            Description ="Gender content",
                            IsActive= true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Women"
                        },
                           new Common{
                            Code = "GENDER" ,
                            Description ="Gender content",
                            IsActive= true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Intermediate"
                        },
                          // Category
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
                            ModifiedBy =user.Id,CreatedBy =user.Id,Title ="Practicing Sports",
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
                        //HAIRCOLOR
                          new Common{
                            Code = "HAIRCOLOR" ,
                            Description ="Hair color",
                            IsActive= true,
                            ModifiedBy =user.Id,
                              CreatedBy =user.Id,
                              Title ="White",
                        },
                            new Common{
                            Code = "HAIRCOLOR" ,
                            Description ="Hair color",
                            IsActive= true,
                            ModifiedBy =user.Id,
                              CreatedBy =user.Id,
                              Title ="Red",
                        },
                        new Common{
                            Code = "HAIRCOLOR" ,
                            Description ="Hair color",
                            IsActive= true,
                            ModifiedBy =user.Id,
                              CreatedBy =user.Id,
                              Title ="Grey",
                        },
                        new Common{
                            Code = "HAIRCOLOR" ,
                            Description ="Hair color",
                            IsActive= true,
                            ModifiedBy =user.Id,
                              CreatedBy =user.Id,
                              Title ="Brown",
                        },
                          new Common{
                            Code = "HAIRCOLOR" ,
                            Description ="Hair color",
                            IsActive= true,
                            ModifiedBy =user.Id,
                              CreatedBy =user.Id,
                              Title ="Blonde",
                        },
                          new Common{
                            Code = "HAIRCOLOR" ,
                            Description ="Hair color",
                            IsActive= true,
                            ModifiedBy =user.Id,
                              CreatedBy =user.Id,
                              Title ="Black",
                        },
                          // EYECOLOR
                           new Common{
                                Code = "EYECOLOR" ,
                                Description ="Eye color",
                                IsActive= true,
                                ModifiedBy =user.Id,
                                CreatedBy =user.Id,
                               Title ="Hazel",
                        },
                             new Common{
                                Code = "EYECOLOR" ,
                                Description ="Eye color",
                                IsActive= true,
                                ModifiedBy =user.Id,
                                CreatedBy =user.Id,
                               Title ="Green",
                        },
                        new Common{
                            Code = "EYECOLOR" ,
                            Description ="Eye color",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Brown",
                        },
                        new Common{
                            Code = "EYECOLOR" ,
                            Description ="Eye color",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Blue",
                        },
                        new Common{
                            Code = "EYECOLOR" ,
                            Description ="Eye color",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Black",
                        },
                        new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Arabic / Levantine",
                        },
                         new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Arabic / Mashriqi or Ammiya",
                        },
                          new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Arabic / Derja",
                        },
                           new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Arabic / Maghrebi",
                        },
                            new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Arabic / Bareqi",
                        },
                        new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Arabic / Hejazi",
                        },
                        new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Arabic / Khaleeji",
                        },
                         new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Arabic / Najdi",
                        },
                          new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Arabic / Emirati",
                        },
                          new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Amharic",
                        },
                          new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Zulu",
                        },
                          new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Zhuang",
                        },
                            new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Yue (Cantonese)",
                        },
                            new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Yoruba",
                        },
                             new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Xiang (Hunnanese)",
                        },
                             new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Maithili",
                        },
                             new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Magahi",
                        },
                              new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Madurese",
                        },
                               new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Lithuanian",
                        },
                                new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Lebanese",
                        },
                                 new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Kurdish",
                        },
                                  new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Korean",
                        },
                                   new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Konkani",
                        },
                                    new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Kirundi",
                        },
                                     new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Kindyarwanda",
                        },
                                      new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Khmer",
                        },
                                       new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Kazakh",
                        },
                                        new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Kannada",
                        },
                                         new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Jin",
                        },
                                          new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Javanese",
                        },
                                           new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Japanese",
                        },
                                            new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Italian",
                        },
                                             new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Indonesian / Malay",
                        },
                                              new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Ilocano",
                        },
                                               new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Igbo",
                        },
                                                new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Hungarian",
                        },
                                                 new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Hmong",
                        },
                        new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Hindi",
                        },
                         new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Hiligaynon",
                        },
                          new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Hausa",
                        },
                           new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Haryanvi",
                        },
                         new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Hakka",
                        },
                         new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Haitian Creole",
                        },
                          new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Gujarati",
                        },
                           new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Greek",
                        },
                            new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="German",
                        },
                             new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Gan Chinese",
                        },
                              new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Fula",
                        },
                               new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="French",
                        },
                                new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="English / American English",
                        },
                        new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="English / British English",
                        },
                        new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Eastern Min",
                        },
                         new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Dutch",
                        },
                         new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Dhundhari",
                        },
                         new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Deccan",
                        },
                         new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Danish",
                        },
                         new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Czech",
                        },
                         new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Chittagonian",
                        },
                        new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Chhattisgarhi",
                        },
                        new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Xhosa",
                        },
                        new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Wu (Shanghainese)",
                        },
                        new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Vietnamese",
                        },
                        new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Uzbek",
                        },
                        new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Uyghur",
                        },
                        new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Urdu",
                        },
                        new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Ukrainian",
                        },
                        new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Turkish / Turkmen",
                        },
                        new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Arabic / Khaleeji",
                        },
                        new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Thai",
                        },
                        new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Telugu",
                        },
                         new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Tamil",
                        },
                          new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Tamazight",
                        },
                           new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Tagalog",
                        },
                            new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Sylheti",
                        },
                             new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Swedish",
                        },
                              new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Swahili",
                        },
                               new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Sudanese",
                        },
                         new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Spanish",
                        },
                          new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Southern Min",
                        },
                           new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Somali",
                        },
                            new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Slovene",
                        },
                        new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Slovak",
                        },
                        new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Sinhalese",
                        },
                        new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Sindhi",
                        },
                        new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Shona",
                        },
                        new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Serbo-Croatian",
                        },
                        new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Saraiki",
                        },
                        new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Russian",
                        },
                        new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Romanian",
                        },
                        new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Quechua",
                        },
                        new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Punjabi",
                        },
                        new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Portuguese",
                        },
                        new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Polish",
                        },
                        new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Persian (Farzi)",
                        },
                        new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Pashto",
                        },
                        new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Oromo",
                        },
                        new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Odia (Oriya)",
                        },
                        new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Norwegian",
                        },
                        new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Northern Min",
                        },
                        new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Nepali",
                        },
                        new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Mossi",
                        },
                        new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Marwari",
                        },
                        new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Marathi",
                        },
                        new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Mandarin",
                        },
                        new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Malayalam",
                        },
                        new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Chewa",
                        },
                        new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Cebuano",
                        },
                        new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Burmese",
                        },
                        new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Bulgarian",
                        },
                        new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Bhojpuri",
                        },
                        new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Bengali",
                        },
                        new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Belarusian",
                        },
                        new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Balochi",
                        },
                        new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Azerbaijani",
                        },
                        new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Assamese",
                        },
                        new Common{
                            Code = "LANGUAGE" ,
                            Description ="Language for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Armenian",
                        },
                        new Common{
                            Code = "NATIONALITY" ,
                            Description ="Nationality for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Afghanistan",
                        },
                        new Common{
                            Code = "NATIONALITY" ,
                            Description ="Nationality for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Albania",
                        },
                        new Common{
                            Code = "NATIONALITY" ,
                            Description ="Nationality for registration",
                            IsActive = true,
                            ModifiedBy =user.Id,
                            CreatedBy =user.Id,
                            Title ="Algeria",
                        },
                    new Common{
                        Code = "NATIONALITY" ,
                        Description ="Nationality for registration",
                        IsActive = true,
                        ModifiedBy =user.Id,
                        CreatedBy =user.Id,
                        Title ="American Samoa",
                    },
                    new Common{
                        Code = "NATIONALITY" ,
                        Description ="Nationality for registration",
                        IsActive = true,
                        ModifiedBy =user.Id,
                        CreatedBy =user.Id,
                        Title ="Andorra",
                    },
                    new Common{
                        Code = "NATIONALITY" ,
                        Description ="Nationality for registration",
                        IsActive = true,
                        ModifiedBy =user.Id,
                        CreatedBy =user.Id,
                        Title ="Angola",
                    },
                    new Common{
                        Code = "NATIONALITY" ,
                        Description ="Nationality for registration",
                        IsActive = true,
                        ModifiedBy =user.Id,
                        CreatedBy =user.Id,
                        Title ="Anguilla",
                    },
                    new Common{
                        Code = "NATIONALITY" ,
                        Description ="Nationality for registration",
                        IsActive = true,
                        ModifiedBy =user.Id,
                        CreatedBy =user.Id,
                        Title ="Antarctica",
                    },
                    new Common{
                        Code = "NATIONALITY" ,
                        Description ="Nationality for registration",
                        IsActive = true,
                        ModifiedBy =user.Id,
                        CreatedBy =user.Id,
                        Title ="Antigua And Barbuda",
                    },
                    new Common{
                        Code = "NATIONALITY" ,
                        Description ="Nationality for registration",
                        IsActive = true,
                        ModifiedBy =user.Id,
                        CreatedBy =user.Id,
                        Title ="Argentina",
                    },
                    new Common{
                        Code = "NATIONALITY" ,
                        Description ="Nationality for registration",
                        IsActive = true,
                        ModifiedBy =user.Id,
                        CreatedBy =user.Id,
                        Title ="Armenia",
                    },
                    new Common{
                        Code = "NATIONALITY" ,
                        Description ="Nationality for registration",
                        IsActive = true,
                        ModifiedBy =user.Id,
                        CreatedBy =user.Id,
                        Title ="Aruba",
                    },
                    new Common{
                        Code = "NATIONALITY" ,
                        Description ="Nationality for registration",
                        IsActive = true,
                        ModifiedBy =user.Id,
                        CreatedBy =user.Id,
                        Title ="Australia",
                    },
                    new Common{
                        Code = "NATIONALITY" ,
                        Description ="Nationality for registration",
                        IsActive = true,
                        ModifiedBy =user.Id,
                        CreatedBy =user.Id,
                        Title ="Austria",
                    },
                    new Common{
                        Code = "NATIONALITY" ,
                        Description ="Nationality for registration",
                        IsActive = true,
                        ModifiedBy =user.Id,
                        CreatedBy =user.Id,
                        Title ="Azerbaijan",
                    },
                    new Common{
                        Code = "NATIONALITY" ,
                        Description ="Nationality for registration",
                        IsActive = true,
                        ModifiedBy =user.Id,
                        CreatedBy =user.Id,
                        Title ="Bahamas The",
                    },
                    new Common{
                        Code = "NATIONALITY" ,
                        Description ="Nationality for registration",
                        IsActive = true,
                        ModifiedBy =user.Id,
                        CreatedBy =user.Id,
                        Title ="Bahrain",
                    },
                    new Common{
                        Code = "NATIONALITY" ,
                        Description ="Nationality for registration",
                        IsActive = true,
                        ModifiedBy =user.Id,
                        CreatedBy =user.Id,
                        Title ="Bangladesh",
                    },
                    new Common{
                        Code = "NATIONALITY" ,
                        Description ="Nationality for registration",
                        IsActive = true,
                        ModifiedBy =user.Id,
                        CreatedBy =user.Id,
                        Title ="Barbados",
                    },
                    new Common{
                        Code = "NATIONALITY" ,
                        Description ="Nationality for registration",
                        IsActive = true,
                        ModifiedBy =user.Id,
                        CreatedBy =user.Id,
                        Title ="Belarus",
                    },
                    new Common{
                        Code = "NATIONALITY" ,
                        Description ="Nationality for registration",
                        IsActive = true,
                        ModifiedBy =user.Id,
                        CreatedBy =user.Id,
                        Title ="Belgium",
                    },
                    new Common{
                        Code = "NATIONALITY" ,
                        Description ="Nationality for registration",
                        IsActive = true,
                        ModifiedBy =user.Id,
                        CreatedBy =user.Id,
                        Title ="Belize",
                    },
                    new Common{
                        Code = "NATIONALITY" ,
                        Description ="Nationality for registration",
                        IsActive = true,
                        ModifiedBy =user.Id,
                        CreatedBy =user.Id,
                        Title ="Benin",
                    },
                    new Common{
                        Code = "NATIONALITY" ,
                        Description ="Nationality for registration",
                        IsActive = true,
                        ModifiedBy =user.Id,
                        CreatedBy =user.Id,
                        Title ="Bermuda",
                    },
                    new Common{
                        Code = "NATIONALITY" ,
                        Description ="Nationality for registration",
                        IsActive = true,
                        ModifiedBy =user.Id,
                        CreatedBy =user.Id,
                        Title ="Bhutan",
                    },
                    new Common{
                        Code = "NATIONALITY" ,
                        Description ="Nationality for registration",
                        IsActive = true,
                        ModifiedBy =user.Id,
                        CreatedBy =user.Id,
                        Title ="Bolivia",
                    },
                    new Common{
                        Code = "NATIONALITY" ,
                        Description ="Nationality for registration",
                        IsActive = true,
                        ModifiedBy =user.Id,
                        CreatedBy =user.Id,
                        Title ="Bosnia and Herzegovina",
                    },
                    new Common{
                        Code = "NATIONALITY" ,
                        Description ="Nationality for registration",
                        IsActive = true,
                        ModifiedBy =user.Id,
                        CreatedBy =user.Id,
                        Title ="Botswana",
                    },
                    new Common{
                        Code = "NATIONALITY" ,
                        Description ="Nationality for registration",
                        IsActive = true,
                        ModifiedBy =user.Id,
                        CreatedBy =user.Id,
                        Title ="Bouvet Island",
                    },
                    new Common{
                        Code = "NATIONALITY" ,
                        Description ="Nationality for registration",
                        IsActive = true,
                        ModifiedBy =user.Id,
                        CreatedBy =user.Id,
                        Title ="Brazil",
                    },
                    new Common{
                        Code = "NATIONALITY" ,
                        Description ="Nationality for registration",
                        IsActive = true,
                        ModifiedBy =user.Id,
                        CreatedBy =user.Id,
                        Title ="British Indian Ocean Territory",
                    },
                    new Common{
                        Code = "NATIONALITY" ,
                        Description ="Nationality for registration",
                        IsActive = true,
                        ModifiedBy =user.Id,
                        CreatedBy =user.Id,
                        Title ="Brunei",
                    },
                    new Common{
                        Code = "NATIONALITY" ,
                        Description ="Nationality for registration",
                        IsActive = true,
                        ModifiedBy =user.Id,
                        CreatedBy =user.Id,
                        Title ="Bulgaria",
                    },
                    new Common{
                        Code = "NATIONALITY" ,
                        Description ="Nationality for registration",
                        IsActive = true,
                        ModifiedBy =user.Id,
                        CreatedBy =user.Id,
                        Title ="Burkina Faso",
                    },
                    new Common{
                        Code = "NATIONALITY" ,
                        Description ="Nationality for registration",
                        IsActive = true,
                        ModifiedBy =user.Id,
                        CreatedBy =user.Id,
                        Title ="Burundi",
                    },
                    new Common{
                        Code = "NATIONALITY" ,
                        Description ="Nationality for registration",
                        IsActive = true,
                        ModifiedBy =user.Id,
                        CreatedBy =user.Id,
                        Title ="Cambodia",
                    },
                    new Common{
                        Code = "NATIONALITY" ,
                        Description ="Nationality for registration",
                        IsActive = true,
                        ModifiedBy =user.Id,
                        CreatedBy =user.Id,
                        Title ="Cameroon",
                    },
                    new Common{
                        Code = "NATIONALITY" ,
                        Description ="Nationality for registration",
                        IsActive = true,
                        ModifiedBy =user.Id,
                        CreatedBy =user.Id,
                        Title ="Canada",
                    },
                    new Common{
                        Code = "NATIONALITY" ,
                        Description ="Nationality for registration",
                        IsActive = true,
                        ModifiedBy =user.Id,
                        CreatedBy =user.Id,
                        Title ="Cape Verde",
                    },
                    new Common{
                        Code = "NATIONALITY" ,
                        Description ="Nationality for registration",
                        IsActive = true,
                        ModifiedBy =user.Id,
                        CreatedBy =user.Id,
                        Title ="Cayman Islands",
                    },
                    new Common{
                        Code = "NATIONALITY" ,
                        Description ="Nationality for registration",
                        IsActive = true,
                        ModifiedBy =user.Id,
                        CreatedBy =user.Id,
                        Title ="Central African Republic",
                    },
                    new Common{
                        Code = "NATIONALITY" ,
                        Description ="Nationality for registration",
                        IsActive = true,
                        ModifiedBy =user.Id,
                        CreatedBy =user.Id,
                        Title ="Chad",
                    },
                    new Common{
                        Code = "NATIONALITY" ,
                        Description ="Nationality for registration",
                        IsActive = true,
                        ModifiedBy =user.Id,
                        CreatedBy =user.Id,
                        Title ="Chile",
                    },
                    new Common{
                        Code = "NATIONALITY" ,
                        Description ="Nationality for registration",
                        IsActive = true,
                        ModifiedBy =user.Id,
                        CreatedBy =user.Id,
                        Title ="China",
                    },
                    new Common{
                        Code = "NATIONALITY" ,
                        Description ="Nationality for registration",
                        IsActive = true,
                        ModifiedBy =user.Id,
                        CreatedBy =user.Id,
                        Title ="Christmas Island",
                    },
                    new Common{
                        Code = "NATIONALITY" ,
                        Description ="Nationality for registration",
                        IsActive = true,
                        ModifiedBy =user.Id,
                        CreatedBy =user.Id,
                        Title ="Cocos (Keeling) Islands",
                    },
                    new Common{
                        Code = "NATIONALITY" ,
                        Description ="Nationality for registration",
                        IsActive = true,
                        ModifiedBy =user.Id,
                        CreatedBy =user.Id,
                        Title ="Colombia",
                    },
                    new Common{
                        Code = "NATIONALITY" ,
                        Description ="Nationality for registration",
                        IsActive = true,
                        ModifiedBy =user.Id,
                        CreatedBy =user.Id,
                        Title ="Comoros",
                    },
                    new Common{
                        Code = "NATIONALITY" ,
                        Description ="Nationality for registration",
                        IsActive = true,
                        ModifiedBy =user.Id,
                        CreatedBy =user.Id,
                        Title ="Cook Islands", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Costa Rica", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Cote D'Ivoire (Ivory Coast)", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Croatia (Hrvatska)", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Cuba", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Cyprus", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Czech Republic", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Democratic Republic Of The Congo", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Denmark", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Djibouti", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Dominica", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Dominican Republic", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="East Timor", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Ecuador", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Egypt", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="El Salvador", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Equatorial Guinea", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Eritrea", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Estonia", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Ethiopia", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="External Territories of Australia", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Falkland Islands", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Faroe Islands", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Fiji Islands", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Finland", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="France", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="French Guiana", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="French Polynesia", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="French Southern Territories", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Gabon", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Gambia The", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Georgia", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Germany", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Ghana", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Gibraltar", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Greece", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Greenland", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Grenada", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Guadeloupe", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Guam", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Guatemala", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Guernsey and Alderney", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Guinea", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Guinea-Bissau", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Guyana", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Haiti", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Heard and McDonald Islands", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Honduras", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Hong Kong S.A.R.", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Hungary", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Iceland", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="India", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Indonesia", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Iran", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Iraq", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Ireland", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Israel", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Italy", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Jamaica", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Japan", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Jersey", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Jordan", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Kazakhstan", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Kenya", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Kiribati", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Korea North", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Korea South", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Kuwait", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Kyrgyzstan", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Laos", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Latvia", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Lebanon", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Lesotho", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Liberia", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Libya", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Liechtenstein", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Lithuania", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Luxembourg", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Macau S.A.R.", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Macedonia", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Madagascar", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Malawi", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Malaysia", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Maldives", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Mali", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Malta", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Man (Isle of)", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Marshall Islands", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Martinique", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Mauritania", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Mauritius", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Mayotte", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Mexico", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Micronesia", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Moldova", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Monaco", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Mongolia", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Montserrat", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Morocco", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Mozambique", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Myanmar", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Namibia", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Nauru", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Nepal", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Netherlands Antilles", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Netherlands The", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="New Caledonia", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="New Zealand", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Nicaragua", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Niger", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Nigeria", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Niue", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Norfolk Island", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Northern Mariana Islands", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Norway", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Oman", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Pakistan", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Palau", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Palestinian Territory Occupied", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Panama", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Papua new Guinea", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Paraguay", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Peru", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Philippines", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Pitcairn Island", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Poland", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Portugal", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Puerto Rico", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Qatar", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Republic Of The Congo", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Reunion", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Romania", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Russia", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Rwanda", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Saint Helena", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Saint Kitts And Nevis", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Saint Lucia", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Saint Pierre and Miquelon", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Saint Vincent And The Grenadines", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Samoa", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="San Marino", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Sao Tome and Principe", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Saudi Arabia", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Senegal", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Serbia", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Seychelles", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Sierra Leone", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Singapore", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Slovakia", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Slovenia", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Smaller Territories of the UK", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Solomon Islands", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Somalia", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="South Africa", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="South Georgia", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="South Sudan", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Spain", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Sri Lanka", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Sudan", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Suriname", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Svalbard And Jan Mayen Islands", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Swaziland", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Sweden", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Switzerland", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Syria", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Taiwan", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Tajikistan", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Tanzania", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Thailand", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Togo", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Tokelau", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Tonga", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Trinidad And Tobago", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Tunisia", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Turkey", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Turkmenistan", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Turks And Caicos Islands", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Tuvalu", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Uganda", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Ukraine", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="United Arab Emirates", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="United Kingdom", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="United States", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="United States Minor Outlying Islands", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Uruguay", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Uzbekistan", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Vanuatu", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Vatican City State (Holy See)", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Venezuela", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Vietnam", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Virgin Islands (British)", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Virgin Islands (US)", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Wallis And Futuna Islands", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Western Sahara", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Yemen", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Yugoslavia", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Zambia", },

    new Common{     Code = "NATIONALITY" ,      Description ="Nationality for registration",        IsActive = true,        ModifiedBy =user.Id,        CreatedBy =user.Id,     Title ="Zimbabwe", },
                    };
                    context.Common.AddRange(lists);
                    context.SaveChanges();
                }
            }
        }

    }
}
