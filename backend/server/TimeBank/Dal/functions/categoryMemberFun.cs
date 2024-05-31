using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.functions
{
    public class categoryMemberFun
    {
        static Models.TimeBankContext db = new Models.TimeBankContext();
        // פונקציה שמחזירה את הקטגוריות של חבר מהמסד בסוג המסד
        public static List<Models.MemberCategory> GetAllmemberCat()
        {
            try
            {
                db.Members.Include(m => m.MemberCategories).ToList();
                db.Reports.Include(m => m.ReportsDetails).ToList();
                db.MemberCategories.Include(m => m.Reports).ToList();
                db.MemberCategories.Include(m => m.Category).ToList();
                List<Models.MemberCategory> l = db.MemberCategories.ToList();
                return l;

            }
            catch
            {
                return null;
            }
        }

        public static  List<Dal.Models.MemberCategory> getAllCategoriesMember()

        {
            db.MemberCategories.Include(mc => mc.Member).ToList();
            db.MemberCategories.Include(mc => mc.Category).ToList();
            //db.MemberCategories.ToList();
/*
            Dictionary<string, List<Dal.Models.MemberCategory>> d = new Dictionary<string, List<Models.MemberCategory>>();
            db.Categories.ToList().ForEach(n => d.Add(n.Name,
            db.MemberCategories.ToList().Where(k => k.Category.Name == n.Name).ToList()));

*/
            List<Dal.Models.MemberCategory> memberCategories = db.MemberCategories.ToList();
            return memberCategories;
        }

        // פונ שמקבלת משתנה קטגורית חבר מסוג המסד ומוסיפה אותו למסד
        public static void addMemberCategory(Dal.Models.MemberCategory newMemCate)
        {
            try
            {
                //db.Members.Include(m => m.MemberCategories).ToList();
                //db.Reports.Include(m => m.ReportsDetails).ToList();
                // db.MemberCategories.Include(m => m.Reports).ToList();
                // db.MemberCategories.Include(m => m.Category).ToList();
                Dal.Models.MemberCategory r = new Dal.Models.MemberCategory() {
                    CategoryId = newMemCate.CategoryId,
                    MemberId = newMemCate.MemberId,
                    ExperienceYears = newMemCate.ExperienceYears,
                    Place = newMemCate.Place,
                    MinGruop = newMemCate.MinGruop,
                    RestrictionsDescription = newMemCate.RestrictionsDescription,
                    PossibilityComeCustomerHome = newMemCate.PossibilityComeCustomerHome
                };
                /*,ExperienceYears = newMemCate.ExperienceYears,ForGroup=newMemCate.ForGroup
                                    ,Place= newMemCate.Place,PossibilityComeCustomerHome = newMemCate.PossibilityComeCustomerHome,*/
                newMemCate.Category = null;
                newMemCate.Member = null;
                db.MemberCategories.Add(r);
                db.SaveChanges();

                return;

            }
            catch(Exception e)
            {
                throw new Exception("it is not work");
            }
        }
        public static Dal.Models.Category GetCategoryIdByName(string name)
        {
            try
            {
                return db.Categories.FirstOrDefault(c => c.Name == name);
            }
            catch
            {
                throw new Exception();
            }
        }

        public static  List<Dal.Models.MemberCategory> GetFilteredMemberCategories(string name, string phone, string? email, string address, bool? gender,
            string category, string place, bool? possibilityComeCustomerHome, short? experienceYears, string restrictionsDescription, bool? forGroup, short? minGroup, short? maxGroup)
        {
            var query = db.MemberCategories.AsQueryable();
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(mc => mc.Member.Name == name);
            }
            if (!string.IsNullOrEmpty(phone))
            {
                query = query.Where(mc => mc.Member.Phone == phone);
            }
            if (!string.IsNullOrEmpty(email))
            {
                query = query.Where(mc => mc.Member.Mail == email);
            }
            if (!string.IsNullOrEmpty(address))
            {
                query = query.Where(mc => mc.Member.Address == address);
            }

            if (gender.HasValue)
            {
                query = query.Where(mc => mc.Member.Gender == gender);
            }

            if (!string.IsNullOrEmpty(category))
            {
                query = query.Where(mc => mc.Category.Name == category);
            }

            if (!string.IsNullOrEmpty(place))
            {
                query = query.Where(mc => mc.Place == place);
            }

            if (possibilityComeCustomerHome.HasValue)
            {
                query = query.Where(mc => mc.PossibilityComeCustomerHome == possibilityComeCustomerHome);
            }

            if (experienceYears.HasValue)
            {
                query = query.Where(mc => mc.ExperienceYears == experienceYears);
            }

            if (!string.IsNullOrEmpty(restrictionsDescription))
            {
                query = query.Where(mc => mc.RestrictionsDescription == restrictionsDescription);
            }

            if (forGroup.HasValue)
            {
                query = query.Where(mc => mc.ForGroup == forGroup);
            }

            if (minGroup.HasValue)
            {
                query = query.Where(mc => mc.MinGruop == minGroup);
            }

            if (maxGroup.HasValue)
            {
                query = query.Where(mc => mc.MaxGroup == maxGroup);
            }
         //   db.MemberCategories.Include(mc => mc.Member).ToList();
            List<Dal.Models.MemberCategory> d =  query.ToList();
            return d;

        }

    }
}
