using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zxcvbn;


namespace Services
{
    public class PasswordService:IPasswordService
    {
       public int CheckStrengthPassword(String password)
        {

           
            return Zxcvbn.Core.EvaluatePassword(password).Score;

        }
    }
}
