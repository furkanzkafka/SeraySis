using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeraySis.Entities.Messages;

namespace SeraySis.BLL.Results
{
    public class BusinessLayerResult<T> where T : class
    {

        public List<ErrorMessageObj> Errors { get; set; }
        public T Result { get; set; }

        public BusinessLayerResult()
        {
            //Errorun bos donme durumu ve tekrar tekrar olusturmamak icin
            Errors = new List<ErrorMessageObj>();
        }

        //Error kodlarini kolay ekleyebilmek icin
        public void AddError(ErrorMessageCode code, string message)
        {
            //Kendi sinifimizi olusturup kendi parametrelerimiz ile islem yaptik
            Errors.Add(new ErrorMessageObj() { Code = code, Message = message });
        }
    }
}
