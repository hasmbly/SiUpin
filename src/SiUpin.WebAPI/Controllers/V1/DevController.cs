using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SiUpin.Shared.Systems.Commands.SeedAsalBantuan;
using SiUpin.Shared.Systems.Commands.SeedBerita;
using SiUpin.Shared.Systems.Commands.SeedFile;
using SiUpin.Shared.Systems.Commands.SeedJenisKomoditi;
using SiUpin.Shared.Systems.Commands.SeedJenisTernak;
using SiUpin.Shared.Systems.Commands.SeedKecamatan;
using SiUpin.Shared.Systems.Commands.SeedKelurahan;
using SiUpin.Shared.Systems.Commands.SeedKota;
using SiUpin.Shared.Systems.Commands.SeedParameterAspek;
using SiUpin.Shared.Systems.Commands.SeedParameterIndikator;
using SiUpin.Shared.Systems.Commands.SeedParameterJawaban;
using SiUpin.Shared.Systems.Commands.SeedParameterKriteria;
using SiUpin.Shared.Systems.Commands.SeedProdukOlahan;
using SiUpin.Shared.Systems.Commands.SeedProvinsi;
using SiUpin.Shared.Systems.Commands.SeedRole;
using SiUpin.Shared.Systems.Commands.SeedSatuan;
using SiUpin.Shared.Systems.Commands.SeedUph;
using SiUpin.Shared.Systems.Commands.SeedUser;
using SiUpin.WebAPI.Common.ApiEnvelopes;

namespace SiUpin.WebAPI.Controllers.V1
{
    public class DevController : BaseController
    {
        [AllowAnonymous]
        [HttpGet("")]
        public ActionResult Index()
        {
            try
            {
                return Ok("Hello Dev");
            }
            catch (Exception exception)
            {
                return BadRequest($"Exception: {exception.Message}");
            }
        }

        [AllowAnonymous]
        [HttpGet("seedingAll")]
        public async Task<ActionResult> SeedingAll()
        {
            try
            {
                await SeedRole();
                await SeedFile();
                await SeedProvinsi();
                await SeedKota();
                await SeedKecamatan();
                await SeedKelurahan();
                await SeedJenisTernak();
                await SeedJenisKomoditi();
                await SeedProdukOlahan();
                await SeedBerita();
                await SeedAsalBantuan();
                await SeedSatuan();
                await SeedParameterAspek();
                await SeedParameterKriteria();
                await SeedParameterIndikator();
                await SeedParameterJawaban();
                await SeedUph();

                await SeedUser();

                return Ok(new Success("Successfull"));
            }
            catch (Exception exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new InternalServerError(exception.Message));
            }
        }

        [AllowAnonymous]
        [HttpGet("seedUser")]
        public async Task<ActionResult> SeedUser()
        {
            try
            {
                return Ok(new Success(await Mediator.Send(new SeedUserRequest()), "Successfully"));
            }
            catch (Exception exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new InternalServerError(exception.Message));
            }
        }

        [AllowAnonymous]
        [HttpGet("seedRole")]
        public async Task<ActionResult> SeedRole()
        {
            try
            {
                return Ok(new Success(await Mediator.Send(new SeedRoleRequest()), "Successfully"));
            }
            catch (Exception exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new InternalServerError(exception.Message));
            }
        }

        [AllowAnonymous]
        [HttpGet("seedProvinsi")]
        public async Task<ActionResult> SeedProvinsi()
        {
            try
            {
                return Ok(new Success(await Mediator.Send(new SeedProvinsiRequest()), "Successfully"));
            }
            catch (Exception exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new InternalServerError(exception.Message));
            }
        }

        [AllowAnonymous]
        [HttpGet("seedKota")]
        public async Task<ActionResult> SeedKota()
        {
            try
            {
                return Ok(new Success(await Mediator.Send(new SeedKotaRequest()), "Successfully"));
            }
            catch (Exception exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new InternalServerError(exception.Message));
            }
        }

        [AllowAnonymous]
        [HttpGet("seedKecamatan")]
        public async Task<ActionResult> SeedKecamatan()
        {
            try
            {
                return Ok(new Success(await Mediator.Send(new SeedKecamatanRequest()), "Successfully"));
            }
            catch (Exception exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new InternalServerError(exception.Message));
            }
        }

        [AllowAnonymous]
        [HttpGet("seedKelurahan")]
        public async Task<ActionResult> SeedKelurahan()
        {
            try
            {
                return Ok(new Success(await Mediator.Send(new SeedKelurahanRequest()), "Successfully"));
            }
            catch (Exception exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new InternalServerError(exception.Message));
            }
        }

        [AllowAnonymous]
        [HttpGet("seedJenisTernak")]
        public async Task<ActionResult> SeedJenisTernak()
        {
            try
            {
                return Ok(new Success(await Mediator.Send(new SeedJenisTernakRequest()), "Successfully"));
            }
            catch (Exception exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new InternalServerError(exception.Message));
            }
        }

        [AllowAnonymous]
        [HttpGet("seedJenisKomoditi")]
        public async Task<ActionResult> SeedJenisKomoditi()
        {
            try
            {
                return Ok(new Success(await Mediator.Send(new SeedJenisKomoditiRequest()), "Successfully"));
            }
            catch (Exception exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new InternalServerError(exception.Message));
            }
        }

        [AllowAnonymous]
        [HttpGet("seedProdukOlahan")]
        public async Task<ActionResult> SeedProdukOlahan()
        {
            try
            {
                return Ok(new Success(await Mediator.Send(new SeedProdukOlahanRequest()), "Successfully"));
            }
            catch (Exception exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new InternalServerError(exception.Message));
            }
        }

        [AllowAnonymous]
        [HttpGet("seedFile")]
        public async Task<ActionResult> SeedFile()
        {
            try
            {
                return Ok(new Success(await Mediator.Send(new SeedFileRequest()), "Successfully"));
            }
            catch (Exception exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new InternalServerError(exception.Message));
            }
        }

        [AllowAnonymous]
        [HttpGet("seedBerita")]
        public async Task<ActionResult> SeedBerita()
        {
            try
            {
                return Ok(new Success(await Mediator.Send(new SeedBeritaRequest()), "Successfully"));
            }
            catch (Exception exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new InternalServerError(exception.Message));
            }
        }

        [AllowAnonymous]
        [HttpGet("seedAsalBantuan")]
        public async Task<ActionResult> SeedAsalBantuan()
        {
            try
            {
                return Ok(new Success(await Mediator.Send(new SeedAsalBantuanRequest()), "Successfully"));
            }
            catch (Exception exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new InternalServerError(exception.Message));
            }
        }

        [AllowAnonymous]
        [HttpGet("seedSatuan")]
        public async Task<ActionResult> SeedSatuan()
        {
            try
            {
                return Ok(new Success(await Mediator.Send(new SeedSatuanRequest()), "Successfully"));
            }
            catch (Exception exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new InternalServerError(exception.Message));
            }
        }

        [AllowAnonymous]
        [HttpGet("seedParameterAspek")]
        public async Task<ActionResult> SeedParameterAspek()
        {
            try
            {
                return Ok(new Success(await Mediator.Send(new SeedParameterAspekRequest()), "Successfully"));
            }
            catch (Exception exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new InternalServerError(exception.Message));
            }
        }

        [AllowAnonymous]
        [HttpGet("seedParameterKriteria")]
        public async Task<ActionResult> SeedParameterKriteria()
        {
            try
            {
                return Ok(new Success(await Mediator.Send(new SeedParameterKriteriaRequest()), "Successfully"));
            }
            catch (Exception exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new InternalServerError(exception.Message));
            }
        }

        [AllowAnonymous]
        [HttpGet("seedParameterIndikator")]
        public async Task<ActionResult> SeedParameterIndikator()
        {
            try
            {
                return Ok(new Success(await Mediator.Send(new SeedParameterIndikatorRequest()), "Successfully"));
            }
            catch (Exception exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new InternalServerError(exception.Message));
            }
        }

        [AllowAnonymous]
        [HttpGet("seedParameterJawaban")]
        public async Task<ActionResult> SeedParameterJawaban()
        {
            try
            {
                return Ok(new Success(await Mediator.Send(new SeedParameterJawabanRequest()), "Successfully"));
            }
            catch (Exception exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new InternalServerError(exception.Message));
            }
        }

        [AllowAnonymous]
        [HttpGet("seedUph")]
        public async Task<ActionResult> SeedUph()
        {
            try
            {
                return Ok(new Success(await Mediator.Send(new SeedUphRequest()), "Successfully"));
            }
            catch (Exception exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new InternalServerError(exception.Message));
            }
        }
    }
}