using SeraySis.BLL;
using SeraySis.BLL.Results;
using SeraySis.Entities;
using SeraySis.WebApp.Filters;
using SeraySis.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SeraySis.Controllers
{
    [Auth]
    [ErrorHandle]
    public class YonetimController : Controller
    {
        UserManager usrMng = new UserManager();
        RaporManager rprMng = new RaporManager();
        StokKartManager stokMng = new StokKartManager();

        // GET: Yonetim
        [HttpGet]
        [Route("Yonetim")]
        public ActionResult Yonetim()
        {
            
            return Redirect("/FaturaIslem");
        }


        [HttpGet]
        [Route("Hata")]
        public ActionResult Hata()
        {
            return View();
        }

        [HttpGet]
        [Route("FaturaIslem")]
        public ActionResult FaturaIslem()
        {
            ViewBag.StokkartId = new SelectList(stokMng.List(), "Id", "MalzemeTanim");


            return View();
        }

        [HttpPost]
        [Route("FaturaIslem")]
        public ActionResult FaturaIslem(Rapor rapor)
        {
            ModelState.Remove("CreatedOn");
            ModelState.Remove("ModifiedOn");
            ModelState.Remove("ModifiedUsername");

            BusinessLayerResult<StokKart> stok = stokMng.GetStokById(rapor.StokkartId);

            //Matematiksel hesaplamalar
            rapor.NetTutar = stok.Result.BirimFiyat * rapor.MiktarLitre;
            rapor.KdvliTutar = rapor.NetTutar * stok.Result.KdvOran / 100;
            rapor.ToplamTutar = rapor.NetTutar + rapor.KdvliTutar;

            if(ModelState.IsValid)
            {

            //Fatura kod
            Random rnd = new Random();
            int rst = rnd.Next(10000, 99999);
            rapor.FaturaKod = int.Parse(rst.ToString() + DateTime.Now.Year.ToString());


            rprMng.insert(rapor);

            return Redirect("/Faturadetay/" + rapor.Id);


            }

                ViewBag.StokkartId = new SelectList(stokMng.List(), "Id", "MalzemeTanim", rapor.StokkartId);
            return View(rapor);

        }

        [HttpGet]
        [Route("FaturaDetay/{id}")]
        public ActionResult FaturaDetay(int id)
        {
            BusinessLayerResult<Rapor> model = rprMng.GetFaturaById(id);

            return View(model.Result);
        }

        public PartialViewResult FaturaListele()
        {
            var model = rprMng.List();

            return PartialView("FaturaListele", model);
        }

        [Route("FaturaSil/{id}")]
        public ActionResult FaturaSil(int id)
        {
            BusinessLayerResult<Rapor> res = rprMng.RemoveFaturaById(id);

            return Redirect("/FaturaIslem");
        }

        [HttpGet]
        [Route("StokKartlari")]
        public ActionResult StokKartlari()
        {
            return View();
        }

        [HttpPost]
        [Route("StokKartlari")]
        public ActionResult StokKartlari(StokKart model)
        {
            ModelState.Remove("CreatedOn");
            ModelState.Remove("ModifiedOn");
            ModelState.Remove("ModifiedUsername");

            if (ModelState.IsValid)
            {
                Random rnd = new Random();
                int rst = rnd.Next(10000, 99999);

                model.Kod = int.Parse(DateTime.Now.Year.ToString() + rst.ToString());

                StokKart control = stokMng.Find(x => x.Kod == model.Kod);

                if (control != null)
                {
                    if (control.Kod == model.Kod)
                    {
                        TempData["Fail"] = "Hatali islem tekrar deneyiniz";
                    }
                }

                stokMng.insert(model);

                return Redirect("/StokKartlari");
            }

            return View(model);
        }

        public PartialViewResult StokKartListele()
        {
            var model = stokMng.List();

            return PartialView("StokKartListele", model);
        }

        [Route("StokSil/{id}")]
        public ActionResult StokSil(int id)
        {
            BusinessLayerResult<StokKart> res = stokMng.RemoveStokById(id);

            return Redirect("/StokKartlari");
        }

        [HttpGet]
        [Route("StokGuncelle/{id}")]
        public ActionResult StokDuzenle(int id)
        {
            BusinessLayerResult<StokKart> model = stokMng.GetStokById(id);
            return View(model.Result);
        }

        [HttpPost]
        [Route("StokGuncelle")]
        public ActionResult StokDuzenle(StokKart data)
        {
            ModelState.Remove("CreatedOn");
            ModelState.Remove("ModifiedOn");
            ModelState.Remove("ModifiedUsername");

            if (ModelState.IsValid)
            {
                BusinessLayerResult<StokKart> model = stokMng.StokGuncelle(data);

                return Redirect("/StokKartlari");
            }

            return View(data);

        }


    }
}