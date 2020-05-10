using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ChurchSMS_offline.JsonNet;
using DataModels.Models;
using DataModels.ViewModels;

namespace ChurchSMS_offline.Controllers
{

    [Authorize]
    public class DataController : BaseController
    {
        //
        // GET: /Data/
        private ChurchSMSofflineContext db = new ChurchSMSofflineContext();

        public JsonResult Requests()
        {
            var d = db.MessageLogs.Where(c => c.Status == 5).Take(5);
            var requests = (from msg in d
                            select new MessageViewModel()
                            {
                                From = msg.PhoneNumber,
                                Request = msg.MessageBody,
                                Time = (DateTime)msg.Time.Value
                            }
                );

            return Json(requests, JsonRequestBehavior.AllowGet);

        }

        public JsonResult Messages(int id)
        {
            var member = db.Users.Find(id);
            var d = db.MessageLogs.Where(i => i.PhoneNumber.Contains(member.PhoneNumber));
            var m = db.Messages.Where(t => t.UserId == id);

            //from message log table
            var messages1 = (from msg in d
                             select new MessageHistoryViewModel()
                             {
                                 Time = (DateTime)msg.Time,
                                 Message = msg.MessageBody,
                                 StatusID = msg.Status,
                                 //Status = msg.MessageStatu.Description,
                                 Direction = msg.Status != 4,
                                 Source = 1,
                                 Id = msg.MessageID
                             }
                ).ToList();

            //from messages table
            var messages2 = (from msg in m
                             select new MessageHistoryViewModel()
                             {
                                 Time = (DateTime)msg.ScheduledTime,
                                 Message = msg.msg_body,
                                 StatusID = msg.Status,
                                 Status = msg.MessageStatu.Description,
                                 Direction = false,
                                 Source = 2,
                                 Id = msg.MessageID
                             }
                ).ToList();

            messages1.AddRange(messages2.AsEnumerable());

            return Json(messages1.OrderByDescending(t => t.Time), JsonRequestBehavior.AllowGet);

        }

        public JsonResult MessageHistory(string from)
        {
            var d = db.MessageLogs.Where(c => c.Status == 5).Take(5);
            var requests = (from msg in d
                            select new MessageViewModel()
                            {
                                From = msg.PhoneNumber,
                                Request = msg.MessageBody,
                                Time = (DateTime)msg.Time.Value
                            }
                );

            return Json(requests, JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetAllContacts()
        {
            var contacts = (from contact in db.Users
                            select new ContactViewModel()
                            {
                                ID = contact.UserId,
                                Name = contact.Name,
                                Phone = contact.PhoneNumber,
                                Selected = false
                            }
                );
            return Json(contacts, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetUnaddedContacts(int groupId)
        {
            var group = db.Groups.Find(groupId);

            var unadded = db.Users.ToList();

            foreach (var member in group.UserGroups)
            {
                unadded.Remove(member.User);
            }

            var contacts = (from contact in unadded
                            select new ContactViewModel()
                            {
                                ID = contact.UserId,
                                Name = contact.Name,
                                Phone = contact.PhoneNumber,
                                Selected = false
                            }
                );
            return Json(contacts, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetUnaddedTags(int groupId)
        {
            var group = db.Groups.Find(groupId);

            var unadded = db.Tags.ToList();

            foreach (var member in group.GroupTags)
            {
                unadded.Remove(member.Tag);
            }

            var contacts = (from contact in unadded
                            select new TagViewModel()
                            {
                                ID = contact.TagId,
                                Name = contact.TagName,
                                Selected = false
                            }
                );
            return Json(contacts, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetUnjoinedGroups(int memberId)
        {
            var member = db.Users.Find(memberId);

            var unjoned = db.Groups.ToList();

            foreach (var gr in member.UserGroups)
            {
                unjoned.Remove(gr.Group);
            }

            var groups = (from gr in unjoned
                          select new GroupViewModel()
                          {
                              ID = gr.GroupID,
                              Name = gr.GroupName,
                              Count = gr.UserGroups.Count,
                              Selected = false
                          }
                );
            return Json(groups, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetUnAddedGifts(int memberId)
        {
            var member = db.Users.Find(memberId);

            var unadded = db.Gifts.ToList();

            foreach (var gift in member.UserGifts)
            {
                unadded.Remove(gift.Gift);
            }
            var gifts = (from gift in unadded
                         select new GiftViewModel()
                         {
                             GiftId = gift.GiftId,
                             GiftName = gift.GiftName,
                             Selected = false
                         }
               );
            return Json(gifts, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetJoinedGroups(int memberId)
        {
            var member = db.Users.Find(memberId);
            var groups = (from gr in member.UserGroups
                          select new GroupViewModel()
                          {
                              ID = gr.GroupID,
                              Name = gr.Group.GroupName,
                              Count = gr.Group.UserGroups.Count,
                              Selected = false
                          }
                );
            return Json(groups, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetOccupations()
        {
            var occupations = db.Occupations;
            var totalUsersCount = db.Users.Count();
            var occn = (occupations.Select(occupation => new LookupViewModel()
            {
                ID = occupation.Id,
                Name = occupation.Title,
                Percentage = (occupation.Users.Count * 100 / totalUsersCount),
                Total = occupation.Users.Count
            })
                );
            return Json(occn, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult GetGifts()
        {
            var gifts = db.Gifts;
            var totalUsersCount = db.Users.Count();
            var g = (from gift in gifts
                     select new LookupViewModel()
                     {
                         ID = gift.GiftId,
                         Name = gift.GiftName,
                         Percentage = (gift.UserGifts.Count * 100 / totalUsersCount),
                         Total = gift.UserGifts.Count
                     }
                );
            return Json(g, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetTagsLookup()
        {
            var tags = db.Tags;
            var totalUsersCount = db.Tags.Count();
            var g = (from gift in tags
                     select new LookupViewModel()
                     {
                         ID = gift.TagId,
                         Name = gift.TagName,
                         Percentage = (gift.GroupTags.Count*100 / totalUsersCount),
                         Total = gift.GroupTags.Count
                     }
                );
            return Json(g, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAddedGifts(int memberId)
        {
            var member = db.Users.Find(memberId);
            var gifts = (from gift in member.UserGifts
                         select new GiftViewModel()
                         {
                             GiftId = gift.Gift.GiftId,
                             GiftName = gift.Gift.GiftName,
                             Selected = false
                         }
                );
            return Json(gifts, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetTags(int groupId)
        {
            var g = db.Groups.Find(groupId);
            var Tags = (from t in g.GroupTags
                        select new Tag()
                        {
                            TagId = t.TagId,
                            TagName = t.Tag.TagName
                        }
                );
            return Json(Tags, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetGroupLeader(int groupId)
        {
            var group = db.UserGroups.Where(t => t.GroupID == groupId);
            var leader = new ContactViewModel();
            if (!@group.Any(t => t.RoleID == 1)) return Json(leader, JsonRequestBehavior.AllowGet);
            var l = @group.First(t => t.RoleID == 1);
            leader.ID = l.UserID;
            leader.Name = l.User.Name;
            leader.Phone = l.User.PhoneNumber;
            leader.Selected = true;
            return Json(leader, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Comments()
        {
            var d = db.MessageLogs.Where(c => c.Status == 6).Take(5);
            var requests = (from msg in d
                            select new MessageViewModel()
                            {
                                From = msg.PhoneNumber,
                                Request = msg.MessageBody,
                                Time = (DateTime)msg.Time.Value
                            }
                );
            return Json(requests, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Send(List<ContactViewModel> selectedcontacts, string msg)
        {
            foreach (var contact in selectedcontacts)
            {
                var message = new Message();
                message.UserId = contact.ID;
                message.msg_body = msg;
                message.Status = 7;
                message.ScheduledTime = DateTime.Now;
                message.SentBy = User.Identity.Name;
                db.Messages.Add(message);
            }
            db.SaveChanges();
            //return RedirectToAction("Index", new { activetab = 2 });
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Send_message(MessageTobeSent msg)
        {
            var message = new Message
            {
                UserId = msg.to,
                msg_body = msg.body,
                Status = 7,
                ScheduledTime = DateTime.Now,
                SentBy = User.Identity.Name
            };
            db.Messages.Add(message);
            db.SaveChanges();
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SaveContactAddress(Address address, int memberId)
        {
            var member = db.Users.Find(memberId);
            address.UserId = memberId;
            member.Address = address;
            db.SaveChanges();
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult remove_message(MessageHistoryViewModel msg)
        {
            switch (msg.Source)
            {
                case 1:
                    {
                        var message = db.MessageLogs.Find(msg.Id);
                        db.MessageLogs.Remove(message);
                    }
                    break;
                case 2:
                    {
                        var message = db.Messages.Find(msg.Id);
                        db.Messages.Remove(message);
                    }
                    break;
            }
            db.SaveChanges();
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Remove(int groupId, int id)
        {
            //var user = db.Users.Find(id);
            //var i = user.User.GroupID;
            var item = db.GroupTags.FirstOrDefault(g => g.GroupId == groupId && g.TagId == id);
            db.GroupTags.Remove(item);
            db.SaveChanges();
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Add(List<ContactViewModel> tobeadded, int groupId)
        {
            foreach (var contact in tobeadded)
            {
                var userGroup = new UserGroup()
                {
                    GroupID = groupId,
                    RoleID = 2,
                    UserID = contact.ID,

                };
                db.UserGroups.Add(userGroup);
            }
            db.SaveChanges();
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Bind(List<TagViewModel> tobeadded, int groupId)
        {
            foreach (var tag in tobeadded)
            {
                var groupTag = new GroupTag()
                {
                    GroupId = groupId,
                    TagId = tag.ID,
                };
                db.GroupTags.Add(groupTag);
            }
            db.SaveChanges();
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Join(List<GroupViewModel> tobejoined, int memberId)
        {
            foreach (var group in tobejoined)
            {
                var userGroup = new UserGroup()
                {
                    GroupID = group.ID,
                    RoleID = 2,
                    UserID = memberId,
                };
                db.UserGroups.Add(userGroup);
            }
            db.SaveChanges();
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult AddGift(List<GiftViewModel> tobeadded, int memberId)
        {
            var member = db.Users.Find(memberId);

            foreach (var gift in tobeadded)
            {
                var g = new UserGift()
                {
                    GiftID = gift.GiftId,
                    UserID = memberId,
                };
                member.UserGifts.Add(g);
            }
            db.SaveChanges();
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult InsertLookup(string title, int lookupid)
        {
            switch (lookupid)
            {
                case 1:
                    var o = new Occupation()
                    {
                        Title = title
                    };
                    db.Occupations.Add(o);
                    break;
                case 2:
                    var g = new Gift()
                   {
                       GiftName = title
                   };
                    db.Gifts.Add(g);
                    break;
                case 3:
                    var t = new Tag()
                    {
                        TagName = title
                    };
                    db.Tags.Add(t);
                    break;
                default:
                    break;
            }

            db.SaveChanges();
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult RemoveLookup(int id, int lookupid)
        {
            switch (lookupid)
            {
                case 1:
                    var o = db.Occupations.Find(id);
                    db.Occupations.Remove(o);
                    break;
                case 2:
                    var g = db.Gifts.Find(id);
                    db.Gifts.Remove(g);
                    break;
                case 3:
                    var t = db.Tags.Find(id);
                    db.Tags.Remove(t);
                    break;
                default:
                    break;
            }

            db.SaveChanges();
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult RemoveGift(int memberId, int giftId)
        {
            var usergift = db.UserGifts.First(t => t.GiftID == giftId && t.UserID == memberId);
            // var member = db.Users.Find(memberId);
            db.UserGifts.Remove(usergift);
            db.SaveChanges();
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);

        }
    }
}