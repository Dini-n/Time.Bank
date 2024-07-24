using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.functions
{
   public class categoryFun
    {
        // משתנה שמכיל את המסד
    //    static Models.TimeBankContext db = new Models.TimeBankContext();

        // פונקציה שמחזירה את הקטגוריות מהמסד בסוג המסד
        public static async Task<List<Models.Category>> GetAllCategories()
        {
            Models.TimeBankContext db = new Models.TimeBankContext();

            try
            {
                db.Members.Include(m => m.MemberCategories).ToList();
                db.Reports.Include(m => m.ReportsDetails).ToList();
                db.MemberCategories.Include(m => m.Reports).ToList();
                db.MemberCategories.Include(m => m.Category).ToList();
                List<Models.Category> l =  await db.Categories.ToListAsync();
                return  db.Categories.ToList();

            }
            catch
            {
                return   null;
            }
        }



        // פונ שמקבלת משתנה קטגוריה מסוג המסד ומוסיפה אותו למסד
        public static async Task addCategory(Dal.Models.Category newCate)
        {
            Models.TimeBankContext db = new Models.TimeBankContext();

            try
            {
                /*       db.Members.Include(m => m.MemberCategories).ToList();
                       db.Reports.Include(m => m.ReportsDetails).ToList();
                       db.MemberCategories.Include(m => m.Reports).ToList();
                       db.MemberCategories.Include(m => m.Category).ToList();*/
                newCate.MemberCategories = null;
                newCate.MemberCategories = null;
                newCate.WaitingLists = null;
                newCate.FatherCategory = null;
                newCate.FatherCategoryId = null;
                db.Categories.Add(newCate);
             await  db.SaveChangesAsync();

                return ;

            }
            catch
            {
                return;
            }
        }
        public static   async Task<Dal.Models.Category> GetCategoryByName(string name)
        {
            Models.TimeBankContext db = new Models.TimeBankContext();

            try
            {
                return await db.Categories.FirstOrDefaultAsync(c => c.Name == name);
            }
            catch
            {
                throw new Exception();
            }
        }
    }
}
