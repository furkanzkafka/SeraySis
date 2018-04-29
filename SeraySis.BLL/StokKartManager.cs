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
    public class StokKartManager : ManagerBase<StokKart>
    {

        public BusinessLayerResult<StokKart> GetStokById(int id)
        {
            BusinessLayerResult<StokKart> res = new BusinessLayerResult<StokKart>();
            res.Result = Find(x => x.Id == id);

            if (res.Result == null)
            {
                res.AddError(ErrorMessageCode.UserNotFound, "Stok Bulunamadi");
            }

            return res;
        }

        public BusinessLayerResult<StokKart> RemoveStokById(int id)
        {
            BusinessLayerResult<StokKart> res = new BusinessLayerResult<StokKart>();
            StokKart control = Find(x => x.Id == id);

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

        public BusinessLayerResult<StokKart> StokGuncelle(StokKart data)
        {
            //Kayitli bir kullanicinin bilgisini alamasin diye

            //StokKart db_stok = Find(x => x.Id != data.Id && (x.MalzemeTanim == data.MalzemeTanim));

            BusinessLayerResult<StokKart> res = new BusinessLayerResult<StokKart>();
        
            //if (db_stok != null && db_stok.Id != data.Id)
            //{
            //    if (db_stok.MalzemeTanim == data.MalzemeTanim)
            //    {
            //        res.AddError(ErrorMessageCode.UsernameAlreadyExists, "Bu Malzeme Kayitli");
            //    }

            //    return res;
            //}

            res.Result = Find(x => x.Id == data.Id);
            res.Result.MalzemeTanim = data.MalzemeTanim;
            res.Result.KdvOran = data.KdvOran;
            res.Result.BirimFiyat = data.BirimFiyat;
            res.Result.BirimPara = data.BirimPara;
            
            if (Update(res.Result) == 0)
            {
                res.AddError(ErrorMessageCode.ProfileCouldNotUpdated, "Stok güncellenemedi.");
            }

            return res;
        }
    }
}
