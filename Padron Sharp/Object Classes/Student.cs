using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Padron.Object_Classes
{
    class Student
    {
        int varId;
        string varUsername;
        string varFirstname;
        string varLastname;
        string varEmail;
        string varCurp;
        string varGeneration;
        string varField;
        string varPhone;
        string varHeadquarters;
        public int Id
        {
            get { return this.varId; }
            set { this.varId = value; }
        }
        public string Username
        {
            get { return this.varUsername; }
            set { this.varUsername = value; }
        }
        public string Firstname
        {
            get { return this.varFirstname; }
            set { this.varFirstname = value; }
        }
        public string Lastname
        {
            get { return this.varLastname; }
            set { this.varLastname = value; }
        }
        public string Email
        {
            get { return this.varEmail; }
            set { this.varEmail = value; }
        }
        public string Curp
        {
            get { return this.varCurp; }
            set { this.varCurp = value; }
        }
        public string Generation
        {
            get { return this.varGeneration; }
            set { this.varGeneration = value; }
        }
        public string Field
        {
            get { return this.varField; }
            set { this.varField = value; }
        }
        public string Phone
        {
            get { return this.varPhone; }
            set { this.varPhone = value; }
        }
        public string Headquarters
        {
            get { return this.varHeadquarters; }
            set { this.varHeadquarters = value; }
        }
    }
}
