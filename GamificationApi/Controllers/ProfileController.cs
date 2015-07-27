using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GamificationApi.GameLogic;
using GamificationApi.ModelRepositories;

namespace GamificationApi.Controllers
{
    public class ProfileController : Controller
    {
        private IUnitOfWork _unitOfWork;
        private IGameLogicApplier _gameLogicApplier;

        public ProfileController()
        {
            //ViewData.Add("LoggedInUser", );
            _unitOfWork = new UnitOfWork();
            _gameLogicApplier = new GameLogicApplier(_unitOfWork, new AchievementChecker(), new StatApplier(), new LevelUpChecker());
        }
        
        // GET: Profile
        public ActionResult Index()
        {
            var player = _unitOfWork.PlayerRepository.Get(null, null, "GeneralStats,Achievements,AssignmentsCompleted,JobPointPurchases").FirstOrDefault();
            return View(player);
        }

        // GET: Profile/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Profile/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        // POST: Profile/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: Profile/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        // POST: Profile/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: Profile/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: Profile/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
