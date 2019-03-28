using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using SportsClubModel.CoreAbstractions.Async.UnitsOfWork;
using SportsClubModel.Domain;
using SportsClubWeb.DTO;
using System;
using System.Threading.Tasks;

namespace SportsClubWeb.Controllers.api
{
    [Route("api/reservations")]
    [ApiController]
    public class ReservationAPIController : ControllerBase
    {
        private readonly ReservationUnitOfWorkAsync reservationUnitOfWork;
        private readonly IMapper autoMapper;
        private readonly LinkGenerator linkGenerator;
        public ReservationAPIController(ReservationUnitOfWorkAsync work, IMapper mapper, LinkGenerator generator)
        {
            reservationUnitOfWork = work;
            autoMapper = mapper;
            linkGenerator = generator;
        }

        [HttpGet]
        public async Task<ActionResult<ReservationDTO[]>> Get()
        {
            var reservations = await reservationUnitOfWork.ReservationRepository.AllReservationsAsync();
            var reservationDTOs = autoMapper.Map<ReservationDTO[]>(reservations);
            return Ok(reservationDTOs);
        }

        [HttpGet("forDate")]
        public async Task<ActionResult<ReservationDTO[]>> Get(DateTime date)
        {
            var reservations = await reservationUnitOfWork.ReservationRepository.ReservationsForDayAsync(date);
            var reservationDTOs = autoMapper.Map<ReservationDTO[]>(reservations);
            return Ok(reservationDTOs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReservationDTO>> Get(long id)
        {
            var reservation = await reservationUnitOfWork.ReservationRepository.FindByIdAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }
            var reservationDTO = autoMapper.Map<ReservationDTO>(reservation);
            return Ok(reservationDTO);
        }

        [HttpPost]
        public async Task<ActionResult<ReservationDTO>> Add(ReservationDTO dto)
        {
            var existingReservations = await reservationUnitOfWork.ReservationRepository
                         .ReservationsForCourtInDateIntervalAsync(dto.CourtId, dto.Start, dto.End);
            if (existingReservations.Length != 0)
            {
                return BadRequest("court not available");
            }
            var location = linkGenerator.GetPathByAction("Get", "ReservationAPI", new { dto.Id });
            var newReservation = autoMapper.Map<Reservation>(dto);
            reservationUnitOfWork.ReservationRepository.Add(newReservation);
            await reservationUnitOfWork.SaveAsync();
            return Created(location, autoMapper.Map<ReservationDTO>(newReservation));

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ReservationDTO>> Update(long id, ReservationDTO dto)
        {
            try
            {
                var existingReservation = await reservationUnitOfWork.ReservationRepository.FindByIdAsync(dto.Id);
                if (existingReservation == null)
                {
                    return NotFound();
                }

                var reservation = autoMapper.Map(dto, existingReservation);
                await reservationUnitOfWork.SaveAsync();
                return autoMapper.Map<ReservationDTO>(reservation);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Internal Failure");
            }

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var existingReservation = await reservationUnitOfWork.ReservationRepository.FindByIdAsync(id);
            if (existingReservation == null)
            {
                return NotFound();
            }
            reservationUnitOfWork.ReservationRepository.Remove(existingReservation);
            await reservationUnitOfWork.SaveAsync();
            return Ok();
        }
    }
}