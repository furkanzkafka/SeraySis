using SeraySis.BLL.Abstract;
using SeraySis.BLL.Results;
using SeraySis.Entities;
using SeraySis.Entities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeraySis.BLL
{
    public class RaporManager : ManagerBase<Rapor>
    {
        public BusinessLayerResult<Rapor> GetFaturaById(int id)
        {
            BusinessLayerResult<Rapor> res = new BusinessLayerResult<Rapor>();
            res.Result = Find(x => x.Id == id);

            if (res.Result == null)
            {
                res.AddError(ErrorMessageCode.UserNotFound, "Fatura Bulunamadi");
            }

            return res;
        }


        public BusinessLayerResult<Rapor> RemoveFaturaById(int id)
        {
            BusinessLayerResult<Rapor> res = new BusinessLayerResult<Rapor>();
            Rapor control = Find(x => x.Id == id);

            if (control != null)
            {
                if (Delete(control) == 0)
                {
                    //res.AddError();
                    return res;
                }
            }
            else
            {
                // hata
            }
            return res;
        }
    }
}
