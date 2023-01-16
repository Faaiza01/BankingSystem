using BankingSystem.Services.IService;
using BankingSystem.Services.Models;
using BankingSystem.Services.Service;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BankingSystem.Controllers
{
    public class TransactionController : Controller
    {
        private IBankingSystemService BankingSystemService;

        public TransactionController()
        {
            BankingSystemService = new BankingSystemService();
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DepositCash(DepositCashDto depositCashDto)
        {
            try
            {
                var userId = User.Identity.GetUserId();
                BankingSystemService.DepositCash(depositCashDto, userId);
                return RedirectToAction("TransactionHistory");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public ActionResult WithDraw()
        {
            return View();
        }

        [HttpPost]
        public ActionResult WithDrawCash(DepositCashDto depositCashDto)
        {
            try
            {
                var userId = User.Identity.GetUserId();
                BankingSystemService.WithDrawCash(depositCashDto, userId);
                return RedirectToAction("TransactionHistory");
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult TransactionHistory()
        {
            var userId = User.Identity.GetUserId();
            ViewBag.history = BankingSystemService.GetTransactionHistory(userId);
            return View(ViewBag.history);
        }
    }
}