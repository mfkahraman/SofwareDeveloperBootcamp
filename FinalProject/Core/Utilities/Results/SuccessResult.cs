using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class SuccessResult : Result
    {
        //Aşağıdaki kodda base ifadesi, base class olan Result' u işaret ediyor
        //Result' un 2 tane constructure'ı var. true,message 2 parametreli olan ve sadece true olan 1 parametreli
        //Aşağıdaki kod sayesinde biz SuccessResult'a sadece mesaj parametresi verdiğimizde, true parametresi vermemize gerek kalmadan
        //Result'ın success propertysini trueya, message propertysini parametre olarak verdiğimiz mesaja eşitleyecek
        //Mesaj yazmadan SuccessResultı parametresiz kullanırsak sadece true olacak
        public SuccessResult (string message) : base(true, message) 
        { 
        }

        public SuccessResult() : base(true) 
        { 
        }
    }
}
