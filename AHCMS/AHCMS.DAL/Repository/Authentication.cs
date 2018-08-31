using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AHCMS.CORE;

namespace AHCMS.DAL.Repository
{
    public class Authentication
    {
        AHCMSEntities context;

        public ValidateUser_Result Login(string username, string password, string role, Int32 source)
        {
            using (context = new AHCMSEntities())
            {
                return context.ValidateUser(username, password, role, source).FirstOrDefault();
            }
        }

        public int PatientRegistration(Patient p)
        {
            using (context = new AHCMSEntities())
            {
                return context.Insert_PatientMembership(p.PatientID,p.PatientReffNo,p.UserName,p.Password,p.Email,p.CountryCode,p.PhoneNumber,p.FirstName,p.MiddleName,p.LastName,p.BirthDate.ToString(),p.Street,p.City,p.State,p.Country,p.ZipCode,p.Img,p.BloodGroup,p.Gender);
            }
        }

        public int EmployeeRegistration(Employee e,string role)
        {
            using (context = new AHCMSEntities())
            {
                return context.Insert_EmployeeMembership(e.EmployeeID,e.ReffNo,e.UserName,e.Password,e.Email,e.CountryCode,e.PhoneNumber,e.FirstName,e.MiddleName,e.LastName,e.BirthDate.ToString(),e.Street,e.City,e.State,e.Country,e.ZipCode,e.Img,e.BloodGroup,e.Gender,role);
            }
        }

        public int? ChangePassword(string id, string username, string email, string password, int source)
        {
            int? i;
            using (context = new AHCMSEntities())
            {
                i = context.ResetPassword(id,username,email,password,source).FirstOrDefault();
                context.SaveChanges();
            }
            return i;
        }

        public ForgotPassword_Result ForgotPassword(string username, string email, int source)
        {
            using (context = new AHCMSEntities())
            {
                return context.ForgotPassword(username,email,source).FirstOrDefault();
            }
        }

        //public Byte[] ProfileImage(string id, string role)
        //{
        //    Byte[] i;
        //    using (context = new AHCMSEntities())
        //    {
        //        i = context.ViewProfileImage(id, role).FirstOrDefault();
        //    }

        //    return i;
        //}
    }
}
