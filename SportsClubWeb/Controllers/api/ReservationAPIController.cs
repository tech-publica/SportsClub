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
            try
            {
                var reservations = await reservationUnitOfWork.ReservationRepository.AllReservationsAsync();
                var reservationDTOs = autoMapper.Map<ReservationDTO[]>(reservations);
                return Ok(reservationDTOs);
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Internal Failure");
            }


        }

        [HttpGet("forDate")]
        public async Task<ActionResult<ReservationDTO[]>> Get(DateTime date)
        {
            try
            {
                var reservations = await reservationUnitOfWork.ReservationRepository.ReservationsForDayAsync(date);
                var reservationDTOs = autoMapper.Map<ReservationDTO[]>(reservations);
                return Ok(reservationDTOs);
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Internal Failure");
            }

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReservationDTO>> Get(long id)
        {
            try
            {
                var reservation = await reservationUnitOfWork.ReservationRepository.FindByIdAsync(id);
                if (reservation == null)
                {
                    return NotFound();
                }
                var reservationDTO = autoMapper.Map<ReservationDTO>(reservation);
                return Ok(reservationDTO);
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Internal Failure");
            }


        }

        [HttpPost]
        public async Task<ActionResult<ReservationDTO>> Add(ReservationDTO dto)
        {
            try
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
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Internal Failure");
            }





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
            try
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
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Internal Failure");
            }

        }
    }
}