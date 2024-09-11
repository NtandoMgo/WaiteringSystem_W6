using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaiteringSystem
{
    public class Person
    {
        //Create an abstract Person base class with an ID, Name and Phone. 
        //Include a default and a parametrised constructor. 
        //Add a ToString method to this class to allow you to display the details of a person.
        //This base class will enable you to easily expand the system to include customer bookings at a later stage.   
        
            #region data members
            private string Id, name, Phone;
            #endregion

            #region Properties
            public string ID
            {
                get { return Id; }
                set { Id = value; }
            }

            public string Name
            {
                get { return name; }
                set { name = value; }
            }
            public string Telephone
            {
                get { return Phone; }
                set { Phone = value; }
            }
            #endregion

            #region Construtor
            public Person()
            {
                Id = "";
                name = "";
                Phone = "";
            }

            public Person(string pID, string pName, string pPhone)
            {
                Id = pID;
                name = pName;
                Phone = pPhone;
            }
            #endregion

            #region ToStringMethod
            public override string ToString()
            {
                return name + '\n' + Phone;
            }

            #endregion
        }
    }

