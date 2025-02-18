using LudoKing.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace LudoKing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LudoKingAPIController : ControllerBase
    {
        public AppDbContext _context;
        public IWebHostEnvironment _environment;

        public LudoKingAPIController(AppDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        [HttpPost("registration")]
        public async Task<IActionResult> registration([FromForm] registration r, [FromForm] IFormFile? photo)
        {
            if (r == null)
            {
                return BadRequest(new basicresponse { status = "error", message = "data can not be null" });
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
           if(photo != null)
            {
                string folderpath = Path.Combine(_environment.WebRootPath, "Avatar");
                string filename = photo.FileName;
                string filepath = Path.Combine(folderpath, filename);
                var stream = new FileStream(filepath, FileMode.Create);
                await photo.CopyToAsync(stream);
                r.photo = filename;
            }
            _context.registration.Add(r);
            _context.SaveChanges();

            var output = new basicresponse
            {
                status = "success",
                message = "Data Successfully Registered",
                data = r
            };
            return Ok(output);
        }
        [HttpGet("registrationshow")]
        public IActionResult registrationshow()
        {
            var data = _context.registration.ToList();
            return Ok(data);
        }
        [HttpGet("registrationshow/{id}")]
        public IActionResult registrationshow(int id)
        {
            var data = _context.registration.Find(id);
            return Ok(data);
        }
        [HttpPut("registrationupdate")]
        public async Task<IActionResult> registrationupdate([FromForm] registration newdata, [FromForm] IFormFile? photo)
        {
            var data = _context.registration.Find(newdata.id);

            data.name = newdata.name;
            data.email = newdata.email;
            data.mobile = newdata.mobile;
            data.otp = newdata.otp;
            data.otpstatus = newdata.otpstatus;
            data.walletbalance = newdata.walletbalance;
            data.datetime = newdata.datetime;
            data.blockstatus = newdata.blockstatus;
            data.photo = newdata.photo;

            if (photo != null)
            {
                string folderpath = Path.Combine(_environment.WebRootPath, "Avatar");
                string filename = photo.FileName;
                string filepath = Path.Combine(folderpath, filename);
                var stream = new FileStream(filepath, FileMode.Create);
                await photo.CopyToAsync(stream);
                newdata.photo = filename;
            }

            _context.registration.Update(data);
            _context.SaveChanges();

            var output = new basicresponse
            {
                status = "Success",
                message = "Registration Data Successfully Updated",
                data = data
            };

            return Ok(data);
        }
        [HttpDelete("registrationdelete/{id}")]
        public IActionResult registrationdelete(int id)
        {
            var data = _context.registration.Find(id);

            _context.registration.Remove(data);
            _context.SaveChanges();

            var output = new basicresponse
            {
                status = "success",
                message = "Registration Data is Successfully Deleted",
                data = data
            };

            return Ok(output);
        }

        [HttpPut("setimg")]
        public async Task<IActionResult> setimg([FromForm] registration i, [FromForm] IFormFile? photo )
        {
            var data = _context.registration.Find(i.id);
            data.photo = i.photo;

            if(photo != null)
            {
                string folderpath = Path.Combine(_environment.WebRootPath, "Avatar");
                string filename = photo.FileName;
                string filepath = Path.Combine(folderpath, filename);
                var stream = new FileStream(filepath, FileMode.Create);
                await photo.CopyToAsync(stream);
                data.photo = filename;
            }

            _context.registration.Update(data);
            _context.SaveChanges();
            var output = new basicresponse
            {
                status = "Success",
                message = "Image Successfully Inserted",
                data = data
            };
            return Ok(data);
        }
        [HttpPost("game")]
        public async Task<IActionResult> game([FromForm] game g, [FromForm] IFormFile? resultscreenshot)
        {
            if (resultscreenshot != null)
            {
                string folderpoath = Path.Combine(_environment.WebRootPath, "game");
                string filename = resultscreenshot.FileName;
                string filepath = Path.Combine(folderpoath, filename);
                var stream = new FileStream(filepath, FileMode.Create);
                await resultscreenshot.CopyToAsync(stream);
                g.resultscreenshot = filename;
            }
            _context.game.Add(g);
            _context.SaveChanges();

            var output = new basicresponse
            {
                status = "Success",
                message = "Game Data Successfully Inserted",
                data = g
            };

            return Ok(output);
        }
        [HttpGet("gameshow")]
        public IActionResult gameshow()
        {
            var data = _context.game.ToList();
            return Ok(data);
        }
        [HttpGet("gameshow/{id}")]
        public IActionResult gameshow(int id)
        {
            var data = _context.game.Find(id);
            return Ok(data);
        }
        [HttpPut("gameupdate")]
        public async Task<IActionResult> gameupdate([FromForm] game newdata, [FromForm] IFormFile? resultscreenshot)
        {
            var data = _context.game.Find(newdata.id);
            data.gametype = newdata.gametype;
            data.amount = newdata.amount;
            data.player1 = newdata.player1;
            data.player2 = newdata.player2;
            data.roomcode = newdata.roomcode;
            data.userresult = newdata.userresult;
            data.resultscreenshot = newdata.resultscreenshot;
            data.finalresult = newdata.finalresult;
            data.datetime = newdata.datetime;



            if (resultscreenshot != null)
            {
                string folderpath = Path.Combine(_environment.WebRootPath, "game");
                string filename = resultscreenshot.FileName;
                string filepath = Path.Combine(folderpath, filename);
                var stream = new FileStream(filepath, FileMode.Create);
                await resultscreenshot.CopyToAsync(stream);
                data.resultscreenshot = filename;
            }

            _context.game.Update(data);
            _context.SaveChanges();

            var output = new basicresponse
            {
                status = "Success",
                message = "Game Data Successfully Updated",
                data = data
            };

            return Ok(data);
        }
        [HttpDelete("gamedelete/{id}")]
        public IActionResult gamedelete(int id)
        {
            var game = _context.game.Find(id);

            _context.game.Remove(game);
            _context.SaveChanges();

            var output = new basicresponse
            {
                status = "Success",
                message = "Game Data Successfully Deleted",
                data = game
            };
            return Ok(output);
        }
        [HttpPost("addwallet")]
        public async Task<IActionResult> addwallet([FromForm] wallet w, [FromForm] IFormFile? screenshot)
        {
           //var data = _context.registration.Find(w.id);
           // data.id = Convert.ToInt32(w.userid);
            w.datetime = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
            w.status= "success";
            
            if (screenshot != null)
            {
                string folderpath = Path.Combine(_environment.WebRootPath, "wallet");
                string filename = screenshot.FileName;
                string filepath = Path.Combine(folderpath, filename);
                var stream = new FileStream(filepath, FileMode.Create);
                await screenshot.CopyToAsync(stream);
                w.screenshot = filepath;
            }

            _context.wallet.Add(w);
            _context.SaveChanges();

            var output = new basicresponse
            {
                status = "Success",
                message = "Wallet Data Successfully Inserted",
                data = w
            };

            return Ok(output);
        }



        [HttpGet("showwallet")]
        public IActionResult showwallet()
        {
            var data = _context.wallet.ToList();
            return Ok(data);
        }
        [HttpGet("showwallet/{id}")]
        public IActionResult showwallet(int id)
        {
            var data = _context.wallet.Find(id);
            return Ok(data);
        }
        [HttpPut("updatewallet")]
        public async Task<IActionResult> updatewallet([FromForm] wallet newdata, [FromForm] IFormFile? screenshot)
        {
            var data = _context.wallet.Find(newdata.id);

            data.type = newdata.type;
            data.remark = newdata.remark;
            data.amount = newdata.amount;
            data.datetime = newdata.datetime;
            data.status = newdata.status;
            data.userid = newdata.userid;
            data.txnid = newdata.txnid;
            data.screenshot = newdata.screenshot;
            data.paymentrefno = newdata.paymentrefno;

            if (screenshot != null)
            {
                string folderpath = Path.Combine(_environment.WebRootPath, "wallet");
                string filename = screenshot.FileName;
                string filepath = Path.Combine(folderpath, filename);
                var filestream = new FileStream(filepath, FileMode.Create);
                await screenshot.CopyToAsync(filestream);
                data.screenshot = filename;
            }

            _context.wallet.Update(data);
            _context.SaveChanges();

            var output = new basicresponse
            {
                status = "Success",
                message = "Wallet Data Successfully Updated",
                data = newdata
            };
            return Ok(data);
        }
        [HttpDelete("deletewallet/{id}")]
        public IActionResult deletewallet(int id)
        {
            var data = _context.wallet.Find(id);

            _context.wallet.Remove(data);
            _context.SaveChanges();

            var output = new basicresponse
            {
                status = "Success",
                message = "Wallet Data Successfully Deleted",
                data = data
            };
            return Ok(output);
        }
        [HttpPost("addappsetting")]
        public IActionResult addappsetting([FromForm] appsetting a)
        {
            _context.appsetting.Add(a);
            _context.SaveChanges();

            var output = new basicresponse
            {
                status = "Success",
                message = "AppSettings Data is Successfully Inserted",
                data = a
            };

            return Ok(output);
        }
        [HttpGet("showappsetting")]
        public IActionResult showappsetting()
        {
            var data = _context.appsetting.ToList();
            return Ok(data);
        }
        [HttpGet("showappsetting/{id}")]
        public IActionResult showappsetting(int id)
        {
            var data = _context.appsetting.Find(id);
            return Ok(data);
        }
        [HttpPut("updateappsetting")]
        public IActionResult updateappsetting([FromForm] appsetting newdata)
        {
            var data = _context.appsetting.Find(newdata.id);

            data.webappstatus = newdata.webappstatus;
            data.undermaintenancemsg = newdata.undermaintenancemsg;
            data.terms = newdata.terms;
            data.gamerules = newdata.gamerules;
            data.whatsapplink = newdata.whatsapplink;
            data.instalink = newdata.instalink;
            data.telegramlink = newdata.telegramlink;

            _context.appsetting.Update(data);
            _context.SaveChanges();

            var output = new basicresponse
            {
                status = "Success",
                message = "AppSetting Data is Successfully Updated",
                data = data
            };

            return Ok(output);
        }
        [HttpDelete("deleteappsetting/{id}")]
        public IActionResult deleteappsetting(int id)
        {
            var data = _context.appsetting.Find(id);

            _context.appsetting.Remove(data);
            _context.SaveChanges();

            var output = new basicresponse
            {
                status = "Success",
                message = "AppSetting Data is Successfully Deleted",
                data = data
            };
            return Ok(output);
        }
        [HttpPost("addslider")]
        public async Task<IActionResult> addslider([FromForm] slider s, [FromForm] IFormFile? pic)
        {
            if (pic != null)
            {
                string folderpath = Path.Combine(_environment.WebRootPath, "slider");
                string filename = pic.FileName;
                string filepath = Path.Combine(folderpath, filename);
                var filestream = new FileStream(filepath, FileMode.Create);
                await pic.CopyToAsync(filestream);
                s.pic = filename;
            }

            _context.slider.Add(s);
            _context.SaveChanges();

            var output = new basicresponse
            {
                status = "Success",
                message = "Slider Data is Successfully Inserted",
                data = s
            };

            return Ok(output);
        }
        [HttpGet("showslider")]
        public IActionResult showslider()
        {
            var data = _context.slider.ToList();
            return Ok(data);
        }
        [HttpGet("showslider/{id}")]
        public IActionResult showslider(int id)
        {
            var data = _context.slider.Find(id);
            return Ok(data);
        }
        [HttpPut("updateslider")]
        public async Task<IActionResult> updateslider([FromForm] slider newdata, [FromForm] IFormFile? pic)
        {
            var data = _context.slider.Find(newdata.id);

            data.pic = newdata.pic;
            data.link = newdata.link;
            data.status = newdata.status;
            data.datetime = newdata.datetime;

            if (pic != null)
            {
                string folderpath = Path.Combine(_environment.WebRootPath, "slider");
                string filename = pic.FileName;
                string filepath = Path.Combine(folderpath, filename);
                var stream = new FileStream(filepath, FileMode.Create);
                await pic.CopyToAsync(stream);
                data.pic = filename;
            }

            _context.slider.Update(data);
            _context.SaveChanges();

            var output = new basicresponse
            {
                status = "Success",
                message = "Slider Data is Successfully Updated",
                data = data,
            };

            return Ok(data);
        }
        [HttpDelete("deleteslider/{id}")]
        public IActionResult deleteslider(int id)
        {
            var data = _context.slider.Find(id);

            _context.slider.Remove(data);
            _context.SaveChanges();

            var output = new basicresponse
            {
                status = "Success",
                message = "Slider Data is Successfully Deleted",
                data = data,
            };
            return Ok(data);
        }
        [HttpPost("addcontact")]
        public IActionResult addcontact([FromForm] contactus c)
        {
            c.datetime = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
            c.status = true;

            _context.contactus.Add(c);
            _context.SaveChanges();

            var output = new basicresponse
            {
                status = "Success",
                message = "Contact Us Data is Successfully Inserted",
                data = c
            };

            return Ok(output);
        }
        [HttpGet("showcontact")]
        public IActionResult showcontact()
        {
            var data = _context.contactus.ToList();
            return Ok(data);
        }
        [HttpGet("showcontact/{id}")]
        public IActionResult showcontact(int id)
        {
            var data = _context.contactus.Find(id);
            return Ok(data);
        }
        [HttpPut("updatecontact")]
        public IActionResult updatecontact([FromForm] contactus newdata)
        {
            var data = _context.contactus.Find(newdata.id);

            data.name = newdata.name;
            data.email = newdata.email;
            data.mobile = newdata.mobile;
            data.message = newdata.message;
            data.datetime = newdata.datetime;
            data.status = newdata.status;

            _context.contactus.Update(data);
            _context.SaveChanges();

            var output = new basicresponse
            {
                status = "Success",
                message = "Contact Data Successfully Updated",
                data = data
            };

            return Ok(output);
        }
        [HttpDelete("deletecontact/{id}")]
        public IActionResult deletecontact(int id)
        {
            var data = _context.contactus.Find(id);

            _context.contactus.Remove(data);
            _context.SaveChanges();

            var output = new basicresponse
            {
                status = "Success",
                message = "Contact Us Data is Successfully Deleted",
                data = data
            };

            return Ok(output);
        }
        //Player Start
        [HttpPost("addplayer1")]
        public IActionResult addplayer1([FromForm] game g)
        {
            _context.game.Add(g);
            _context.SaveChanges();

            var output = new basicresponse
            {
                status = "Success",
                message = "Player1 Data Successfully Inserted",
                data = g
            };

            return Ok(output);
        }
        [HttpDelete("deleteplayer1/{id}")]
        public IActionResult deleteplayer1(int id)
        {
            var data = _context.game.Find(id);

            _context.game.Remove(data);
            _context.SaveChanges();

            var output = new basicresponse
            {
                status = "Success",
                message = "Player1 Data successfully deleted",
                data = data
            };
            return Ok(output);
        }
        [HttpPost("addplayer2")]
        public IActionResult addplayer2([FromForm] game g)
        {
            _context.game.Add(g);
            _context.SaveChanges();

            var output = new basicresponse
            {
                status = "Success",
                message = "Player2 Data Successfully Inserted",
                data = g
            };
            return Ok(output);
        }
        [HttpDelete("deleteplayer2/{id}")]
        public IActionResult deleteplayer2(int id)
        {
            var data = _context.game.Find(id);

            _context.game.Remove(data);
            _context.SaveChanges();

            var output = new basicresponse
            {
                status = "Delete",
                message = "Player2 Data Successfully Deleted",
                data = data
            };

            return Ok(output);
        }
        //Player End

        //Start Roomcode
        [HttpPost("addroomcode")]
        public IActionResult addroomcode([FromForm] game g)
        {
            _context.game.Add(g);
            _context.SaveChanges();

            var output = new basicresponse
            {
                status = "Success",
                message = "Room Code Successfully Inserted",
                data = g
            };

            return Ok(output);
        }

        [HttpDelete("deleteroomcode/{id}")]
        public IActionResult deleteroomcode(int id)
        {
            var data = _context.game.Find(id);

            _context.game.Remove(data);
            _context.SaveChanges();

            var output = new basicresponse
            {
                status = "Delete",
                message = "Room Code Data Successfully Deleted",
                data = data
            };

            return Ok(output);
        }
        //End Roomcode
        //Start Withdraw
        [HttpPost("addwithdraw")]
        public async Task<IActionResult> addwithdraw([FromForm] withdraw w, [FromForm] IFormFile? screenshot)
        {
            w.datetime = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
             
            if (screenshot != null)
            {
                string folderpath = Path.Combine(_environment.WebRootPath, "withdraw");
                string filename = screenshot.FileName;
                string filepath = Path.Combine(folderpath, filename);
                var stream = new FileStream(filepath, FileMode.Create);
                await screenshot.CopyToAsync(stream);
                w.screenshot = filename;
            }

            _context.withdraw.Add(w);
            _context.SaveChanges();

            var output = new basicresponse
            {
                status = "Success",
                message = "Withdraw Data Successfully Inserted",
                data = w
            };
            return Ok(output);
        }
        [HttpDelete("deletewithdraw/{id}")]
        public IActionResult deletewithdraw(int id)
        {
            var data = _context.withdraw.Find(id);

            _context.withdraw.Remove(data);
            _context.SaveChanges();

            var output = new basicresponse
            {
                status = "Success",
                message = "Withdraw Data Successfully Deleted",
                data = data
            };
            return Ok(output);
        }
        //End Withdraw
        //start Deposit
        [HttpPost("adddeposit")]
        public async Task<IActionResult> adddeposit([FromForm] deposited d, [FromForm] IFormFile? screenshot)
        {
            if (screenshot != null)
            {
                string folderpath = Path.Combine(_environment.WebRootPath, "deposit");
                string filename = screenshot.FileName;
                string filepath = Path.Combine(folderpath, filename);
                var stream = new FileStream(filepath, FileMode.Create);
                await screenshot.CopyToAsync(stream);
                d.screenshot = filename;
            }

            _context.deposited.Add(d);
            _context.SaveChanges();

            var output = new basicresponse
            {
                status = "Success",
                message = "Deposit Data Successfully Inserted",
                data = d
            };
            return Ok(output);
        }
        //End Deposit

        //start payment history
        [HttpPost("addpaymenthistory")]
        public IActionResult addpaymenthistory([FromForm] paymenthistory p)
        {
            _context.paymenthistory.Add(p);
            _context.SaveChanges();

            var output = new basicresponse
            {
                status = "Success",
                message = "Data Successfully Inserted",
                data = p
            };
            return Ok(output);
        }
        [HttpDelete("deletepaymenthistory/{id}")]
        public IActionResult deletepaymenthistory(int id)
        {
            var data = _context.paymenthistory.Find(id);

            _context.paymenthistory.Remove(data);
            _context.SaveChanges();

            var output = new basicresponse
            {
                status = "Success",
                message = "data Successfully Deleted",
                data = data
            };
            return Ok(data);
        }
        //end payment history
        //start login
        [HttpPost("login")]
        public IActionResult Login([FromForm] string mobile)
        {
            var data = _context.registration.FirstOrDefault(x => x.mobile == mobile);

            data.datetime = DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss");
            data.otpstatus = true;
            data.blockstatus = false;
            

            if (data != null)
            {
                // otp create new random, update in database

                Random random = new Random();
                int randomNumber = random.Next(100000, 999999); // Generates a number between 100000 - 999999

                // Update user record with new random number
                data.otp = randomNumber.ToString(); // Assuming "otp" is the field for storing the random number
                _context.SaveChanges();


                var output = new basicresponse
                {
                    status = "Success",
                    message = "Login Successfull",
                    data = data
                };
                return Ok(output); 
            }
            else
            {
                var output = new basicresponse
                {
                    status = "Unsuccess",
                    message = "Mobile Number or OTP is Incorrect"
                };
                return NotFound(output); 
            }
        }

        //end login
        //start verify otp
        [HttpPost("verifyotp")]
        public IActionResult verifyotp([FromForm] string mobile, [FromForm] string otp)
        {
            var user = _context.registration.FirstOrDefault(x => x.mobile == mobile);

            //user.otpstatus = true;

            if (user != null)
            {
                if (user.otp == otp)
                {
                    // ✅ Set OTP status to true
                    

                    _context.SaveChanges(); // Save changes to database

                    var output = new basicresponse
                    {
                        status = "Success",
                        message = "OTP Verified Successfully",
                        datetime = user.datetime // Send DateTime in response
                    };
                    return Ok(output);
                }
                else
                {
                    var output = new basicresponse
                    {
                        status = "Unsuccess",
                        message = "Invalid OTP. Please try again."
                    };
                    return BadRequest(output);
                }
            }
            else
            {
                var output = new basicresponse
                {
                    status = "Unsuccess",
                    message = "Mobile Number Not Found"
                };
                return NotFound(output);
            }
        }

        //end verify 
        //resend otp
        [HttpPut("resendotp")]
        public IActionResult resendotp([FromForm] registration r)
        {
            var data = _context.registration.Find(r.id);

            data.otp = r.otp;

            // send otp


            var output = new basicresponse
            {
                status = "Success",
                message = "OTP Successfully Resend",
                data = data
            };
            return Ok(output);
        }
        //end resend otp
        //start roomcode
        [HttpPut("roomcode")]
        public IActionResult roomcode([FromForm] game g)
        {
            var data = _context.game.Find(g.id);

            data.roomcode = g.roomcode;

            _context.game.Update(data);
            _context.SaveChanges();

            var output = new basicresponse
            {
                status = "Success",
                message = "Sent Successfully Room Code",
                data = data
            };
            return Ok(output);
        }
        //end roomcode
        //new game
        [HttpPut("newgame")]
        public IActionResult newgame([FromForm] game g)
        {
            var data = _context.game.Find(g.id);

            data.player1 = g.player1;
            data.player2 = g.player2;

            _context.game.Update(data);
            _context.SaveChanges();

            var output = new basicresponse
            {
                status = "Success",
                message = "New Game is Started",
                data = data
            };
            return Ok(output);
        }
        //end new game
        //start submit result
        [HttpPut("submitresult")]
        public async Task<IActionResult> submitresult([FromForm] game g, [FromForm] IFormFile? resultscreenshot)
        {
            var data = _context.game.Find(g.id);

            data.userresult = g.userresult;
            data.resultscreenshot = g.resultscreenshot;

            if (resultscreenshot != null)
            {
                string folderpath = Path.Combine(_environment.WebRootPath, "game");
                string filename = resultscreenshot.FileName;
                string filepath = Path.Combine(folderpath, filename);
                var stream = new FileStream(filepath, FileMode.Create);
                await resultscreenshot.CopyToAsync(stream);
                data.resultscreenshot = filename;
            }

            _context.game.Update(data);
            _context.SaveChanges();

            var output = new basicresponse
            {
                status = "Success",
                message = "Result Successfully Submitted",
                data = data
            };
            return Ok(data);
        }
        //end submit result
        //Start Game Detail
        [HttpGet("gamedetail/{id}")]
        public IActionResult gamedetail([FromForm] gamedetail d)
        {
            var data = _context.gamedetail.ToList();
            return Ok(data);
        }

        
        //End Game Detail
    }
}
