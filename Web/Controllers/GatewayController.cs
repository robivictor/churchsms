using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.WebPages;
using ChurchSMS.Models;
using DataModels.Models;

namespace ChurchSMS_offline.Controllers
{
    public class GatewayController : ApiController
    {
        private ChurchSMSofflineContext _db = new ChurchSMSofflineContext();
        private readonly MessageValidate _mv = new MessageValidate();


        public HttpResponseMessage Post(SMSRequest request)
        {
            var phone = _db.PhoneStatus.Find(1);
            phone.BatteryLevel = request.battery;
            phone.Network = request.network;
            phone.PowerMode = request.power;
            phone.SIM_Number = request.phone_number;
            //phone.LastConnected = _mv.ToDateTime(Convert.ToDouble(request.now));
            phone.LastConnected = DateTime.Now;
            _db.SaveChanges();

            var smsevents = new SMSEvents();
            char[] separators = { ' ', ',', '-', '_', '/', ':', ';', '~' };

            switch (request.action)
            {
                case "test":
                    break;
                case "outgoing":
                    {
                        var msgs = _db.Messages.Where(m => m.Status == 7).Take(200);
                        var msgLogs = _db.MessageLogs.Where(m => m.Status == 4);
                        var messages = new List<SmsOutgoingMessage>();

                        //This if clause is needed because the outgoing messages are fetched from two tables and sent to the mobile client as if they are all coming from the same table.
                        if (msgs.Any())
                        {
                            messages.AddRange(msgs.ToList().Select(msg => new SmsOutgoingMessage()
                            {
                                id = "P" + msg.MessageID.ToString(),
                                message = msg.msg_body,
                                to = msg.User.PhoneNumber,
                                priority = null,
                                type = null
                            }));
                        }
                        if (msgLogs.Any())
                        {
                            messages.AddRange(msgLogs.ToList().Select(msg => new SmsOutgoingMessage()
                            {
                                id = "S" + msg.MessageID.ToString(),
                                message = msg.MessageBody,
                                to = msg.PhoneNumber,
                                priority = null,
                                type = null
                            }));
                        }

                        var sendevents = new List<SmsEventSend>();
                        var ev = new SmsEventSend()
                        {
                            @event = "send",
                            messages = messages
                        };
                        sendevents.Add(ev);
                        smsevents.events = sendevents;
                        return Request.CreateResponse(HttpStatusCode.OK, smsevents);
                    }

                case "incoming":
                    {
                        if (request.message_type != "sms")
                            //Add MMS Functionality here
                            return Request.CreateResponse(HttpStatusCode.OK, request);
                        var fm = request.from;

                        //RealHub.Value.Clients.All.notify();

                        //Check if the message is coming from a registered user
                        var s = _db.Users.Where(t => t.PhoneNumber == fm).ToList().FirstOrDefault();

                        //var tag = request.message.TrimStart().Take(1).FirstOrDefault();


                        char[] separator = { ' ' };
                        var token = request.message;
                        var code = request.message.Split(separator).First().ToUpper();
                        var replay = new MessageLog();
                        var comprayer = new MessageLog();
                        var services = _db.ServiceCodes.Where(y => y.Type == 1).ToList();
                        var customServices = _db.ServiceCodes.Where(y => y.Type == 2 && y.Active == true).ToList();

                        var serviceRequest = new ServiceRequest
                        {
                            RequestFromNumber = request.@from,
                            RequestTime = DateTime.Now,
                            RequestFromName = s != null ? s.Name : ""
                        };


                        //Determine which original service type it is: Registration, Prayer and Comments
                        // var c=' ';
                        if (code.Equals(services.Find(t => t.ServiceCodeID == 1).Code.ToUpper()))
                        {
                            //It means it is a registration request
                            //c = 'R';
                            var sr = services.Find(t => t.ServiceCodeID == 1);
                            serviceRequest.ServiceCodeID = 1;  
                            sr.ServiceRequests.Add(serviceRequest);
                            _db.SaveChanges();

                            if (sr.Active)
                            {
                                var values = token.Split(separator, 3);
                                try
                                {
                                    var firstName = values[1];
                                    var lastName = values[2];
                                }
                                catch (IndexOutOfRangeException e)
                                {
                                    
                                }

                                var member = new User
                                {
                                    PhoneNumber = request.@from,
                                    Name = (values[1] + " " + values[2]).ToUpper(),
                                    Status = 3
                                };
                                var exists = _db.Users.Where(t => t.PhoneNumber == fm).ToList();

                                if (!exists.Any())
                                {
                                    _db.Users.Add(member);
                                    _db.SaveChanges();
                                    if (sr.AutoReply)
                                    {
                                        replay.PhoneNumber = request.from;
                                        replay.MessageBody = sr.Response;
                                        replay.Status = 4;
                                        replay.Time = DateTime.Now;
                                        _db.MessageLogs.Add(replay);
                                    }
                                    _db.SaveChanges();
                                }
                                else
                                {


                                    if (sr.AutoReply)
                                    {
                                        replay.PhoneNumber = request.from;
                                        replay.MessageBody = "Someone has already been registered from this number: " +
                                                             request.from;
                                        replay.Status = 4;
                                        replay.Time = DateTime.Now;
                                        _db.MessageLogs.Add(replay);
                                        _db.SaveChanges();
                                    }
                                }
                            }
                        }
                        else if (code.Equals(services.Find(t => t.ServiceCodeID == 2).Code.ToUpper()))
                        {
                            // It means it is a prayer request
                            //c = 'P';
                            var sr = services.Find(t => t.ServiceCodeID == 2);
                            serviceRequest.ServiceCodeID = 2;
                            sr.ServiceRequests.Add(serviceRequest);
                            _db.SaveChanges();

                            if (sr.Active)
                            {
                                var vals = token.Split(separator, 2);
                                if (s != null)
                                {
                                    comprayer.PhoneNumber = s.Name + Environment.NewLine + request.from;
                                }
                                else
                                {
                                    comprayer.PhoneNumber = request.from;
                                }
                                comprayer.MessageBody = vals[1];
                                comprayer.Status = 5;
                                comprayer.Time = DateTime.Now;
                                _db.MessageLogs.Add(comprayer);
                                _db.SaveChanges();
                                if (sr.AutoReply)
                                {
                                    replay.PhoneNumber = request.from;
                                    replay.MessageBody = sr.Response;
                                    replay.Status = 4;
                                    replay.Time = DateTime.Now;
                                    _db.MessageLogs.Add(replay);
                                    _db.SaveChanges();
                                }
                            }
                        }
                        else if (code.Equals(services.Find(t => t.ServiceCodeID == 3).Code.ToUpper()))
                        {
                            //It means it is a comment
                            //c = 'C';
                            var sr = services.Find(t => t.ServiceCodeID == 3);
                            serviceRequest.ServiceCodeID = 3;
                            sr.ServiceRequests.Add(serviceRequest);
                            _db.SaveChanges();
                            if (sr.Active)
                            {
                                var valls = token.Split(separator, 2);
                                if (s != null)
                                {
                                    comprayer.PhoneNumber = s.Name + Environment.NewLine + request.from;
                                }
                                else
                                {
                                    comprayer.PhoneNumber = request.from;
                                }
                                comprayer.MessageBody = valls[1];
                                comprayer.Status = 6;
                                comprayer.Time = DateTime.Now;
                                _db.MessageLogs.Add(comprayer);
                                _db.SaveChanges();
                                if (sr.AutoReply)
                                {
                                    replay.PhoneNumber = request.from;
                                    replay.MessageBody = sr.Response;
                                    replay.Status = 4;
                                    replay.Time = DateTime.Now;
                                    _db.MessageLogs.Add(replay);
                                    _db.SaveChanges();
                                }
                            }
                        }
                        else
                        {
                            var custom = true;
                            foreach (var cs in customServices)
                            {
                                if (code.Equals(cs.Code.ToUpper()) && cs.Active && cs.AutoReply)
                                {
                                    serviceRequest.ServiceCodeID = cs.ServiceCodeID;
                                    cs.ServiceRequests.Add(serviceRequest);
                                    _db.SaveChanges();
                                    replay.PhoneNumber = request.from;
                                    replay.MessageBody = cs.Response;
                                    replay.Status = 4;
                                    replay.Time = DateTime.Now;
                                    _db.MessageLogs.Add(replay);
                                    _db.SaveChanges();
                                    custom = false;
                                }
                            }

                            if (s != null && custom)
                            {
                                if (s.CurrentSurvey == null)
                                {
                                    // A registered member is sending a message for niether services nor for poll answers
                                    var m = new MessageLog
                                    {
                                        MessageBody = request.message,
                                        Status = 1,
                                        Time = _mv.ToDateTime(Convert.ToDouble(request.timestamp)),
                                        PhoneNumber = s.Name + Environment.NewLine + request.from
                                    };

                                    _db.MessageLogs.Add(m);
                                    _db.SaveChanges();
                                }
                            }
                            else if (custom)
                            {
                                // Some body is who is not registered is sending a message 
                                var m = new MessageLog
                                    {
                                        MessageBody = request.message,
                                        Status = 1,
                                        Time = _mv.ToDateTime(Convert.ToDouble(request.timestamp)),
                                        PhoneNumber = request.from
                                    };
                                _db.MessageLogs.Add(m);
                                _db.SaveChanges();
                            }
                        }

                        // Analyze Poll Answers
                        if (s != null && s.CurrentSurvey != null)
                        {
                            var response = request.message;
                            var answers = response.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                            //response.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                            var participant = _db.Users.Find(s.UserId);

                            //Check if this participant  already has answered for this question
                            var done =
                                _db.Answers.Any(
                                    a => a.User_UserId == s.UserId && a.Question.Survey_SurveyId == s.Survey.SurveyId);

                            var survey = participant.Survey;
                            var questions = survey.Questions;

                            if (done) return Request.CreateResponse(HttpStatusCode.OK, request);

                            if (survey.Questions.Count == answers.Count())
                            {
                                var i = 0;
                                var feedback = new List<Answer>();
                                var parity = new List<bool>();

                                foreach (var question in questions)
                                {
                                    switch (question.QuestionType)
                                    {
                                        case 1:
                                            if (answers[i].ToLower().Contains("yes"))
                                            {
                                                parity.Add(true);
                                                var ansYes = new Answer()
                                                {
                                                    Question_QuestionId = question.QuestionId,
                                                    User_UserId = participant.UserId,
                                                    AnswerType = 1,
                                                    Response = "Yes",
                                                    TimeStamp = _mv.ToDateTime(Convert.ToDouble(request.timestamp))
                                                };
                                                feedback.Add(ansYes);
                                            }
                                            else if (answers[i].ToLower().Contains("no"))
                                            {
                                                parity.Add(true);
                                                var ansNo = new Answer()
                                                {
                                                    Question_QuestionId = question.QuestionId,
                                                    User_UserId = participant.UserId,
                                                    AnswerType = 2,
                                                    Response = "No",
                                                    TimeStamp = _mv.ToDateTime(Convert.ToDouble(request.timestamp))
                                                };
                                                feedback.Add(ansNo);
                                            }
                                            else
                                            {
                                                parity.Add(false);
                                            }
                                            break;
                                        case 2:
                                            if (answers[i].IsDecimal() || answers[i].IsInt())
                                            {
                                                var ansQty = new Answer()
                                                {
                                                    Question_QuestionId = question.QuestionId,
                                                    User_UserId = participant.UserId,
                                                    AnswerType = 3,
                                                    Response = answers[i],
                                                    TimeStamp = _mv.ToDateTime(Convert.ToDouble(request.timestamp))
                                                };
                                                feedback.Add(ansQty);
                                            }
                                            else
                                            {
                                                parity.Add(false);
                                            }
                                            break;
                                    }
                                    i++;
                                }

                                if (parity.TrueForAll(t => t.Equals(true)))
                                {
                                    var j = 0;
                                    foreach (var qs in questions)
                                    {
                                        qs.Answers.Add(feedback[j]);
                                        j++;
                                    }
                                    _db.SaveChanges();
                                    s.CurrentSurvey = null;
                                    _db.SaveChanges();
                                }
                                else
                                {
                                    var r = new Resolution
                                    {
                                        SurveyID = survey.SurveyId,
                                        UserId = participant.UserId,
                                        message = request.message,
                                        Resolved = false,
                                        Time = _mv.ToDateTime(Convert.ToDouble(request.timestamp))

                                    };
                                    _db.Resolutions.Add(r);
                                    _db.SaveChanges();
                                }
                            }
                            else
                            {
                                var r = new Resolution
                                {
                                    SurveyID = survey.SurveyId,
                                    UserId = participant.UserId,
                                    message = request.message,
                                    Resolved = false,
                                    Time = _mv.ToDateTime(Convert.ToDouble(request.timestamp))

                                };
                                _db.Resolutions.Add(r);
                                _db.SaveChanges();
                            }
                        }



                        //else
                        //{
                        //    var m = new MessageLog
                        //    {
                        //        MessageBody = request.message, 
                        //        PhoneNumber = request.@from, 
                        //        Status = 1,
                        //        Time = _mv.ToDateTime(Convert.ToDouble(request.timestamp))
                        //    };
                        //    _db.MessageLogs.Add(m);
                        //    _db.SaveChanges();
                        //}

                        return Request.CreateResponse(HttpStatusCode.OK, request);
                    }
                case "send_status":
                    {
                        if (request.status == "sent")
                        {
                            var temp = request.id;
                            if (temp.StartsWith("P"))
                            {
                                var id = Convert.ToInt32(request.id.Substring(1));
                                var msg = _db.Messages.Find(id);
                                msg.Status = 2;
                                msg.SentTime = DateTime.Now;
                                _db.SaveChanges();
                            }
                            else if (temp.StartsWith("S"))
                            {
                                var id = Convert.ToInt32(request.id.Substring(1));
                                var msg = _db.MessageLogs.Find(id);
                                msg.Status = 7;
                                msg.Time = DateTime.Now;
                                _db.SaveChanges();
                            }
                        }
                        break;
                    }
            }
            return Request.CreateResponse(HttpStatusCode.OK, smsevents);
        }
    }
}